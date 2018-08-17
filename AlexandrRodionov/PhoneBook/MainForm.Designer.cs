namespace PhoneBook
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.personsListBox = new System.Windows.Forms.ListBox();
            this.editPersonButton = new System.Windows.Forms.Button();
            this.NewPersonButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.errorLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // personsListBox
            // 
            this.personsListBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.personsListBox.FormattingEnabled = true;
            this.personsListBox.Location = new System.Drawing.Point(29, 79);
            this.personsListBox.Name = "personsListBox";
            this.personsListBox.Size = new System.Drawing.Size(191, 212);
            this.personsListBox.TabIndex = 0;
            this.personsListBox.SelectedValueChanged += new System.EventHandler(this.personsListBox_SelectedValueChanged);
            // 
            // editPersonButton
            // 
            this.editPersonButton.BackColor = System.Drawing.SystemColors.Control;
            this.editPersonButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editPersonButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.editPersonButton.Location = new System.Drawing.Point(318, 93);
            this.editPersonButton.Name = "editPersonButton";
            this.editPersonButton.Size = new System.Drawing.Size(75, 24);
            this.editPersonButton.TabIndex = 1;
            this.editPersonButton.Text = "Edit";
            this.editPersonButton.UseVisualStyleBackColor = false;
            this.editPersonButton.Click += new System.EventHandler(this.EditButtonClick);
            this.editPersonButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EditPersonButton_MouseMove);
            // 
            // NewPersonButton
            // 
            this.NewPersonButton.BackColor = System.Drawing.SystemColors.Control;
            this.NewPersonButton.Location = new System.Drawing.Point(318, 145);
            this.NewPersonButton.Name = "NewPersonButton";
            this.NewPersonButton.Size = new System.Drawing.Size(75, 23);
            this.NewPersonButton.TabIndex = 1;
            this.NewPersonButton.Text = "New";
            this.NewPersonButton.UseVisualStyleBackColor = false;
            this.NewPersonButton.Click += new System.EventHandler(this.NewButtonClick);
            // 
            // ImportButton
            // 
            this.ImportButton.BackColor = System.Drawing.SystemColors.Control;
            this.ImportButton.Location = new System.Drawing.Point(318, 282);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 23);
            this.ImportButton.TabIndex = 1;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = false;
            this.ImportButton.Click += new System.EventHandler(this.ImportButtonClick);
            // 
            // ExportButton
            // 
            this.ExportButton.BackColor = System.Drawing.SystemColors.Control;
            this.ExportButton.Location = new System.Drawing.Point(318, 240);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 1;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = false;
            this.ExportButton.Click += new System.EventHandler(this.ExportButtonClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(12, 324);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(32, 13);
            this.errorLabel.TabIndex = 2;
            this.errorLabel.Text = "Error:";
            this.errorLabel.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.SystemColors.Control;
            this.deleteButton.Location = new System.Drawing.Point(318, 184);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PhoneBook.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(459, 346);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.NewPersonButton);
            this.Controls.Add(this.editPersonButton);
            this.Controls.Add(this.personsListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(475, 385);
            this.MinimumSize = new System.Drawing.Size(475, 385);
            this.Name = "MainForm";
            this.Text = "PhoneBook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox personsListBox;
        private System.Windows.Forms.Button editPersonButton;
        private System.Windows.Forms.Button NewPersonButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button deleteButton;
    }
}

