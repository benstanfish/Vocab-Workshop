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

            

            Flashcard card = new Flashcard() { Question = "Question", Hint = "Hint", Answer = "Answer", ImagePath = @"\\servershare\folder\" };
            List<string> list = card.Sides();
            Console.WriteLine(card.GetId());
            Console.WriteLine(list.Count + " elements");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Element {0}: is {1}", i, list[i]);
            }

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\text3.xml";
            card.WriteXml(savePath);

            var newCard = Flashcard.ReadXml(savePath);
            Console.WriteLine(newCard);

            string stackSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\text4.xml";

            FlashcardSet set = new FlashcardSet();
            set.Cards.Add(new Flashcard() { Question = "Question1", Hint = "Hint1", Answer = "Answer1", ImagePath = @"\\servershare\folder\1" });
            set.Cards.Add(new Flashcard() { Question = "Question2", Hint = "Hint2", Answer = "Answer2", ImagePath = @"\\servershare\folder\2" });
            set.Cards.Add(new Flashcard() { Question = "Question3", Hint = "Hint3", Answer = "Answer3", ImagePath = @"\\servershare\folder\3" });

            set.WriteXml(stackSavePath);

            var newSet = FlashcardSet.ReadXml(stackSavePath);

            foreach (Flashcard flashcard in newSet.Cards)
            {
                string printStr = string.Empty;
                List<string> sides = flashcard.Sides();
                for (int i = 0; i < sides.Count - 1; i++)
                {
                    printStr += sides[i] + ", ";
                }
                printStr += sides[sides.Count - 1];
                Console.WriteLine(printStr);
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
