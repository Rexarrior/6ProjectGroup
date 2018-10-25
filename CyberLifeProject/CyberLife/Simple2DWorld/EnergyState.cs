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
                    log.Info("Бот умер от недостатка энергии,его энергия "+ bot._energy+"его id "+bot.Id);
                    flag = EnergyStates.Dead;
                    bot._dead = true;
                    return flag;
                }
                if (bot._energy >= MaxEnergy)
                {
                log.Info("Бот умер от переизбытка энергии,его энергия " + bot._energy + "его id " + bot.Id);
                flag = EnergyStates.EnergyCollapse;
                    bot._dead = true;
                    return flag;
                }
                if (bot._energy >= MaxEnergy * 0.8)
                {
                    flag = EnergyStates.ForsedReproduction;
                    return flag;
                }
                if (bot._energy >= MaxEnergy* 0.3)
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
