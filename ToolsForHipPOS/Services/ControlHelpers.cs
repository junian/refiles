using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsForHipPOS.Services
{
    internal class ControlHelpers
    {
        public static int ControlWidthFixer(Control ParentControl, double BootstrapColumnInt)
        {
            return Convert.ToInt32(Convert.ToDouble(ParentControl.Size.Width) * BootstrapColumnInt / 12.0);
        }
    }
}
