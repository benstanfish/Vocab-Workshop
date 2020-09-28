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
    public static class ProjectFolders
    {
        public static string Desktop()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";
        }

        public static string ConfigFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Vocab Workshop\Program Config\";
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
            }
            
        }


    }
}
