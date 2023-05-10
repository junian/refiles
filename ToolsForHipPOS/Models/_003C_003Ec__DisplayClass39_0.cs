using CorePOS.Business.Objects;
using CorePOS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsForHipPOS.Models
{
    internal class _003C_003Ec__DisplayClass39_0
    {
        public GlobalOrderHistoryObjects.Response response;

        public List<int> custIDs;

        public _003C_003Ec__DisplayClass39_0()
        {
        }

        internal bool _003CsearchCustomer_003Eb__9(Customer x)
        {
            if (x.CustomerCell != null && x.CustomerCell == response.customer_info.customer_cell)
            {
                return true;
            }
            if (x.CustomerHome != null)
            {
                return x.CustomerHome == response.customer_info.customer_home;
            }
            return false;
        }
    }
}
