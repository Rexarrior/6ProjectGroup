using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeButtonSample
{
    public partial class Form1 : Form
    {
        private List<Button> buttons;
        public Form1()
        {
            InitializeComponent();
            buttons = new List<Button>();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Button button = new Button();
            button.Location = buttons.Count == 0 ? new Point(13, 13) :
                new Point(buttons.Last().Location.X, buttons.Last().Location.Y + 30);
            button.Name = $"button{buttons.Count}";
            button.Size = new Size(210, 20);
            
            button.TabIndex = buttons.Count + 2; // Because tabIndex 1 for AddButton and tab index count from 1. 
            button.Text = $"Button № {buttons.Count}";
            button.UseVisualStyleBackColor = true;
            button.Click += MakedButtonClick;
            buttons.Add(button);
            makedButtonPanel.Controls.Add(button);
        }



        private void MakedButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show($"Button {((Button) sender).Name} clicked.");
        }
    }
}
