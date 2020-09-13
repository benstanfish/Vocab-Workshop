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
