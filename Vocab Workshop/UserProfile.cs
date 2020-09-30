using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Vocab_Workshop
{
    [Serializable]
    public class UserProfile
    {
        [XmlElement] public string Id { get; set; }
        [XmlElement] public DateTime CreateDate { get; set; }
        [XmlElement] public string UserName { get; set; }
        [XmlElement] public readonly List<DateTime> SignIns = new List<DateTime>();
        [XmlElement] public int Rating { get; set; }
        [XmlElement] public int LifetimeCards { get; set; }

        public UserProfile()
        {
            Id = Guid.NewGuid().ToString();
            CreateDate = DateTime.Now;
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
        public void SignIn()
        {
            SignIns.Add(DateTime.Now);
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

        public void Promote(int points)
        {
            Rating += points;
        }

        public void Demote(int points)
        {
            if (Rating - points <= 0)
                Rating = 0;
            else
                Rating -= points;
        }

    }
}
