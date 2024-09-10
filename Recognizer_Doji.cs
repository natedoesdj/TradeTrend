using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    internal class Recognizer_Doji : Recognizer
    {
        public Recognizer_Doji() : base("Doji", 1) { }

        public override bool Recognize(List<SmartCandlestick> sc, int index)
        {
            bool result = sc[index].bodyRange < sc[index].range * 0.1m;

            sc[index].patternDictionary.Add(patternName, result);

            return result;
        }
    }
}
