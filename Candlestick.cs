using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    /// <summary>
    /// Candlestick class. Has date, open, high, low, close, adj close, and volume as members
    /// </summary>
    internal class Candlestick
    {
        // Use getters and setters to initialize candlestick variables
        // The candlestick class will have date, open, high, low, close, adj close, and volume.
        public DateTime date { get; set; }
        public decimal open { get; set; }
        public decimal high { get; set; } 
        public decimal low { get; set; }
        public decimal close { get; set; }
        public decimal adj_close { get; set; }
        public ulong volume { get; set; }

        public Candlestick() { }

        /// <summary>
        /// Candlestick class.
        /// </summary>
        /// <param name="rowOfData">Takes a row of data from a csv file as a parameter</param>
        public Candlestick(string rowOfData)
        {
            // Initialize delimeters and splits the row of data
            char[] separators = new char[] { ',', ' ', '"' };
            string[] subs = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Get the date to parse it
            string dateString = subs[0];

            //Parse the date
            date = DateTime.Parse(dateString);

            // Create a temporary variable use to test parsing
            // If the parse is successful, it stores the data
            decimal temp;
            // Parse for open
            bool success = decimal.TryParse(subs[1], out temp);
            if (success) { open = temp; }
            
            // Parse for high
            success = decimal.TryParse(subs[2], out temp);
            if (success) { high = temp; }
            
            // Parse for low
            success = decimal.TryParse(subs[3], out temp);
            if (success) { low = temp; }
            
            // Parse for close
            success = decimal.TryParse(subs[4], out temp);
            if (success) { close = temp; }
            
            // Parse for adj close
            success = decimal.TryParse(subs[5], out temp);
            if (success) { adj_close = temp; }
            
            // ulong for volume since it can be a very large number
            ulong tempVolume;

            // Parse for volume
            success = ulong.TryParse(subs[6], out tempVolume);
            if (success) { volume = tempVolume; }
        }

        
    }
}
