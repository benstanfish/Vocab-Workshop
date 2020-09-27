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
    [DataContract]
    public class Card
    {
        [DataMember (Name = "Id", Order = 0)] private Guid _id { get; set; }
        [DataMember (Name = "Side", IsRequired = false, Order = 1)] public readonly List<string> Sides;

        public Card()
        {
            _id = Guid.NewGuid();
            Sides = new List<string>();
        }

        public override string ToString() { return Sides[0]; }
        public void SetId(string tryGuid) { if (Guid.TryParse(tryGuid, out Guid tempGuid)) { _id = tempGuid; } }
        public Guid GetId() { return _id; }
        public void SetId(Guid guid) { _id = guid; }

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

        public void WriteDCXml(string savePath)
        {
            var xml = new DataContractSerializer(typeof(Card));
            using (var writer = new FileStream(savePath, FileMode.OpenOrCreate)) { xml.WriteObject(writer, this); }
        }

        public static Card ReadDCXml(string filePath)
        {
            Card card;
            var serializer = new DataContractSerializer(typeof(Card));
            using (var reader = new FileStream(filePath, FileMode.Open)) { card = (Card)serializer.ReadObject(reader); }
            return card;
        }


    }
}
