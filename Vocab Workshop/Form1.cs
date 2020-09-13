using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Drawing.Drawing2D;

namespace Vocab_Workshop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Toolbox tb = new Toolbox();

        }

        #region Production Methods
        public static bool IsKanji(char ch)
        {
            int lb = int.Parse("4E00", System.Globalization.NumberStyles.HexNumber);
            int ub = int.Parse("9FBF", System.Globalization.NumberStyles.HexNumber);
            if ((int)ch >= lb && (int)ch <= ub) { return true; }
            else { return false; }
        }
        public static bool IsKana(char ch)
        {
            int lb = int.Parse("3040", System.Globalization.NumberStyles.HexNumber);
            int ub = int.Parse("30FF", System.Globalization.NumberStyles.HexNumber);
            if ((int)ch >= lb && (int)ch <= ub) { return true; }
            else { return false; }
        }
        public static bool IsHiragana(char ch)
        {
            int lb = int.Parse("3040", System.Globalization.NumberStyles.HexNumber);
            int ub = int.Parse("309F", System.Globalization.NumberStyles.HexNumber);
            if ((int)ch >= lb && (int)ch <= ub) { return true; }
            else { return false; }
        }
        public static bool IsKatakana(char ch)
        {
            int lb = int.Parse("30A0", System.Globalization.NumberStyles.HexNumber);
            int ub = int.Parse("309F", System.Globalization.NumberStyles.HexNumber);
            if ((int)ch >= lb && (int)ch <= ub) { return true; }
            else { return false; }
        }
        public static string Kanji(string myString)
        {
            char[] charArr = myString.ToCharArray();
            StringBuilder sb = new StringBuilder();
            foreach (char ch in charArr)
            {
                if (IsKanji(ch) == true) { sb.Append(ch); }
            }
            return sb.ToString();
        }
        public static string Furigana(string word, string hiragana)
        {
            // .... UNDER DEVELOPMENT
            char[] wordArr = word.ToCharArray();
            char[] hiraganaArr = hiragana.ToCharArray();
            StringBuilder sb = new StringBuilder();
            foreach (char ch in wordArr)
            {
                if (IsKanji(ch) == true) { sb.Append(ch); }
            }
            return sb.ToString();
        }
        public static string Okurigana(string myString)
        {
            char[] charArr = myString.ToCharArray();
            StringBuilder sb = new StringBuilder();
            foreach (char ch in charArr)
            {
                if (IsKanji(ch) == false) { sb.Append(ch); }
            }
            return sb.ToString();
        }


        #endregion

        #region Test Functions
        public static string CheckString(string myString)
        {
            char[] charArr = myString.ToCharArray();
            bool[] boolArr = new bool[myString.Length];
            int i = 0;
            foreach (char ch in charArr)
            {
                boolArr[i] = IsKanji(ch);
                i++;
            }
            string myText = String.Join(", ", boolArr);
            return myText;
        }



        #endregion

        #region JSON Test
        //var ai = new AutoIncrement();
        //List<string> Glosses = new List<string>
        //{
        //    "to collect",
        //    "to safekeep",
        //    "to hold for someone"
        //};

        //List<string> Categories = new List<string>
        //{
        //    "actions",
        //    "intent"
        //};

        //Entry w = new Entry("預かる", "あずかる", Glosses, Categories);
        //w.pos = "動五";
        //w.setID = ai.GenerateId();


        //List<string> Glosses2 = new List<string>
        //{
        //    "to collect",
        //    "to safekeep"
        //};

        //List<string> Categories2 = new List<string>
        //{
        //    "actions"
        //};

        //Entry x = new Entry("預ける", "あずける", Glosses2, Categories2);
        //x.pos = "動下";
        //x.setID = ai.GenerateId();

        ////string jsonString;
        ////jsonString = JsonSerializer.Serialize(w);
        //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //string fileName = filePath + @"\test.json";
        ////File.WriteAllText(fileName, jsonString);

        //string jsonString2;
        //var options = new JsonSerializerOptions
        //{
        //    WriteIndented = true
        //};
        //jsonString2 = JsonSerializer.Serialize(w, options);
        //jsonString2 = jsonString2 + "\n\r" + JsonSerializer.Serialize(x, options);

        //string fileName2 = filePath + @"\test2.json";
        //File.WriteAllText(fileName2, jsonString2);


        ////Entry z;
        ////String jsonString3 = File.ReadAllText(fileName2);
        ////z = JsonSerializer.Deserialize<Entry>(jsonString3);
        ////Console.WriteLine(z.guid + ", " + z.word + ", " + z.hiragana);

        #endregion
    }
}
