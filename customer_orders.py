import requests;
import json;
import pyodbc;
import datetime;

class CustomerInfo:
    def __init__(self):
        self.customer_id = 0
        self.customer_name = None
        self.customer_cell = None
        self.customer_home = None
        self.customer_email = None
        self.customer_address = None
        self.last_modified = None
    def __str__(self):
        return str(vars(self))

class Order:
    def __init__(self):
        self.location_id = None
        self.order_number = None
        self.customer_phone = None
        self.item_barcode = None
        self.item_id = 0
        self.item_name = None
        self.item_qty = 0.0
        self.item_instruction = None
        self.item_identifier = 0
        self.item_identifier_string = None
        self.combo_id = 0
        self.option_tab = None
        self.option_group_name = None
        self.date_paid = None
        self.date_created = None
    def __str__(self):
        return str(vars(self))

def date_hook(json_dict):
    for (key, value) in json_dict.items():
        try:
            json_dict[key] = datetime.datetime.strptime(value, "%Y-%m-%dT%H:%M:%S")
        except:
            pass
    return json_dict

def main():
    # Some other example server values are
    # server = 'localhost\sqlexpress' # for a named instance
    # server = 'myserver,port' # to specify an alternate port
    server = 'DESKMINI-X300' 
    database = 'Hippos' 
    username = 'dba' 
    password = '' # Set with the SQL Server Password 

    readyOnlyAPIServer = "https://fetch1.hipposhq.com/";
    getOrderHistoryUrl = readyOnlyAPIServer + "getorderhistory";

    globalCustomerList = [];
    globalOrderList = [];

    phone_number = ''; # Set with phone number to search, e.g. 123456789
    token = '';

    # ENCRYPT defaults to yes starting in ODBC Driver 18. It's good to always specify ENCRYPT=yes on the client side to avoid MITM attacks.
    cnxn = pyodbc.connect('DRIVER={ODBC Driver 18 for SQL Server};SERVER='+server+';DATABASE='+database+';ENCRYPT=no;UID='+username+';PWD='+ password)
    cursor = cnxn.cursor();

    # Get Customer data from Database
    cursor.execute("SELECT * FROM Customers WHERE ((CustomerCell IS NOT NULL) AND (CustomerCell LIKE ?)) OR ((CustomerHome IS NOT NULL) AND (CustomerHome LIKE ?)) ORDER BY LastModified DESC", phone_number, phone_number);
    while True:
        row = cursor.fetchone()
        if not row:
            break
        cust = CustomerInfo();
        cust.customer_address = row.Address;
        cust.customer_cell = row.CustomerCell;
        cust.customer_email = row.CustomerEmail;
        cust.customer_home = row.CustomerHome;
        cust.customer_id = row.CustomerID;
        cust.customer_name = row.CustomerName;
        cust.last_modified = row.LastModified if row.LastModified else row.DateCreated;
        globalCustomerList.append(vars(cust));
    
    # Get API Token from Database
    cursor.execute("SELECT * FROM Settings WHERE [Key]=?", 'cloudsync_api_key');
    row = cursor.fetchone();
    token = row.Value if row else '';
    
    orderHistoryRequest = {
        'phone_number': phone_number,
        'token': token,
    };

    headers = {
        'Content-Type': 'application/json',
    };

    orderHistoryResponse = requests.post(url=getOrderHistoryUrl, json=orderHistoryRequest, headers=headers);

    orderHistoryApiResponse = json.loads(orderHistoryResponse.text, object_hook=date_hook);
    # print(json.dumps(orderHistoryApiResponse, indent=2));

    customer = None;
    orderNumberLookup = {}

    if orderHistoryApiResponse and 'customer_info' in orderHistoryApiResponse and 'orders' in orderHistoryApiResponse:
        for o in orderHistoryApiResponse['orders']:
            o['date_created'] = o['date_paid'];
        globalOrderList = orderHistoryApiResponse['orders'];
        customer = orderHistoryApiResponse['customer_info'];
    
    for o in globalOrderList:
        # print(o);
        orderNumberLookup[o['order_number']] = o;
    
    #print(json.dumps(customer, indent=2));
    #print(json.dumps(orderNumberLookup, indent=2));

    custIDs = [a['customer_id'] for a in globalCustomerList];
    #print(custIDs);
    
    # Select all orders without ShareItem
    dbOrderList = []
    cursor.execute("SELECT * FROM [Orders] WHERE ([Paid] = 1) AND (NOT ([Void] = 1)) AND ([CustomerID] IS NOT NULL) AND (([CustomerID]) IN (?)) AND ([DatePaid] IS NOT NULL) AND (NOT ([DateRefunded] IS NOT NULL)) AND ([ItemID] > 0) AND (NOT ([ShareItemID] IS NOT NULL)) ORDER BY [LastDateModified], [DateCreated], [ComboID]", custIDs);
    while True:
        row = cursor.fetchone()
        if not row:
            break
        dbOrderList.append(row);

    # Select all orders with ShareItem
    dbSource2List = []
    cursor.execute("SELECT * FROM [Orders] WHERE ([Paid] = 1) AND (NOT ([Void] = 1)) AND ([CustomerID] IS NOT NULL) AND (([CustomerID]) IN (?)) AND ([DatePaid] IS NOT NULL) AND (NOT ([DateRefunded] IS NOT NULL)) AND ([ItemID] > 0) AND ([ShareItemID] IS NOT NULL)", custIDs);
    while True:
        row = cursor.fetchone()
        if not row:
            break
        dbSource2List.append(row);
    
    globalOrderNumberSet = set([a['order_number'] for a in globalOrderList]);
    list2 = [a.ShareItemID for a in dbSource2List]
    list3 = [];

    for x in dbOrderList:
        if x.OrderNumber in globalOrderNumberSet:
            continue;
        item = Order()
        item.combo_id = x.ComboID
        item.customer_phone = x.CustomerInfoPhone
        item.date_created = (x.LastDateModified if x.LastDateModified else x.DateCreated).isoformat()
        item.date_paid = (x.DatePaid).isoformat()
        item.item_barcode = x.ItemBarcode
        item.item_id = x.ItemID
        item.item_identifier = 1 if x.ItemIdentifier == "MainItem" else 2 if x.ItemIdentifier == "ChildItem" else 3
        item.item_identifier_string = x.ItemIdentifier
        item.item_instruction = x.Instructions
        item.item_name = x.ItemName
        item.item_qty = x.Qty * (1 if len(list2) <= 0 else list2.count(x.OrderId) + 1)
        item.option_group_name = str(x.ItemOptionId)
        item.option_tab = "###"
        item.order_number = x.OrderNumber
        list3.append(vars(item))
    
    globalOrderList.extend(list3);
    globalOrderList = sorted(globalOrderList, key=lambda x: (x['date_created'], x['combo_id']));

    print(json.dumps(globalOrderList, indent=2, default=str));

    cnxn.close();

if __name__ == '__main__':
    main()
