using System;
using System.Reflection.Metadata.Ecma335;

namespace Testing_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            string a = "\u263A";
            Console.WriteLine(a);
            Console.WriteLine("預かる");
            ReturnKanji();

            Console.WriteLine("Input a word in Japanese: ");
            string myString = Console.ReadLine();
            CheckString(myString);

        }

        public static void ReturnKanji()
        {
            string myText = "預かる";
            char[] charArr = myText.ToCharArray();
            foreach (char ch in charArr)
            {
                //Console.WriteLine(ch.ToString());
                //Console.WriteLine(ch.ToString().GetHashCode());
                //Console.WriteLine("{0:x4} ", (int)ch);

                Console.WriteLine("Character is kanji: " + IsKanji(ch));
            }
        }

        public static void CheckString(string myString)
        {
            char[] charArr = myString.ToCharArray();
            foreach (char ch in charArr)
            {
                Console.WriteLine(ch + ": " + IsKanji(ch));
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
