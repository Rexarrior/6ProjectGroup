using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{
    public enum ColorType
    {
        Default = 0,
        EnergyDisplay = 1
    }

     #region SpecialRegion
    /*
     * 
     *          Александр,с днём рождения :)
     *         
     *         
     */
    #endregion

    class ColorState : LifeFormState
    {
        #region fields
        private ColorType colorType;
        private Queue<string> _lastEnergyReactions;
        private byte R;
        private byte G;
        private byte B;
        long lifeFormId;
        public WorldMetadata worldMetadata;

        #endregion


        #region properties

        public ColorType ColorType
        {
            get { return colorType; }
            set { colorType = value; }
        }
        public long LifeFormId
        {
            get { return lifeFormId; }
            set { lifeFormId = value; }
        }

        #endregion


        #region methods

        /// <summary>
        /// Обновляет информацию о последних действиях получения энергии формы жизни
        /// </summary>
        /// <param name="worldMetadata"></param>
        public void Update(WorldMetadata worldMetadata)
        {
            this.worldMetadata = worldMetadata;
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
            stateMetadata.Add("ColorType", colorType.ToString());
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
            byte part = 0;
            switch (colorType)
            {
                case ColorType.Default:
                    if (_lastEnergyReactions == null)
                        throw new ArgumentNullException();
                    foreach (string Action in _lastEnergyReactions)
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
                    if (R < 0 || G < 0 || B < 0)
                        throw new ArgumentException("Один из параметров RGB был отрицательным");
                    if (R + G + B != 0)
                        part = Convert.ToByte(255 / (R + G + B));
                    R = Convert.ToByte(part * R);
                    G = Convert.ToByte(part * G);
                    B = Convert.ToByte(part * B);
                    break;
                case ColorType.EnergyDisplay:
                    const int MaxBotEnergy = 1500;
                    R = 255;
                    G = (byte)(255 - ((worldMetadata[lifeFormId]["EnergyState"].Value / 1500) * 255)); // Нужен ли отлов исключений при приведении к (byte)?
                    break;
            }
       
        }

        #endregion


        #region constructors

        public ColorState(string name, double value, long id,ColorType colorType, Dictionary<string, string> Params = null) : base(name, value, Params)
        {
            lifeFormId = id;
            this.colorType = colorType;
        }


        public ColorState(StateMetadata metadata) : base(metadata)
        {
            byte[] bytes = metadata["Color"].Split(' ').Select(x => byte.Parse(x)).ToArray();
            R = bytes[0];
            G = bytes[1];
            B = bytes[2];
            if (!Enum.TryParse(metadata["ColorType"], out this.colorType))
                throw new ArgumentException("Недопустимое знчение metadata[\"ColorType\"]", metadata["ColorType"]);
        }

        #endregion
    }
}
