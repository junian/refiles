using CorePOS.Business.Objects;
using CorePOS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsForHipPOS.Models
{
    internal class _003C_003Ec__DisplayClass39_1
    {
        public Customer customer;

        public _003C_003Ec__DisplayClass39_1()
        {
        }

        internal bool _003CsearchCustomer_003Eb__11(GlobalOrderHistoryObjects.CustomerInfo a)
        {
            return a.customer_id == customer.CustomerID;
        }
    }
}
