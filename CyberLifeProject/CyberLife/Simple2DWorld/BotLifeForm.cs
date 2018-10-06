﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    public class BotLifeForm: LifeForm
    {
        #region fields

        #endregion


        #region properties

        #endregion


        #region methods

        /// <summary>
        /// Получает состояния, неоходимые для инициализации бота
        /// </summary>
        /// <returns>Состояния формы жизни "Бот"</returns>
        public static Dictionary<string, LifeFormState> _getStates(long id)
        {
            EnergyState energy = new EnergyState("EnergyState", 300);
            GenotypeState genotype = new GenotypeState("GenotypeState", 0,id);
            ColorState color = new ColorState("ColorState", 0 ,id,ColorType.Default);
            Dictionary<string, LifeFormState> states = new Dictionary<string, LifeFormState>(3)
            {
                {"EnergyState", energy},
                {"GenotypeState", genotype},
                {"ColorState", color}
            };
            return states;
        }

        #endregion


        #region constructors

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
        /// Инициирует бота базовыми состояниями и случайной точкой на карте.
        /// </summary>
        /// <param name="mapsize">Размер карты</param>
        public BotLifeForm(MapSize mapsize,long id):this(Place.RandomPlace(mapsize), _getStates(id))
        {

        }

        #endregion
    }
}
