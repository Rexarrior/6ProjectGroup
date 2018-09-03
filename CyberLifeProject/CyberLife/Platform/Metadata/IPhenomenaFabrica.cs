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
    public interface IPhenomenaFabrica
    {


        IPhenomen ReconstructPhenomen(PhenomenMetadata phenomenMetadata);


    }
}