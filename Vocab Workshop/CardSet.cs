using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Vocab_Workshop
{
    [DataContract]
    public class CardSet 
    {
        /// <summary>
        /// The CardRing is a collection of one or more cards.
        /// </summary>
        [DataMember]
        private Guid _id = Guid.NewGuid();
        [DataMember]
        public string Title;
        [DataMember]
        public string ShortTitle;
        [DataMember]
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
