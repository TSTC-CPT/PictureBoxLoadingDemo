using System;
using System.Windows.Forms;

//TODO: Give the user the option of choosing a different location for images

namespace Backgrounds
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Each button click will call a static method and return a
        /// value to the PictureBox control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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