using System;
using System.Windows.Forms;

//TODO: Give the user the option of choosing a different location for images.
//TODO: Make all dialog boxes appear on top of other windows when invoked.

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
        private void btnNext_Click(object sender, EventArgs e)
        {
            pbxDisplayImage.Image = Images.LoadNextImage();            
        }

        /// <summary>
        /// The form will load and call the static function to begin browsing for a directory.
        /// The bulk of the work is being done in that single method in the Images.cs class file.
        /// </summary>
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