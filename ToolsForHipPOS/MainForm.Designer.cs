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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDecryptedString = new System.Windows.Forms.TextBox();
            this.buttonDecryptString = new System.Windows.Forms.Button();
            this.textBoxEncryptedString = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxCustomerOrders = new System.Windows.Forms.TextBox();
            this.buttonCustomerCellphone = new System.Windows.Forms.Button();
            this.textBoxCustomerCellphone = new System.Windows.Forms.TextBox();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "String Cipher";
            // 
            // textBoxDecryptedString
            // 
            this.textBoxDecryptedString.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDecryptedString.Location = new System.Drawing.Point(472, 19);
            this.textBoxDecryptedString.Multiline = true;
            this.textBoxDecryptedString.Name = "textBoxDecryptedString";
            this.textBoxDecryptedString.Size = new System.Drawing.Size(374, 209);
            this.textBoxDecryptedString.TabIndex = 2;
            // 
            // buttonDecryptString
            // 
            this.buttonDecryptString.Location = new System.Drawing.Point(391, 79);
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
            this.textBoxEncryptedString.Size = new System.Drawing.Size(379, 209);
            this.textBoxEncryptedString.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxCustomerOrders);
            this.groupBox2.Controls.Add(this.buttonCustomerCellphone);
            this.groupBox2.Controls.Add(this.textBoxCustomerCellphone);
            this.groupBox2.Location = new System.Drawing.Point(12, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(852, 350);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Order";
            // 
            // textBoxCustomerOrders
            // 
            this.textBoxCustomerOrders.Location = new System.Drawing.Point(6, 48);
            this.textBoxCustomerOrders.Multiline = true;
            this.textBoxCustomerOrders.Name = "textBoxCustomerOrders";
            this.textBoxCustomerOrders.Size = new System.Drawing.Size(840, 296);
            this.textBoxCustomerOrders.TabIndex = 2;
            // 
            // buttonCustomerCellphone
            // 
            this.buttonCustomerCellphone.Location = new System.Drawing.Point(245, 19);
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
            this.textBoxCustomerCellphone.Size = new System.Drawing.Size(233, 20);
            this.textBoxCustomerCellphone.TabIndex = 0;
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(389, 112);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonEncrypt.TabIndex = 3;
            this.buttonEncrypt.Text = "← Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 626);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tools for HipPOS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDecryptedString;
        private System.Windows.Forms.Button buttonDecryptString;
        private System.Windows.Forms.TextBox textBoxEncryptedString;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxCustomerOrders;
        private System.Windows.Forms.Button buttonCustomerCellphone;
        private System.Windows.Forms.TextBox textBoxCustomerCellphone;
        private System.Windows.Forms.Button buttonEncrypt;
    }
}

