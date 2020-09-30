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
    //[DataContract]
    //public class OldFlashcards
    //{
    //    [DataMember(Name = "ID")]
    //    private Guid _guid = Guid.NewGuid();
    //    [DataMember]
    //    public string Question { get; set; }
    //    [DataMember]
    //    public string Hint { get; set; }
    //    [DataMember]
    //    public string Answer { get; set; }
    //    [DataMember]
    //    public string ImagePath { get; set; }

    //    public OldFlashcards()
    //    {
    //        Question = string.Empty;
    //        Hint = string.Empty;
    //        Answer = string.Empty;
    //        ImagePath = string.Empty;
    //    }

    //    public List<string> Sides()
    //    {
    //        var sides = new List<string>();
    //        if (Question != string.Empty)
    //            sides.Add(Question);
    //        if (Hint != string.Empty)
    //            sides.Add(Hint);
    //        if (Answer != string.Empty)
    //            sides.Add(Answer);
    //        if (ImagePath != string.Empty)
    //            sides.Add(ImagePath);
    //        return sides;
    //    }

    //    public override string ToString()
    //    {
    //        return Question;
    //    }

    //    public void SetId(string tryGuid)
    //    {
    //        if (Guid.TryParse(tryGuid, out Guid tempGuid))
    //            _guid = tempGuid;
    //    }
    //    public void SetId(Guid guid)
    //    {
    //        _guid = guid;
    //    }
    //    public Guid GetId()
    //    {
    //        if (_guid == default(Guid))
    //            _guid = Guid.NewGuid();
    //        return _guid;
    //    }

    //    public void WriteXml(string savePath)
    //    {
    //        var xml = new DataContractSerializer(typeof(OldFlashcards));
    //        using (var writer = new FileStream(savePath, FileMode.Create))
    //        {
    //            xml.WriteObject(writer, this);
    //        }

    //    }

    //    public static OldFlashcards ReadXml(string filePath)
    //    {

    //        OldFlashcards card = new OldFlashcards();
    //        var serializer = new DataContractSerializer(typeof(OldFlashcards));
    //        using (var reader = new FileStream(filePath, FileMode.Open))
    //        {
    //            card = (OldFlashcards)serializer.ReadObject(reader);
    //        }
    //        return card;
    //    }

    //}

    //[DataContract]
    //public class FlashcardSet
    //{
    //    [DataMember(Name = "ID")]
    //    private Guid _guid = Guid.NewGuid();
    //    [DataMember]
    //    public string Title;
    //    [DataMember]
    //    public string Description;
    //    [DataMember]
    //    public readonly List<OldFlashcards> Cards = new List<OldFlashcards>();

    //    public void SetId(string guidCandidate)
    //    {
    //        if (Guid.TryParse(guidCandidate, out Guid tempGuid))
    //            _guid = tempGuid;
    //    }
    //    public void SetId(Guid guid)
    //    {
    //        _guid = guid;
    //    }
    //    public Guid GetGuid()
    //    {
    //        if (_guid == default(Guid))
    //            _guid = Guid.NewGuid();
    //        return _guid;
    //    }

    //    public void WriteXml(string savePath)
    //    {
    //        var xml = new DataContractSerializer(typeof(FlashcardSet));
    //        using (var writer = new FileStream(savePath, FileMode.Create))
    //        {
    //            xml.WriteObject(writer, this);
    //        }
    //    }

    //    public static FlashcardSet ReadXml(string filePath)
    //    {
    //        FlashcardSet cardSet = new FlashcardSet();
    //        CleanXmlID(filePath);
    //        var serializer = new DataContractSerializer(typeof(FlashcardSet));
    //        try
    //        {
    //            using (var reader = new FileStream(filePath, FileMode.Open))
    //            {
    //                cardSet = (FlashcardSet)serializer.ReadObject(reader);
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            string errorMsg = "Error: Could not deserialize because one of the records has a blank ID. Either provide an ID or delete the field \"<ID></ID>\".";
    //            Console.WriteLine(errorMsg);
    //        }

    //        return cardSet;
    //    }

    //    private static void CleanXmlID(string filePath)
    //    {
    //        var temp = string.Empty;
    //        using (var reader = new StreamReader(filePath))
    //        {
    //            temp = reader.ReadToEnd();
    //            reader.Close();
    //        }
    //        temp = Regex.Replace(temp, "<ID></ID>", "<ID>" + Guid.NewGuid() + "</ID>");
    //        using (var writer = new StreamWriter(filePath))
    //        {
    //            writer.Write(temp);
    //            writer.Close();
    //        }
    //    }


    //}
    //[DataContract]
    //public class UserProfile
    //{
    //    [DataMember(Name = "ID")]
    //    private Guid _guid;
    //    [DataMember]
    //    private DateTime CreatedDate { get; set; }
    //    [DataMember]
    //    public string UserName { get; set; }
    //    [DataMember(Name = "Valid")]
    //    private bool _valid;    // If the username has been set.
    //    [DataMember]
    //    public readonly List<DateTime> Sessions = new List<DateTime>();

    //    public UserProfile()
    //    {
    //        _guid = Guid.NewGuid();
    //        CreatedDate = DateTime.Now;
    //    }
    //    public UserProfile(string userName)
    //        : this()
    //    {
    //        if (userName != string.Empty)
    //        {
    //            UserName = userName;
    //            _valid = true;
    //        }
    //    }

    //    public void SetId(string tryGuid)
    //    {
    //        if (Guid.TryParse(tryGuid, out Guid tempGuid))
    //            _guid = tempGuid;
    //    }
    //    public void SetId(Guid guid)
    //    {
    //        _guid = guid;
    //    }
    //    public Guid GetId()
    //    {
    //        if (_guid == default(Guid))
    //            _guid = Guid.NewGuid();
    //        return _guid;
    //    }
    //    public DateTime DateCreated()
    //    {
    //        return CreatedDate;
    //    }
    //    public void SignIn(string savePath = null)
    //    {
    //        Sessions.Add(DateTime.Now);
    //        if (savePath != null)
    //            WriteXml(savePath);
    //    }
    //    public void UpdateUsername(string newName)
    //    {
    //        if (newName != string.Empty)
    //        {
    //            UserName = newName;
    //        }
    //        else
    //        {
    //            UserName = "Please update your Username.";
    //        }
    //        _valid = true;
    //    }

    //    public void WriteXml(string savePath)
    //    {
    //        var xml = new DataContractSerializer(typeof(UserProfile));
    //        using (var writer = new FileStream(savePath, FileMode.OpenOrCreate))
    //        {
    //            xml.WriteObject(writer, this);
    //        }
    //    }

    //    public static UserProfile ReadXml(string filePath)
    //    {
    //        UserProfile user = new UserProfile();
    //        var serializer = new DataContractSerializer(typeof(UserProfile));
    //        using (var reader = new FileStream(filePath, FileMode.Open))
    //        {
    //            user = (UserProfile)serializer.ReadObject(reader);
    //        }
    //        user._valid = true;
    //        return user;
    //    }

    //    public bool UserExists()
    //    {
    //        if (_valid != false) { return true; }
    //        else { return false; }
    //    }

    //    public static void RepairXml(string filePath)
    //    {
    //        var temp = string.Empty;
    //        using (var reader = new StreamReader(filePath))
    //        {
    //            temp = reader.ReadToEnd();
    //            reader.Close();
    //        }

    //        temp = Regex.Replace(temp, "<ID/>", "<ID></ID>");
    //        temp = Regex.Replace(temp, "<UserName/>", "<UserName>Please update your Username.</UserName>");
    //        temp = Regex.Replace(temp, "<Valid/>", "<Valid>true</Valid>");
    //        temp = Regex.Replace(temp, "<ID></ID>", "<ID>" + Guid.NewGuid() + "</ID>");
            
    //        using (var writer = new StreamWriter(filePath))
    //        {
    //            writer.Write(temp);
    //            writer.Close();
    //        }
    //    }



    //}




}
