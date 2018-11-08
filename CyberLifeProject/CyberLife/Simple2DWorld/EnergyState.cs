using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    public enum EnergyStates
    {
        Dead,
        CanReproduce,
        ForsedReproduction,
        EnergyCollapse,
        Alive
    }
    class EnergyState : LifeFormState
    {
        Logger log = LogManager.GetCurrentClassLogger();
        public const int MaxEnergy = 10000;

        #region fields

        #endregion


        #region properties

        #endregion


        #region methods

        public override void Update(Simple2DWorld world)
        {
            foreach (BotLifeForm bot in world.LifeForms.Values)
            {
                bot.EnergyState = GetState(bot);
            }
        }

        /// <summary>
        /// получает флаг бота на основании текущей энергии бота
        /// </summary>
        /// <returns></returns>
        private EnergyStates GetState(BotLifeForm bot)
        {
            EnergyStates flag;
            if (bot.Energy < 0)
            {
                flag = EnergyStates.Dead;
                bot.Dead = true;
                return flag;
            }
            if (bot.Energy >= MaxEnergy)
            {
                flag = EnergyStates.EnergyCollapse;
                bot.Dead = true;
                return flag;
            }
            if (bot.Energy >= MaxEnergy * 0.8)
            {
                flag = EnergyStates.ForsedReproduction;
                return flag;
            }
            if (bot.Energy >= MaxEnergy * 0.3)
            {
                flag = EnergyStates.CanReproduce;
                return flag;
            }
            flag = EnergyStates.Alive;
            return flag;

        }

        #endregion


        #region constructors

        public EnergyState(string name, double value) : base(name, value)
        {

        }

        #endregion
    }
}
