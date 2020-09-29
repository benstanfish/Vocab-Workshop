using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
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
        public CardSet(Card card) : this()
        {
            Cards.Add(card);
        }
        public CardSet(List<Card> cards)
        {
            Cards = cards;
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
            using (var reader = new FileStream(filePath, FileMode.Open)) { cardSet = (CardSet)serializer.Deserialize(reader); }
            return cardSet;
        }

        public static CardSet ReadTsv(string filePath)
        {
            var cardSet = new CardSet();
            using (var reader = new StreamReader(filePath))
            {
                char[] delim = new char[] { '\t' };
                while (!reader.EndOfStream)
                {
                    string[] entries = reader.ReadLine()?.Split(delim);
                    var card = new Card();
                    foreach (string entry in entries)
                    {
                        card.Sides.Add(entry);
                    }
                    cardSet.Cards.Add(card);
                }
            }
            return cardSet;
        }


        


    }



}
