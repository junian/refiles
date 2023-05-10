namespace ToolsForHipPOS
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.textBoxDecryptedString = new System.Windows.Forms.TextBox();
            this.buttonDecryptString = new System.Windows.Forms.Button();
            this.textBoxEncryptedString = new System.Windows.Forms.TextBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstItems = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstOrderHistory = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstCustomers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxCustomerOrders = new FastColoredTextBoxNS.FastColoredTextBox();
            this.buttonCustomerCellphone = new System.Windows.Forms.Button();
            this.textBoxCustomerCellphone = new System.Windows.Forms.TextBox();
            this.tabPageTools = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSaveConnectionString = new System.Windows.Forms.Button();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxCustomerOrders)).BeginInit();
            this.tabPageTools.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonEncrypt);
            this.groupBox1.Controls.Add(this.textBoxDecryptedString);
            this.groupBox1.Controls.Add(this.buttonDecryptString);
            this.groupBox1.Controls.Add(this.textBoxEncryptedString);
            this.groupBox1.Location = new System.Drawing.Point(6, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "String Cipher";
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(364, 112);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonEncrypt.TabIndex = 3;
            this.buttonEncrypt.Text = "← Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // textBoxDecryptedString
            // 
            this.textBoxDecryptedString.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDecryptedString.Location = new System.Drawing.Point(445, 17);
            this.textBoxDecryptedString.Multiline = true;
            this.textBoxDecryptedString.Name = "textBoxDecryptedString";
            this.textBoxDecryptedString.Size = new System.Drawing.Size(345, 118);
            this.textBoxDecryptedString.TabIndex = 2;
            // 
            // buttonDecryptString
            // 
            this.buttonDecryptString.Location = new System.Drawing.Point(364, 19);
            this.buttonDecryptString.Name = "buttonDecryptString";
            this.buttonDecryptString.Size = new System.Drawing.Size(75, 23);
            this.buttonDecryptString.TabIndex = 1;
            this.buttonDecryptString.Text = "Decrypt →";
            this.buttonDecryptString.UseVisualStyleBackColor = true;
            this.buttonDecryptString.Click += new System.EventHandler(this.buttonDecryptString_Click);
            // 
            // textBoxEncryptedString
            // 
            this.textBoxEncryptedString.Location = new System.Drawing.Point(6, 19);
            this.textBoxEncryptedString.Multiline = true;
            this.textBoxEncryptedString.Name = "textBoxEncryptedString";
            this.textBoxEncryptedString.Size = new System.Drawing.Size(352, 116);
            this.textBoxEncryptedString.TabIndex = 0;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageOrders);
            this.tabControlMain.Controls.Add(this.tabPageTools);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(816, 602);
            this.tabControlMain.TabIndex = 2;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.groupBox2);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(808, 576);
            this.tabPageOrders.TabIndex = 0;
            this.tabPageOrders.Text = "Orders";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lstItems);
            this.groupBox2.Controls.Add(this.lstOrderHistory);
            this.groupBox2.Controls.Add(this.lstCustomers);
            this.groupBox2.Controls.Add(this.textBoxCustomerOrders);
            this.groupBox2.Controls.Add(this.buttonCustomerCellphone);
            this.groupBox2.Controls.Add(this.textBoxCustomerCellphone);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(796, 567);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Order";
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstItems.HideSelection = false;
            this.lstItems.Location = new System.Drawing.Point(343, 48);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(447, 285);
            this.lstItems.TabIndex = 8;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 260;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 260;
            // 
            // lstOrderHistory
            // 
            this.lstOrderHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstOrderHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lstOrderHistory.FullRowSelect = true;
            this.lstOrderHistory.GridLines = true;
            this.lstOrderHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstOrderHistory.HideSelection = false;
            this.lstOrderHistory.Location = new System.Drawing.Point(6, 110);
            this.lstOrderHistory.MultiSelect = false;
            this.lstOrderHistory.Name = "lstOrderHistory";
            this.lstOrderHistory.Size = new System.Drawing.Size(331, 223);
            this.lstOrderHistory.TabIndex = 7;
            this.lstOrderHistory.UseCompatibleStateImageBehavior = false;
            this.lstOrderHistory.View = System.Windows.Forms.View.Details;
            this.lstOrderHistory.SelectedIndexChanged += new System.EventHandler(this.lstOrderHistory_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 260;
            // 
            // lstCustomers
            // 
            this.lstCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstCustomers.FullRowSelect = true;
            this.lstCustomers.GridLines = true;
            this.lstCustomers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstCustomers.HideSelection = false;
            this.lstCustomers.Location = new System.Drawing.Point(6, 48);
            this.lstCustomers.MultiSelect = false;
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(331, 56);
            this.lstCustomers.TabIndex = 6;
            this.lstCustomers.UseCompatibleStateImageBehavior = false;
            this.lstCustomers.View = System.Windows.Forms.View.Details;
            this.lstCustomers.SelectedIndexChanged += new System.EventHandler(this.lstCustomers_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Phone";
            this.columnHeader2.Width = 260;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Address";
            this.columnHeader3.Width = 260;
            // 
            // textBoxCustomerOrders
            // 
            this.textBoxCustomerOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCustomerOrders.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.textBoxCustomerOrders.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
            this.textBoxCustomerOrders.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.textBoxCustomerOrders.BackBrush = null;
            this.textBoxCustomerOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCustomerOrders.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.textBoxCustomerOrders.CharHeight = 14;
            this.textBoxCustomerOrders.CharWidth = 8;
            this.textBoxCustomerOrders.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxCustomerOrders.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBoxCustomerOrders.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.textBoxCustomerOrders.IsReplaceMode = false;
            this.textBoxCustomerOrders.Language = FastColoredTextBoxNS.Language.JS;
            this.textBoxCustomerOrders.LeftBracket = '(';
            this.textBoxCustomerOrders.LeftBracket2 = '{';
            this.textBoxCustomerOrders.Location = new System.Drawing.Point(6, 339);
            this.textBoxCustomerOrders.Name = "textBoxCustomerOrders";
            this.textBoxCustomerOrders.Paddings = new System.Windows.Forms.Padding(0);
            this.textBoxCustomerOrders.RightBracket = ')';
            this.textBoxCustomerOrders.RightBracket2 = '}';
            this.textBoxCustomerOrders.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textBoxCustomerOrders.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textBoxCustomerOrders.ServiceColors")));
            this.textBoxCustomerOrders.Size = new System.Drawing.Size(784, 222);
            this.textBoxCustomerOrders.TabIndex = 2;
            this.textBoxCustomerOrders.Zoom = 100;
            // 
            // buttonCustomerCellphone
            // 
            this.buttonCustomerCellphone.Location = new System.Drawing.Point(262, 19);
            this.buttonCustomerCellphone.Name = "buttonCustomerCellphone";
            this.buttonCustomerCellphone.Size = new System.Drawing.Size(75, 23);
            this.buttonCustomerCellphone.TabIndex = 1;
            this.buttonCustomerCellphone.Text = "Get Orders";
            this.buttonCustomerCellphone.UseVisualStyleBackColor = true;
            this.buttonCustomerCellphone.Click += new System.EventHandler(this.buttonCustomerCellphone_Click);
            // 
            // textBoxCustomerCellphone
            // 
            this.textBoxCustomerCellphone.Location = new System.Drawing.Point(6, 19);
            this.textBoxCustomerCellphone.Name = "textBoxCustomerCellphone";
            this.textBoxCustomerCellphone.Size = new System.Drawing.Size(250, 20);
            this.textBoxCustomerCellphone.TabIndex = 0;
            this.textBoxCustomerCellphone.Text = "4316684171";
            // 
            // tabPageTools
            // 
            this.tabPageTools.Controls.Add(this.groupBox3);
            this.tabPageTools.Controls.Add(this.groupBox1);
            this.tabPageTools.Location = new System.Drawing.Point(4, 22);
            this.tabPageTools.Name = "tabPageTools";
            this.tabPageTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTools.Size = new System.Drawing.Size(808, 576);
            this.tabPageTools.TabIndex = 1;
            this.tabPageTools.Text = "Tools & Options";
            this.tabPageTools.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.buttonSaveConnectionString);
            this.groupBox3.Controls.Add(this.textBoxConnectionString);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(796, 145);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DB Connection String";
            // 
            // buttonSaveConnectionString
            // 
            this.buttonSaveConnectionString.Location = new System.Drawing.Point(364, 19);
            this.buttonSaveConnectionString.Name = "buttonSaveConnectionString";
            this.buttonSaveConnectionString.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveConnectionString.TabIndex = 1;
            this.buttonSaveConnectionString.Text = "Save";
            this.buttonSaveConnectionString.UseVisualStyleBackColor = true;
            this.buttonSaveConnectionString.Click += new System.EventHandler(this.buttonSaveConnectionString_Click);
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(6, 19);
            this.textBoxConnectionString.Multiline = true;
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(352, 116);
            this.textBoxConnectionString.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 626);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tools for HipPOS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxCustomerOrders)).EndInit();
            this.tabPageTools.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDecryptedString;
        private System.Windows.Forms.Button buttonDecryptString;
        private System.Windows.Forms.TextBox textBoxEncryptedString;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView lstOrderHistory;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lstCustomers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private FastColoredTextBoxNS.FastColoredTextBox textBoxCustomerOrders;
        private System.Windows.Forms.Button buttonCustomerCellphone;
        private System.Windows.Forms.TextBox textBoxCustomerCellphone;
        private System.Windows.Forms.TabPage tabPageTools;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSaveConnectionString;
        private System.Windows.Forms.TextBox textBoxConnectionString;
    }
}

