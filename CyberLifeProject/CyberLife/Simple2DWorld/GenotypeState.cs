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
        Extraction,
        ForsedReproduction = 7,
        None = 0
    }

    public class GenotypeState : LifeFormState
    {
        Random rnd = new Random();
        #region fields

        Directions _direction;
        Actions _action;
        private byte YTK;
        private List<byte> _genom;
        public long _id;

        #endregion


        #region properties

        #endregion


        #region methods

        /// <summary>
        /// Обновляет действия бота в соответствии с геномом
        /// </summary>
        /// <param name="metadata"></param>
        public void Update(WorldMetadata metadata)
        {
            if (metadata[_id]["EnergyState"]["EnergyState"] == "ForsedReproduction")
            {
                _action = Actions.ForsedReproduction;
                NextStep();
            }
            else
            {
                switch (_genom[YTK])
                {
                    case 1:
                        _action = Actions.CheckEnergy;
                        NextStep();
                        _direction = (Directions)((_genom[YTK] / 8) + 1);
                        NextStep();
                        Update(metadata);
                        break;
                    case 2:
                        _action = Actions.Photosynthesis;
                        NextStep();
                        break;
                    case 3:
                        _action = Actions.Move;
                        NextStep();
                        _direction = (Directions)((_genom[YTK] / 8) + 1);
                        NextStep();
                        break;
                    case 4:
                        _action = Actions.Eat;
                        NextStep();
                        _direction = (Directions)((_genom[YTK] / 8) + 1);
                        NextStep();
                        break;
                    case 5:
                        if (metadata[_id]["EnergyState"]["EnergyState"] == "CanReproduce")
                        {
                            _action = Actions.DoDescendant;
                            NextStep();
                            _direction = (Directions)((_genom[YTK] / 8) + 1);
                            NextStep();
                        }
                        else
                        {
                            _action = Actions.None;
                            _direction = Directions.None;
                            NextStep();
                            Update(metadata);
                        }
                        break;
                    default:
                        try
                        {
                            YTK = Convert.ToByte(YTK + _genom[YTK] - 1);
                        }
                        catch (Exception e)
                        {
                            throw new  ArgumentException("Недопустимое значение YTK", (YTK + _genom[YTK] - 1).ToString(), e);
                        }
                        NextStep();
                        _action = Actions.None;
                        _direction = Directions.None;
                        NextStep();
                        Update(metadata);
                        break;
                    case 6:
                        _action = Actions.Extraction;
                        NextStep();
                        break;

                }
            }
        }



        /// <summary>
        /// Устанавливает геном из его строкового представления
        /// </summary>
        /// <param name="str"></param>
        public void SetGenom(string str)
        {
            const byte mutationPercent = 10;
            _genom = str.Split('|').Select(x => Convert.ToByte(x)).ToList();
            if(rnd.Next(1,(100/mutationPercent)+1) == 1)
            {
                _genom[rnd.Next(0, 64)] =(Byte) rnd.Next(0, 64); 
            }
        }

        public override StateMetadata GetMetadata()
        {
            string strGenom = "";
            StateMetadata stateMetadata = base.GetMetadata();
            if (_action == Actions.Move || _action == Actions.CheckEnergy
                || _action == Actions.Eat || _action == Actions.DoDescendant)
            {
                stateMetadata.Add("Action", _action.ToString()+"|" + _direction.ToString());
            }
            else
            {
                stateMetadata.Add("Action", _action.ToString());
            }
            foreach (byte b in _genom)
            {
                strGenom += b.ToString() + "|";
            }
            stateMetadata.Add("Genom", "" + strGenom);
            stateMetadata.Add("YTK", YTK.ToString());
            return stateMetadata;
        }



        public void NextStep()
        {
            YTK = (byte) ((YTK + 1) % 64);
        }

        #endregion


        #region constructors

        public GenotypeState(string name, double value, long lifeFormId, Dictionary<string, string> Params = null) : base(name, value, Params)
        {
            _genom = new List<byte> { };
            YTK = 0;
            _direction = Directions.None;
            _action = Actions.None;
            List<int> workingList = Enumerable.Repeat(1, 10)
                .Concat(Enumerable.Repeat(2, 10))
                .Concat(Enumerable.Repeat(3, 10))
                .Concat(Enumerable.Repeat(4, 10))
                .Concat(Enumerable.Repeat(5, 10))
                .Concat(Enumerable.Repeat(6, 14)).ToList();
            foreach (int i in workingList)
            {
                _genom.Add(Convert.ToByte(i));
            }
        }


        public GenotypeState(StateMetadata metadata) : base(metadata)
        {
            YTK = Convert.ToByte(metadata["YTK"]);
            SetGenom(metadata["Genom"]);
            _direction = Directions.None;
            _action = Actions.None;
        }

        #endregion
    }
}
