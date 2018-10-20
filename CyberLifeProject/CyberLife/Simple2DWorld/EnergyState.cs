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
        public const int MaxEnergy = 1500;

        #region fields

        #endregion


        #region properties

        #endregion


        #region methods

        public override void Update(Simple2DWorld world)
        {
            foreach(BotLifeForm bot in world.LifeForms.Values)
            {
                bot._energyState = GetState(bot);
            }
        }

        /// <summary>
        /// получает флаг бота на основании текущей энергии бота
        /// </summary>
        /// <returns></returns>
        private EnergyStates GetState(BotLifeForm bot)
        {
            EnergyStates flag;
                if (bot._energy < 0)
                {
                   flag = EnergyStates.Dead;
                    bot._dead = true;
                    return flag;
                }
                if (bot._energy >= MaxEnergy)
                {
                    flag = EnergyStates.EnergyCollapse;
                    bot._dead = true;
                    return flag;
                }
                if (bot._energy >= MaxEnergy * 0.9)
                {
                    flag = EnergyStates.ForsedReproduction;
                    return flag;
                }
                if (bot._energy >= 500)
                {
                    flag = EnergyStates.CanReproduce;
                    return flag;
                }
                flag = EnergyStates.Alive;
                return flag;
            
        }

        #endregion


        #region constructors

        public EnergyState(string name, double value, Dictionary<string, string> Params = null) : base(name, value, Params)
        {

        }

        #endregion
    }
}
