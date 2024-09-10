using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace COP4365_Project1__C__
{
    public partial class form_stock : Form
    {
        // Initalize the candlesticks and boundCandlesticks to be null
        private List<Candlestick> candlesticks = null;
        private BindingList<Candlestick> boundCandlesticks = null;

        // List to store all of the recognizers
        private List<Recognizer> recognizersList = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public form_stock()
        {
            InitializeComponent();
            
            InitializeRecognizersList();

            // Initialize a new list of candlesticks
            candlesticks = new List<Candlestick>(1024);

            // Set the starting and ending dates to intial values
            dateTimePicker_Start.Value = new DateTime(2022, 1, 1);
            dateTimePicker_End.Value = DateTime.Now;
        }

        /// <summary>
        /// Constructor for form_stock
        /// </summary>
        /// <param name="stockFile">Takes the file as input</param>
        /// <param name="start">Starting date</param>
        /// <param name="end">Ending date</param>
        public form_stock(string stockFile, DateTime start, DateTime end)
        {
            InitializeComponent();

            InitializeRecognizersList();

            // Set the dateTimePickers starting and ending date
            dateTimePicker_Start.Value = start;
            dateTimePicker_End.Value = end;

            // Read a file and return a list of candlesticks
            candlesticks = ReadFile(stockFile);

            // update the display

            updateDisplay();
        }
        
        

        // Event handler for button ticker click
        private void button_ticker_Click(object sender, EventArgs e)
        {
            // When the button is clicked, it displays the openFileDialog file explorer
            openFileDialog_StockChooser.ShowDialog();
        }

        // Event handler for button update click
        private void button_update_Click(object sender, EventArgs e)
        {
            // Some error handling. Ensures the list isn't empty and the start date isn't > end date.
            if ((candlesticks.Count > 0) && (dateTimePicker_Start.Value <= dateTimePicker_End.Value))
            {
                // Calls the updateDisplay() method to update the chart with the new date range
                updateDisplay();
            }
        }

        
        // Event handler for the openFileDialog
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //Get the starting and ending date
            DateTime startDate = dateTimePicker_Start.Value;
            DateTime endDate = dateTimePicker_End.Value;

            // Go through each file
            int numberOfFiles = openFileDialog_StockChooser.FileNames.Count();

            // Loop for each file
            for (int i = 0; i < numberOfFiles; ++i)
            {
                // Get the ith path name
                string pathName = openFileDialog_StockChooser.FileNames[i];
                string ticker = Path.GetFileNameWithoutExtension(pathName);

                // Instantiate a new form
                form_stock form_StockViewer;

                // The case if it's the parent form
                if (i == 0)
                {
                    // Go read the file and display the stock
                    form_StockViewer = this;
                    readAndDisplayStock();

                    // Text for parent form
                    form_StockViewer.Text = "Parent: " + ticker;
                }

                // Case if it's a child form
                else
                {
                    // Instantiate a new form
                    form_StockViewer = new form_stock(pathName, startDate, endDate);
                    
                    readAndDisplayStock();

                    // Text for child form
                    form_StockViewer.Text = "Child: " + ticker;
                }

                // Go display the new form
                form_StockViewer.Show();
                form_StockViewer.BringToFront();

            }
          
            
        }
        
        /// <summary>
        /// Method to read and display the stock
        /// </summary>
        private void readAndDisplayStock()
        {
            // Calls the ReadFile method to read a file
            ReadFile();
            
            List<SmartCandlestick> smartCandlesticks = candlesticks.ConvertAll(c => (SmartCandlestick)c);
            InitializeRecognizers(smartCandlesticks);

            // Calls the updateDisplay method to display the list of candlesticks on the chart
            updateDisplay();
        }


        /// <summary>
        /// This is the method that reads the stock data file, named ReadFile
        /// </summary>
        /// <param name="filename">This argument takes a filename, which is from the openFileDialog</param>
        /// <returns>Returns a list of candlesticks</returns>
        // TODO: Instead of adding candlesticks to the list, add smart candlesticks
        private List<Candlestick> ReadFile(string filename)
        {

            // Creates a reference string for the header row of the CSV file
            const string referenceString = "Date,Open,High,Low,Close,Adj Close,Volume";

            // Create a new list of candlesticks for the resulting list
            List<Candlestick> resultingList = new List<Candlestick>(1024);
            
            // StreamReader will read the file, given a file path
            using (StreamReader sr = new StreamReader(filename))
            {
                // Read the first line
                string line = sr.ReadLine();

                // Checks if the first line is the reference string
                if(line == referenceString)
                {
                    // Read each line until end of file
                    while ((line = sr.ReadLine()) != null)
                    {
                   
                        // Instantiate a new SmartCandlestick
                        SmartCandlestick scs = new SmartCandlestick(line);

                        // Add the candlestick to the list
                        resultingList.Add(scs);
                    }
                }
                else
                {
                    // Error handling if the file is bad
                    Text = "Bad File" + filename;
                }
            }
            // Returns the resulting list
            return resultingList;
        }

        /// <summary>
        /// This is the overload for the ReadFile method and returns a list of candlesticks "candlesticks"
        /// </summary>
        private void ReadFile()
        {
            // Call ReadFile and return a list of candlesticks
            candlesticks = ReadFile(openFileDialog_StockChooser.FileName);

            // Bind the list of candlesticks to a binding list
            boundCandlesticks = new BindingList<Candlestick>(candlesticks);

        }

        /// <summary>
        /// This method filters the list of candlesticks according to a specific date range (inclusive)
        /// </summary>
        /// <param name="unfilteredList">Takes the list we created from reading the file (unfiltered)</param>
        /// <param name="startDate">Takes the starting date from the dateTimePicker</param>
        /// <param name="endDate">Takes the ending date from the dateTimePicker</param>
        /// <returns>Returns a filterd list of candlesticks</returns>
        private List<Candlestick> filterCandlesticks(List<Candlestick> unfilteredList, DateTime startDate, DateTime endDate)
        {

        

#if true
            // Create a new list with the size of the unfiltered list
            List<Candlestick> filteredList = new List<Candlestick>(unfilteredList.Count);
            
            // Iterate through each candlestick in the unfiltered list
            foreach(Candlestick cs in unfilteredList)
            {
                // If we have not reached the start date yet, keep iterating
                if (cs.date < startDate)
                    continue;
                // Break the loop once it's past the end date
                if (cs.date > endDate)
                    break;
                // Adds the candlestick in the desired date range to the new list
                filteredList.Add(cs);
            }
#endif
            // Return the filtered list 
            return filteredList;
        }

        /// <summary>
        ///  Overload of filterCandlesticks, which calls the filterCandlesticks method. Also, I bind the filtered list to a binding list
        /// </summary>
        private void filterCandlesticks()
        {
            // Call the filterCandlesticks function. Returns a filtered list of candlesticks. 
            List<Candlestick> filteredList = filterCandlesticks(candlesticks, dateTimePicker_Start.Value, dateTimePicker_End.Value);

            // Bind the filtered list
            boundCandlesticks = new BindingList<Candlestick>(filteredList);

            // Call the updateComboBox method to update the combobox
            updateComboBox();
        }
        
        /// <summary>
        /// Method for displaying the list of candlesticks on the grid and chart. 
        /// </summary>
        /// <param name="list">this parameter takes the list of candlesticks to be displayed</param>
        private void displayCandlesticks(BindingList<Candlestick> list)
        {
            // Bind the list of candlesticks to the dataGridView 
            //dataGridView_Stock.DataSource = list;

            // Resize the Y axis to fit the data contents
            normalizeChart();

            // Clear the annotations in the chart
            chart_OHLCV.Annotations.Clear();

            // Bind the list of candlesticks to the chart
            chart_OHLCV.DataSource = list;
            chart_OHLCV.DataBind();
        }
        /// <summary>
        /// Overload for displayCandlesticks. Passes the list of bound candlesticks
        /// </summary>
        private void displayCandlesticks()
        {
            // Calls displayCandlesticks and passes the list boundCandlesticks 
            displayCandlesticks(boundCandlesticks);
        }
        /// <summary>
        /// Void function to update the grid and chart
        /// It calls filterCandlesticks and displayCandlesticks
        /// </summary>
        private void updateDisplay()
        {
            // Before filtering, create a loop where it iterates through the list of recognizers and calls RecognizeAll

            // Call filterCandlesticks
            filterCandlesticks();

            // Call displayCandlesticks
            displayCandlesticks();

            // Update the ComboBox
            //updateComboBox();

            // Normalize Display
            //normalizeChart();
        }
        /// <summary>
        /// Method to normalize the chart's Y axis to within 2% of the high and low. It makes the chart look more full. 
        /// </summary>
        /// <param name="list">Takes a list of candlesticks to find the low and high use to adjust the chart</param>
        private void normalizeChart(BindingList<Candlestick> list)
        {
            // Set the minimum to the first candlestick's low 
            decimal min = list.First().low;
            
            // Set the max to 0
            decimal max = 0;

            // Go through each candlestick in the list
            foreach (Candlestick cs in list)
            {
                // Checks if the candlestick's low is the lowest 
                if (cs.low < min) 
                {
                    min = cs.low;
                }

                // Checks if the candlestick's high is the highest
                if (cs.high > max) 
                {
                    max = cs.high;
                }
            }

            // Changes the Y axis so that there's a 2% offset
            chart_OHLCV.ChartAreas[0].AxisY.Minimum = Math.Floor(Decimal.ToDouble(min) * 0.98); 
            chart_OHLCV.ChartAreas[0].AxisY.Maximum = Math.Ceiling(Decimal.ToDouble(max) * 1.02);
        }

        /// <summary>
        /// Overload for normalizeChart. Passes the boundCandlesticks list.
        /// </summary>
        private void normalizeChart()
        {
            // Takes the list of bound candlesticks and finds the minimum low and maximum high, then adjusts the Y axis.
            normalizeChart(boundCandlesticks);
        }


        /// <summary>
        /// Method to update the combobox
        /// </summary>
        /// <param name="boundList">Takes a bound list of candlesticks</param>
        private void updateComboBox(BindingList<Candlestick> boundList)
        {
            // if the list is not empty
            if (boundList.Count != 0) 
            {
                // clear the combobox
                this.comboBoxPattern.Items.Clear();

                // cast to a SmartCandlestick
                SmartCandlestick scs = (SmartCandlestick)boundList[0];   

                // Iterate and add each key into the combobox
                foreach (string key in scs.patternDictionary.Keys)
                {
                    // Initialize Recognizers

                    this.comboBoxPattern.Items.Add(key);
                // So basically, for some reason it's only updating the combo box on the parent form
                }
                // But, if you add an item outside of the loop, it appears on both forms. Weird...
                
            }
        }

        /// <summary>
        /// Overload method for updateComboBox
        /// </summary>
        private void updateComboBox()
        {
            // Pass the bound list of candlesticks into the updateComboBox method
            updateComboBox(boundCandlesticks);
        }


        /// <summary>
        /// Event handler for the combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPattern_SelectedIndexChanged(object sender, EventArgs e) // This is where we will iterate through and check the recognizers
        {
            // Clear the chart of annotations
            chart_OHLCV.Annotations.Clear();

            // Iterate through all the candlesticks
            for (int i = 0; i < boundCandlesticks.Count; i++)
            {
                // Cast to a SmartCandlestick
                SmartCandlestick scs = (SmartCandlestick)boundCandlesticks[i];

                

                // Create a new variable of type DataPoint
                DataPoint dataPoint = chart_OHLCV.Series[0].Points[i];

                // If the candlestick is not null

                if (scs != null)
                {
                    // Create a new arrow of ArrowAnnotation type
                    ArrowAnnotation arrow = new ArrowAnnotation();
                    
                    // Create a new rectangle annotation for multicandlestick patterns
                  

                    // Adjust to axis to that of the chart_OHLCV
                    arrow.AxisX = chart_OHLCV.ChartAreas[0].AxisX;
                    arrow.AxisX = chart_OHLCV.ChartAreas[0].AxisY;


                    // Adjust the width and height of the arrow
                    arrow.Width = 0.5;
                    arrow.Height = 0.5;

                    

                    // if the pattern in the candlestick matches the selected item in the combobox
                    if (scs.patternDictionary[comboBoxPattern.SelectedItem.ToString()])
                    {
                        
                        // anchor the arrow on the candlestick 
                        arrow.SetAnchor(dataPoint);

                        // add a new arrow 
                        chart_OHLCV.Annotations.Add(arrow);
                    }

                }
            }
        }

        private void InitializeRecognizersList(/*List<SmartCandlestick> sc, int index*/)
        {
            //comboBoxPattern.Items.Clear();

            recognizersList = new List<Recognizer>();

            recognizersList.Add(new Recognizer_Bullish());
            recognizersList.Add(new Recognizer_Bearish());
            recognizersList.Add(new Recognizer_Neutral());
            recognizersList.Add(new Recognizer_Marubozu());
            recognizersList.Add(new Recognizer_Hammer());
            recognizersList.Add(new Recognizer_Doji());
            recognizersList.Add(new Recognizer_DragonflyDoji());
            recognizersList.Add(new Recognizer_GravestoneDoji());
            recognizersList.Add(new Recognizer_Engulfing_Bullish());
            recognizersList.Add(new Recognizer_Engulfing_Bearish());
            recognizersList.Add(new Recognizer_Harami_Bullish());
            recognizersList.Add(new Recognizer_Harami_Bearish());
            recognizersList.Add(new Recognizer_Peak());
            recognizersList.Add(new Recognizer_Valley());

            

        }
        
        private void InitializeRecognizers(List<SmartCandlestick> scList)
        {
            for (int i = 0; i < scList.Count; i++)
            {
                
                for (int j = 0; j < recognizersList.Count; j++) 
                { 
                    Recognizer recognizer = recognizersList[j];

                    recognizer.Recognize(scList, i);
                }
                
                // probably add the recognizeAll function here
                
            }
        }














        private void form_stock_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox_StartDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_EndDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_End_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_Start_ValueChanged(object sender, EventArgs e)
        {
        }

        
    }
}
