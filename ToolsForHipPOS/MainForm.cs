using CorePOS.Business.Methods;
using CorePOS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsForHipPOS.Services;

namespace ToolsForHipPOS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonDecryptString_Click(object sender, EventArgs e)
        {
            var encryptedText = textBoxEncryptedString.Text;
            var decryptedText = StringCipher.Decrypt(encryptedText, Constant.EncryptionKey);
            textBoxDecryptedString.Text = decryptedText;
        }
    }
}
