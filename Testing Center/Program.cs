using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Testing_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("預かる");
            ReturnKanji();

        }

        public static void ReturnKanji()
        {
            string myText = "預かる";
            char[] charArr = myText.ToCharArray();
            int lb = int.Parse("4E00", System.Globalization.NumberStyles.HexNumber);
            int ub = int.Parse("9FBF", System.Globalization.NumberStyles.HexNumber);
            foreach (char ch in charArr)
            {
                //Console.WriteLine(ch.ToString());
                //Console.WriteLine(ch.ToString().GetHashCode());
                //Console.WriteLine("{0:x4} ", (int)ch);
                
                

            }
        }

        public static bool IsKanji(char ch)
        {
            int lb = int.Parse("4E00", System.Globalization.NumberStyles.HexNumber);
            int ub = int.Parse("9FBF", System.Globalization.NumberStyles.HexNumber);
            if ((int)ch >= lb && (int)ch <= ub)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
   
}
