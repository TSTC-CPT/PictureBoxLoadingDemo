using System;
using System.Windows.Forms;

namespace Backgrounds
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pbxDisplayImage.Image = Images.LoadNextImage();            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Images.LoadImagesToList();

            // This is to bring the application to the front of all other windows/forms/etc
            // It's a weird trick, but it works.
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}