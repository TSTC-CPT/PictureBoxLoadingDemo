using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Backgrounds
{
    class Images
    {
        // Global variables for handling Images
        private static List<Bitmap> lstImages = new List<Bitmap>();
        private static int ImageCount = 0;
        private static int NumberOfListItems = 0;
        
        /// <summary>
        /// Method used to take an image from a list by index number
        /// and return that image to be used with a PictureBox control.
        /// </summary>
        /// <returns>image</returns>
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

        /// <summary>
        /// Allow the user to choose a directory of images to be loaded into a list
        /// for the use of a PictureBox control. 
        /// 
        /// Provides the user with Warnings that they can suppress if the directory 
        /// contains an unsupported file type for the PictureBox control. 
        /// </summary>
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
                        // Flags and Dialog Results
                        DialogResult dialogIgnore = DialogResult.No;
                        DialogResult dialogWarning = DialogResult.Yes;
                        bool blnUserWarned = false;
                        bool blnSupressWarnings = false;

                        string[] images = Directory.GetFiles(fbdDirectorySelect.SelectedPath); // Get all files in the directory
                        foreach (string image in images)
                        {
                            try // Success = Image added to list
                            {
                                Bitmap picture = new Bitmap(image);
                                lstImages.Add(picture);
                                NumberOfListItems++;
                            }
                            catch (Exception) // There is a file that cannot be loaded into the PictureBox control
                            {
                                // Do not load that file to list
                                // The directory has an unsupported image file inside

                                // This is prompted only once for this instance,
                                // but is used to determine if warnings should be displayed.
                                if (!blnUserWarned)
                                {
                                    dialogWarning = MessageBox.Show($"This folder contains unsupported file/image types.\n\n" +
                                        $"Would you like to see notifications for each file that is not supported?",
                                        "Wrong file type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                    blnUserWarned = true;
                                }

                                // Determine if warnings messages continue or not.
                                if (dialogIgnore == DialogResult.No && dialogWarning == DialogResult.Yes && blnSupressWarnings == false)
                                {
                                    dialogIgnore = MessageBox.Show($"The file: {image} is not a supported type.\n\nIgnore all future warnings?",
                                    "Wrong file type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                }
                                else
                                    blnSupressWarnings = true;
                            }                            
                        }
                    }
                    else
                    {
                        // Display a message to the user if they do not select a folder from the Browser Dialog
                        DialogResult dialogRetry = MessageBox.Show("No folder selection means no images to load!", 
                            "Instructions", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);

                        // A retry will call the method again.
                        if (dialogRetry == DialogResult.Retry)
                            LoadImagesToList();
                    }
                }
            }
            catch (Exception)
            {
                // This will most likely happen if they tried to manually enter 
                // a directory path, which shouldn't happen, but is handled at any rate.
                // Another instance is that the user does not have permissions to access 
                // the files inside of that directory.
                MessageBox.Show("The folder does not exist or you do not have permissions to this folder",
                    "Problem with Folder Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }                        
        }
    }
}