using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    enum Flags
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

        private Flags _state;
        private bool _isDead;

        #endregion


        #region properties

        public bool IsDead { get => _isDead; }
        internal Flags State { get => _state;}

        #endregion


        #region methods

        /// <summary>
        /// Обновляет флаги энергии бота 
        /// </summary>
        /// <param name="metadata"></param>
        public void Update(WorldMetadata metadata)
        {
            if (!_isDead)
                _state = GetState();            
        }


        /// <summary>
        /// получает флаг бота на основании текущей энергии бота
        /// </summary>
        /// <returns></returns>
        public Flags GetState()
        {
            Flags flag;
            if (Value < 0)
            {
                flag = Flags.Dead;
                _isDead = true;
                return flag;
            }
            if(Value >= MaxEnergy)
            {
                flag = Flags.EnergyCollapse;
                _isDead = true;
                return flag;
            }
            if (Value >= MaxEnergy * 0.9)
            {
                flag = Flags.ForsedReproduction;
                return flag;
            }
            if (Value >= 500)
            {
                flag = Flags.CanReproduce;
                return flag;
            }
            flag = Flags.Alive;
            return flag;
        }



        public override StateMetadata GetMetadata()
        {
            StateMetadata metadata = base.GetMetadata();
            if (_state == Flags.EnergyCollapse)
                metadata.Add(Flags.Dead.ToString(), "true");
            metadata.Add(_state.ToString(), "true");
            return metadata;
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
