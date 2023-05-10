using CorePOS.Business.Objects;
using CorePOS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsForHipPOS.Models
{
    internal class _003C_003Ec__DisplayClass49_0
    {
        public Customer cus;

        public _003C_003Ec__DisplayClass49_0()
        {
        }

        internal bool _003ClstCustomers_SelectedIndexChanged_003Eb__1(GlobalOrderHistoryObjects.Order x)
        {
            if (!(x.customer_phone == cus.CustomerHome))
            {
                return x.customer_phone == cus.CustomerCell;
            }
            return true;
        }
    }
}
