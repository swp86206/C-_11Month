namespace NBA_OneGameScore {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBookTotal = new System.Windows.Forms.TextBox();
            this.txtQ1 = new System.Windows.Forms.TextBox();
            this.lblMinMax = new System.Windows.Forms.Label();
            this.txtQ2 = new System.Windows.Forms.TextBox();
            this.txtQ3 = new System.Windows.Forms.TextBox();
            this.txtQ4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chartScore = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartScore)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "GameInfo Url:";
            // 
            // txtUrl
            // 
            this.txtUrl.BackColor = System.Drawing.Color.DarkGray;
            this.txtUrl.Location = new System.Drawing.Point(137, 11);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(509, 32);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "http://www.nba.com/games/20160115/CLEHOU/gameinfo.html";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(663, 10);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(86, 70);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Book total:";
            // 
            // txtBookTotal
            // 
            this.txtBookTotal.BackColor = System.Drawing.Color.DarkGray;
            this.txtBookTotal.Location = new System.Drawing.Point(137, 48);
            this.txtBookTotal.Name = "txtBookTotal";
            this.txtBookTotal.Size = new System.Drawing.Size(70, 32);
            this.txtBookTotal.TabIndex = 6;
            this.txtBookTotal.Text = "205.5";
            this.txtBookTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtQ1
            // 
            this.txtQ1.BackColor = System.Drawing.Color.DarkGray;
            this.txtQ1.ForeColor = System.Drawing.Color.Black;
            this.txtQ1.Location = new System.Drawing.Point(22, 139);
            this.txtQ1.Multiline = true;
            this.txtQ1.Name = "txtQ1";
            this.txtQ1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQ1.Size = new System.Drawing.Size(170, 133);
            this.txtQ1.TabIndex = 7;
            // 
            // lblMinMax
            // 
            this.lblMinMax.AutoSize = true;
            this.lblMinMax.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMinMax.Location = new System.Drawing.Point(17, 89);
            this.lblMinMax.Name = "lblMinMax";
            this.lblMinMax.Size = new System.Drawing.Size(60, 25);
            this.lblMinMax.TabIndex = 8;
            this.lblMinMax.Text = "--------";
            // 
            // txtQ2
            // 
            this.txtQ2.BackColor = System.Drawing.Color.DarkGray;
            this.txtQ2.ForeColor = System.Drawing.Color.Black;
            this.txtQ2.Location = new System.Drawing.Point(209, 139);
            this.txtQ2.Multiline = true;
            this.txtQ2.Name = "txtQ2";
            this.txtQ2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQ2.Size = new System.Drawing.Size(170, 133);
            this.txtQ2.TabIndex = 9;
            // 
            // txtQ3
            // 
            this.txtQ3.BackColor = System.Drawing.Color.DarkGray;
            this.txtQ3.ForeColor = System.Drawing.Color.Black;
            this.txtQ3.Location = new System.Drawing.Point(396, 139);
            this.txtQ3.Multiline = true;
            this.txtQ3.Name = "txtQ3";
            this.txtQ3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQ3.Size = new System.Drawing.Size(170, 133);
            this.txtQ3.TabIndex = 10;
            // 
            // txtQ4
            // 
            this.txtQ4.BackColor = System.Drawing.Color.DarkGray;
            this.txtQ4.ForeColor = System.Drawing.Color.Black;
            this.txtQ4.Location = new System.Drawing.Point(583, 139);
            this.txtQ4.Multiline = true;
            this.txtQ4.Name = "txtQ4";
            this.txtQ4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQ4.Size = new System.Drawing.Size(170, 133);
            this.txtQ4.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(212, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(595, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(402, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "3";
            // 
            // chartScore
            // 
            this.chartScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartScore.BackColor = System.Drawing.Color.DarkGray;
            this.chartScore.BorderlineColor = System.Drawing.Color.DimGray;
            this.chartScore.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.BackColor = System.Drawing.Color.DarkGray;
            chartArea2.Name = "ChartArea1";
            this.chartScore.ChartAreas.Add(chartArea2);
            this.chartScore.Location = new System.Drawing.Point(22, 283);
            this.chartScore.Name = "chartScore";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Maroon;
            series2.Name = "score";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartScore.Series.Add(series2);
            this.chartScore.Size = new System.Drawing.Size(731, 242);
            this.chartScore.TabIndex = 16;
            this.chartScore.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 537);
            this.Controls.Add(this.chartScore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQ4);
            this.Controls.Add(this.txtQ3);
            this.Controls.Add(this.txtQ2);
            this.Controls.Add(this.lblMinMax);
            this.Controls.Add(this.txtQ1);
            this.Controls.Add(this.txtBookTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MainForm";
            this.Text = "Viewing NBA Game Score";
            ((System.ComponentModel.ISupportInitialize)(this.chartScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBookTotal;
        private System.Windows.Forms.TextBox txtQ1;
        private System.Windows.Forms.Label lblMinMax;
        private System.Windows.Forms.TextBox txtQ2;
        private System.Windows.Forms.TextBox txtQ3;
        private System.Windows.Forms.TextBox txtQ4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartScore;
    }
}

