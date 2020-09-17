using System.Collections.Generic;

namespace Vocab_Workshop
{
    public class CardRing
    {
        /// <summary>
        /// The CardRing is a collection of one or more cards.
        /// </summary>
        
        public int Id;
        public string Title;
        public string ShortTitle;
        public readonly List<Card> cards = new List<Card>();

    }



}
