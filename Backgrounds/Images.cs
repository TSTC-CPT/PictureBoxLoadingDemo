using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Backgrounds
{
    class Images
    {
        private static List<Bitmap> lstImages = new List<Bitmap>();
        private static int ImageCount = 0;
        private static int NumberOfListItems = 0;
        
        public static Image LoadNextImage()
        {            
            if (NumberOfListItems == 0)
                return null;

            Image image = lstImages[ImageCount];

            if (ImageCount == NumberOfListItems - 1)
            {
                ImageCount = 0;
            }
            ImageCount++;
            return image;
        }

        public static void LoadImagesToList()
        {
            MessageBox.Show("Use the FolderBrowserDialog() control to select a folder of images.", 
                "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            
            try
            {
                using(FolderBrowserDialog fbdDirectorySelect = new FolderBrowserDialog())
                {
                    DialogResult dialogFolder = fbdDirectorySelect.ShowDialog();
                    if (dialogFolder == DialogResult.OK && !string.IsNullOrEmpty(fbdDirectorySelect.SelectedPath))
                    {
                        string[] images = Directory.GetFiles(fbdDirectorySelect.SelectedPath);
                        foreach (string image in images)
                        {
                            Bitmap picture = new Bitmap(image);
                            lstImages.Add(picture);
                            NumberOfListItems++;
                        }
                    }
                    else
                    {
                        DialogResult dialogRetry = MessageBox.Show("No folder selection means no images to load!", 
                            "Instructions", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);

                        if (dialogRetry == DialogResult.Retry)
                            LoadImagesToList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You goofed!","Directory doesn't exist", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                        
        }
    }
}