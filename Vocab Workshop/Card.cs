using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vocab_Workshop
{

    [Serializable]
    public class Card
    {
        [XmlElement] public string Id { get; set; }
        [XmlElement] public readonly List<string> Sides;

        public Card()
        {
            Id = Guid.NewGuid().ToString();
            Sides = new List<string>();
        }

        public Card(List<string> sides) : this()
        {
            Sides = sides;
        }

        public override string ToString() { return Sides[0].ToString(); }

        public void WriteXml(string savePath)
        {
            var xml = new XmlSerializer(typeof(Card));
            using (var writer = new FileStream(savePath, FileMode.OpenOrCreate)) { xml.Serialize(writer, this); }
        }

        public static Card ReadXml(string filePath)
        {
            Card card = new Card();
            var serializer = new XmlSerializer(typeof(Card));
            using (var reader = new FileStream(filePath, FileMode.Open)) { card = (Card)serializer.Deserialize(reader); }
            return card;
        }

    }


}
