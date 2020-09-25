using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Testing_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;

            //string a = "\u263A";
            //Console.WriteLine(a);
            //Console.WriteLine("預かる");
            //ReturnKanji();

            //Console.WriteLine("Input a word in Japanese: ");
            //string myString = Console.ReadLine();
            //CheckString(myString);

            Flashcard Card = new Flashcard();
            Card.Question = "Here is a question";
            Card.Hint = "Here's a hint";
            Card.Answer = "Answer";
            Card.ImagePath = @"\\servershare\folder\";
            List<string> list = Card.Sides();

            Console.WriteLine(Card.GetId());
            Console.WriteLine(list.Count + " elements");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Element {0}: is {1}", i, list[i]);
            }
            
        }



        public class Flashcard
        {
            private Guid _guid = Guid.NewGuid();
            public string Question { get; set; }
            public string Hint { get; set; }
            public string Answer { get; set; }
            public string ImagePath { get; set; }

            public List<string> Sides()
            {
                var sides = new List<string>();
                if (Question != string.Empty)
                    sides.Add(Question);
                if (Hint != string.Empty)
                    sides.Add(Hint);
                if (Answer != string.Empty)
                    sides.Add(Answer);
                if (ImagePath != string.Empty)
                    sides.Add(ImagePath);
                return sides;
            }

            public override string ToString()
            {
                return Question;
            }

            public void SetId(string tryGuid)
            {
                if (Guid.TryParse(tryGuid, out Guid tempGuid))
                    _guid = tempGuid;
            }
            public void SetId(Guid guid)
            {
                _guid = guid;
            }
            public Guid GetId()
            {
                return _guid;
            }

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
