using CyberLife.Platform.World_content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberLife.Simple2DWorld
{
    public partial class MainForm : Form
    {
        public MainForm(Bitmap bitmap)
        {
            this.Width = bitmap.Width;
            this.Height = bitmap.Height;
            mapPicture.Width = bitmap.Width;
            mapPicture.Height = bitmap.Height;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
