using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project1__C__
{
    internal abstract class Recognizer
    {
        public string patternName;
        public int patternLength;


        public abstract bool Recognize(List<SmartCandlestick> sc, int index);

        public void RecognizeAll(List<SmartCandlestick> sc)
        {
            for (int index = 0; index < sc.Count; index++)
            {
                Recognize(sc, index);
            }
        }

        public Recognizer(string pN, int pL)
        {
            patternName = pN;
            patternLength = pL;
        }
    }
}
