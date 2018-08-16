namespace Proj1
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
            this.newMember_btn = new System.Windows.Forms.Button();
            this.ChangeMember_btn = new System.Windows.Forms.Button();
            this.Members_list = new System.Windows.Forms.ListBox();
            this.search_tb = new System.Windows.Forms.TextBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newMember_btn
            // 
            this.newMember_btn.Location = new System.Drawing.Point(3, 304);
            this.newMember_btn.Name = "newMember_btn";
            this.newMember_btn.Size = new System.Drawing.Size(101, 23);
            this.newMember_btn.TabIndex = 0;
            this.newMember_btn.Text = "Новый контакт";
            this.newMember_btn.UseVisualStyleBackColor = true;
            this.newMember_btn.Click += new System.EventHandler(this.newMember_btn_Click);
            // 
            // ChangeMember_btn
            // 
            this.ChangeMember_btn.Location = new System.Drawing.Point(185, 304);
            this.ChangeMember_btn.Name = "ChangeMember_btn";
            this.ChangeMember_btn.Size = new System.Drawing.Size(75, 23);
            this.ChangeMember_btn.TabIndex = 1;
            this.ChangeMember_btn.Text = "Изменить";
            this.ChangeMember_btn.UseVisualStyleBackColor = true;
            this.ChangeMember_btn.Click += new System.EventHandler(this.ChangeMember_btn_Click);
            // 
            // Members_list
            // 
            this.Members_list.FormattingEnabled = true;
            this.Members_list.Location = new System.Drawing.Point(3, 34);
            this.Members_list.Name = "Members_list";
            this.Members_list.Size = new System.Drawing.Size(257, 264);
            this.Members_list.TabIndex = 2;
            // 
            // search_tb
            // 
            this.search_tb.Location = new System.Drawing.Point(109, 8);
            this.search_tb.Name = "search_tb";
            this.search_tb.Size = new System.Drawing.Size(151, 20);
            this.search_tb.TabIndex = 3;
            this.search_tb.TextChanged += new System.EventHandler(this.search_tb_TextChanged);
            // 
            // search_btn
            // 
            this.search_btn.Location = new System.Drawing.Point(3, 6);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(75, 23);
            this.search_btn.TabIndex = 4;
            this.search_btn.Text = "Поиск";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 333);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.search_tb);
            this.Controls.Add(this.Members_list);
            this.Controls.Add(this.ChangeMember_btn);
            this.Controls.Add(this.newMember_btn);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newMember_btn;
        private System.Windows.Forms.Button ChangeMember_btn;
        private System.Windows.Forms.ListBox Members_list;
        private System.Windows.Forms.TextBox search_tb;
        private System.Windows.Forms.Button search_btn;
    }
}

