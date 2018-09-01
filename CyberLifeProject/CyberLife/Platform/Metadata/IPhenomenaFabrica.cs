using System;
using System.Collections.Generic;
using System.Linq;
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