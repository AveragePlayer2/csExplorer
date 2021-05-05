using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace csharpExplorer.Classes
{
    class Utils
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;
        public static bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }


        public static readonly string csPath = Environment.GetEnvironmentVariable("LocalAppData") + @"\csharpExplorer\";


        public static string getDir(string line)
        {
            string[] lines = line.Split('\\');
            string result = "";
            for (int i = 0; i < lines.Length - 1; i++)
                result += lines[i] + @"\";
            if (!result.EndsWith(@"\"))
                result += @"\";
            return result;
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
