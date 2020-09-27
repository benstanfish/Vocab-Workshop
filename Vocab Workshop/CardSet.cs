using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Xml.Serialization;

namespace Vocab_Workshop
{
    [Serializable]
    public class CardSet 
    {
        [XmlElement] public string Id { get; set; }
        [XmlElement] public string Title { get; set; }
        [XmlElement] public string Description { get; set; }
        [XmlElement] public readonly List<Card> Cards;

        public CardSet()
        {
            Id = Guid.NewGuid().ToString();
            Cards = new List<Card>();
        }

        public void WriteXml(string savePath)
        {
            var xml = new XmlSerializer(typeof(CardSet));
            using (var writer = new FileStream(savePath, FileMode.OpenOrCreate)) { xml.Serialize(writer, this); }
        }

        public static CardSet ReadXml(string filePath)
        {
            var cardSet = new CardSet();
            var serializer = new XmlSerializer(typeof(CardSet));
            using (var reader = new FileStream(filePath, FileMode.OpenOrCreate)) { cardSet = (CardSet)serializer.Deserialize(reader); }
            return cardSet;
        }

    }



}
