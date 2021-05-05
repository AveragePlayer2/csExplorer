using csharpExplorer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpExplorer
{
    public partial class Main : Form
    {
        public static string currentPathstring = @"C:\";

        public void makeFile(Panel panel, FileInfo file, int x, int y)
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

        public void makeFolder(Panel panel, DirectoryInfo file, int x, int y)
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
            picBox.DoubleClick += (sender, EventArgs) => { openFolder(sender, null, file, panel); };
        }


        void openFolder(object sender, MouseEventArgs e, DirectoryInfo dir, Panel panel)
        {
            loadFolder(dir.FullName, panel, true);
            currentPathstring = dir.FullName;
            this.currentPath.Text = dir.FullName;
        }

        public void loadFolder(string folderPath, Panel panel, bool shouldClear)
        {

            try
            {
                // clear the panel if needed
                if (shouldClear)
                {
                    foreach (Control c in panel.Controls)
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
            catch { }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Utils.logfilename = "log.txt";
            Utils.log("Loaded form");
            loadFolder(currentPathstring, filePanel, true);
        }

        private void currentPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadFolder(currentPath.Text, filePanel, true);
            }
            catch
            { }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            try
            {
                loadFolder(currentPath.Text, filePanel, true);
            }
            catch
            { }
        }

        private void back_Click(object sender, EventArgs e)
        {
            string[] paths = currentPath.Text.Split('\\');
            string path = "";
            int j = 1;
            if (currentPath.Text.EndsWith(@"\"))
                j = 2;
            for (int i = 0; i < paths.Count() - j; i++)
                path += paths[i] + @"\";
            if (!path.EndsWith(@"\"))
                path += @"\";
            currentPathstring = path;
            this.currentPath.Text = path;
        }
    }
}
