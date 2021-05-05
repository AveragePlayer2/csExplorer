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

        public static void makeFile(Panel panel, FileInfo file, int x, int y)
        {
            // define the label
            PictureBox picBox = new PictureBox();
            Label label = new Label();

            // label settings
            label.MaximumSize = new Size(58, 0);
            label.AutoSize = true;
            label.Text = file.Name;
            label.Location = new Point(x, y);
            label.ForeColor = Color.White;

            // picturebox settings
            picBox.Size = new Size(58, 60);
            picBox.Location = new Point(x, y - 63);
            picBox.BackgroundImage = (Image)Properties.Resources.file;
            picBox.BackgroundImageLayout = ImageLayout.Zoom;

            // add it to the panel
            panel.Controls.Add(picBox);
            panel.Controls.Add(label);
            picBox.BringToFront();
        }

        public static void makeFolder(Panel panel, DirectoryInfo file, int x, int y)
        {
            // define the label
            PictureBox picBox = new PictureBox();
            Label label = new Label();

            // label settings
            label.MaximumSize = new Size(58, 0);
            label.AutoSize = true;
            label.Text = file.Name;
            label.Location = new Point(x, y);
            label.ForeColor = Color.White;

            // picturebox settings
            picBox.Size = new Size(58, 60);
            picBox.Location = new Point(x, y - 63);
            picBox.BackgroundImage = (Image)Properties.Resources.folder;
            picBox.BackgroundImageLayout = ImageLayout.Zoom;

            // add it to the panel
            panel.Controls.Add(picBox);
            panel.Controls.Add(label);
            picBox.BringToFront();
        }



        public static void loadFolder(string folderPath, Form form, Panel panel, bool shouldClear)
        {
            // clear the panel if needed
            if(shouldClear)
            {
                foreach(Control c in panel.Controls)
                {
                    c.Dispose();
                }

                // extra check because for some reason the above sometimes doesnt work
                panel.Controls.Clear();
            }


            // define ints for positions
            int x = 3;
            int y = 66;

            // check if a new row has been made in the form
            bool newRow = false;

            // foreach folders in the path
            foreach (DirectoryInfo dir in new DirectoryInfo(folderPath).GetDirectories())
            {
                // if x is too big for panel, make new row
                if(x + 64 >= panel.Size.Width)
                {
                    newRow = true;
                }
                // if theres a new row
                if(newRow)
                {
                    x = 3;
                    y += 89;
                    newRow = false;
                }
                makeFolder(panel, dir, x, y);
                x += 64;
            }

            // foreach file in the path
            foreach (FileInfo file in new DirectoryInfo(folderPath).GetFiles())
            {
                // if x is too big for panel, make new row
                if (x + 64 >= panel.Size.Width)
                {
                    newRow = true;
                }
                // if theres a new row
                if (newRow)
                {
                    x = 3;
                    y += 89;
                    newRow = false;
                }
                makeFile(panel, file, x, y);
                x += 64;
            }
        }

    }
}
