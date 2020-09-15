using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Workshop
{
    public class Card
    {
        public int Id;
        public string Word;
        public string Hint;
        public string Meaning;
    }

    public class CardStack
    {
        public int Id;
        public string Title;
        public string ShortTitle;
        public readonly List<Card> card = new List<Card>();
        public readonly List<TopicRing> topic = new List<TopicRing>();
    }

    public class TopicRing
    {
        public string topic;
    }


}
