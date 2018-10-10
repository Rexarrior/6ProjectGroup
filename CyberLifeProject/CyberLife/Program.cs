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
         Метод ColorState.Update вызывается с несуществующим id
         Коллективные вымирания.Наблюдаются при энергии менее 500.У всего мира перестаёт прибавляться энергия.Энергия уходит без действий
         Форма жизни приобретает цвет в соответствии с геномом,а не последними её действиями.Нужно выделить и передавать доп параметри при фотосинтезе,минералах,и поедании других ботов
         Не работает отображение на форму,нужен отдельный поток для формы
         Необходимо исправить отображение органики при ColorType.EnergyDisplay,на данный момент такой бот отображается как живой
         Не реализовано отображение органики
         ...
        */
        static void Main(string[] args)
        {

            Logger log = LogManager.GetCurrentClassLogger();
            log.Debug("Начало работы");
            Simple2DWorld.Simple2DWorld world = new Simple2DWorld.Simple2DWorld(100, 100, 20);
            IVisualizer visualizer = new Simple2dVisualizer();
            world.Visualizer = visualizer;
            while (true)
            {
                world.Update();
               
            }
            Console.Read();
        }
    }
}
