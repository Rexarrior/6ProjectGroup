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
using System.Threading;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.IO;

namespace CyberLife.Simple2DWorld
{
    public partial class MainForm : Form
    {
        public class CustomPictureBox : PictureBox
        {
            private InterpolationMode interpolationMode = InterpolationMode.NearestNeighbor;

            public InterpolationMode InterpolationMode
            {
                get => interpolationMode;
                set
                {
                    interpolationMode = value;
                    this.Invalidate(); 
                }
            }

            protected override void OnPaint(PaintEventArgs pe)
            {
                pe.Graphics.InterpolationMode = interpolationMode;
                base.OnPaint(pe);
            }
        }

        public bool IsLoading;
        Simple2DWorld world;
        bool colortype = true;
        delegate void Changed(string str, Bitmap map);
        Changed changed;
        public MainForm(World simple2DWorld)
        {
            world = (Simple2DWorld)simple2DWorld;
            InitializeComponent();
            mapPicture2.Height = world.Size.Height;
            mapPicture2.Width = world.Size.Width;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            while (true)
            {
                mapPicture2.Width++;
                mapPicture2.Height++;
                if (mapPicture2.Width + 500 > this.Width || mapPicture2.Height + 100 > this.Height)
                {
                    mapPicture2.Width--;
                    mapPicture2.Height--;
                    break;
                }
            }

        }


        public void UpdateMap()
        {
            while (true)
            {
                world.Update();
                Invoke("Кол-во форм жизни " + world.LifeForms.Count.ToString() +
                    "\r\nКол-во органики " + world.Organic.Count.ToString() +
                    "\r\nТекущий ход " + world.Age.ToString() +
                    "\r\nТекущий сезон " + ((SeasonsPhenomen)world.NaturalPhenomena["SeasonsPhenomen"]).CurSeason.ToString(), ((Simple2dVisualizer)world.Visualizer).Map);

            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(UpdateMap);
            thread.Priority = ThreadPriority.Highest;
            thread.Start();

        }

        public void Invoke(string str, Bitmap map)
        {
            changed = new Changed(Change);

            statsLabel.Invoke(changed, new object[] { str, map });
        }
        public void Change(string str, Bitmap map)
        {
            statsLabel.Text = str;
            mapPicture2.Image = map;

        }
        private void ColorTypeButton_Click(object sender, EventArgs e)
        {
            if (colortype)
            {
                colortype = false;
                ((ColorState)world.States["ColorState"]).ColorType = ColorType.EnergyDisplay;
            }
            else
            {
                colortype = true;
                ((ColorState)world.States["ColorState"]).ColorType = ColorType.Default;
            }

        }

    }
}
