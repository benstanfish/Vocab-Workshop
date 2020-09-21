using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Workshop
{
    public static class Extensions
    {
        private static System.Random rng = new System.Random();

        // Shuffles the order in which the Cards are popped from the list
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // Reverses the order in which the Cards are popped from the list
        public static void Reverse<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = list.Count - n;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void WriteToXML(IStream stream)
        {

        }


    }
}
