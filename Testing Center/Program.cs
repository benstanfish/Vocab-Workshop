using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.ExceptionServices;
using Microsoft.VisualBasic;
using Vocab_Workshop;


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



            //Flashcard card = new Flashcard() { Question = "Question", Hint = "Hint", Answer = "Answer", ImagePath = @"\\servershare\folder\" };
            //List<string> list = card.Sides();
            //Console.WriteLine(card.GetId());
            //Console.WriteLine(list.Count + " elements");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine("Element {0}: is {1}", i, list[i]);
            //}

            //string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\text3.xml";
            //card.WriteXml(savePath);

            //var newCard = Flashcard.ReadXml(savePath);
            //Console.WriteLine(newCard);

            //string stackSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\text4.xml";

            //FlashcardSet set = new FlashcardSet();
            //set.Cards.Add(new Flashcard() { Question = "Question1", Hint = "Hint1", Answer = "Answer1", ImagePath = @"\\servershare\folder\1" });
            //set.Cards.Add(new Flashcard() { Question = "Question2", Hint = "Hint2", Answer = "Answer2", ImagePath = @"\\servershare\folder\2" });
            //set.Cards.Add(new Flashcard() { Question = "Question3", Hint = "Hint3", Answer = "Answer3", ImagePath = @"\\servershare\folder\3" });

            //set.WriteXml(stackSavePath);


            //var newSet = FlashcardSet.ReadXml(stackSavePath);
            //newSet.Title = "Text new set";
            //newSet.Description = "Here is a description";


            //foreach (Flashcard flashcard in newSet.Cards)
            //{
            //    string printStr = string.Empty;
            //    List<string> sides = flashcard.Sides();
            //    for (int i = 0; i < sides.Count; i++)
            //    {
            //        printStr += sides[i] + ", ";
            //    }
            //    printStr += flashcard.GetId();
            //    Console.WriteLine(printStr);
            //}

            //string newUserPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\NewUser.xml";
            //UserProfile profile = new UserProfile("benstanfish");
            //profile.WriteXml(newUserPath);


            //UserProfile.RepairXml(newUserPath);
            //var user = UserProfile.ReadXml(newUserPath);

            //var fakeUser = new UserProfile("");
            //user.SignIn(newUserPath);

            //Console.WriteLine(user.UserName + " is valid: " + user.UserExists());
            //Console.WriteLine(fakeUser.UserName + " is valid: " + fakeUser.UserExists());

            //Console.WriteLine();
            //Console.WriteLine("Username: " + user.UserName);
            //Console.WriteLine("GuiD: " + user.GetId().ToString());
            //Console.WriteLine("Created on " + user.DateCreated().ToString());
            //Console.WriteLine("Signed in on: ");
            //foreach (DateTime dateTime in user.Sessions)
            //{
            //    Console.WriteLine(dateTime.ToString());
            //}

            //user.UpdateUsername("Benstanfish");
            //Console.WriteLine(user.UserName.ToString());

            //string newCardPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\NewCard.xml";
            //var newCard = new Card()
            //{
            //    Sides = {"list", "two", "more", "merry"}
            //};

            //newCard.WriteXml(newCardPath);

            //Console.WriteLine("Write Guid = " + newCard.ID);


            //var newerCard = Card.ReadXml(newCardPath);
            //for (int i = 0; i < newerCard.Sides.Count; i++)
            //{
            //    Console.WriteLine("Side {0}: {1}", i, newerCard.Sides[i]);
            //}
            //Console.WriteLine("Write Guid = " + newerCard.ID);

            string NewCardsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\NewCards.xml";
            //var cardSet = new CardSet()
            //{
            //    Title = "This is the Title",
            //    Description = "There's no description right now",
            //    Id = Guid.NewGuid().ToString(),
            //    Cards =
            //    {
            //        new Card(new List<string>(){ "here1", "there1", "everywhere1" }),
            //        new Card(new List<string>(){ "here2", "there2", "everywhere2" }),
            //        new Card(new List<string>(){ "here3", "there3", "everywhere3" })
            //    }
            //};

            //cardSet.WriteXml(NewCardsPath);
            var newSet = CardSet.ReadXml(NewCardsPath);
            foreach (Card card in newSet.Cards)
            {
                Console.WriteLine(card.Sides[0]);
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
