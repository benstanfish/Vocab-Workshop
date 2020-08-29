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

namespace Vocab_Workshop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var ai = new AutoIncrement();
            List<string> Glosses = new List<string>
            {
                "to collect",
                "to safekeep",
                "to hold for someone"
            };

            List<string> Categories = new List<string>
            {
                "actions",
                "intent"
            };

            Entry w = new Entry("預かる", "あずかる", Glosses, Categories);
            w.pos = "動五";
            w.setID = ai.GenerateId();


            List<string> Glosses2 = new List<string>
            {
                "to collect",
                "to safekeep"
            };

            List<string> Categories2 = new List<string>
            {
                "actions"
            };

            Entry x = new Entry("預ける", "あずける", Glosses2, Categories2);
            x.pos = "動下";
            x.setID = ai.GenerateId();





            //string jsonString;
            //jsonString = JsonSerializer.Serialize(w);
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = filePath + @"\test.json";
            //File.WriteAllText(fileName, jsonString);

            string jsonString2;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString2 = JsonSerializer.Serialize(w, options);
            jsonString2 = jsonString2 + "\n\r" + JsonSerializer.Serialize(x, options);

            string fileName2 = filePath + @"\test2.json";
            File.WriteAllText(fileName2, jsonString2);


            //Entry z;
            //String jsonString3 = File.ReadAllText(fileName2);
            //z = JsonSerializer.Deserialize<Entry>(jsonString3);
            //Console.WriteLine(z.guid + ", " + z.word + ", " + z.hiragana);



        }


    }
}
