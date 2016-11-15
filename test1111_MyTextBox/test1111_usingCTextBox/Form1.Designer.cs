namespace test1111_usingCTextBox
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
            this.cTextBox5 = new test1111_MyTextBox.CTextBox();
            this.cTextBox4 = new test1111_MyTextBox.CTextBox();
            this.cTextBox3 = new test1111_MyTextBox.CTextBox();
            this.cTextBox2 = new test1111_MyTextBox.CTextBox();
            this.cTextBox1 = new test1111_MyTextBox.CTextBox();
            this.cTextBox6 = new test1111_MyTextBox.CTextBox();
            this.SuspendLayout();
            // 
            // cTextBox5
            // 
            this.cTextBox5.Location = new System.Drawing.Point(31, 193);
            this.cTextBox5.Name = "cTextBox5";
            this.cTextBox5.Size = new System.Drawing.Size(100, 22);
            this.cTextBox5.SupportUpDown = false;
            this.cTextBox5.TabIndex = 4;
            // 
            // cTextBox4
            // 
            this.cTextBox4.Location = new System.Drawing.Point(31, 150);
            this.cTextBox4.Name = "cTextBox4";
            this.cTextBox4.Size = new System.Drawing.Size(100, 22);
            this.cTextBox4.SupportUpDown = false;
            this.cTextBox4.TabIndex = 3;
            // 
            // cTextBox3
            // 
            this.cTextBox3.Location = new System.Drawing.Point(31, 112);
            this.cTextBox3.Name = "cTextBox3";
            this.cTextBox3.Size = new System.Drawing.Size(100, 22);
            this.cTextBox3.SupportUpDown = false;
            this.cTextBox3.TabIndex = 2;
            // 
            // cTextBox2
            // 
            this.cTextBox2.Location = new System.Drawing.Point(31, 74);
            this.cTextBox2.Name = "cTextBox2";
            this.cTextBox2.Size = new System.Drawing.Size(100, 22);
            this.cTextBox2.SupportUpDown = false;
            this.cTextBox2.TabIndex = 1;
            // 
            // cTextBox1
            // 
            this.cTextBox1.Location = new System.Drawing.Point(13, 34);
            this.cTextBox1.Name = "cTextBox1";
            this.cTextBox1.Size = new System.Drawing.Size(149, 22);
            this.cTextBox1.SupportUpDown = false;
            this.cTextBox1.TabIndex = 0;
            // 
            // cTextBox6
            // 
            this.cTextBox6.Location = new System.Drawing.Point(156, 212);
            this.cTextBox6.Name = "cTextBox6";
            this.cTextBox6.Size = new System.Drawing.Size(100, 22);
            this.cTextBox6.SupportUpDown = false;
            this.cTextBox6.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cTextBox6);
            this.Controls.Add(this.cTextBox5);
            this.Controls.Add(this.cTextBox4);
            this.Controls.Add(this.cTextBox3);
            this.Controls.Add(this.cTextBox2);
            this.Controls.Add(this.cTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private test1111_MyTextBox.CTextBox cTextBox1;
        private test1111_MyTextBox.CTextBox cTextBox2;
        private test1111_MyTextBox.CTextBox cTextBox3;
        private test1111_MyTextBox.CTextBox cTextBox4;
        private test1111_MyTextBox.CTextBox cTextBox5;
        private test1111_MyTextBox.CTextBox cTextBox6;
    }
}

