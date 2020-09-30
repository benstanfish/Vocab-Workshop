using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Vocab_Workshop
{
    public enum JLPTLevel { None, N1, N2, N3, N4, N5 }
    public enum KankenLevel { None, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10 }

    [Serializable]
    public class UserProfile
    {
        [XmlElement] public string Id { get; set; }
        [XmlElement] public DateTime CreateDate { get; set; }
        [XmlElement] public string UserName { get; set; }
        [XmlElement] public readonly List<DateTime> SignIns = new List<DateTime>();
        [XmlElement] public int Rating { get; set; }
        [XmlElement] public int LifetimeCards { get; set; }
        [XmlElement] public JLPTLevel JLPT { get; set; }
        [XmlElement] public KankenLevel Kanken { get; set; }

        public UserProfile()
        {
            Id = Guid.NewGuid().ToString();
            CreateDate = DateTime.Now;
            JLPT = JLPTLevel.None;
            Kanken = KankenLevel.None;
        }
        public UserProfile(string userName)
            : this()
        {
            if (userName != string.Empty)
            {
                UserName = userName;
            }
        }

        public override string ToString()
        {
            return UserName;
        }

        public void SetId(string tryGuid)
        {
            if (Guid.TryParse(tryGuid, out Guid tempGuid))
                Id = tempGuid.ToString();
        }
        public void SetId(Guid guid)
        {
            Id = guid.ToString();
        }
        public DateTime DateCreated()
        {
            return CreateDate;
        }
        public void SignIn(string savePath = null)
        {
            SignIns.Add(DateTime.Now);
        }

        public void UpdateUsername(string newName)
        {
            if (newName != string.Empty)
            {
                UserName = newName;
            }
            else
            {
                UserName = "Please update your Username.";
            }
        }

        public void WriteXml(string savePath)
        {
            var xml = new XmlSerializer(typeof(UserProfile));
            using (var writer = new FileStream(savePath, FileMode.OpenOrCreate))
            {
                xml.Serialize(writer, this);
            }
        }

        public static UserProfile ReadXml(string filePath)
        {
            UserProfile user = new UserProfile();
            var serializer = new XmlSerializer(typeof(UserProfile));
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                user = (UserProfile)serializer.Deserialize(reader);
            }
            return user;
        }

        private static void RepairXml(string filePath)
        {
            // This is for DataContract deserialization... no longer necessary with public properties
            var temp = string.Empty;
            using (var reader = new StreamReader(filePath))
            {
                temp = reader.ReadToEnd();
                reader.Close();
            }

            temp = Regex.Replace(temp, "<Id/>", "<Id></Id>");
            temp = Regex.Replace(temp, "<UserName/>", "<UserName>Please update your Username.</UserName>");
            temp = Regex.Replace(temp, "<Valid/>", "<Valid>true</Valid>");
            temp = Regex.Replace(temp, "<Id></Id>", "<Id>" + Guid.NewGuid() + "</Id>");

            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(temp);
                writer.Close();
            }
        }

        public void Promote(int points)
        {
            Rating += points;
        }

        public void Demote(int points)
        {
            Rating -= points;
        }

    }
}
