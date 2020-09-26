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
    public class UserProfile
    {
        [DataMember(Name = "Id")]
        private Guid _guid;
        [DataMember(Name = "CreateDate")]
        private DateTime _createDate { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember(Name = "Valid")]
        private bool _valid;    // If the username has been set.
        [DataMember]
        public readonly List<DateTime> SignIns = new List<DateTime>();

        public UserProfile()
        {
            _guid = Guid.NewGuid();
            _createDate = DateTime.Now;
        }
        public UserProfile(string userName)
            : this()
        {
            if (userName != string.Empty)
            {
                UserName = userName;
                _valid = true;
            }
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
        public DateTime DateCreated()
        {
            return _createDate;
        }
        public void SignIn(string savePath = null)
        {
            SignIns.Add(DateTime.Now);
            if (savePath != null)
                WriteXml(savePath);
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
            _valid = true;
        }

        public void WriteXml(string savePath)
        {
            var xml = new DataContractSerializer(typeof(UserProfile));
            using (var writer = new FileStream(savePath, FileMode.OpenOrCreate))
            {
                xml.WriteObject(writer, this);
            }
        }

        public static UserProfile ReadXml(string filePath)
        {
            UserProfile user = new UserProfile();
            var serializer = new DataContractSerializer(typeof(UserProfile));
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                user = (UserProfile)serializer.ReadObject(reader);
            }
            user._valid = true;
            return user;
        }

        public bool UserExists()
        {
            if (_valid != false) { return true; }
            else { return false; }
        }

        public static void RepairXml(string filePath)
        {
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



    }
}
