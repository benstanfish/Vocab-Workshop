using System;
using System.Collections.Generic;

namespace Vocab_Workshop
{
    
    public class CardSet
    {
        /// <summary>
        /// The CardRing is a collection of one or more cards.
        /// </summary>
        private Guid _id = Guid.NewGuid();
        public string Title;
        public string ShortTitle;
        public readonly List<Card> Cards = new List<Card>();

        public void SetGuid(string guidCandidate)
        {
            if (Guid.TryParse(guidCandidate, out Guid tempGuid))
                _id = tempGuid;
        }
        public Guid GetGuid()
        {
            return _id;
        }

    }



}
