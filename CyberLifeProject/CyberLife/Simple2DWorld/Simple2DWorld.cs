using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberLife.Platform.Logging.LogMessages;
using CyberLife.Platform.World_content;

namespace CyberLife.Simple2DWorld
{
    class Simple2DWorld : World
    {
        #region fields

        private Dictionary<Int64, LifeForm> _organic;

        #endregion


        #region properties


        #endregion


        #region methods

        /// <summary>
        /// Получает окружающую среду для первичной инициализации Simple2DWorld
        /// </summary>
        /// <param name="width">Ширина карты</param>
        /// <param name="height">Высота карты</param>
        /// <returns>Инициализированная окружающая среда</returns>
        private static Environment _getEnvironment(int width, int height)
        {
            MapSize mapsize = new MapSize(width, height);
            SunPhenomen sun = new SunPhenomen(mapsize);
            MineralsPhenomen minerals = new MineralsPhenomen(mapsize);
            SeasonsPhenomen seasons = new SeasonsPhenomen();
            List<IPhenomen> phenomens = new List<IPhenomen>(3) { seasons, minerals, sun };
            return new Environment(phenomens, mapsize);
        }



        /// <summary>
        /// Получает список форм жизни "Бот" для первичной инициализации 
        /// Simple2DWorld
        /// </summary>
        /// <param name="count">Число форм жизни</param>
        /// <param name="width">Ширина карты</param>
        /// <param name="height">Высота карты</param>
        /// <returns></returns>
        private static List<LifeForm> _getLifeForms(int count, int width, int height)
        {
            MapSize mapsize = new MapSize(width, height);
            List<LifeForm> lifeForms = new List<LifeForm>(count);
            for (int i = 0; i < count; i++)
            {
                lifeForms.Add(new BotLifeForm(mapsize));
            }

            return lifeForms;
        }



        /// <summary>
        /// Инициализирует базовые реакции Simple2DWorld
        /// </summary>
        private void _InitReactions()
        {
            if (_reactions == null)
                _reactions = new Dictionary<string, ReactionDelegate>();
            if (_reactions.Count > 0)
                return;

            _reactions.Add("EnergyReaction",_energyReaction);
            _reactions.Add("GenotypeReaction",_genotypeReaction);
            _reactions.Add("ColorReaction", _colorReaction);
        }



        /// <summary>
        /// Реакция, отвечающая за изменение состояния 
        /// EnergyState у форм жизни
        /// </summary>
        /// <param name="world">Обрабатываемый мир</param>
        private static void _energyReaction(World world)
        {

        }



        private static void _genotypeReaction(World world)
        {

        }



        private static void _colorReaction(World world)
        {

        }

        #endregion


        #region constructors

        /// <inheritdoc />
        /// <summary>
        /// Инициализирует Simple2DWorld из заданных параметров
        /// </summary>
        /// <param name="name">Название мира</param>
        /// <param name="environment">Окружающая среда мира</param>
        /// <param name="visualizer">Визуализатор для мира</param>
        /// <param name="lifeForms">Формы жизни</param>
        /// <param name="organic">"мертвые" формы жизни, являющиеся органикой</param>
        public Simple2DWorld(string name, Environment environment, IVisualizer visualizer, List<LifeForm> lifeForms, List<LifeForm> organic) :
            base(name, environment, visualizer, lifeForms)
        {
            log.Trace(LogMetadataMessages.Constructor, "Simple2DWorld");

            _organic = new Dictionary<Int64, LifeForm>();
            if (organic != null)
            {
                foreach (var lifeForm in organic)
                {
                    _organic.Add(lifeForm.Id, lifeForm);
                }
            }
                
            log.Info("Кол-во органики " + _organic.Count.ToString());

            _InitReactions();
            log.Trace(LogMetadataMessages.OkConstructor, "Simple2DWorld");

        }


        /// <inheritdoc />
        /// <summary>
        /// Инициализирует Simple2DWorld из метаданных и фабрики природных явлений
        /// </summary>
        /// <param name="metadata">Метаданные мра</param>
        /// <param name="phenomenaFabrica">Фабрика природных явлений для разбора природных явлений мира</param>
        public Simple2DWorld(Simple2DWorldMetadata metadata, IPhenomenaFabrica phenomenaFabrica) : base(metadata, phenomenaFabrica)
        {
            log.Trace(LogMetadataMessages.Constructor, "Simple2DWorld");
            _organic = new Dictionary<long, LifeForm>(metadata.OrganicMetadata.Count);
            foreach (var organicMetadataPair in metadata.OrganicMetadata)
            {
                
                _organic.Add(organicMetadataPair.Key, new LifeForm(organicMetadataPair.Value));                
            }
            log.Info("Кол-во органики " + _organic.Count.ToString());

            _InitReactions();
            log.Trace(LogMetadataMessages.OkConstructor, "Simple2DWorld");

        }


        /// <summary>
        /// Производит первичную инициализацию мира
        /// </summary>
        /// <param name="width">Ширина карты мира</param>
        /// <param name="height">Высота карты мира</param>
        /// <param name="lifeFormCount">Количество форм жизни</param>
        public Simple2DWorld(int width = 1000, int height = 1000, int lifeFormCount = 100 ):
            this("Simple2DWorld",_getEnvironment(width, height), new RemoteVisualizer(), _getLifeForms(lifeFormCount, width, height), null  )
        {
           
            _InitReactions();
            log.Trace(LogMetadataMessages.OkConstructor, "Simple2DWorld");
        }
        #endregion
    }
}
