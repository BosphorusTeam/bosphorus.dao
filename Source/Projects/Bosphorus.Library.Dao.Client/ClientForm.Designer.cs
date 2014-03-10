namespace Bosphorus.Dao.Client
{
    partial class ClientForm
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
            this.lbQueries = new System.Windows.Forms.ListBox();
            this.dgResult = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lbQueries
            // 
            this.lbQueries.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbQueries.FormattingEnabled = true;
            this.lbQueries.Location = new System.Drawing.Point(0, 0);
            this.lbQueries.Name = "lbQueries";
            this.lbQueries.Size = new System.Drawing.Size(205, 397);
            this.lbQueries.TabIndex = 0;
            this.lbQueries.DoubleClick += new System.EventHandler(this.lbQueries_DoubleClick);
            this.lbQueries.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbQueries_KeyUp);
            // 
            // dgResult
            // 
            this.dgResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgResult.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dgResult.DataMember = "";
            this.dgResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgResult.FlatMode = true;
            this.dgResult.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgResult.Location = new System.Drawing.Point(205, 0);
            this.dgResult.Name = "dgResult";
            this.dgResult.ReadOnly = true;
            this.dgResult.Size = new System.Drawing.Size(660, 397);
            this.dgResult.TabIndex = 1;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 397);
            this.Controls.Add(this.dgResult);
            this.Controls.Add(this.lbQueries);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dal Client Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbQueries;
        private System.Windows.Forms.DataGrid dgResult;
    }
}