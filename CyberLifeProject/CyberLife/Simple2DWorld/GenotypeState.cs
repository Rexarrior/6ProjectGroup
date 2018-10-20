using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        #region fields

        #endregion


        #region properties
         
        #endregion


        #region methods

        /// <summary>
        /// Обновляет действия бота в соответствии с геномом
        /// </summary>
        /// <param name="metadata"></param>
        public override void Update(Simple2DWorld world)
        {
            foreach (BotLifeForm lifeForm in world.LifeForms.Values)
            {
                if (lifeForm._energyState == EnergyStates.ForsedReproduction)
                {
                    lifeForm._action = Actions.ForsedReproduction;
                    NextStep(lifeForm);
                }
                else
                {
                    SetAction(lifeForm);

                }
            }
        }

        private void SetAction(BotLifeForm lifeForm)
        {
            switch (lifeForm._genom[lifeForm.YTK])
            {
                case 1:
                    lifeForm._action = Actions.CheckEnergy;
                    NextStep(lifeForm);
                    lifeForm._direction = (Directions)((lifeForm._genom[lifeForm.YTK] / 8) + 1);
                    NextStep(lifeForm);
                   // SetAction(lifeForm);
                    break;
                case 2:
                    lifeForm._action = Actions.Photosynthesis;                    
                    NextStep(lifeForm);
                    break;
                case 3:
                   lifeForm._action = Actions.Move;
                    NextStep(lifeForm);
                  lifeForm.  _direction = (Directions)((lifeForm. _genom[lifeForm. YTK] / 8) + 1);
                    NextStep(lifeForm);
                    break;
                case 4:
                   lifeForm. _action = Actions.Eat;
                    NextStep(lifeForm);
                   lifeForm. _direction = (Directions)((lifeForm. _genom[lifeForm. YTK] / 8) + 1);
                    NextStep(lifeForm);
                    break;
                case 5:
                       lifeForm. _action = Actions.DoDescendant;
                        NextStep(lifeForm);
                       lifeForm. _direction = (Directions)((lifeForm. _genom[lifeForm. YTK] / 8) + 1);
                        NextStep(lifeForm);
                    break;
                default:
                    try
                    {
                        lifeForm.YTK = Convert.ToByte(lifeForm.YTK + lifeForm._genom[lifeForm. YTK] - 1);
                    }
                    catch (Exception e)
                    {
                        throw new ArgumentException("Недопустимое значение YTK", (lifeForm.YTK + lifeForm._genom[lifeForm.YTK] - 1).ToString(), e);
                    }
                    NextStep(lifeForm);
                    lifeForm._action = Actions.None;
                    lifeForm._direction = Directions.None;
                    NextStep(lifeForm);
                   // SetAction(lifeForm);

                    break;
                case 6:
                    lifeForm._action = Actions.Extraction;
                    NextStep(lifeForm);
                    break;

            }
        }

        public void NextStep(BotLifeForm bot)
        {
           bot. YTK = (byte) ((bot.YTK + 1) % 64);
        }



        public static Int64 GetFreeId(Dictionary<long, LifeForm> lifeForms, Dictionary<long, LifeForm> organic)
        {
            return  Enumerable.Range(0, lifeForms.Count + organic.Count+1).
                               Select(x => (Int64)x).
                               First(x => !lifeForms.ContainsKey(x) && !organic.ContainsKey(x)); 

        }



        public static void DoDescendant(World world,LifeForm bot,int X,int Y)
        {
            Simple2DWorld sworld = (Simple2DWorld)world;
            long id = GetFreeId(sworld.LifeForms,sworld.Organic);
            BotLifeForm lifeForm = new BotLifeForm(new Place(PlaceType.Array, new Point(X, Y)),id,((BotLifeForm)bot));
            sworld.LifeForms.Add(id, lifeForm);
        }

        #endregion


        #region constructors

        public GenotypeState(string name, double value, Dictionary<string, string> Params = null) : base(name, value, Params)
        {

        }

        #endregion
    }
}
