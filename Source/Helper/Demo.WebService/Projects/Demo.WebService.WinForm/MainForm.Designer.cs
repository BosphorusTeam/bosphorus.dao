namespace Demo.WebService.WinForm
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
            this.btnCustomer = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnAcccountCustomDao = new System.Windows.Forms.Button();
            this.btnBank = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(12, 353);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(468, 347);
            this.dataGrid1.TabIndex = 1;
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(93, 353);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(123, 23);
            this.btnAccount.TabIndex = 3;
            this.btnAccount.Text = "Acccount";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnAcccountCustomDao
            // 
            this.btnAcccountCustomDao.Location = new System.Drawing.Point(93, 379);
            this.btnAcccountCustomDao.Name = "btnAcccountCustomDao";
            this.btnAcccountCustomDao.Size = new System.Drawing.Size(123, 23);
            this.btnAcccountCustomDao.TabIndex = 4;
            this.btnAcccountCustomDao.Text = "Acccount Custom Dao";
            this.btnAcccountCustomDao.UseVisualStyleBackColor = true;
            this.btnAcccountCustomDao.Click += new System.EventHandler(this.btnAcccountCustomDao_Click);
            // 
            // btnBank
            // 
            this.btnBank.Location = new System.Drawing.Point(222, 353);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(123, 23);
            this.btnBank.TabIndex = 5;
            this.btnBank.Text = "Bank";
            this.btnBank.UseVisualStyleBackColor = true;
            this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Bank";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 414);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBank);
            this.Controls.Add(this.btnAcccountCustomDao);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.btnCustomer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnAcccountCustomDao;
        private System.Windows.Forms.Button btnBank;
        private System.Windows.Forms.Button button1;
    }
}

