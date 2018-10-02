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
    }
    class EnergyState : LifeFormState
    {
        private const int maxEnergy = 1500;
        private Flags _state;

        public void Update(WorldMetadata metadata)
        {
            _state = GetState();            
        }
        public Flags GetState()
        {
            Flags flag;
            if (Value < 0)
            {
                flag = Flags.Dead;
                return flag;
            }
            if(Value >= maxEnergy)
            {
                flag = Flags.EnergyCollapse;
            }
            if (Value >= maxEnergy * 0.9)
            {
                flag = Flags.ForsedReproduction;
                return flag;
            }
            if (Value >= 500)
            {
                flag = Flags.CanReproduce;
                return flag;
            }
            throw new ArgumentException("Пустой экземпляр flag,энергия была равна "+Value);
        }

        public override StateMetadata GetMetadata()
        {
            StateMetadata metadata = base.GetMetadata();
            if (_state == Flags.EnergyCollapse)
                metadata.Add(Flags.Dead.ToString(), "true");
            metadata.Add(_state.ToString(), "true");
            return metadata;
        }
        public EnergyState(string name, double value, Dictionary<string, string> Params = null) : base(name, value, Params)
        {

        }

        public EnergyState(StateMetadata metadata) : base(metadata)
        {

        }
    }
}
