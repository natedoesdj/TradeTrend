using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    internal class Recognizer_Peak : Recognizer
    {
        // Might have to change the parameter index
        public Recognizer_Peak() : base("Peak", 3)  { }

        public override bool Recognize(List<SmartCandlestick> sc, int index)
        {
            if(index > 0 && index < sc.Count - 1) 
            {
                decimal previousHigh = sc[index - 1].high;
                decimal currentHigh = sc[index].high;
                decimal nextHigh = sc[index + 1].high;

                bool result = (previousHigh < currentHigh) && (currentHigh > nextHigh);

                sc[index].patternDictionary.Add(patternName, result);

                return result;
            }
            sc[index].patternDictionary.Add(patternName, false);

            return false;
        }
    }
}
