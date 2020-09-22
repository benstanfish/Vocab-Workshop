using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vocab_Workshop
{
    public class FolderSetup
    {

        public void CreateCommonFolder()
        {
            string profiles = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Vocab Workshop\Settings\Profiles\";
            string records = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Vocab Workshop\Settings\Records\";
            string flashcards = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Vocab Workshop\Flashcards\";
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(profiles);
                DirectoryInfo dj = Directory.CreateDirectory(records);
                DirectoryInfo dk = Directory.CreateDirectory(flashcards);
            }
            catch (Exception e)
            {
                
            }
            
        }


    }
}
