namespace CyberLife.Simple2DWorld
{
    partial class MainForm
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
            this.statsLabel = new System.Windows.Forms.Label();
            this.ColorTypeButton = new System.Windows.Forms.Button();
            this.mapPicture2 = new CyberLife.Simple2DWorld.MainForm.CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture2)).BeginInit();
            this.SuspendLayout();
            // 
            // statsLabel
            // 
            this.statsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statsLabel.AutoSize = true;
            this.statsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsLabel.Location = new System.Drawing.Point(112, 12);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(43, 18);
            this.statsLabel.TabIndex = 1;
            this.statsLabel.Text = "Label";
            // 
            // ColorTypeButton
            // 
            this.ColorTypeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorTypeButton.Location = new System.Drawing.Point(156, 101);
            this.ColorTypeButton.Name = "ColorTypeButton";
            this.ColorTypeButton.Size = new System.Drawing.Size(131, 65);
            this.ColorTypeButton.TabIndex = 2;
            this.ColorTypeButton.Text = "Режим отображения";
            this.ColorTypeButton.UseVisualStyleBackColor = true;
            this.ColorTypeButton.Click += new System.EventHandler(this.ColorTypeButton_Click);
            // 
            // mapPicture2
            // 
            this.mapPicture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapPicture2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.mapPicture2.Location = new System.Drawing.Point(9, 9);
            this.mapPicture2.Margin = new System.Windows.Forms.Padding(0);
            this.mapPicture2.Name = "mapPicture2";
            this.mapPicture2.Size = new System.Drawing.Size(100, 100);
            this.mapPicture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mapPicture2.TabIndex = 3;
            this.mapPicture2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 352);
            this.Controls.Add(this.ColorTypeButton);
            this.Controls.Add(this.mapPicture2);
            this.Controls.Add(this.statsLabel);
            this.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.Name = "MainForm";
            this.Text = "NoMetadata version";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label statsLabel;
        private System.Windows.Forms.Button ColorTypeButton;
        private CustomPictureBox mapPicture2;
    }
}