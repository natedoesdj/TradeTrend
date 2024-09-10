using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    internal class Recognizer_DragonflyDoji : Recognizer
    {
        public Recognizer_DragonflyDoji() : base("DragonflyDoji", 1) { }

        public override bool Recognize(List<SmartCandlestick> sc, int index)
        {
            bool result = (sc[index].bodyRange < sc[index].range * 0.1m) && sc[index].lowerTail > (2 * sc[index].bodyRange) && sc[index].upperTail < (0.01m * sc[index].bodyRange);

            sc[index].patternDictionary.Add(patternName, result);

            return result;
        }

    }
}
