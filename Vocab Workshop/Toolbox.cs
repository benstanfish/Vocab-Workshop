using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Vocab_Workshop
{

    /*
    #region Parsing Methods
    public bool IsKanji(char ch)
    {
        int lb = int.Parse("4E00", System.Globalization.NumberStyles.HexNumber);
        int ub = int.Parse("9FBF", System.Globalization.NumberStyles.HexNumber);
        if ((int)ch >= lb && (int)ch <= ub) { return true; }
        else { return false; }
    }
    public bool IsKana(char ch)
    {
        int lb = int.Parse("3040", System.Globalization.NumberStyles.HexNumber);
        int ub = int.Parse("30FF", System.Globalization.NumberStyles.HexNumber);
        if ((int)ch >= lb && (int)ch <= ub) { return true; }
        else { return false; }
    }
    public bool IsHiragana(char ch)
    {
        int lb = int.Parse("3040", System.Globalization.NumberStyles.HexNumber);
        int ub = int.Parse("309F", System.Globalization.NumberStyles.HexNumber);
        if ((int)ch >= lb && (int)ch <= ub) { return true; }
        else { return false; }
    }
    public bool IsKatakana(char ch)
    {
        int lb = int.Parse("30A0", System.Globalization.NumberStyles.HexNumber);
        int ub = int.Parse("309F", System.Globalization.NumberStyles.HexNumber);
        if ((int)ch >= lb && (int)ch <= ub) { return true; }
        else { return false; }
    }
    public string Kanji(string myString)
    {
        char[] charArr = myString.ToCharArray();
        StringBuilder sb = new StringBuilder();
        foreach (char ch in charArr)
        {
            if (IsKanji(ch) == true) { sb.Append(ch); }
        }
        return sb.ToString();
    }
    public string Furigana(string word, string hiragana)
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
    public string Okurigana(string myString)
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
    public string CheckString(string myString)
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
    */

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



    static class Toolbox
    {
        
    }

    public class AutoIncrement
    {
        private int id = 1;
        public int GenerateId()
        {
            return id++;
        }
    }

    class Entry
    {
        public Guid guid { get; set; } 
        public int setID { get; set; }
        public string word { get; set; }
        public string hiragana { get; set; }
        public string pos { get; set; }
        public List<string> glosses { get; set; }
        public List<string> categories { get; set; }

        public Entry()
        {
        }
        public Entry(string Word)
        {
            Guid g = Guid.NewGuid();
            guid = g;
            word = Word;
            hiragana = Word;
        }
        public Entry(string Word, string Hiragana, string POS)
        {
            Guid g = Guid.NewGuid();
            guid = g;
            word = Word;
            hiragana = Hiragana;
            pos = POS;
        }

        public Entry(string Word, string Hiragana, List<string> Glosses, List<string> Categories)
        {
            Guid g = Guid.NewGuid();
            guid = g;
            word = Word;
            hiragana = Hiragana;
            glosses = Glosses;
            categories = Categories;
        }
    }


    
    
}
