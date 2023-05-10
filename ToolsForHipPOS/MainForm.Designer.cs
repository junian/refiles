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
            this.textBoxEncryptedString = new System.Windows.Forms.TextBox();
            this.buttonDecryptString = new System.Windows.Forms.Button();
            this.textBoxDecryptedString = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxDecryptedString);
            this.groupBox1.Controls.Add(this.buttonDecryptString);
            this.groupBox1.Controls.Add(this.textBoxEncryptedString);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "String Decryptor";
            // 
            // textBoxEncryptedString
            // 
            this.textBoxEncryptedString.Location = new System.Drawing.Point(6, 19);
            this.textBoxEncryptedString.Multiline = true;
            this.textBoxEncryptedString.Name = "textBoxEncryptedString";
            this.textBoxEncryptedString.Size = new System.Drawing.Size(379, 209);
            this.textBoxEncryptedString.TabIndex = 0;
            // 
            // buttonDecryptString
            // 
            this.buttonDecryptString.Location = new System.Drawing.Point(391, 113);
            this.buttonDecryptString.Name = "buttonDecryptString";
            this.buttonDecryptString.Size = new System.Drawing.Size(75, 23);
            this.buttonDecryptString.TabIndex = 1;
            this.buttonDecryptString.Text = "Decrypt";
            this.buttonDecryptString.UseVisualStyleBackColor = true;
            this.buttonDecryptString.Click += new System.EventHandler(this.buttonDecryptString_Click);
            // 
            // textBoxDecryptedString
            // 
            this.textBoxDecryptedString.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDecryptedString.Location = new System.Drawing.Point(472, 19);
            this.textBoxDecryptedString.Multiline = true;
            this.textBoxDecryptedString.Name = "textBoxDecryptedString";
            this.textBoxDecryptedString.ReadOnly = true;
            this.textBoxDecryptedString.Size = new System.Drawing.Size(374, 209);
            this.textBoxDecryptedString.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 538);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Tools for HipPOS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDecryptedString;
        private System.Windows.Forms.Button buttonDecryptString;
        private System.Windows.Forms.TextBox textBoxEncryptedString;
    }
}

