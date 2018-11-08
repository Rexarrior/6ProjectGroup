﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    public class BotLifeForm : LifeForm
    {
        Random rnd = new Random();
        #region fields

        private List<byte> _genom;
        private Color _color;
        private Queue<Actions> _lastEnergyActions;
        private byte _YTK;
        private Directions _direction;
        private Actions _action;
        private bool _dead;
        private EnergyStates _energyState;
        private int _energy;

        #endregion


        #region properties

        public List<byte> Genom { get => _genom; set => _genom = value; }
        public Color Color { get => _color; set => _color = value; }
        public Queue<Actions> LastEnergyActions { get => _lastEnergyActions; set => _lastEnergyActions = value; }
        public byte YTK { get => _YTK; set => _YTK = value; }
        public Directions Direction { get => _direction; set => _direction = value; }
        public Actions Action { get => _action; set => _action = value; }
        public bool Dead { get => _dead; set => _dead = value; }
        public EnergyStates EnergyState { get => _energyState; set => _energyState = value; }
        public int Energy { get => _energy; set => _energy = value; }

        #endregion


        #region methods

        public List<byte> GetCommonGenom()
        {
            List<byte> Genom = new List<byte> { };
            //{ 6,6,4,5,5,6,3,3,6,5,2,3,6,4,4,4,3,4,2,2,5,3,4,4,3,5,3,4,4,6,3,2,4,2,5,5,3,6,2,6,6,4,6,2,5,4,2,4,2,2,4,5,2,3,6,4,4,2,4,2,5,6,5,6 };
            List<int> workingList = Enumerable.Repeat(2, 10)
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


        #endregion


        #region constructors

        /// <inheritdoc />
        /// <summary>
        /// Инициализирует форму жизни "Бот"
        /// </summary>
        /// <param name="place">Пространство, занимаемое ботом</param>
        /// <param name="states">Состояния бота</param>
        public BotLifeForm(Point point, BotLifeForm byBot = null) : base(point)
        {
            Dead = false;
            if (byBot == null)
            {
                Genom = GetCommonGenom();
                LastEnergyActions = new Queue<Actions> { };
            }
            else
            {
                LastEnergyActions = new Queue<Actions> { };
                if (byBot.LastEnergyActions.Count != 0)
                {
                    LastEnergyActions.Enqueue(byBot.LastEnergyActions.Peek());
                }
                Genom = new List<byte> { };
                foreach (byte i in byBot.Genom)
                {
                    Genom.Add(i);
                }
                Color = byBot.Color;
            }
            const byte mutationPercent = 100;
            if (rnd.Next(1, (100 / mutationPercent) + 1) == 1)
            {
                Genom[rnd.Next(0, 64)] = (Byte)rnd.Next(0, 64);
            }
            Energy = 300;
        }


        /// <summary>
        /// Инициирует бота базовыми состояниями и случайной точкой на карте.
        /// </summary>
        /// <param name="mapsize">Размер карты</param>
        public BotLifeForm(MapSize mapsize,Dictionary<Point,LifeForm> bots, BotLifeForm byBot = null) : this(Point.RandomPoint(mapsize,bots), byBot)
        {

        }

        #endregion
    }
}
