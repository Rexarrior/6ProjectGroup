﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using CyberLife.Simple2DWorld;

namespace CyberLife
{
    class Program
    {

        static void Main(string[] args)
        {
            Logger log = LogManager.GetCurrentClassLogger();
            log.Debug("Начало работы");
            Simple2DWorld.Simple2DWorld world = new Simple2DWorld.Simple2DWorld(1000,1000, 5000);
            IVisualizer visualizer = new Simple2dVisualizer();
            world.Visualizer = visualizer;
            MainForm mainForm = new MainForm(world);
            mainForm.ShowDialog();    
        }
    }
}
