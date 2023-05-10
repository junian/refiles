using CorePOS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsForHipPOS.Models
{
    internal class _003C_003Ec__DisplayClass39_2
    {
        public Order x;

        public _003C_003Ec__DisplayClass39_2()
        {
        }

        internal bool _003CsearchCustomer_003Eb__17(Guid a)
        {
            return a == x.OrderId;
        }
    }
}
