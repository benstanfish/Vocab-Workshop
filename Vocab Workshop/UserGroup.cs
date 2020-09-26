using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Vocab_Workshop
{
    [DataContract]
    class UserGroup
    {
        [DataMember(Name = "Id")]
        private Guid _id = Guid.NewGuid();
        public readonly  List<UserProfile> users = new List<UserProfile>();

        
    }
}
