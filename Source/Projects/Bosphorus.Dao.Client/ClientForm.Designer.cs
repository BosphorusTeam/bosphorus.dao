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
            this.tbConsole = new System.Windows.Forms.RichTextBox();
            this.splRight = new System.Windows.Forms.Splitter();
            this.tvExecutionList = new System.Windows.Forms.TreeView();
            this.splLeft = new System.Windows.Forms.Splitter();
            this.dgResult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tbConsole
            // 
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbConsole.Location = new System.Drawing.Point(1256, 0);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(327, 714);
            this.tbConsole.TabIndex = 14;
            this.tbConsole.Text = "";
            // 
            // splRight
            // 
            this.splRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splRight.Location = new System.Drawing.Point(1251, 0);
            this.splRight.Name = "splRight";
            this.splRight.Size = new System.Drawing.Size(5, 714);
            this.splRight.TabIndex = 15;
            this.splRight.TabStop = false;
            // 
            // tvExecutionList
            // 
            this.tvExecutionList.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvExecutionList.Location = new System.Drawing.Point(0, 0);
            this.tvExecutionList.Name = "tvExecutionList";
            this.tvExecutionList.Size = new System.Drawing.Size(353, 714);
            this.tvExecutionList.TabIndex = 20;
            this.tvExecutionList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvExecutionList_NodeMouseDoubleClick);
            // 
            // splLeft
            // 
            this.splLeft.Location = new System.Drawing.Point(353, 0);
            this.splLeft.Name = "splLeft";
            this.splLeft.Size = new System.Drawing.Size(5, 714);
            this.splLeft.TabIndex = 21;
            this.splLeft.TabStop = false;
            // 
            // dgResult
            // 
            this.dgResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgResult.Location = new System.Drawing.Point(358, 0);
            this.dgResult.Name = "dgResult";
            this.dgResult.ReadOnly = true;
            this.dgResult.Size = new System.Drawing.Size(893, 714);
            this.dgResult.TabIndex = 22;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 714);
            this.Controls.Add(this.dgResult);
            this.Controls.Add(this.splLeft);
            this.Controls.Add(this.tvExecutionList);
            this.Controls.Add(this.splRight);
            this.Controls.Add(this.tbConsole);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dal Client Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbConsole;
        private System.Windows.Forms.Splitter splRight;
        private System.Windows.Forms.TreeView tvExecutionList;
        private System.Windows.Forms.Splitter splLeft;
        private System.Windows.Forms.DataGridView dgResult;
    }
}