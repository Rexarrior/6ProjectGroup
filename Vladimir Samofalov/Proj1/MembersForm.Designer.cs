namespace Proj1
{
    partial class MembersForm
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
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.firstName_tb = new System.Windows.Forms.TextBox();
            this.LastName_tb = new System.Windows.Forms.TextBox();
            this.number_tb = new System.Windows.Forms.TextBox();
            this.info_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(12, 169);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 0;
            this.save_btn.Text = "Сохранить";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(244, 169);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // firstName_tb
            // 
            this.firstName_tb.Location = new System.Drawing.Point(47, 12);
            this.firstName_tb.Name = "firstName_tb";
            this.firstName_tb.Size = new System.Drawing.Size(104, 20);
            this.firstName_tb.TabIndex = 2;
            // 
            // LastName_tb
            // 
            this.LastName_tb.Location = new System.Drawing.Point(219, 12);
            this.LastName_tb.Name = "LastName_tb";
            this.LastName_tb.Size = new System.Drawing.Size(100, 20);
            this.LastName_tb.TabIndex = 3;
            // 
            // number_tb
            // 
            this.number_tb.Location = new System.Drawing.Point(113, 41);
            this.number_tb.Name = "number_tb";
            this.number_tb.Size = new System.Drawing.Size(206, 20);
            this.number_tb.TabIndex = 4;
            // 
            // info_tb
            // 
            this.info_tb.Location = new System.Drawing.Point(15, 88);
            this.info_tb.Multiline = true;
            this.info_tb.Name = "info_tb";
            this.info_tb.Size = new System.Drawing.Size(304, 75);
            this.info_tb.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Информация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Номер Телефона";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Имя";
            // 
            // MembersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 201);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.info_tb);
            this.Controls.Add(this.number_tb);
            this.Controls.Add(this.LastName_tb);
            this.Controls.Add(this.firstName_tb);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.save_btn);
            this.Name = "MembersForm";
            this.Load += new System.EventHandler(this.MembersForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox firstName_tb;
        private System.Windows.Forms.TextBox LastName_tb;
        private System.Windows.Forms.TextBox number_tb;
        private System.Windows.Forms.TextBox info_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}