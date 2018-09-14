using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
    }
}
