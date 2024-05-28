using Plugin.Settings.Abstractions;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToolsForHipPOS.Services
{
    internal class LocalSettingService
    {
        private ISettings CurrentSettings => CrossSettings.Current;

        public static readonly string DefaultConnectionString = "Data Source=DeskMini-X300;Initial Catalog=Hippos;Persist Security Info=True;User ID=hippos_dbuser;Password=hippos_dbpassword";
        public string ConnectionString
        {
            get => CurrentSettings.GetValueOrDefault(nameof(ConnectionString), DefaultConnectionString);
            set => CurrentSettings.AddOrUpdateValue(nameof(ConnectionString), value);
        }
    }
}
