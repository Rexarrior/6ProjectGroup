using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    class BotLifeForm: LifeForm
    {
        
        /// <inheritdoc />
        /// <summary>
        /// Инициализирует форму жизни "Бот"
        /// </summary>
        /// <param name="place">Пространство, занимаемое ботом</param>
        /// <param name="states">Состояния бота</param>
        public BotLifeForm(Place place, Dictionary<string, LifeFormState> states) : base(place, states)
        {

        }




        /// <inheritdoc />
        /// <summary>
        /// Инициализирует форму жизни "бот" из ее метаданных
        /// </summary>
        /// <param name="metadata">Метаданные Бота</param>
        public BotLifeForm(LifeFormMetadata metadata) : base(metadata)
        {
            //TODO check metadata.
        }



        /// <summary>
        /// Получает состояния, неоходимые для инициализации бота
        /// </summary>
        /// <returns>Состояния формы жизни "Бот"</returns>
        private static Dictionary<string, LifeFormState> _getStates()
        {
            EnergyState energy = new EnergyState("EnergyState", 0);
            GenotypeState genotype = new GenotypeState("GenotypeState", 0);
            ColorState color = new ColorState("ColorState", 0);
            Dictionary<string, LifeFormState> states = new Dictionary<string, LifeFormState>(3)
            {
                {"EnergyState", energy},
                {"GenotypeState", genotype},
                {"ColorState", color}
            };
            return states;
        }



        /// <summary>
        /// Инициирует бота базовыми состояниями и случайной точкой на карте.
        /// </summary>
        /// <param name="mapsize">Размер карты</param>
        public BotLifeForm(MapSize mapsize):this(Place.RandomPlace(mapsize), _getStates())
        {

        }
    }





    //Заглушки
    internal class EnergyState:LifeFormState
    {
        public EnergyState(string name, double value, Dictionary<string, string> Params = null) : base(name, value, Params)
        {
        }

        public EnergyState(StateMetadata metadata) : base(metadata)
        {
        }
    }
    internal class GenotypeState : LifeFormState
    {
        public GenotypeState(string name, double value, Dictionary<string, string> Params = null) : base(name, value, Params)
        {
        }

        public GenotypeState(StateMetadata metadata) : base(metadata)
        {
        }
    }
    /*
    internal class ColorState : LifeFormState
    {
        public ColorState(string name, double value, Dictionary<string, string> Params = null) : base(name, value, Params)
        {
        }

        public ColorState(StateMetadata metadata) : base(metadata)
        {
        }
        
    }*/
}
