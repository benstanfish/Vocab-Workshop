using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms.VisualStyles;


namespace Vocab_Workshop
{

    [Serializable]
    public class Card
    {
        [XmlElement] public string Id { get; set; }
        [XmlElement] public string Front { get; set; }
        [XmlElement] public string Hint { get; set; }
        [XmlElement] public string Back { get; set; }
        [XmlElement] public string ImagePath { get; set; }

        public Card()
        {
            Id = Guid.NewGuid().ToString();
        }
        public override string ToString() { return Front; }

        public void WriteXml(string savePath)
        {
            var xml = new XmlSerializer(typeof(Card));
            using (var writer = new FileStream(savePath, FileMode.OpenOrCreate)) { xml.Serialize(writer, this); }
        }

        [XmlIgnore]
        [JsonIgnore]
        // This is a property used internal to the program. It does not need to be serialized.
        public List<string> Sides
        {
            get
            {
                List<string> sides = new List<string>();
                sides.Add(Front);
                if (Hint == string.Empty)
                {
                    sides.Add(Front);
                }
                else
                {
                    sides.Add(Hint);
                }
                sides.Add(Back);
                if (ImagePath != string.Empty && File.Exists(ImagePath))
                {
                    sides.Add(ImagePath);
                }
                return sides;
            }
        }

        public static Card ReadXml(string filePath)
        {
            Card card = new Card();
            var serializer = new XmlSerializer(typeof(Card));
            using (var reader = new FileStream(filePath, FileMode.Open)) { card = (Card)serializer.Deserialize(reader); }
            return card;
        }

        public void WriteJson(string savePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(this, this.GetType(), options);
            File.WriteAllText(savePath, jsonString);
        }

        public static Card ReadJson(string filePath)
        {
            Card card = new Card();
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                card = JsonSerializer.Deserialize<Card>(jsonString);
            }
            return card;
        }

        public void WriteTsv(string savePath)
        {
            string temp = this.Front + "\t" + this.Hint + "\t" + this.Back + "\t" + this.ImagePath + "\t" + this.Id;
            File.WriteAllText(savePath, temp);
        }

        public static Card ReadTsv(string tsvString)
        {
            var card = new Card();
            string[] temp = tsvString.Split('\t');
            switch (temp.Length)
            {
                case 2:
                    card.Front = temp[0];
                    card.Back = temp[1];
                    break;
                case 3:
                    card.Front = temp[0];
                    card.Hint = temp[1];
                    card.Back = temp[2];
                    break;
                case 4:
                    card.Front = temp[0];
                    card.Hint = temp[1];
                    card.Back = temp[2];
                    if (Guid.TryParse(temp[4], out var newGuid))
                    {
                        card.Id = newGuid.ToString();
                    }
                    else if (File.Exists(temp[3]))
                    {
                        card.ImagePath = temp[3];
                    }
                    break;
                default:
                    break;
            }
            return card;
        }
    }


}
