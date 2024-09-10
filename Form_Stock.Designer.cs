namespace COP4365_Project1__C__
{
    partial class form_stock
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_ticker = new System.Windows.Forms.Button();
            this.openFileDialog_StockChooser = new System.Windows.Forms.OpenFileDialog();
            this.chart_OHLCV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.textBox_EndDate = new System.Windows.Forms.TextBox();
            this.textBox_StartDate = new System.Windows.Forms.TextBox();
            this.button_update = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxPattern = new System.Windows.Forms.ComboBox();
            this.candlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLCV)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_ticker
            // 
            this.button_ticker.Location = new System.Drawing.Point(919, 40);
            this.button_ticker.Name = "button_ticker";
            this.button_ticker.Size = new System.Drawing.Size(209, 56);
            this.button_ticker.TabIndex = 0;
            this.button_ticker.Text = "Select a Stock";
            this.button_ticker.UseVisualStyleBackColor = true;
            this.button_ticker.Click += new System.EventHandler(this.button_ticker_Click);
            // 
            // openFileDialog_StockChooser
            // 
            this.openFileDialog_StockChooser.Filter = "All Files|*.csv*|Monthly|*Month.csv|Weekly|*Week.csv|Daily|*Day.csv";
            this.openFileDialog_StockChooser.FilterIndex = 2;
            this.openFileDialog_StockChooser.InitialDirectory = "C:\\Users\\natha\\Documents\\StockData";
            this.openFileDialog_StockChooser.Multiselect = true;
            this.openFileDialog_StockChooser.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // chart_OHLCV
            // 
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_OHLCV.ChartAreas.Add(chartArea1);
            this.chart_OHLCV.ChartAreas.Add(chartArea2);
            this.chart_OHLCV.Location = new System.Drawing.Point(-4, -2);
            this.chart_OHLCV.Name = "chart_OHLCV";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series1.IsXValueIndexed = true;
            series1.Name = "Series_OHLC";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "high,low,open,close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_Volume";
            series2.IsXValueIndexed = true;
            series2.Name = "Series_Volume";
            series2.XValueMember = "date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "volume";
            this.chart_OHLCV.Series.Add(series1);
            this.chart_OHLCV.Series.Add(series2);
            this.chart_OHLCV.Size = new System.Drawing.Size(1823, 1013);
            this.chart_OHLCV.TabIndex = 2;
            this.chart_OHLCV.Text = "chart_stock";
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(303, 51);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(395, 31);
            this.dateTimePicker_Start.TabIndex = 3;
            this.dateTimePicker_Start.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_Start.ValueChanged += new System.EventHandler(this.dateTimePicker_Start_ValueChanged);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(1138, 51);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(395, 31);
            this.dateTimePicker_End.TabIndex = 4;
            this.dateTimePicker_End.ValueChanged += new System.EventHandler(this.dateTimePicker_End_ValueChanged);
            // 
            // textBox_EndDate
            // 
            this.textBox_EndDate.Location = new System.Drawing.Point(1240, 14);
            this.textBox_EndDate.Name = "textBox_EndDate";
            this.textBox_EndDate.Size = new System.Drawing.Size(154, 31);
            this.textBox_EndDate.TabIndex = 5;
            this.textBox_EndDate.Text = "End Date:";
            this.textBox_EndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_EndDate.TextChanged += new System.EventHandler(this.textBox_EndDate_TextChanged);
            // 
            // textBox_StartDate
            // 
            this.textBox_StartDate.Location = new System.Drawing.Point(434, 14);
            this.textBox_StartDate.Name = "textBox_StartDate";
            this.textBox_StartDate.Size = new System.Drawing.Size(154, 31);
            this.textBox_StartDate.TabIndex = 6;
            this.textBox_StartDate.Text = "Start Date:";
            this.textBox_StartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_StartDate.TextChanged += new System.EventHandler(this.textBox_StartDate_TextChanged);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(704, 39);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(209, 56);
            this.button_update.TabIndex = 7;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxPattern);
            this.panel1.Controls.Add(this.button_ticker);
            this.panel1.Controls.Add(this.button_update);
            this.panel1.Controls.Add(this.dateTimePicker_Start);
            this.panel1.Controls.Add(this.textBox_StartDate);
            this.panel1.Controls.Add(this.dateTimePicker_End);
            this.panel1.Controls.Add(this.textBox_EndDate);
            this.panel1.Location = new System.Drawing.Point(-4, 1017);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1823, 111);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBoxPattern
            // 
            this.comboBoxPattern.FormattingEnabled = true;
            this.comboBoxPattern.Location = new System.Drawing.Point(1539, 51);
            this.comboBoxPattern.Name = "comboBoxPattern";
            this.comboBoxPattern.Size = new System.Drawing.Size(271, 33);
            this.comboBoxPattern.TabIndex = 8;
            this.comboBoxPattern.SelectedIndexChanged += new System.EventHandler(this.comboBoxPattern_SelectedIndexChanged);
            // 
            // candlestickBindingSource
            // 
            this.candlestickBindingSource.DataSource = typeof(COP4365_Project1__C__.Candlestick);
            // 
            // form_stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1818, 1140);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart_OHLCV);
            this.Name = "form_stock";
            this.Text = "Stock Form";
            this.Load += new System.EventHandler(this.form_stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_OHLCV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ticker;
        private System.Windows.Forms.OpenFileDialog openFileDialog_StockChooser;
        private System.Windows.Forms.BindingSource candlestickBindingSource;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OHLCV;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.TextBox textBox_EndDate;
        private System.Windows.Forms.TextBox textBox_StartDate;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxPattern;
    }
}

