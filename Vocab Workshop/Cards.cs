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
        
        public int Id;
        public readonly List<string> Faces = new List<string>();

        public override string ToString()
        {
            return Faces[0];
        }



    }



}
