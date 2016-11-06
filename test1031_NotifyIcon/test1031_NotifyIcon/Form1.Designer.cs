namespace test1031_NotifyIcon
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iten1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iten2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iten3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iten3ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "XXX";
            this.notifyIcon1.BalloonTipTitle = "T^T";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(44, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iten1ToolStripMenuItem,
            this.iten2ToolStripMenuItem,
            this.iten3ToolStripMenuItem,
            this.iten3ToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.restoreToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 142);
            // 
            // iten1ToolStripMenuItem
            // 
            this.iten1ToolStripMenuItem.Name = "iten1ToolStripMenuItem";
            this.iten1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.iten1ToolStripMenuItem.Text = "item1";
            this.iten1ToolStripMenuItem.Click += new System.EventHandler(this.iten1ToolStripMenuItem_Click);
            // 
            // iten2ToolStripMenuItem
            // 
            this.iten2ToolStripMenuItem.Name = "iten2ToolStripMenuItem";
            this.iten2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.iten2ToolStripMenuItem.Text = "item2";
            // 
            // iten3ToolStripMenuItem
            // 
            this.iten3ToolStripMenuItem.Name = "iten3ToolStripMenuItem";
            this.iten3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.iten3ToolStripMenuItem.Text = "item3";
            // 
            // iten3ToolStripMenuItem1
            // 
            this.iten3ToolStripMenuItem1.Name = "iten3ToolStripMenuItem1";
            this.iten3ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.iten3ToolStripMenuItem1.Text = "iten3";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 301);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iten1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iten2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iten3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iten3ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
    }
}

