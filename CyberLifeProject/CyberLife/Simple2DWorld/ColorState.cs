using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    class ColorState : LifeFormState
    {  
        #region fields

        private Queue<string> _lastEnergyReactions;
        private byte R;
        private byte G;
        private byte B;
        long lifeFormId;

        #endregion


        #region properties

        #endregion


        #region methods

        /// <summary>
        /// Обновляет информацию о последних действиях получения энергии формы жизни
        /// </summary>
        /// <param name="worldMetadata"></param>
        public void Update(WorldMetadata worldMetadata)
        {
            if (_lastEnergyReactions.Count >= 10)
                _lastEnergyReactions.Dequeue();
            switch (worldMetadata[lifeFormId]["GenorypeState"]["Action"])
            {
                case "Extraction":
                    _lastEnergyReactions.Enqueue("Extraction");
                    break;
                case "Photosynthesis":
                    _lastEnergyReactions.Enqueue("Photosynthesis");
                    break;
                case "Meat": // Имя придумано,позже необходимо привести в соответсвие с текстом команды
                    _lastEnergyReactions.Enqueue("Meat");
                    break;
                default:
                    break;
            }
            SetRGB();
        }



        /// <summary>
        /// Формирует метаданные цвета формы жизни
        /// </summary>
        /// <returns></returns>
        public override StateMetadata GetMetadata()
        {
            StateMetadata stateMetadata = base.GetMetadata();
            stateMetadata.Add("Color", $"{R} {G} {B}");
            return stateMetadata;
        }



        /// <summary>
        /// Устанавливает RGB в соответствии с последними действиями формы жизни
        /// </summary>
        public void SetRGB()
        {
            R = 0;
            G = 0;
            B = 0;
            if (_lastEnergyReactions == null)
                throw new ArgumentNullException();
            foreach(string Action in _lastEnergyReactions)
            {
                switch (Action)
                {
                    case "Extraction":
                        B++;
                        break;
                    case "Photosynthesis":
                        G++;
                        _lastEnergyReactions.Enqueue("Photosynthesis");
                        break;
                    case "Meat": // Имя придумано,позже необходимо привести в соответсвие с текстом команды
                        R++;
                        break;
                }
            }
            byte part = 0;
            if (R + G + B != 0)     
            part = Convert.ToByte(255 / (R + G + B));
            R = Convert.ToByte(part * R);
            G = Convert.ToByte(part * G);
            B = Convert.ToByte(part * B);        
        }

        #endregion


        #region constructors

        public ColorState(string name, double value, long id, Dictionary<string, string> Params = null) : base(name, value, Params)
        {
            lifeFormId = id;
        }


        public ColorState(StateMetadata metadata) : base(metadata)
        {
            byte[] bytes = metadata["Color"].Split(' ').Select(x => byte.Parse(x)).ToArray();
            R = bytes[0];
            G = bytes[1];
            B = bytes[2];
        }

        #endregion
    }
}
