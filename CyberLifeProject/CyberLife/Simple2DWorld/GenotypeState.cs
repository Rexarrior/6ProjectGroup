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
    */
    public class GenotypeState : LifeFormState
    {
        #region fields

        Directions direction;
        Actions action;
        private byte YTK;
        private List<byte> genom;
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
                switch (genom[YTK])
                {
                    case 1:
                        action = Actions.CheckEnergy;
                        NextStep();
                        direction = (Directions)((genom[YTK] / 8) + 1);
                        NextStep();
                        Update(metadata);
                        break;
                    case 2:
                        action = Actions.Photosynthesis;
                        NextStep();
                        break;
                    case 3:
                        action = Actions.Move;
                        NextStep();
                        direction = (Directions)((genom[YTK] / 8) + 1);
                        NextStep();
                        break;
                    case 4:
                        action = Actions.Eat;
                        NextStep();
                        direction = (Directions)((genom[YTK] / 8) + 1);
                        NextStep();
                        break;
                    case 5:
                        if (metadata[id]["EnergyState"]["EnergyState"] == "CanReproduce")
                        {
                            action = Actions.DoDescendant;
                            NextStep();
                            direction = (Directions)((genom[YTK] / 8) + 1);
                            NextStep();
                        }
                        else
                        {
                            action = Actions.None;
                            direction = Directions.None;
                            NextStep();
                            Update(metadata);
                        }
                        break;
                    default:
                        YTK = Convert.ToByte(YTK + genom[YTK] - 1);
                        NextStep();
                        action = Actions.None;
                        direction = Directions.None;
                        NextStep();
                        Update(metadata);
                        break;
                }
            }
        }
        public void SetGenom(string str)
        {
            genom.Clear();
            genom = str.Split('|').Select(x => Convert.ToByte(x)).ToList();
        }

        public override StateMetadata GetMetadata()
        {
            string strGenom = "";
            StateMetadata stateMetadata = base.GetMetadata();
            if (action == Actions.Move || action == Actions.CheckEnergy
                || action == Actions.Eat || action == Actions.DoDescendant)
            {
                stateMetadata.Add("Action", action.ToString() + direction.ToString());
            }
            else
            {
                stateMetadata.Add("Action", action.ToString());
            }
            foreach (byte b in genom)
            {
                strGenom += b.ToString() + "|";
            }
            stateMetadata.Add("Genom", "" + strGenom);
            stateMetadata.Add("YTK", YTK.ToString());
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

        public GenotypeState(string name, double value, long lifeFormId, Dictionary<string, string> Params = null) : base(name, value, Params)
        {
            genom = new List<byte> { };
            YTK = 0;
            direction = Directions.None;
            action = Actions.None;
            List<int> workingList = Enumerable.Repeat(1, 10)
                .Concat(Enumerable.Repeat(2, 10))
                .Concat(Enumerable.Repeat(3, 10))
                .Concat(Enumerable.Repeat(4, 10))
                .Concat(Enumerable.Repeat(5, 10))
                .Concat(Enumerable.Repeat(0, 14)).ToList();
            foreach (int i in workingList)
            {
                genom.Add(Convert.ToByte(i));
            }
        }

        public GenotypeState(StateMetadata metadata) : base(metadata)
        {
            YTK = Convert.ToByte(metadata["YTK"]);
            SetGenom(metadata["Genom"]);
            direction = Directions.None;
            action = Actions.None;
        }

        #endregion
    }
}
