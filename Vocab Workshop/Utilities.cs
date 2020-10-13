using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;



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
        public static string LoadCardSetFile()
        {
            string myPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Utilities.CardSetsFolder();
                ofd.Filter = "Xml files (*.xml)|*.xml|Json files (*.json)|*.json|All files (*.*)|*.*";
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    myPath = ofd.FileName;
                }
            }
            return myPath;
        }


        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            Double ratio = Math.Min(ratioX, ratioY);
            ratio = ratio * 0.9;

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        public static void Reveal()
        {
            // get all public static properties of MyClass type
            PropertyInfo[] propertyInfos;
            propertyInfos = typeof(Card).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            // sort properties by name
            Array.Sort(propertyInfos, delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2){ return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            // write property names
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine(propertyInfo.Name);
            }
        }
        
    }
}
