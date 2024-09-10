using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    internal class Recognizer_Bullish : Recognizer
    {
        /// <summary>
        /// Constructor for Recognizer Bullish
        /// </summary>
        /// <param name="pN">Name of the pattern</param>
        /// <param name="pL">Length of candlesticks</param>
        public Recognizer_Bullish() : base("Bullish", 1)
        {

        }

        public override bool Recognize(List<SmartCandlestick> sc, int index)
        {
            bool result = sc[index].close > sc[index].open;
            sc[index].patternDictionary.Add(patternName, result);
            return result;
        }

        
    }
}
