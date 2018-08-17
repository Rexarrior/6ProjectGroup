namespace PhoneBook
{
    partial class RecordEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordEditForm));
            this.captionTextBox = new System.Windows.Forms.TextBox();
            this.typeRecordBox = new System.Windows.Forms.ComboBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.recordTypeNameTextBox = new System.Windows.Forms.TextBox();
            this.recordTypeFilterTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // captionTextBox
            // 
            this.captionTextBox.Location = new System.Drawing.Point(12, 153);
            this.captionTextBox.Name = "captionTextBox";
            this.captionTextBox.Size = new System.Drawing.Size(156, 20);
            this.captionTextBox.TabIndex = 0;
            this.captionTextBox.Text = "Caption";
            // 
            // typeRecordBox
            // 
            this.typeRecordBox.FormattingEnabled = true;
            this.typeRecordBox.Location = new System.Drawing.Point(12, 39);
            this.typeRecordBox.Name = "typeRecordBox";
            this.typeRecordBox.Size = new System.Drawing.Size(156, 21);
            this.typeRecordBox.TabIndex = 1;
            this.typeRecordBox.SelectedIndexChanged += new System.EventHandler(this.TypeRecordBox_SelectedIndexChanged);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(12, 193);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(156, 20);
            this.valueTextBox.TabIndex = 0;
            this.valueTextBox.Text = "Value";
            this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
            // 
            // recordTypeNameTextBox
            // 
            this.recordTypeNameTextBox.Location = new System.Drawing.Point(12, 78);
            this.recordTypeNameTextBox.Name = "recordTypeNameTextBox";
            this.recordTypeNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.recordTypeNameTextBox.TabIndex = 2;
            this.recordTypeNameTextBox.Text = "Name of type";
            this.recordTypeNameTextBox.Visible = false;
            // 
            // recordTypeFilterTextBox
            // 
            this.recordTypeFilterTextBox.Location = new System.Drawing.Point(12, 104);
            this.recordTypeFilterTextBox.Name = "recordTypeFilterTextBox";
            this.recordTypeFilterTextBox.Size = new System.Drawing.Size(100, 20);
            this.recordTypeFilterTextBox.TabIndex = 2;
            this.recordTypeFilterTextBox.Text = "Regular expression";
            this.recordTypeFilterTextBox.Visible = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(188, 101);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SaveButton_MouseMove);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(188, 191);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // RecordEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PhoneBook.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.recordTypeFilterTextBox);
            this.Controls.Add(this.recordTypeNameTextBox);
            this.Controls.Add(this.typeRecordBox);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.captionTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecordEditForm";
            this.Text = "Record edit";
            this.Shown += new System.EventHandler(this.RecordEditForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox captionTextBox;
        private System.Windows.Forms.ComboBox typeRecordBox;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.TextBox recordTypeNameTextBox;
        private System.Windows.Forms.TextBox recordTypeFilterTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}