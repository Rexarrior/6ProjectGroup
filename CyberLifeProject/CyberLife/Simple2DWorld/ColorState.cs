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

    class ColorState : LifeFormState
    {
        #region fields
        private ColorType _colorType;
        private readonly Queue<string> _lastEnergyReactions;
        private byte R;
        private byte G;
        private byte B;
        long _lifeFormId;
        private double _energy;

        #endregion


        #region properties

        public ColorType ColorType
        {
            get { return _colorType; }
            set { _colorType = value; }
        }
        public long LifeFormId
        {
            get { return _lifeFormId; }
            set { _lifeFormId = value; }
        }

        #endregion


        #region methods

        /// <summary>
        /// Обновляет информацию о последних действиях получения энергии формы жизни
        /// </summary>
        /// <param name="worldMetadata"></param>
        public void Update(WorldMetadata worldMetadata)
        {
            _energy = worldMetadata[_lifeFormId]["EnergyState"].Value;
            if (_lastEnergyReactions.Count >= 10)
                _lastEnergyReactions.Dequeue();
            switch (worldMetadata[_lifeFormId]["GenorypeState"]["Action"])
            {
                case "Extraction":
                    _lastEnergyReactions.Enqueue("Extraction");
                    break;
                case "Photosynthesis":
                    _lastEnergyReactions.Enqueue("Photosynthesis");
                    break;
                default:
                    if (worldMetadata[_lifeFormId]["GenorypeState"]["Action"].Split('|')[0] == "Eat")
                        _lastEnergyReactions.Enqueue("Eat");
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
            stateMetadata.Add("ColorType", _colorType.ToString());
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
            switch (_colorType)
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
                                break;
                            case "Eat":
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
                    G = (byte)(255 - ((_energy / MaxBotEnergy) * 255));
                    break;
            }
        }

        #endregion


        #region constructors

        public ColorState(string name, double value, long id,ColorType colorType, Dictionary<string, string> Params = null) : base(name, value, Params)
        {
            _lifeFormId = id;
            this._colorType = colorType;
            _lastEnergyReactions = new Queue<string>();
        }


        public ColorState(StateMetadata metadata) : base(metadata)
        {
            _lastEnergyReactions = new Queue<string>();
            byte[] bytes = metadata["Color"].Split(' ').Select(x => byte.Parse(x)).ToArray();
            R = bytes[0];
            G = bytes[1];
            B = bytes[2];
            if (!Enum.TryParse(metadata["ColorType"], out this._colorType))
                throw new ArgumentException("Недопустимое знчение metadata[\"ColorType\"]", metadata["ColorType"]);
        }

        #endregion
    }
}
