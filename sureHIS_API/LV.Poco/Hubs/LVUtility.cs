using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco
{
    public class LVUtility
    {
        #region IO Util
        public static void WriteLogFile(string log)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Logs");
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists) dir.Create();
            FileStream fileStream = new FileStream(path + "/" + DateTime.Now.ToString("yyyyMMdd") + ".txt", FileMode.OpenOrCreate);
            fileStream.Seek(0L, SeekOrigin.End);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("- " + DateTime.Now.ToString("HH:mm:ss") + ": " + log);
            streamWriter.Close();
            fileStream.Close();
        }

        #endregion

        // Cắt chuỗi
        public static string ExtractString(string source, string start, string end)
        {

            int startIndex = source.IndexOf(start) + start.Length;
            if (startIndex > (start.Length - 1))
            {
                int endIndex = source.IndexOf(end, startIndex);
                return source.Substring(startIndex, endIndex - startIndex);
            }
            else
                return "";
        }

        public static void WriteFileText(string pathfile, List<string> Contain)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/" + pathfile);
            DirectoryInfo dir = new DirectoryInfo(path);
            //  if (!dir.Exists) {dir.Create(); }

            File.WriteAllText(path, String.Empty);

            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            fileStream.Seek(0L, SeekOrigin.End);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            foreach (var str in Contain)
            {
                streamWriter.WriteLine(str);
            }
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
