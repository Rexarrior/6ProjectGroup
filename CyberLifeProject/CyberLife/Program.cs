using System;
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
        /*
         Известные баги:
         Не работает отображение на форму,нужен отдельный поток для формы
         Необходимо исправить отображение органики при ColorType.EnergyDisplay,на данный момент такой бот отображается как живой
         Не реализовано отображение органики
         ...
        */
        static void Main(string[] args)
        {

            Logger log = LogManager.GetCurrentClassLogger();
            log.Debug("Начало работы");
            Simple2DWorld.Simple2DWorld world = new Simple2DWorld.Simple2DWorld(100, 100, 300);
            IVisualizer visualizer = new Simple2dVisualizer();
            world.Visualizer = visualizer;
            MainForm mainForm = new MainForm(world);
            mainForm.ShowDialog();    
        }
    }
}
