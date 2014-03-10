namespace Bosphorus.Library.Dao.Core.Extension.Demo
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
            this.btnCustomDao = new System.Windows.Forms.Button();
            this.btnGenericDao = new System.Windows.Forms.Button();
            this.btnCacheDecorator = new System.Windows.Forms.Button();
            this.btnThreadDecorator = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomDao
            // 
            this.btnCustomDao.Location = new System.Drawing.Point(12, 12);
            this.btnCustomDao.Name = "btnCustomDao";
            this.btnCustomDao.Size = new System.Drawing.Size(120, 23);
            this.btnCustomDao.TabIndex = 0;
            this.btnCustomDao.Text = "Custom Dao";
            this.btnCustomDao.UseVisualStyleBackColor = true;
            this.btnCustomDao.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // btnGenericDao
            // 
            this.btnGenericDao.Location = new System.Drawing.Point(12, 41);
            this.btnGenericDao.Name = "btnGenericDao";
            this.btnGenericDao.Size = new System.Drawing.Size(120, 23);
            this.btnGenericDao.TabIndex = 1;
            this.btnGenericDao.Text = "Generic Dao";
            this.btnGenericDao.UseVisualStyleBackColor = true;
            this.btnGenericDao.Click += new System.EventHandler(this.btnGeneric_Click);
            // 
            // btnCacheDecorator
            // 
            this.btnCacheDecorator.Location = new System.Drawing.Point(138, 12);
            this.btnCacheDecorator.Name = "btnCacheDecorator";
            this.btnCacheDecorator.Size = new System.Drawing.Size(117, 23);
            this.btnCacheDecorator.TabIndex = 3;
            this.btnCacheDecorator.Text = "Cached Bank";
            this.btnCacheDecorator.UseVisualStyleBackColor = true;
            this.btnCacheDecorator.Click += new System.EventHandler(this.btnCacheDecorator_Click);
            // 
            // btnThreadDecorator
            // 
            this.btnThreadDecorator.Location = new System.Drawing.Point(12, 97);
            this.btnThreadDecorator.Name = "btnThreadDecorator";
            this.btnThreadDecorator.Size = new System.Drawing.Size(120, 23);
            this.btnThreadDecorator.TabIndex = 4;
            this.btnThreadDecorator.Text = "Repository.Threaded";
            this.btnThreadDecorator.UseVisualStyleBackColor = true;
            this.btnThreadDecorator.Click += new System.EventHandler(this.btnThreadDecorator_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.Location = new System.Drawing.Point(12, 126);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(120, 23);
            this.btnTransaction.TabIndex = 5;
            this.btnTransaction.Text = "Transaction";
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 181);
            this.Controls.Add(this.btnTransaction);
            this.Controls.Add(this.btnThreadDecorator);
            this.Controls.Add(this.btnCacheDecorator);
            this.Controls.Add(this.btnGenericDao);
            this.Controls.Add(this.btnCustomDao);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCustomDao;
        private System.Windows.Forms.Button btnGenericDao;
        private System.Windows.Forms.Button btnCacheDecorator;
        private System.Windows.Forms.Button btnThreadDecorator;
        private System.Windows.Forms.Button btnTransaction;
    }
}

