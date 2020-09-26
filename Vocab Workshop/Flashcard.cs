using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

namespace Testing_Center
{
    [DataContract]
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
            if (_guid == default(Guid))
                _guid = Guid.NewGuid();
            return _guid;
        }

        public void WriteXml(string savePath)
        {
            var xml = new DataContractSerializer(typeof(Flashcard));
            using (var writer = new FileStream(savePath, FileMode.Create))
            {
                xml.WriteObject(writer, this);
            }

        }

        public static Flashcard ReadXml(string filePath)
        {

            Flashcard card = new Flashcard();
            var serializer = new DataContractSerializer(typeof(Flashcard));
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                card = (Flashcard)serializer.ReadObject(reader);
            }
            return card;
        }

    }

}
