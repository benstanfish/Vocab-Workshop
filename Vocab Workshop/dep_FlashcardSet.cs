using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Text.RegularExpressions;


namespace Vocab_Workshop
{
    [DataContract]
    public class dep_FlashcardSet
    {
        [DataMember(Name = "Id")]
        private Guid _guid = Guid.NewGuid();
        [DataMember]
        public string Title;
        [DataMember]
        public string Description;
        [DataMember]
        public readonly List<dep_Flashcard> Cards = new List<dep_Flashcard>();

        public void SetId(string guidCandidate)
        {
            if (Guid.TryParse(guidCandidate, out Guid tempGuid))
                _guid = tempGuid;
        }
        public void SetId(Guid guid)
        {
            _guid = guid;
        }
        public Guid GetGuid()
        {
            if (_guid == default(Guid))
                _guid = Guid.NewGuid();
            return _guid;
        }

        public void WriteXml(string savePath)
        {
            var xml = new DataContractSerializer(typeof(dep_FlashcardSet));
            using (var writer = new FileStream(savePath, FileMode.Create))
            {
                xml.WriteObject(writer, this);
            }
        }

        public static dep_FlashcardSet ReadXml(string filePath)
        {
            dep_FlashcardSet cardSet = new dep_FlashcardSet();
            CleanXmlID(filePath);
            var serializer = new DataContractSerializer(typeof(dep_FlashcardSet));
            try
            {
                using (var reader = new FileStream(filePath, FileMode.Open))
                {
                    cardSet = (dep_FlashcardSet)serializer.ReadObject(reader);
                }
            }
            catch (Exception)
            {
                string errorMsg = "Error: Could not deserialize because one of the records has a blank Id. Either provide an Id or delete the field \"<Id></Id>\".";
                Console.WriteLine(errorMsg);
            }

            return cardSet;
        }

        private static void CleanXmlID(string filePath)
        {
            var temp = string.Empty;
            using (var reader = new StreamReader(filePath))
            {
                temp = reader.ReadToEnd();
                reader.Close();
            }
            temp = Regex.Replace(temp, "<Id></Id>", "<Id>" + Guid.NewGuid() + "</Id>");
            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(temp);
                writer.Close();
            }
        }


    }

}
