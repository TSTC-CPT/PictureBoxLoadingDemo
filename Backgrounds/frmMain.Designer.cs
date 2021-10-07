
namespace Backgrounds
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pbxCorner = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.pbxDisplayImage = new System.Windows.Forms.PictureBox();
            this.fbdBrowser = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCorner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplayImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxCorner
            // 
            this.pbxCorner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxCorner.Image = global::Backgrounds.Properties.Resources.cornerBanner;
            this.pbxCorner.Location = new System.Drawing.Point(496, 0);
            this.pbxCorner.Name = "pbxCorner";
            this.pbxCorner.Size = new System.Drawing.Size(814, 508);
            this.pbxCorner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCorner.TabIndex = 2;
            this.pbxCorner.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Image = global::Backgrounds.Properties.Resources.btnBG;
            this.btnNext.Location = new System.Drawing.Point(105, 388);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(274, 72);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "NEXT";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pbxDisplayImage
            // 
            this.pbxDisplayImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbxDisplayImage.Image = global::Backgrounds.Properties.Resources.startingImage;
            this.pbxDisplayImage.Location = new System.Drawing.Point(12, 12);
            this.pbxDisplayImage.Name = "pbxDisplayImage";
            this.pbxDisplayImage.Size = new System.Drawing.Size(499, 328);
            this.pbxDisplayImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDisplayImage.TabIndex = 0;
            this.pbxDisplayImage.TabStop = false;
            // 
            // fbdBrowser
            // 
            this.fbdBrowser.RootFolder = System.Environment.SpecialFolder.MyPictures;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1310, 510);
            this.Controls.Add(this.pbxDisplayImage);
            this.Controls.Add(this.pbxCorner);
            this.Controls.Add(this.btnNext);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display Images";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCorner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisplayImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxDisplayImage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.PictureBox pbxCorner;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowser;
    }
}

