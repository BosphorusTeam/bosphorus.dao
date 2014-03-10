namespace Bosphorus.Library.Dao.RI
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
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnThreaded = new System.Windows.Forms.Button();
            this.btnUnThreaded = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnMutilThreaded = new System.Windows.Forms.Button();
            this.btnThreadAccount = new System.Windows.Forms.Button();
            this.btnThreadTransaction = new System.Windows.Forms.Button();
            this.btnDatabaseTransaction = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSaveArray = new System.Windows.Forms.Button();
            this.btnRepositoryObject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(6, 177);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(111, 23);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Text = "Account";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnThreaded
            // 
            this.btnThreaded.Location = new System.Drawing.Point(126, 10);
            this.btnThreaded.Name = "btnThreaded";
            this.btnThreaded.Size = new System.Drawing.Size(111, 23);
            this.btnThreaded.TabIndex = 1;
            this.btnThreaded.Text = "Threaded";
            this.btnThreaded.UseVisualStyleBackColor = true;
            this.btnThreaded.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUnThreaded
            // 
            this.btnUnThreaded.Location = new System.Drawing.Point(241, 10);
            this.btnUnThreaded.Name = "btnUnThreaded";
            this.btnUnThreaded.Size = new System.Drawing.Size(113, 23);
            this.btnUnThreaded.TabIndex = 2;
            this.btnUnThreaded.Text = "UnThreaded";
            this.btnUnThreaded.UseVisualStyleBackColor = true;
            this.btnUnThreaded.Click += new System.EventHandler(this.btnUnThreaded_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "UnThreaded";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Threaded";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnMutilThreaded
            // 
            this.btnMutilThreaded.Location = new System.Drawing.Point(126, 80);
            this.btnMutilThreaded.Name = "btnMutilThreaded";
            this.btnMutilThreaded.Size = new System.Drawing.Size(111, 23);
            this.btnMutilThreaded.TabIndex = 5;
            this.btnMutilThreaded.Text = "Multi Threaded";
            this.btnMutilThreaded.UseVisualStyleBackColor = true;
            this.btnMutilThreaded.Click += new System.EventHandler(this.btnMultiThread_Click);
            // 
            // btnThreadAccount
            // 
            this.btnThreadAccount.Location = new System.Drawing.Point(126, 109);
            this.btnThreadAccount.Name = "btnThreadAccount";
            this.btnThreadAccount.Size = new System.Drawing.Size(111, 23);
            this.btnThreadAccount.TabIndex = 6;
            this.btnThreadAccount.Text = "Thread Account";
            this.btnThreadAccount.UseVisualStyleBackColor = true;
            this.btnThreadAccount.Click += new System.EventHandler(this.btnThreadAccount_Click);
            // 
            // btnThreadTransaction
            // 
            this.btnThreadTransaction.Location = new System.Drawing.Point(126, 138);
            this.btnThreadTransaction.Name = "btnThreadTransaction";
            this.btnThreadTransaction.Size = new System.Drawing.Size(111, 23);
            this.btnThreadTransaction.TabIndex = 7;
            this.btnThreadTransaction.Text = "Thread Transaction";
            this.btnThreadTransaction.UseVisualStyleBackColor = true;
            this.btnThreadTransaction.Click += new System.EventHandler(this.btnThreadTransaction_Click);
            // 
            // btnDatabaseTransaction
            // 
            this.btnDatabaseTransaction.Location = new System.Drawing.Point(126, 204);
            this.btnDatabaseTransaction.Name = "btnDatabaseTransaction";
            this.btnDatabaseTransaction.Size = new System.Drawing.Size(231, 23);
            this.btnDatabaseTransaction.TabIndex = 8;
            this.btnDatabaseTransaction.Text = "Database Transaction";
            this.btnDatabaseTransaction.UseVisualStyleBackColor = true;
            this.btnDatabaseTransaction.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Transaction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Repository.Threaded";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(246, 109);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Thread Account";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(246, 80);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Multi Threaded";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSaveArray
            // 
            this.btnSaveArray.Location = new System.Drawing.Point(375, 10);
            this.btnSaveArray.Name = "btnSaveArray";
            this.btnSaveArray.Size = new System.Drawing.Size(132, 23);
            this.btnSaveArray.TabIndex = 14;
            this.btnSaveArray.Text = "Save Array";
            this.btnSaveArray.UseVisualStyleBackColor = true;
            this.btnSaveArray.Click += new System.EventHandler(this.btnSaveArray_Click);
            // 
            // btnRepositoryObject
            // 
            this.btnRepositoryObject.Location = new System.Drawing.Point(375, 39);
            this.btnRepositoryObject.Name = "btnRepositoryObject";
            this.btnRepositoryObject.Size = new System.Drawing.Size(132, 23);
            this.btnRepositoryObject.TabIndex = 15;
            this.btnRepositoryObject.Text = "Repository Object";
            this.btnRepositoryObject.UseVisualStyleBackColor = true;
            this.btnRepositoryObject.Click += new System.EventHandler(this.btnRepositoryObject_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 239);
            this.Controls.Add(this.btnRepositoryObject);
            this.Controls.Add(this.btnSaveArray);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDatabaseTransaction);
            this.Controls.Add(this.btnThreadTransaction);
            this.Controls.Add(this.btnThreadAccount);
            this.Controls.Add(this.btnMutilThreaded);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnUnThreaded);
            this.Controls.Add(this.btnThreaded);
            this.Controls.Add(this.btnAccount);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnThreaded;
        private System.Windows.Forms.Button btnUnThreaded;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnMutilThreaded;
        private System.Windows.Forms.Button btnThreadAccount;
        private System.Windows.Forms.Button btnThreadTransaction;
        private System.Windows.Forms.Button btnDatabaseTransaction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSaveArray;
        private System.Windows.Forms.Button btnRepositoryObject;
    }
}

