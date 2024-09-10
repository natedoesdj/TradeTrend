using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    internal class Recognizer_Engulfing_Bullish : Recognizer
    {
        public Recognizer_Engulfing_Bullish() : base("Engulfing(Bullish)", 2) { }

        public override bool Recognize(List<SmartCandlestick> sc, int index)
        {
            if (index < sc.Count - 1)
            {
                // Checks if the first candlestick is bearish
                bool result1 = sc[index].close < sc[index].open;

                // Checks if the second candlestick is bullish
                bool result2 = sc[index + 1].close > sc[index + 1].open;

                // If both are true and the second candlestick's body range is larger
                bool result = result1 && result2 && sc[index].bodyRange < sc[index + 1].bodyRange;

                // Add the pattern to the dictionary
                sc[index].patternDictionary.Add(patternName, result);
            
                return result;
            }
            sc[index].patternDictionary.Add(patternName, false);

            return false;
        }
    }
}
