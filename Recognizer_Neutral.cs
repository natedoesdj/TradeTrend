using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    internal class Recognizer_Neutral : Recognizer
    {
        public Recognizer_Neutral() : base("Neutral", 1) { }

        public override bool Recognize(List<SmartCandlestick> sc, int index)
        {
            bool result = sc[index].open == sc[index].close;

            sc[index].patternDictionary.Add(patternName, result);

            return result;
        }
    }
}
