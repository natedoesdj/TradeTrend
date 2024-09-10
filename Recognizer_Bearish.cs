using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    internal class Recognizer_Bearish : Recognizer
    {
        public Recognizer_Bearish() : base("Bearish", 1) { }

        /// <summary>
        /// Override method for Recognize
        /// </summary>
        /// <param name="sc">Takes a list of smart candlesticks</param>
        /// <param name="index">Specific candlestick in the list</param>
        /// <returns></returns>
        public override bool Recognize(List<SmartCandlestick> sc, int index)
        {
            bool result = sc[index].close < sc[index].open;

            sc[index].patternDictionary.Add(patternName, result);

            return result;
        }
    }
}
