using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Vocab_Workshop
{
    [Serializable]
    public class Card
    {
        public Guid Id { get; set; }
        public readonly List<string> Sides;

        public Card()
        {
            Id = Guid.NewGuid();
            Sides = new List<string>();
        }

        public override string ToString() { return Sides[0]; }
        public void SetId(string tryGuid) { if (Guid.TryParse(tryGuid, out Guid tempGuid)) { Id = tempGuid; } }
        public Guid GetId() { return Id; }
        public void SetId(Guid guid) { Id = guid; }

        public void WriteXml(string savePath)
        {
            var xml = new XmlSerializer(typeof(Card));
            using (var writer = new FileStream(savePath, FileMode.OpenOrCreate)) { xml.Serialize(writer, this); }
        }

        public static Card ReadXml(string filePath)
        {
            Card card;
            var serializer = new XmlSerializer(typeof(Card));
            using (var reader = new FileStream(filePath, FileMode.Open)) { card = (Card)serializer.Deserialize(reader); }
            return card;
        }

    }
}
