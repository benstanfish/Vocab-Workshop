using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Workshop
{

    public class Card
    {
        /// <summary>
        /// The Card an individual multi-sided card object. Each face takes a string.
        /// </summary>

        private Guid _id = Guid.NewGuid();
        public readonly List<string> Faces = new List<string>();

        public override string ToString()
        {
            return Faces[0];
        }
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
