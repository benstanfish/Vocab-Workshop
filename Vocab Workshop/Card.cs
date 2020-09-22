using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Vocab_Workshop
{
  
    [DataContract]
    [Serializable]
    public class Card
    {
        /// <summary>
        /// The Card an individual multi-sided card object. Each face takes a string.
        /// </summary>
        [DataMember]
        private Guid Id = Guid.NewGuid();
        [DataMember]
        public readonly List<string> Sides = new List<string>();

        public override string ToString()
        {
            return Sides[0];
        }
        
        public void SetGuid(string guidCandidate)
        {
            if (Guid.TryParse(guidCandidate, out Guid tempGuid))
                Id = tempGuid;
            else
                Id = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return Id;
        }

    }



}
