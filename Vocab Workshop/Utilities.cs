using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vocab_Workshop
{

    public static class Utilities
    {
        public static string Desktop()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";
        }

        public static string ConfigFolder(string subfolders = null)
        {
            string thisPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                              @"\Vocab Workshop\Program Config\";
            if (subfolders != null)
            {
                thisPath += subfolders;
            }
            return thisPath;
        }

        public static string ErrorLogFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                              @"\Vocab Workshop\Program Config\ErrorLogs\";
        }

        public static string NowString()
        {
            return DateTime.Now.ToString("yyyyMMdd_hhmmss");
        }

        public static string ImagesFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Vocab Workshop\Images\";
        }

        public static string CardSetsFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Vocab Workshop\Card Sets\";
        }

        public static void CreateCommonFolder()
        {
            try
            {
                DirectoryInfo configDirectory = Directory.CreateDirectory(ConfigFolder());
                DirectoryInfo imagesDirectory = Directory.CreateDirectory(ImagesFolder());
                DirectoryInfo cardSetDirectory = Directory.CreateDirectory(CardSetsFolder());
            }
            catch (Exception)
            {
            }

        }
        public static void CreateCommonFolder(string path = null)
        {
            try
            {
                if (path != null)
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {
            }

        }
        public static void CreateCommonFolder(IList<string> paths = null)
        {
            try
            {
                if (paths != null)
                    foreach (var path in paths)
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                    }
            }
            catch (Exception)
            {
            }
            
        }

    }
}
