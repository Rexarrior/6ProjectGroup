﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    public class BotLifeForm: LifeForm
    {
        Random rnd = new Random();
        #region fields

        public List<byte> _genom;
        public Color _color;
        public  Queue<Actions> _lastEnergyActions;
        public byte YTK;
        public Directions _direction;
        public Actions _action;
        public bool _dead;
        public EnergyStates _energyState;
        public int _energy;

        #endregion


        #region properties

        #endregion


        #region methods

        public List<byte> GetCommonGenom()
        {
            List<byte> Genom =new List<byte> { };
            List<int> workingList = Enumerable.Repeat(1, 10)
                                  .Concat(Enumerable.Repeat(2, 10))
                                  .Concat(Enumerable.Repeat(3, 10))
                                  .Concat(Enumerable.Repeat(4, 10))
                                  .Concat(Enumerable.Repeat(5, 10))
                                  .Concat(Enumerable.Repeat(6, 14)).ToList();
            foreach (int i in workingList)
            {
                Genom.Add(Convert.ToByte(i));
            }
            return Genom;
        }

        public override void Update(World world)
        {
            //todo
        }

        #endregion


        #region constructors

        /// <inheritdoc />
        /// <summary>
        /// Инициализирует форму жизни "Бот"
        /// </summary>
        /// <param name="place">Пространство, занимаемое ботом</param>
        /// <param name="states">Состояния бота</param>
        public BotLifeForm(Place place, long id, BotLifeForm byBot = null) : base(place,id)
        {
            _dead = false;
            if (byBot == null)
            {
                _genom = GetCommonGenom();
                _lastEnergyActions = new Queue<Actions> { };
            }
            else
            {
                _lastEnergyActions = byBot._lastEnergyActions;
                _genom = byBot._genom;
                _color = byBot._color;
            }
            const byte mutationPercent = 10;
            if (rnd.Next(1, (100 / mutationPercent) + 1) == 1)
            {
                _genom[rnd.Next(0, 64)] = (Byte)rnd.Next(0, 64);
            }
            _energy = 300;
        }


        /// <summary>
        /// Инициирует бота базовыми состояниями и случайной точкой на карте.
        /// </summary>
        /// <param name="mapsize">Размер карты</param>
        public BotLifeForm(MapSize mapsize,long id, BotLifeForm byBot = null) :this(Place.RandomPlace(mapsize),id,byBot)
        {

        }

        #endregion
    }
}
