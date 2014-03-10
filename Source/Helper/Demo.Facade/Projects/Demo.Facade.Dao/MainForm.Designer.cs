namespace Demo.Facade.Dao
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
            this.btnLive = new System.Windows.Forms.Button();
            this.btnCache = new System.Windows.Forms.Button();
            this.btnThreaded1 = new System.Windows.Forms.Button();
            this.btnThreaded2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLive
            // 
            this.btnLive.Location = new System.Drawing.Point(12, 12);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(75, 23);
            this.btnLive.TabIndex = 0;
            this.btnLive.Text = "Live";
            this.btnLive.UseVisualStyleBackColor = true;
            this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
            // 
            // btnCache
            // 
            this.btnCache.Location = new System.Drawing.Point(12, 41);
            this.btnCache.Name = "btnCache";
            this.btnCache.Size = new System.Drawing.Size(75, 23);
            this.btnCache.TabIndex = 1;
            this.btnCache.Text = "Cache";
            this.btnCache.UseVisualStyleBackColor = true;
            this.btnCache.Click += new System.EventHandler(this.btnCache_Click);
            // 
            // btnThreaded1
            // 
            this.btnThreaded1.Location = new System.Drawing.Point(12, 70);
            this.btnThreaded1.Name = "btnThreaded1";
            this.btnThreaded1.Size = new System.Drawing.Size(75, 23);
            this.btnThreaded1.TabIndex = 2;
            this.btnThreaded1.Text = "Threaded 1";
            this.btnThreaded1.UseVisualStyleBackColor = true;
            this.btnThreaded1.Click += new System.EventHandler(this.btnThreaded_Click);
            // 
            // btnThreaded2
            // 
            this.btnThreaded2.Location = new System.Drawing.Point(12, 99);
            this.btnThreaded2.Name = "btnThreaded2";
            this.btnThreaded2.Size = new System.Drawing.Size(75, 23);
            this.btnThreaded2.TabIndex = 6;
            this.btnThreaded2.Text = "Threaded 2";
            this.btnThreaded2.UseVisualStyleBackColor = true;
            this.btnThreaded2.Click += new System.EventHandler(this.btnThreaded2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnThreaded2);
            this.Controls.Add(this.btnThreaded1);
            this.Controls.Add(this.btnCache);
            this.Controls.Add(this.btnLive);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.Button btnCache;
        private System.Windows.Forms.Button btnThreaded1;
        private System.Windows.Forms.Button btnThreaded2;
    }
}

