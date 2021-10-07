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
                        DialogResult dialogIgnore = DialogResult.No;
                        DialogResult dialogWarning = DialogResult.Yes;
                        bool blnUserWarned = false;
                        bool blnSupressWarnings = false;

                        string[] images = Directory.GetFiles(fbdDirectorySelect.SelectedPath);
                        foreach (string image in images)
                        {
                            try
                            {
                                Bitmap picture = new Bitmap(image);
                                lstImages.Add(picture);
                                NumberOfListItems++;
                            }
                            catch (Exception)
                            {
                                // Do not load that file to list
                                // The directory has an unsupported image file inside

                                if (!blnUserWarned)
                                {
                                    dialogWarning = MessageBox.Show($"This folder contains unsupported file/image types. " +
                                        $"Would you like to see notifications for each file that is not supported?",
                                        "Wrong file type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                    blnUserWarned = true;
                                }

                                if (dialogIgnore == DialogResult.No && dialogWarning == DialogResult.Yes && blnSupressWarnings == false)
                                {
                                    dialogIgnore = MessageBox.Show($"The file: {image} is not a supported type. Ignore all future warnings?",
                                    "Wrong file type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                }
                                else
                                    blnSupressWarnings = true;
                            }                            
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