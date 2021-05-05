using csharpExplorer.Classes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace csharpExplorer
{
    public partial class Main : Form
    {
        public static string currentPathstring = @"C:\";

        public void cm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                ToolStripItem item = e.ClickedItem;
                if (item.Text == "Run")
                {
                    Process.Start((string)item.Tag);
                }
                if (item.Text == "Delete")
                {
                    File.Delete((string)item.Tag);
                    refresh();
                }
                if (item.Text == "Rename")
                {
                    string renameTo = Microsoft.VisualBasic.Interaction.InputBox("What do you want to rename this to?", "Rename", "");
                    if (renameTo != "")
                    {
                        renameTo.Replace(@"\", "");
                        File.Copy((string)item.Tag, Utils.getDir((string)item.Tag) + renameTo);
                        File.Delete((string)item.Tag);
                        refresh();
                    }
                }
                if (item.Text == "Copy")
                {
                    Clipboard.SetDataObject(File.ReadAllBytes((string)item.Tag));
                }
                if (item.Text == "Properties")
                {
                    Utils.ShowFileProperties((string)item.Tag);
                }
                if (item.Text == "Extract")
                {
                    try
                    {
                        string extract = Microsoft.VisualBasic.Interaction.InputBox("Where do you want to extract this to?", "Extract", Utils.getDir((string)item.Tag));
                        if (extract != "")
                        {
                            ZipFile.ExtractToDirectory((string)item.Tag, extract);
                            refresh();
                        }
                    }
                    catch { MessageBox.Show("Error"); }
                }
            }
            catch { MessageBox.Show("Error!"); }
        }

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
            bool isArchive = false;
            switch(file.Extension.ToLower())
            {
                case ".exe":
                    picBox.BackgroundImage = (Image)Properties.Resources.exe;
                    break;
                case ".zip":
                    picBox.BackgroundImage = (Image)Properties.Resources.archive;
                    isArchive = true;
                    break;
                case ".tar":
                    picBox.BackgroundImage = (Image)Properties.Resources.archive;
                    isArchive = true;
                    break;
                case ".rar":
                    picBox.BackgroundImage = (Image)Properties.Resources.archive;
                    isArchive = true;
                    break;
                case ".rar5":
                    picBox.BackgroundImage = (Image)Properties.Resources.archive;
                    isArchive = true;
                    break;
                case ".7z":
                    picBox.BackgroundImage = (Image)Properties.Resources.archive;
                    isArchive = true;
                    break;
                default:
                    picBox.BackgroundImage = (Image)Properties.Resources.file;
                    break;
            }
            picBox.BackgroundImageLayout = ImageLayout.Zoom;


            // context menu
            ContextMenuStrip cm = new ContextMenuStrip();
            string[] contexts = new string[] { "Run", "Delete", "Rename", "Copy", "Properties", "Extract"};
            for(int i = 0; i < contexts.Length; i++)
            {
                cm.Items.Add(contexts[i]);

                // shit fix but it worksi guess
                cm.Items[i].Tag = file.FullName;
            }
            picBox.ContextMenuStrip = cm;
            cm.ItemClicked += new ToolStripItemClickedEventHandler(cm_ItemClicked);


            // add it to the panel
            panel.Controls.Add(picBox);
            panel.Controls.Add(label);
            picBox.BringToFront();
            picBox.DoubleClick += (sender, EventArgs) => { openFile(sender, null, file); };
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

        void refresh()
        {
            loadFolder(this.currentPath.Text, this.filePanel, true);
            currentPathstring = this.currentPath.Text;
        }

        void openFile(object sender, MouseEventArgs e, FileInfo file)
        {
            Process.Start(file.FullName);
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
