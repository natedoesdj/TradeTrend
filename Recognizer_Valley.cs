using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    internal class Recognizer_Valley : Recognizer
    {
        public Recognizer_Valley() : base("Valley", 3) { }

        public override bool Recognize(List<SmartCandlestick> sc, int index)
        {
            if (index > 0 && index < sc.Count - 1)
            {
                decimal previousLow = sc[index - 1].low;
                decimal nextLow = sc[index + 1].low;
                decimal currentLow = sc[index].low;

                bool result = (currentLow < previousLow) && (currentLow < nextLow);

                sc[index].patternDictionary.Add(patternName, result);

                return result;
            }
            sc[index].patternDictionary.Add(patternName, false);

            return false;
        }
    }
}
