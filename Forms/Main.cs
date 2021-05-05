using csharpExplorer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpExplorer
{
    public partial class Main : Form
    {
        public static string currentPathstring = @"C:\";

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Utils.log("Loaded form");
            Utils.loadFolder(currentPathstring, this, filePanel, true);
        }

        private void currentPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Utils.loadFolder(currentPath.Text, this, filePanel, true);
            }
            catch
            { }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            try
            {
                Utils.loadFolder(currentPath.Text, this, filePanel, true);
            }
            catch
            { }
        }
    }
}
