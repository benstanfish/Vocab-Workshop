using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.Json;
using System.Threading;

namespace Vocab_Workshop
{
    [Serializable]
    public class CardSet 
    {
        [XmlElement] public string Id { get; set; }
        [XmlElement] public string Title { get; set; }
        [XmlElement] public string Description { get; set; }
        [XmlElement] public string Created { get; set; }
        [XmlElement] public List<Card> Cards { get; set; }

        public CardSet()
        {
            Id = Guid.NewGuid().ToString();
            Cards = new List<Card>();
            Created = DateTime.Now.ToString();
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

        public void WriteJson(string savePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(this, this.GetType(), options);
            File.WriteAllText(savePath, jsonString);
        }

        public static CardSet ReadJson(string filePath)
        {
            CardSet cardSet = new CardSet();
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                cardSet = JsonSerializer.Deserialize<CardSet>(jsonString);
            }
            return cardSet;
        }

        public static bool IsXmlFile(string filePath)
        {
            string text = "";
            if (File.Exists(filePath))
            {
                text = File.ReadAllText(filePath).Trim();
                
            }
            return text.StartsWith("<") && text.EndsWith(">");
        }

        public static bool IsJsonFile(string filePath)
        {
            string text = "";
            if (File.Exists(filePath))
            {
                text = File.ReadAllText(filePath).Trim();
            }
            return text.StartsWith("{") && text.EndsWith("}");
        }
        public static CardSet Read(string filePath)
        {
            CardSet cardSet = new CardSet();
            if (IsXmlFile(filePath) == true)
            {
                cardSet = CardSet.ReadXml(filePath);
            }
            else if (IsJsonFile(filePath) == true)
            {
                cardSet = CardSet.ReadJson(filePath);
            }
            else
            {
                cardSet = null;
            }

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
                    string[] temp = reader.ReadLine()?.Split(delim);
                    var card = new Card();
                    if (temp.Length == 1)
                    {
                        card.Front = temp[0];
                    }
                    if (temp.Length == 2)
                    {
                        card.Front = temp[0];
                        card.Back = temp[1];
                    }
                    if (temp.Length == 3)
                    {
                        card.Front = temp[0];
                        card.Hint = temp[1];
                        card.Back = temp[2];
                    }
                    if (temp.Length == 4)
                    {
                        card.Front = temp[0];
                        card.Hint = temp[1];
                        card.Back = temp[2];
                        card.ImagePath = temp[3];
                    }
                    if (temp.Length >= 5)
                    {
                        card.Front = temp[0];
                        card.Hint = temp[1];
                        card.Back = temp[2];
                        card.ImagePath = temp[3];
                        card.Id = temp[4];
                    }
                    cardSet.Cards.Add(card);
                }
            }
            return cardSet;
        }
    }



}
