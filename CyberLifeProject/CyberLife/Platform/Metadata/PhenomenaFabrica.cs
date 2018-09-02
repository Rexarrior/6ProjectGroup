using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using CyberLife.Platform.Logging.LogMessages;
namespace CyberLife
{
    /// <summary>
    /// Класс, предназначенный для восстановления природных явлений из их метаданных.
    /// Пока никак не реализован
    /// </summary>
    public class PhenomenaFabrica
    {
        Logger log = LogManager.GetCurrentClassLogger();

        public virtual IPhenomen ReconstructPhenomen(PhenomenMetadata phenomenMetadata)
        {
            throw new NotImplementedException();
        }

        public static object PhenomenFromString(string pairValue)
        {
            throw new NotImplementedException();
        }
    }
}