using CorePOS.Business.Objects;
using CorePOS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsForHipPOS.Models
{
    internal class _003C_003Ec__DisplayClass39_4
    {
        public List<Guid> sharedOrderIDs;

        public _003C_003Ec__DisplayClass39_4()
        {
        }

        internal GlobalOrderHistoryObjects.Order _003CsearchCustomer_003Eb__23(Order x)
        {
            _003C_003Ec__DisplayClass39_5 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_5
            {
                x = x
            };
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
                item_qty = CS_0024_003C_003E8__locals0.x.Qty * (decimal)((sharedOrderIDs.Count <= 0) ? 1 : (sharedOrderIDs.Where((Guid a) => a == CS_0024_003C_003E8__locals0.x.OrderId).Count() + 1)),
                option_group_name = CS_0024_003C_003E8__locals0.x.ItemOptionId.ToString(),
                option_tab = "###",
                order_number = CS_0024_003C_003E8__locals0.x.OrderNumber
            };
        }
    }
}
