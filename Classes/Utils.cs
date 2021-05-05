using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpExplorer.Classes
{
    class Utils
    {
        public static string TrimEnd(string input, string suffixToRemove, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            if (suffixToRemove != null && input.EndsWith(suffixToRemove, comparisonType))
            {
                return input.Substring(0, input.Length - suffixToRemove.Length);
            }

            return input;
        }

        public static readonly string csPath = Environment.GetEnvironmentVariable("LocalAppData") + @"\csharpExplorer\";


        public static string requestLocalText(string path)
        {
            return File.ReadAllText(csPath + path);
        }

        // gets path name
        public static string getFileType(FileInfo file)
        {
            try
            {
                if (file.Extension.ToLower() == ".exe")
                {
                    string[] pathSplit = file.FullName.Split('\\');
                    return pathSplit[pathSplit.Length];
                }
                else
                    return file.Name;
            }
            catch { }
            return "File";
        }

        public static string logfilename;
        public static bool doneFirstWrite;

        public static void log(string line)
        {
            string path = Environment.GetEnvironmentVariable("LocalAppData") + @"\csharpExplorer\";

            // if havent made path
            if (!doneFirstWrite)
            {
                Directory.CreateDirectory(path);
                doneFirstWrite = true;
            }
            try
            {
                using (StreamWriter sw = File.AppendText(path + logfilename))
                {
                    // log
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff") + " || [CSHARP-EXPLORER] : " + line);
                    Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff") + " || [CSHARP-EXPLORER] : " + line);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch { }
        }

    }
}
