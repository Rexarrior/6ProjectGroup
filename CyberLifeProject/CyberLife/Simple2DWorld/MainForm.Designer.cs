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
            this.mapPicture = new System.Windows.Forms.PictureBox();
            this.statsLabel = new System.Windows.Forms.Label();
            this.ColorTypeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // mapPicture
            // 
            this.mapPicture.BackColor = System.Drawing.SystemColors.Control;
            this.mapPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapPicture.Location = new System.Drawing.Point(12, 12);
            this.mapPicture.Name = "mapPicture";
            this.mapPicture.Size = new System.Drawing.Size(178, 162);
            this.mapPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mapPicture.TabIndex = 0;
            this.mapPicture.TabStop = false;
            this.mapPicture.Click += new System.EventHandler(this.mapPicture_Click);
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
            this.ColorTypeButton.Location = new System.Drawing.Point(115, 50);
            this.ColorTypeButton.Name = "ColorTypeButton";
            this.ColorTypeButton.Size = new System.Drawing.Size(131, 65);
            this.ColorTypeButton.TabIndex = 2;
            this.ColorTypeButton.Text = "Режим отображения";
            this.ColorTypeButton.UseVisualStyleBackColor = true;
            this.ColorTypeButton.Click += new System.EventHandler(this.ColorTypeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 352);
            this.Controls.Add(this.ColorTypeButton);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.mapPicture);
            this.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox mapPicture;
        private System.Windows.Forms.Label statsLabel;
        private System.Windows.Forms.Button ColorTypeButton;
    }
}