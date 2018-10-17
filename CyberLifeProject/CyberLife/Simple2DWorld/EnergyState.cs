using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    enum EnergyStates
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

        /// <summary>
        /// получает флаг бота на основании текущей энергии бота
        /// </summary>
        /// <returns></returns>
        private EnergyStates GetState(BotLifeForm bot)
        {
            EnergyStates flag;
                if (Value < 0)
                {
                   flag = EnergyStates.Dead;
                    bot._isDead = true;
                    return flag;
                }
                if (Value >= MaxEnergy)
                {
                    flag = EnergyStates.EnergyCollapse;
                    _isDead = true;
                    return flag;
                }
                if (Value >= MaxEnergy * 0.9)
                {
                    flag = EnergyStates.ForsedReproduction;
                    return flag;
                }
                if (Value >= 500)
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
            _isDead = false;
        }


        public EnergyState(StateMetadata metadata) : base(metadata)
        {
            _isDead = false;
        }

        #endregion
    }
}
