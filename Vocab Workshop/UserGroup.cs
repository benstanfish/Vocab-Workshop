using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Vocab_Workshop
{
    [Serializable]
    public class UserGroup
    {
        [XmlElement] public string Id;
        [XmlElement] public readonly  List<UserProfile> users = new List<UserProfile>();

        public UserGroup()
        {
            Id = Guid.NewGuid().ToString();
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

        public void WriteXml(string savePath)
        {
            var xml = new XmlSerializer(typeof(UserGroup));
            using (var writer = new FileStream(savePath, FileMode.OpenOrCreate))
            {
                xml.Serialize(writer, this);
            }
        }

        public static UserGroup ReadXml(string filePath)
        {
            UserGroup userGroup = new UserGroup();
            var serializer = new XmlSerializer(typeof(UserGroup));
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                userGroup = (UserGroup)serializer.Deserialize(reader);
            }
            return userGroup;
        }

    }
}
