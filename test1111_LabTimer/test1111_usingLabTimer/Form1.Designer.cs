namespace test1111_usingLabTimer
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
            this.button1 = new System.Windows.Forms.Button();
            this.cLabTimer1 = new test1111_LabTimer.CLabTimer();
            this.cLabTimer2 = new test1111_LabTimer.CLabTimer();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(77, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cLabTimer1
            // 
            this.cLabTimer1.Location = new System.Drawing.Point(77, 102);
            this.cLabTimer1.Name = "cLabTimer1";
            this.cLabTimer1.Size = new System.Drawing.Size(224, 102);
            this.cLabTimer1.TabIndex = 3;
            this.cLabTimer1.TimeInterval = 2000;
            this.cLabTimer1.AtTime += new System.EventHandler(this.cLabTimer1_AtTime);
            this.cLabTimer1.AtTime2 += new test1111_LabTimer.TimerHandler(this.cLabTimer1_AtTime2);
            // 
            // cLabTimer2
            // 
            this.cLabTimer2.Location = new System.Drawing.Point(51, 26);
            this.cLabTimer2.Name = "cLabTimer2";
            this.cLabTimer2.Size = new System.Drawing.Size(485, 100);
            this.cLabTimer2.TabIndex = 1;
            this.cLabTimer2.TimeInterval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 450);
            this.Controls.Add(this.cLabTimer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cLabTimer2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private test1111_LabTimer.CLabTimer cLabTimer2;
        private System.Windows.Forms.Button button1;
        private test1111_LabTimer.CLabTimer cLabTimer1;
    }
}

