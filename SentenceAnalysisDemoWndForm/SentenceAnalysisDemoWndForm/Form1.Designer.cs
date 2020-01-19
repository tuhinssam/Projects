namespace SentenceAnalysisDemoWndForm
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgAgentResponses = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgCustomerRes = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chartSentiment = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblCustomerScore = new System.Windows.Forms.Label();
            this.lblAgentScore = new System.Windows.Forms.Label();
            this.lblPredictedScore = new System.Windows.Forms.Label();
            this.lblSentScore = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAgentResponses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerRes)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSentiment)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearchVal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(459, 38);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 27);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(374, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 27);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchVal
            // 
            this.txtSearchVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchVal.Location = new System.Drawing.Point(87, 38);
            this.txtSearchVal.Name = "txtSearchVal";
            this.txtSearchVal.Size = new System.Drawing.Size(281, 22);
            this.txtSearchVal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket#";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgAgentResponses);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dgCustomerRes);
            this.groupBox2.Location = new System.Drawing.Point(23, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 573);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Text";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dgAgentResponses
            // 
            this.dgAgentResponses.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgAgentResponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAgentResponses.Location = new System.Drawing.Point(6, 319);
            this.dgAgentResponses.Name = "dgAgentResponses";
            this.dgAgentResponses.RowTemplate.Height = 24;
            this.dgAgentResponses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgAgentResponses.Size = new System.Drawing.Size(542, 248);
            this.dgAgentResponses.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Agent Responses:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Customer Responses:";
            // 
            // dgCustomerRes
            // 
            this.dgCustomerRes.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgCustomerRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomerRes.Location = new System.Drawing.Point(6, 50);
            this.dgCustomerRes.Name = "dgCustomerRes";
            this.dgCustomerRes.RowTemplate.Height = 24;
            this.dgCustomerRes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgCustomerRes.Size = new System.Drawing.Size(542, 234);
            this.dgCustomerRes.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chartSentiment);
            this.groupBox3.Location = new System.Drawing.Point(595, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(683, 539);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Visual sentiment analysis";
            // 
            // chartSentiment
            // 
            this.chartSentiment.BackColor = System.Drawing.Color.BurlyWood;
            this.chartSentiment.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chartSentiment.BorderlineColor = System.Drawing.Color.Black;
            this.chartSentiment.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartSentiment.BorderlineWidth = 2;
            chartArea1.AxisX.Title = "Responses";
            chartArea1.AxisY.Title = "Sentiment";
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            chartArea1.Name = "ChartArea1";
            this.chartSentiment.ChartAreas.Add(chartArea1);
            legend1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.TopRight;
            legend1.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.SameAsSeriesOrder;
            legend1.Name = "Legend1";
            this.chartSentiment.Legends.Add(legend1);
            this.chartSentiment.Location = new System.Drawing.Point(12, 35);
            this.chartSentiment.Name = "chartSentiment";
            this.chartSentiment.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "CustScore";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "AgentScore";
            this.chartSentiment.Series.Add(series1);
            this.chartSentiment.Series.Add(series2);
            this.chartSentiment.Size = new System.Drawing.Size(665, 490);
            this.chartSentiment.TabIndex = 0;
            this.chartSentiment.Text = "chart1";
            title1.Name = "User Data Analysis";
            this.chartSentiment.Titles.Add(title1);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox4.Controls.Add(this.lblCustomerScore);
            this.groupBox4.Controls.Add(this.lblAgentScore);
            this.groupBox4.Controls.Add(this.lblPredictedScore);
            this.groupBox4.Controls.Add(this.lblSentScore);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox4.Location = new System.Drawing.Point(595, 557);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(683, 128);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Analysed Data";
            // 
            // lblCustomerScore
            // 
            this.lblCustomerScore.AutoSize = true;
            this.lblCustomerScore.Location = new System.Drawing.Point(284, 28);
            this.lblCustomerScore.Name = "lblCustomerScore";
            this.lblCustomerScore.Size = new System.Drawing.Size(0, 17);
            this.lblCustomerScore.TabIndex = 6;
            // 
            // lblAgentScore
            // 
            this.lblAgentScore.AutoSize = true;
            this.lblAgentScore.Location = new System.Drawing.Point(265, 65);
            this.lblAgentScore.Name = "lblAgentScore";
            this.lblAgentScore.Size = new System.Drawing.Size(0, 17);
            this.lblAgentScore.TabIndex = 5;
            // 
            // lblPredictedScore
            // 
            this.lblPredictedScore.AutoSize = true;
            this.lblPredictedScore.Location = new System.Drawing.Point(194, 97);
            this.lblPredictedScore.Name = "lblPredictedScore";
            this.lblPredictedScore.Size = new System.Drawing.Size(0, 17);
            this.lblPredictedScore.TabIndex = 4;
            // 
            // lblSentScore
            // 
            this.lblSentScore.AutoSize = true;
            this.lblSentScore.Location = new System.Drawing.Point(239, 28);
            this.lblSentScore.Name = "lblSentScore";
            this.lblSentScore.Size = new System.Drawing.Size(0, 17);
            this.lblSentScore.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Predicted CSAT Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Agent Sentiment Median Score:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer Sentiment Median Score:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 697);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Salesforce Sentiment Analysis";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAgentResponses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomerRes)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSentiment)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgAgentResponses;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgCustomerRes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSentiment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAgentScore;
        private System.Windows.Forms.Label lblPredictedScore;
        private System.Windows.Forms.Label lblSentScore;
        private System.Windows.Forms.Label lblCustomerScore;
        private System.Windows.Forms.Button btnRefresh;
    }
}

