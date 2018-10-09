using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberLife.Platform.World_content;

namespace CyberLife.Simple2DWorld
{
    class PhenomenaFabrica: IPhenomenaFabrica
    {
        private string _sunPhenomenTypeName;
        private string _seasonsPhenomenTypeName;
        private string _mineralPhenomenTypeName;


        
        /// <summary>
        ///  Воссоздает природное явление из Simple2DWorld из его метаданных
        /// </summary>
        /// <param name="phenomenMetadata">Метаданные природного явления</param>
        /// <returns></returns>
        public IPhenomen ReconstructPhenomen(PhenomenMetadata phenomenMetadata)
        {
            string name = phenomenMetadata.Name;
            if (name == _sunPhenomenTypeName)
            {
                return new SunPhenomen(phenomenMetadata.Place);
            }
            else if (name == _seasonsPhenomenTypeName)
            {
                return  new SeasonsPhenomen();
            }
            else if (name == _mineralPhenomenTypeName)
            {
                return  new MineralsPhenomen(phenomenMetadata.Place);
            }
            else
            {
                throw  new ArgumentException("The phenomenMetadata describing phenomen isn't be contained in Simple2DWorld.",
                    nameof(phenomenMetadata));
            }

        }
            
    




        /// <summary>
        /// Инициализирует экземпляр фабрики природных явлений
        /// </summary>
        public PhenomenaFabrica()
        {
            _mineralPhenomenTypeName = typeof(MineralsPhenomen).Name;
            _sunPhenomenTypeName = typeof(SunPhenomen).Name;
            _seasonsPhenomenTypeName = typeof(SeasonsPhenomen).Name;
        }
    }
}
