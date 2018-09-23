using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    public enum Directions
    {
        TopLeft = 1,
        Top,
        TopRight,
        Right,
        BottomRight,
        Bottom,
        BottomLeft,
        Left = 8,

        None = 0
    }
    public enum Actions
    {
        CheckEnergy = 1,
        Photosynthesis,
        Move,
        Eat,
        DoDescendant,
        ForsedReproduction = 6,
        None = 0
    }
/*
 Команда 1 = проверить энергию
 Команда 2 = фотосинтез
 Команда 3 = передвижение
 Команда 4 = съесть
 Команда 5 = отпочковать потомка
 Команда 6 = ForsedReproduction
*/
    public class GenotypeState : LifeFormState
    {
        #region fields

        Directions direction;
        Actions action;
        private byte YTK;
        private List<byte> Genom;
        public long id;

        #endregion

        #region properties

        #endregion

        #region methods
        
        public void Update(WorldMetadata metadata)
        {
            if (metadata[id]["EnergyState"]["EnergyState"] == "ForsedReproduction")
            {
                action = Actions.ForsedReproduction;
                NextStep();
            }
            else
            {
                switch (Genom[YTK])
                {
                    case 1:
                        action = Actions.CheckEnergy;
                        NextStep();
                        direction = (Directions)Enum.Parse(typeof(Directions), Enum.GetNames(typeof(Directions))[(byte)Genom[YTK] / 8]);
                        break;
                    case 2:
                        action = Actions.Photosynthesis;
                        break;
                    case 3:
                        action = Actions.Move;
                        NextStep();
                        direction = (Directions)Enum.Parse(typeof(Directions), Enum.GetNames(typeof(Directions))[(byte)Genom[YTK] / 8]);
                        break;
                    case 4:
                        action = Actions.Eat;
                        NextStep();
                        direction = (Directions)Enum.Parse(typeof(Directions), Enum.GetNames(typeof(Directions))[(byte)Genom[YTK] / 8]);
                        break;
                    case 5:
                        if (metadata[id]["EnergyState"]["EnergyState"] == "CanReproduce")
                        {
                            action = Actions.DoDescendant;
                            NextStep();
                            direction = (Directions)Enum.Parse(typeof(Directions), Enum.GetNames(typeof(Directions))[(byte)Genom[YTK] / 8]);
                        }
                        else
                        {
                            action = Actions.None;
                            direction = Directions.None;
                        }
                        break;
                    default:
                        YTK = Convert.ToByte(YTK + Genom[YTK] - 1);
                        NextStep();
                        action = Actions.None;
                        direction = Directions.None;
                        break;
                }
            }
            NextStep();
        }

        public override StateMetadata GetMetadata()
        {
            StateMetadata stateMetadata = base.GetMetadata();
            if(action == Actions.Move || action == Actions.CheckEnergy 
                || action ==Actions.Eat || action == Actions.DoDescendant)
            {
                stateMetadata.Add("Action", action.ToString() + direction.ToString());
                return stateMetadata;
            }
            stateMetadata.Add("Action", action.ToString());
            return stateMetadata;
        }

        public void NextStep()
        {
            YTK++;
            if (YTK == 64)
                YTK = 0;
        }

        #endregion

        #region constructors

        public GenotypeState(string name, double value,long lifeFormId, Dictionary<string, string> Params = null) : base(name, value, Params)
        {
            YTK = 0;
            direction = Directions.None;
            action = Actions.None;
            // Заполнение генома
        }

        public GenotypeState(StateMetadata metadata) : base(metadata)
        {
            YTK = 0;
            direction = Directions.None;
            action = Actions.None;
            // Заполнение генома
        }

        #endregion
    }
}
