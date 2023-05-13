using CorePOS.Business;
using CorePOS.Business.Methods;
using CorePOS.Business.Objects;
using CorePOS.Business.Properties;
using CorePOS.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsForHipPOS.Models;
using ToolsForHipPOS.Services;

namespace ToolsForHipPOS
{
    public partial class MainForm : Form
    {
        private int int_0;
        private bool bool_0;

        private string string_0 = string.Empty;
        private string string_2 = string.Empty;

        private List<GlobalOrderHistoryObjects.Order> list_2;

        private List<GlobalOrderHistoryObjects.CustomerInfo> list_3;

        private GlobalOrderHistoryObjects.CustomerInfo customerInfo_0;

        private GlobalOrderHistoryObjects.Response _apiResponse;

        private LocalSettingService _settings;
        private string _connectionString;

        private GClass6 gclass6_0;

        public MainForm()
        {
            int_0 = 0;
            bool_0 = true;
            string_2 = string.Empty;
            list_2 = new List<GlobalOrderHistoryObjects.Order>();
            list_3 = new List<GlobalOrderHistoryObjects.CustomerInfo>();
            customerInfo_0 = new GlobalOrderHistoryObjects.CustomerInfo();
            _apiResponse = new GlobalOrderHistoryObjects.Response();
            gclass6_0 = new GClass6();
            _settings = new LocalSettingService();
            InitializeComponent();
        }

        private void buttonDecryptString_Click(object sender, EventArgs e)
        {
            var encryptedText = textBoxEncryptedString.Text;
            var decryptedText = StringCipher.Decrypt(encryptedText, Constant.EncryptionKey);
            textBoxDecryptedString.Text = decryptedText;
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            var decryptedText = textBoxDecryptedString.Text;
            var encryptedText = StringCipher.Encrypt(decryptedText, Constant.EncryptionKey);
            textBoxEncryptedString.Text = encryptedText;
        }

        private string GenerateJSVar(string variableName, object value)
        {
            return $"var {variableName} = {Environment.NewLine}{JsonConvert.SerializeObject(value, Formatting.Indented)}{Environment.NewLine};";
        }

        private void buttonCustomerCellphone_Click(object sender, EventArgs e)
        {
            lstCustomers.Items.Clear();
            lstOrderHistory.Items.Clear();
            lstItems.Items.Clear();

            string_0 = textBoxCustomerCellphone.Text;
            _connectionString = textBoxConnectionString.Text;

            method_5();

            var output = string.Join($"{Environment.NewLine}{Environment.NewLine}",
                GenerateJSVar("orders", list_2),
                GenerateJSVar("customers", list_3),
                GenerateJSVar("apiResponse", _apiResponse));

            textBoxCustomerOrders.Text = output;
        }

        private void method_5()
        {
            list_2.Clear();
            GClass6 gClass = new GClass6(_connectionString);
            if (string.IsNullOrEmpty(string_0) || string_0.Length <= 3)
            {
                return;
            }
            var sourceQuery = gClass.Customers.Where((Customer c) => (c.CustomerCell != null && c.CustomerCell.Contains(string_0)) || (c.CustomerHome != null && c.CustomerHome.Contains(string_0)));
            GetSQLText(gClass, sourceQuery);
            List<Customer> source = sourceQuery.ToList();
            list_3 = (from x in (from x in source
                                 orderby (x.CustomerCell + x.CustomerHome).Length
                                 select x into a
                                 orderby a.LastModified descending
                                 select a).Take(10)
                      select new GlobalOrderHistoryObjects.CustomerInfo
                      {
                          customer_address = x.Address,
                          customer_cell = x.CustomerCell,
                          customer_email = x.CustomerEmail,
                          customer_home = x.CustomerHome,
                          customer_id = x.CustomerID,
                          customer_name = x.CustomerName,
                          last_modified = (x.LastModified.HasValue ? x.LastModified.Value : x.DateCreated)
                      }).ToList();
            if ((SettingsHelper.hasGlobalOrderHistoryAddOn || true) && string_0.Length >= 10)
            {
                _003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass39_0();
                if (string.IsNullOrEmpty(string_2))
                {
                    var cloudSyncQuery = gClass.Settings.Where((Setting s) => s.Key == "cloudsync_api_key");
                    GetSQLText(gClass, cloudSyncQuery);
                    string_2 = cloudSyncQuery.FirstOrDefault().Value;
                }
                CS_0024_003C_003E8__locals3.response = _apiResponse = method_6(string_0);
                if (CS_0024_003C_003E8__locals3.response != null && CS_0024_003C_003E8__locals3.response.orders != null && CS_0024_003C_003E8__locals3.response.customer_info != null)
                {
                    _003C_003Ec__DisplayClass39_1 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass39_1();
                    CS_0024_003C_003E8__locals3.response.orders.ForEach(delegate (GlobalOrderHistoryObjects.Order a)
                    {
                        a.date_created = a.date_paid;
                    });
                    list_2 = CS_0024_003C_003E8__locals3.response.orders;
                    CS_0024_003C_003E8__locals4.customer = (from a in source.Where(delegate (Customer x)
                    {
                        if (x.CustomerCell != null && x.CustomerCell == CS_0024_003C_003E8__locals3.response.customer_info.customer_cell)
                        {
                            return true;
                        }
                        return x.CustomerHome != null && x.CustomerHome == CS_0024_003C_003E8__locals3.response.customer_info.customer_home;
                    })
                                                            orderby a.LastModified descending
                                                            select a).FirstOrDefault();
                    if (CS_0024_003C_003E8__locals4.customer == null)
                    {
                        CS_0024_003C_003E8__locals4.customer = new Customer
                        {
                            Active = true,
                            Address = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_address == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_address),
                            CustomerCell = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_cell == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_cell),
                            CustomerEmail = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_email == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_email),
                            CustomerHome = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_home == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_home),
                            CustomerName = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_name == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_name),
                            DateCreated = DateTime.Now,
                            LoyaltyCardNo = string.Empty,
                            EmployeeID = (((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"] == 0) ? 1 : ((int)CorePOS.Data.Properties.Settings.Default["LoggedInEmployeeID"])),
                            Comments = string.Empty,
                            MemberNumber = string.Empty,
                            LastModified = DateTime.Now,
                            Synced = false
                        };
                        //gClass.Customers.InsertOnSubmit(CS_0024_003C_003E8__locals4.customer);
                        //gClass.SubmitChanges();
                        CS_0024_003C_003E8__locals3.response.customer_info.customer_id = CS_0024_003C_003E8__locals4.customer.CustomerID;
                        list_3.Add(CS_0024_003C_003E8__locals3.response.customer_info);
                    }
                    else if (CS_0024_003C_003E8__locals4.customer.LastModified < CS_0024_003C_003E8__locals3.response.customer_info.last_modified)
                    {
                        CS_0024_003C_003E8__locals4.customer.Address = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_address == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_address);
                        CS_0024_003C_003E8__locals4.customer.CustomerCell = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_cell == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_cell);
                        CS_0024_003C_003E8__locals4.customer.CustomerEmail = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_email == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_email);
                        CS_0024_003C_003E8__locals4.customer.CustomerHome = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_home == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_home);
                        CS_0024_003C_003E8__locals4.customer.CustomerName = ((CS_0024_003C_003E8__locals3.response.customer_info.customer_name == null) ? string.Empty : CS_0024_003C_003E8__locals3.response.customer_info.customer_name);
                        CS_0024_003C_003E8__locals4.customer.LastModified = CS_0024_003C_003E8__locals3.response.customer_info.last_modified;
                        CS_0024_003C_003E8__locals4.customer.Synced = false;
                        //gClass.SubmitChanges();
                        GlobalOrderHistoryObjects.CustomerInfo customerInfo = list_3.Where((GlobalOrderHistoryObjects.CustomerInfo a) => a.customer_id == CS_0024_003C_003E8__locals4.customer.CustomerID).FirstOrDefault();
                        if (customerInfo != null)
                        {
                            customerInfo.customer_name = CS_0024_003C_003E8__locals4.customer.CustomerName;
                            customerInfo.customer_address = CS_0024_003C_003E8__locals4.customer.Address;
                            customerInfo.customer_cell = CS_0024_003C_003E8__locals4.customer.CustomerCell;
                            customerInfo.customer_home = CS_0024_003C_003E8__locals4.customer.CustomerHome;
                            customerInfo.customer_email = CS_0024_003C_003E8__locals4.customer.CustomerEmail;
                            customerInfo.last_modified = (CS_0024_003C_003E8__locals4.customer.LastModified.HasValue ? CS_0024_003C_003E8__locals4.customer.LastModified.Value : DateTime.Now);
                        }
                    }
                    foreach (GlobalOrderHistoryObjects.CustomerInfo item2 in list_3)
                    {
                        string text = string.Empty;
                        if (!string.IsNullOrEmpty(item2.customer_cell))
                        {
                            text = "Cell " + item2.customer_cell + " / " + "Home " + item2.customer_home;
                        }
                        ListViewItem value = new ListViewItem(new string[4]
                        {
                            item2.customer_name,
                            text,
                            item2.customer_address,
                            item2.customer_id.ToString()
                        });
                        lstCustomers.Items.Add(value);
                    }
                }
                if (list_2 == null)
                {
                    list_2 = new List<GlobalOrderHistoryObjects.Order>();
                }
                CS_0024_003C_003E8__locals3.custIDs = list_3.Select((GlobalOrderHistoryObjects.CustomerInfo x) => x.customer_id).ToList();
                
                var listQuery =    gClass.Orders.Where((Order x) => x.DatePaid > DateTime.Now.AddYears(-1) && x.Paid == true && x.Void == false && x.CustomerID != null && CS_0024_003C_003E8__locals3.custIDs.Contains(x.CustomerID.Value) && x.DatePaid.HasValue && !x.DateRefunded.HasValue && x.ItemID > 0 && !x.ShareItemID.HasValue);
                GetSQLText(gClass, listQuery);
                List<Order> list = listQuery.ToList();

                var source2Query = gClass.Orders.Where((Order x) => x.DatePaid > DateTime.Now.AddYears(-1) && x.Paid == true && x.Void == false && x.CustomerID != null && CS_0024_003C_003E8__locals3.custIDs.Contains(x.CustomerID.Value) && x.DatePaid.HasValue && !x.DateRefunded.HasValue && x.ItemID > 0 && x.ShareItemID.HasValue);
                GetSQLText(gClass, source2Query);
                List<Order> source2 = source2Query.ToList();

                if (list.Count() > 0)
                {
                    //list.Select((Order a) => a.OrderId).ToList();
                    List<Guid> list2 = source2.Select((Order a) => a.ShareItemID.Value).ToList();
                    List<GlobalOrderHistoryObjects.Order> list3 = new List<GlobalOrderHistoryObjects.Order>();
                    using (List<Order>.Enumerator enumerator2 = list.GetEnumerator())
                    {
                        while (enumerator2.MoveNext())
                        {
                            _003C_003Ec__DisplayClass39_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_2();
                            CS_0024_003C_003E8__locals0.x = enumerator2.Current;
                            if (!list_2.Select((GlobalOrderHistoryObjects.Order a) => a.order_number).Contains(CS_0024_003C_003E8__locals0.x.OrderNumber))
                            {
                                GlobalOrderHistoryObjects.Order item = new GlobalOrderHistoryObjects.Order
                                {
                                    combo_id = CS_0024_003C_003E8__locals0.x.ComboID,
                                    customer_phone = CS_0024_003C_003E8__locals0.x.CustomerInfoPhone,
                                    date_created = (CS_0024_003C_003E8__locals0.x.LastDateModified.HasValue ? CS_0024_003C_003E8__locals0.x.LastDateModified.Value : CS_0024_003C_003E8__locals0.x.DateCreated.Value),
                                    date_paid = CS_0024_003C_003E8__locals0.x.DatePaid.Value,
                                    item_barcode = CS_0024_003C_003E8__locals0.x.ItemBarcode,
                                    item_id = CS_0024_003C_003E8__locals0.x.ItemID,
                                    item_identifier = (byte)((CS_0024_003C_003E8__locals0.x.ItemIdentifier == "MainItem") ? 1 : ((CS_0024_003C_003E8__locals0.x.ItemIdentifier == "ChildItem") ? 2 : 3)),
                                    item_identifier_string = CS_0024_003C_003E8__locals0.x.ItemIdentifier,
                                    item_instruction = CS_0024_003C_003E8__locals0.x.Instructions,
                                    item_name = CS_0024_003C_003E8__locals0.x.ItemName,
                                    item_qty = CS_0024_003C_003E8__locals0.x.Qty * (decimal)((list2.Count <= 0) ? 1 : (list2.Where((Guid a) => a == CS_0024_003C_003E8__locals0.x.OrderId).Count() + 1)),
                                    option_group_name = CS_0024_003C_003E8__locals0.x.ItemOptionId.ToString(),
                                    option_tab = "###",
                                    order_number = CS_0024_003C_003E8__locals0.x.OrderNumber
                                };
                                list3.Add(item);
                            }
                        }
                    }
                    if (list3.Count > 0)
                    {
                        list_2.AddRange(list3);
                        list_2 = (from x in list_2
                                  orderby x.date_created, x.combo_id
                                  select x).ToList();
                    }
                }
            }
            else if (list_3.Count() > 0)
            {
                _003C_003Ec__DisplayClass39_3 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass39_3();
                foreach (GlobalOrderHistoryObjects.CustomerInfo item3 in list_3)
                {
                    string text2 = string.Empty;
                    if (!string.IsNullOrEmpty(item3.customer_cell))
                    {
                        text2 = "Cell " + item3.customer_cell + " / " + " Home" + item3.customer_home;
                    }
                    ListViewItem value2 = new ListViewItem(new string[4]
                    {
                        item3.customer_name,
                        text2,
                        item3.customer_address,
                        item3.customer_id.ToString()
                    });
                    lstCustomers.Items.Add(value2);
                }
                CS_0024_003C_003E8__locals1.custIDs = list_3.Select((GlobalOrderHistoryObjects.CustomerInfo x) => x.customer_id).ToList();
                
                var source3Query = gClass.Orders.Where((Order x) => x.DatePaid > DateTime.Now.AddYears(-1) && x.Paid == true && x.Void == false && CS_0024_003C_003E8__locals1.custIDs.Contains(x.CustomerID.Value) && x.DatePaid.HasValue && !x.DateRefunded.HasValue && x.ItemID > 0 && !x.ShareItemID.HasValue);
                GetSQLText(gClass, source3Query);
                List<Order> source3 = source3Query.ToList();

                var source4Query = gClass.Orders.Where((Order x) => x.DatePaid > DateTime.Now.AddYears(-1) && x.Paid == true && x.Void == false && CS_0024_003C_003E8__locals1.custIDs.Contains(x.CustomerID.Value) && x.DatePaid.HasValue && !x.DateRefunded.HasValue && x.ItemID > 0 && x.ShareItemID.HasValue);
                GetSQLText(gClass, source4Query);
                List<Order> source4 = source4Query.ToList();

                if (source3.Count() > 0)
                {
                    _003C_003Ec__DisplayClass39_4 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass39_4();
                    source3.Select((Order a) => a.OrderId).ToList();
                    CS_0024_003C_003E8__locals2.sharedOrderIDs = source4.Select((Order a) => a.ShareItemID.Value).ToList();
                    list_2 = (from x in source3.Select(delegate (Order x)
                    {
                        _003C_003Ec__DisplayClass39_5 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_5();
                        CS_0024_003C_003E8__locals0.x = x;
                        return new GlobalOrderHistoryObjects.Order
                        {
                            combo_id = CS_0024_003C_003E8__locals0.x.ComboID,
                            customer_phone = CS_0024_003C_003E8__locals0.x.CustomerInfoPhone,
                            date_created = (CS_0024_003C_003E8__locals0.x.LastDateModified.HasValue ? CS_0024_003C_003E8__locals0.x.LastDateModified.Value : CS_0024_003C_003E8__locals0.x.DateCreated.Value),
                            date_paid = CS_0024_003C_003E8__locals0.x.DatePaid.Value,
                            item_barcode = CS_0024_003C_003E8__locals0.x.ItemBarcode,
                            item_id = CS_0024_003C_003E8__locals0.x.ItemID,
                            item_identifier = (byte)((CS_0024_003C_003E8__locals0.x.ItemIdentifier == "MainItem") ? 1 : ((CS_0024_003C_003E8__locals0.x.ItemIdentifier == "ChildItem") ? 2 : 3)),
                            item_identifier_string = CS_0024_003C_003E8__locals0.x.ItemIdentifier,
                            item_instruction = CS_0024_003C_003E8__locals0.x.Instructions,
                            item_name = CS_0024_003C_003E8__locals0.x.ItemName,
                            item_qty = CS_0024_003C_003E8__locals0.x.Qty * (decimal)((CS_0024_003C_003E8__locals2.sharedOrderIDs.Count <= 0) ? 1 : (CS_0024_003C_003E8__locals2.sharedOrderIDs.Where((Guid a) => a == CS_0024_003C_003E8__locals0.x.OrderId).Count() + 1)),
                            option_group_name = CS_0024_003C_003E8__locals0.x.ItemOptionId.ToString(),
                            option_tab = "###",
                            order_number = CS_0024_003C_003E8__locals0.x.OrderNumber
                        };
                    })
                              orderby x.date_created
                              select x).ThenBy((GlobalOrderHistoryObjects.Order a) => a.combo_id).ToList();
                }
            }
            else
            {
                textBoxCustomerCellphone.Text = string_0;
            }

            if (lstCustomers.Items.Count == 1 && string_0.Length >= 10)
            {
                lstCustomers.Items[0].Selected = true;
            }

        }

        private GlobalOrderHistoryObjects.Response method_6(string string_7)
        {
            GlobalOrderHistoryObjects.Response result = new GlobalOrderHistoryObjects.Response();
            if (Convert.ToBoolean(CorePOS.Data.Properties.Settings.Default["isHipposServersOnline"]) || true)
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(DebugSettings.readyOnlyAPIServer + "getorderhistory");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Proxy = null;
                GlobalOrderHistoryObjects.Request value = new GlobalOrderHistoryObjects.Request
                {
                    phone_number = string_7,
                    token = string_2
                };
                httpWebRequest.Timeout = 10000;
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string value2 = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        MaxDepth = 2000
                    });
                    streamWriter.Write(value2);
                }
                try
                {
                    using (StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()))
                    {
                        var response = streamReader.ReadToEnd();
                        Debug.WriteLine(response);
                        result = JsonConvert.DeserializeObject<GlobalOrderHistoryObjects.Response>(response);
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString());
                    return result;
                }
            }
            return result;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //method_10();
            textBoxConnectionString.Text = _settings.ConnectionString;
        }

        private void method_10()
        {
            lstCustomers.Columns[0].Width = ControlHelpers.ControlWidthFixer(lstCustomers, 2.0);
            lstCustomers.Columns[1].Width = ControlHelpers.ControlWidthFixer(lstCustomers, 5.0);
            lstCustomers.Columns[2].Width = ControlHelpers.ControlWidthFixer(lstCustomers, 5.0);
        }

        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndices.Count <= 0)
            {
                return;
            }
            lstOrderHistory.Items.Clear();
            lstItems.Items.Clear();
            if (lstCustomers.SelectedItems[0].SubItems.Count <= 1)
            {
                return;
            }
            bool_0 = false;
            if (lstCustomers.SelectedItems[0].SubItems[3].Text == string.Empty)
            {
                int_0 = 0;
            }
            else
            {
                int_0 = Convert.ToInt32(lstCustomers.SelectedItems[0].SubItems[3].Text);
            }
            if (int_0 > 0)
            {
                _003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass49_0();
                GClass6 gClass = new GClass6(_connectionString);
                CS_0024_003C_003E8__locals0.cus = gClass.Customers.Where((Customer a) => a.CustomerID == int_0).FirstOrDefault();
                if (CS_0024_003C_003E8__locals0.cus != null)
                {
                    //method_7(CS_0024_003C_003E8__locals0.cus);
                    //btnCancel.Enabled = true;
                    var enumerable = (from x in list_2
                                      where x.customer_phone == CS_0024_003C_003E8__locals0.cus.CustomerHome || x.customer_phone == CS_0024_003C_003E8__locals0.cus.CustomerCell
                                      group x by x.order_number into a
                                      select new
                                      {
                                          OrderNumber = a.Key,
                                          DateCreated = a.FirstOrDefault().date_paid
                                      } into x
                                      orderby x.DateCreated descending
                                      select x).Take(10);
                    if (enumerable.Count() > 0)
                    {
                        foreach (var item in enumerable)
                        {
                            ListViewItem value = new ListViewItem(new string[2]
                            {
                            item.DateCreated.ToShortDateString(),
                            item.OrderNumber
                            });
                            lstOrderHistory.Items.Add(value);
                        }
                        lstOrderHistory.Items[0].Selected = true;
                        //btnDuplicate.Enabled = true;
                    }
                    else
                    {
                        //btnDuplicate.Enabled = false;
                    }
                }
                else
                {
                    //btnDuplicate.Enabled = false;
                }
            }
            else
            {
                //method_8();
                //btnDuplicate.Enabled = false;
            }
        }

        private void lstOrderHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOrderHistory.SelectedItems.Count <= 0)
            {
                return;
            }
            lstItems.Items.Clear();
            foreach (GlobalOrderHistoryObjects.Order item in (from order_0 in list_2
                                                              where order_0.order_number == lstOrderHistory.SelectedItems[0].SubItems[1].Text
                                                              select order_0 into x
                                                              orderby x.date_paid, x.combo_id
                                                              select x).ThenBy((GlobalOrderHistoryObjects.Order z) => z.item_identifier).ToList())
            {
                ListViewItem listViewItem = new ListViewItem(new string[3]
                {
                MathHelper.DecimalToFraction(item.item_qty),
                item.item_name,
                item.item_instruction,
                });
                if (item.item_identifier_string == "MainItem")
                {
                    listViewItem.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
                }
                else
                {
                    listViewItem.Font = new Font("Microsoft Sans Serif", 8.75f, FontStyle.Regular);
                    if (item.item_identifier_string == "OptionItem")
                    {
                        listViewItem.ForeColor = Color.DarkRed;
                    }
                }
                lstItems.Items.Add(listViewItem);
            }
        }

        private void buttonSaveConnectionString_Click(object sender, EventArgs e)
        {
            _settings.ConnectionString = textBoxConnectionString.Text;
        }

        private void GetSQLText<T>(GClass6 gClass, IQueryable<T> q)
        {
            var dc = gClass.GetCommand(q);
            Debug.WriteLine(dc.CommandText);
        }
    }
}
