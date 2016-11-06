namespace test1103_ShareEvent
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
            this.textA = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textA
            // 
            this.textA.Location = new System.Drawing.Point(27, 31);
            this.textA.Name = "textA";
            this.textA.Size = new System.Drawing.Size(100, 22);
            this.textA.TabIndex = 0;
            this.textA.Text = "123456789";
            this.textA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "A-123456789";
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyKeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MyKeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(27, 144);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(145, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "B-123456789";
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyKeyDown);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MyKeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(27, 186);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(145, 22);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "C-123456789";
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyKeyDown);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MyKeyPress);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(27, 224);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(145, 22);
            this.textBox4.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 294);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textA;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}

