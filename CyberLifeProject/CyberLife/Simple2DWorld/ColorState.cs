﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    public enum ColorType
    {
        Default = 0,
        EnergyDisplay = 1
    }

    class ColorState : LifeFormState
    {
        #region fields

        private ColorType _colorType;

        #endregion


        #region properties

        public ColorType ColorType
        {
            get { return _colorType; }
            set { _colorType = value; }
        }

        #endregion


        #region methods

        /// <summary>
        /// Обновляет информацию о последних действиях получения энергии формы жизни
        /// </summary>
        /// <param name="worldMetadata"></param>
        public override void Update(Simple2DWorld world)
        {
            foreach (BotLifeForm bot in world.LifeForms.Values)
            {
                if (!bot.Dead)
                {
                    if (bot.LastEnergyActions.Count >= 20)
                        bot.LastEnergyActions.Dequeue();
                    SetRGB(bot);
                }
                else
                {
                    bot.Color = Color.FromArgb(132, 132, 132);
                }
            }
        }



        /// <summary>
        /// Устанавливает RGB в соответствии с последними действиями формы жизни
        /// </summary>
        public void SetRGB(BotLifeForm bot)
        {
            const int MaxBotEnergy = 10000;
            byte R = 0;
            byte G = 0;
            byte B = 0;
            byte part = 0;
            switch (_colorType)
            {
                case ColorType.Default:
                    foreach (Actions Action in bot.LastEnergyActions)
                    {
                        switch (Action)
                        {
                            case Actions.Extraction:
                                B++;
                                break;
                            case Actions.Photosynthesis:
                                G++;
                                break;
                            case Actions.Eat:
                                R++;
                                break;
                        }
                    }
                    if (R < 0 || G < 0 || B < 0)
                        throw new ArgumentException("Один из параметров RGB был отрицательным");
                    if (R + G + B != 0)
                        part = Convert.ToByte(255 / (R + G + B));
                    bot.Color = Color.FromArgb((part * R), (part * G), (part * B));
                    break;
                case ColorType.EnergyDisplay:
                    R = 255;
                    G = (byte)(255 - (bot.Energy / (double)MaxBotEnergy) * 255);
                    bot.Color = Color.FromArgb(R, G, B);
                    break;
            }
        }

        #endregion


        #region constructors

        public ColorState(string name, double value, ColorType colorType) : base(name, value)
        {
            this._colorType = colorType;
        }


        #endregion
    }
}