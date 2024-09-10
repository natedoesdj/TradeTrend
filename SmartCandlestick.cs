using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    /// <summary>
    /// SmartCandlestick class. Inherits Candlestick
    /// ComputeExtraProperties calculates range, bodyRange, topPrice, bottomPrice, upperTail and lowerTail
    /// ComputeExtraPatterns calculates candlestick patterns bullish, bearish, neutral, marubozu, hammer, doji, dragonflydoji, gravestonedoji
    /// </summary>
    internal class SmartCandlestick : Candlestick
    {
        // Initialization of the SmartCandlestick properties
        public decimal range { get; set; }
        public decimal bodyRange { get; set; }
        public decimal topPrice { get; set; }
        public decimal bottomPrice { get; set; }
        public decimal upperTail { get; set; }
        public decimal lowerTail { get; set; }

        // Create a dictionary, patternDictionary, which will store the candlesticks patterns in a dictionary.
        public Dictionary<string, bool> patternDictionary = new Dictionary<string, bool>();

        /// <summary>
        /// Constructor for SmartCandlestick
        /// </summary>
        /// <param name="rowOfData">Takes the row of CSV data</param>
        public SmartCandlestick(string rowOfData) : base(rowOfData)
        {
            // Call ComputeExtraProperties to calculate range, bodyRange, etc.
            ComputeExtraProperties();

            // Call ComputeExtraPatterns to calculate the bullish, bearish, etc.
            //ComputeExtraPatterns();
        }

        /// <summary>
        /// Constructor for SmartCandlestick
        /// </summary>
        /// <param name="cs">Takes an object of type Candlestick as an input</param>
        public SmartCandlestick(Candlestick cs)
        {
            // Access the properties of the Candlestick and assign it to the SmartCandlestick
            date = cs.date;
            open = cs.open;
            close = cs.close;
            high = cs.high;
            low = cs.low;
            volume = cs.volume;

            // Call ComputeExtraProperties to calculate range, bodyRange, etc.
            ComputeExtraProperties();

            // Call ComputeExtraPatterns to calculate the bullish, bearish, etc.
            //ComputeExtraPatterns();
        }

        /// <summary>
        /// Method to calculate the extra properties range, topPrice, etc.
        /// </summary>
        public void ComputeExtraProperties()
        {
            range = high - low;
            topPrice = Math.Max(open, close);
            bottomPrice = Math.Min(open, close);
            bodyRange = topPrice - bottomPrice;
            upperTail = high - topPrice;
            lowerTail = bottomPrice - low;
        }

        /// <summary>
        /// Helper method for patternDictionary. Adds a key and value to the dictionary.
        /// </summary>
        /// <param name="patternName">Takes a string for the name of the pattern</param>
        /// <param name="isPresent">Takes a bool for whether the candlestick has the pattern</param>
        public void AddPattern(string patternName, bool isPresent)
        {
            // Adds the key and value to the dictionary
            patternDictionary.Add(patternName, isPresent);
            
        }

        // TODO: DELETE COMPUTEEXTRAPATTERNS
        /// <summary>
        /// Method to calculate the candlestick patterns
        /// </summary>
        public void ComputeExtraPatterns()
        {
            /*
            // Clears the dictionary.
            patternDictionary.Clear();

            // Calculate bullish
            bool isBullish()
            {
               return close > open;
            }

            // Add to dictionary
            AddPattern("Bullish", isBullish());

            // Calculate bearish
            bool isBearish()
            {
                return close < open;
            }

            // Add to dictionary
            AddPattern("Bearish", isBearish());

            // Calculate neutral
            bool isNeutral()
            {
                return close == open;
            }

            // Add to dictionary
            AddPattern("Neutral", isNeutral());

            // Calculate marubozu
            bool isMarubozu()
            {
                return bodyRange >= (range * 0.8m) && upperTail < 0.1m && lowerTail < 0.1m;
            }

            // Add to dictionary
            AddPattern("Marubozu", isMarubozu());

            // Calculate hammer
            bool isHammer()
            {
                return bodyRange < range * 0.1m && lowerTail >= bodyRange * 2 && topPrice == high;
            }

            // Add to dictionary
            AddPattern("Hammer", isHammer());

            // Calculate doji
            bool isDoji()
            {
                return bodyRange < range * 0.1m;
            }

            // Add to dictionary
            AddPattern("Doji", isDoji());

            // Calculate dragonflydoji
            bool isDragonflyDoji()
            {
                return isDoji() && lowerTail > (2 * bodyRange) && upperTail < (0.01m * bodyRange);
            }

            // add to dictionary
            AddPattern("DragonflyDoji", isDragonflyDoji());

            // Calculate gravestone doji
            bool isGravestoneDoji()
            {
                return isDoji() && upperTail > (2 * bodyRange) && lowerTail < (0.01m * bodyRange);
            }

            // add to dictionary
            AddPattern("GravestoneDoji", isGravestoneDoji());
            */
        }

    }
}
