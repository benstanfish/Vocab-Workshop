using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Vocab_Workshop
{
    [DataContract]
    [Serializable]
    public class Flashcard
    {
        [DataMember(Name = "Id")]
        private Guid _guid = Guid.NewGuid();
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public string Hint { get; set; }
        [DataMember]
        public string Answer { get; set; }
        [DataMember]
        public string ImagePath { get; set; }

        public Flashcard()
        {
            Question = string.Empty;
            Hint = string.Empty;
            Answer = string.Empty;
            ImagePath = string.Empty;
        }

        public List<string> Sides()
        {
            var sides = new List<string>();
            if (Question != string.Empty)
                sides.Add(Question);
            if (Hint != string.Empty)
                sides.Add(Hint);
            if (Answer != string.Empty)
                sides.Add(Answer);
            if (ImagePath != string.Empty)
                sides.Add(ImagePath);
            return sides;
        }

        public override string ToString()
        {
            return Question;
        }

        public void SetId(string tryGuid)
        {
            if (Guid.TryParse(tryGuid, out Guid tempGuid))
                _guid = tempGuid;
        }
        public void SetId(Guid guid)
        {
            _guid = guid;
        }
        public Guid GetId()
        {
            return _guid;
        }

    }
}
