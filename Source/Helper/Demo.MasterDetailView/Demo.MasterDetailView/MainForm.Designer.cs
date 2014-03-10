namespace Demo.MasterDetailView
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
            this.btMasterVao = new System.Windows.Forms.Button();
            this.btnDetailVao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btMasterVao
            // 
            this.btMasterVao.Location = new System.Drawing.Point(12, 12);
            this.btMasterVao.Name = "btMasterVao";
            this.btMasterVao.Size = new System.Drawing.Size(75, 23);
            this.btMasterVao.TabIndex = 0;
            this.btMasterVao.Text = "Master Vao";
            this.btMasterVao.UseVisualStyleBackColor = true;
            this.btMasterVao.Click += new System.EventHandler(this.btMasterVao_Click);
            // 
            // btnDetailVao
            // 
            this.btnDetailVao.Location = new System.Drawing.Point(12, 41);
            this.btnDetailVao.Name = "btnDetailVao";
            this.btnDetailVao.Size = new System.Drawing.Size(75, 23);
            this.btnDetailVao.TabIndex = 1;
            this.btnDetailVao.Text = "Detail Vao";
            this.btnDetailVao.UseVisualStyleBackColor = true;
            this.btnDetailVao.Click += new System.EventHandler(this.btnDetailVao_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnDetailVao);
            this.Controls.Add(this.btMasterVao);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btMasterVao;
        private System.Windows.Forms.Button btnDetailVao;
    }
}

