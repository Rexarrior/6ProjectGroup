using System;
using System.Collections.Generic;
using System.Linq;
using  System.IO;
using Google.Protobuf;
using NLog;
using CyberLife.Platform.Logging.LogMessages;
using CyberLife;
using CyberLife.Simple2DWorld;

namespace CyberLife
{
    /// <summary>
    /// Реаилзует цельный мир.
    /// </summary>
    public class World
    {
        protected Logger log = LogManager.GetCurrentClassLogger();

        public delegate void ReactionDelegate(World world);

        #region fields

        protected Dictionary<string,IPhenomen> _naturalPhenomena;
        protected MapSize _size;
        protected string _name;
        protected IVisualizer _visualizer;
        protected Dictionary<Int64, LifeForm> _lifeForms;
        protected int _age;

        protected Dictionary<string, ReactionDelegate> _reactions; 

        #endregion


        #region properties

        public string Name { get => _name; set => _name = value; }
        public Dictionary<Int64, LifeForm> LifeForms { get => _lifeForms;  }
        public IVisualizer Visualizer { get => _visualizer; set => _visualizer = value; }//todo
        public int Age { get { return _age; } }
        internal Dictionary<string, IPhenomen> NaturalPhenomena { get => _naturalPhenomena; }
        internal MapSize Size { get => _size; }

        #endregion


        #region methods
        /// <summary>
        /// Вызывает обновление всех компонентов мира. 
        /// </summary>
        public virtual void Update()
        {
          // nothing?
        }
        

        /// <summary>
        /// Cохраняет этот мир в бинарном формате по протоколу googleProtobuff
        /// </summary>
        /// <param name="fileName">Имя файла для сохранения</param>
        public void SaveToFile(string fileName)
        {
            //todo
            /*
            log.Trace(CommonLogMessages.ProtobuffFromSome, "World");
            Protobuff.Metadata.WorldMetadata metadata = this.GetMetadata().GetProtoMetadata();

            try
            {

                FileStream fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write);
                metadata.WriteTo(fs);
                fs.Close();
            }
            catch (Exception e)
            {
                log.Error("Что-то отвалилось в World.SaveToFile,текст Exception   " + e);
                throw;
            }
            log.Trace(CommonLogMessages.OkProtobuffFromSome);
            */
        }


        /// <summary>
        /// Загружает мир из бинарного файла в формате googleProtobuff. 
        /// </summary>
        /// <param name="fileName">Имя файла для загрузки</param>
        /// <param name="fabrica">Фабрика природных явлений</param>
        /// <returns>Загруженный мир</returns>
       /* public static World LoadFromFile(string fileName IPhenomenaFabrica fabrica)
        {
            // todo
            
            Logger log = LogManager.GetCurrentClassLogger();
            log.Trace("Загружаем экземпляр World из файла");
            World world;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                world = new World(new WorldMetadata(Protobuff.Metadata.WorldMetadata.Parser.ParseFrom(fs)), fabrica);
                fs.Close();
            }
            catch (FileNotFoundException ex)
            {
                log.Error("Файл не найден", ex);
                throw;
            }
            catch(Exception ex)
            {
                log.Error("Что - то отвалилось в World.LoadFromFile, текст Exception   " + ex);
                throw;
            }
            log.Trace("Экземпляр успешно загружен");
            return world;
            
        }*/

        
        /// <summary>
        /// Добавляет данную реакцию под данным именем. 
        /// Имя является уникальным идентификатором.
        /// </summary>
        /// <param name="reactionName">Уникальное имя реакции</param>
        /// <param name="reaction">Добавляемая реакция</param>
        /// <returns>Успешно?</returns>
        public bool AddReaction(string reactionName, ReactionDelegate reaction)
        {
            log.Trace("Добавляется реакция {0}", reactionName);
            if (_reactions.ContainsKey(reactionName))
                return false;
            _reactions.Add(reactionName, reaction);
            log.Trace(CommonLogMessages.EndMethod, "AddReaction");
            return true;
        }




        /// <summary>
        /// Удаляет реакцию с указанным именем
        /// </summary>
        /// <param name="reactionName">Имя реакции для удаления</param>
        /// <returns>Успешно?</returns>
        public bool DeleteReaction(string reactionName)
        {
            log.Trace("Удаляется реакция {0}", reactionName);
            if (!_reactions.ContainsKey(reactionName))
                return false;
            _reactions.Remove(reactionName);
            log.Trace(CommonLogMessages.EndMethod, "DeleteReaction");
            return true;
        }



        /// <summary>
        /// Заменяет реакцию с указанным именем на данную
        /// </summary>
        /// <param name="reactionName">Имя реакции, которую необходимо заменить</param>
        /// <param name="reaction">Новая реакция</param>
        /// <returns>Успешно?</returns>
        public bool ReplaceReaction(string reactionName, ReactionDelegate reaction)
        {
            log.Trace("Заменяется реакция {0}", reactionName);
            if (!_reactions.ContainsKey(reactionName))
                return false;
            _reactions[reactionName] = reaction;
            log.Trace(CommonLogMessages.EndMethod, "ReplaceReaction");
            return true;
        }

        #endregion


        #region constructors
        /// <summary>
        /// Инициализирует мир на основе его компонентов
        /// </summary>
        /// <param name="name">Название мира</param>
        /// <param name="environment">Окружающая среда для этого мира</param>
        /// <param name="visualizer">Визуализатор, предназначенный для отрисовки компонентов мира</param>
        /// <param name="lifeForms">Формы жизни</param>
        public World(string name, IVisualizer visualizer, List<LifeForm> lifeForms, Dictionary<string, IPhenomen> phenomens,MapSize mapSize)
        {
            if (lifeForms == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(lifeForms));
                log.Error(CommonLogMessages.NullArgument, "List<LifeForm> lifeForms");
                throw ex;
            }

            if (lifeForms.Count == 0)
            {
                ArgumentException ex = new ArgumentException("List of life forms shouldn\t be empty.", nameof(lifeForms));
                log.Error("В коллекции List<LifeForm> lifeForms нет форм жизни");
                throw ex;
            }

            if (name == "" || name == null)
            {
                ArgumentException ex = new ArgumentException("Name shouldn't be empty", nameof(name));
                log.Error(CommonLogMessages.NullArgument, "string name");
                throw ex;
            }
            if(phenomens ==null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(phenomens));
                log.Error(CommonLogMessages.NullArgument, "phenomens environment");
                throw ex;
            }
            if(visualizer ==null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(visualizer));
                log.Error(CommonLogMessages.NullArgument, "IVisualizer visualizer");
                throw ex;
            }
            if (mapSize == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(mapSize));
                log.Error(CommonLogMessages.NullArgument, "mapSize");
                throw ex;
            }
            _size = mapSize;
            _naturalPhenomena = phenomens;
            _visualizer = visualizer;
            _name = name;
            _lifeForms = new Dictionary<long, LifeForm>();
            foreach (var lifeForm in lifeForms)
            {
                _lifeForms.Add(lifeForm.Id, lifeForm);
            }

            _reactions = new Dictionary<string, ReactionDelegate>();

            log.Info("Кол-во форм жизни " + _lifeForms.Count.ToString());
            log.Trace(CommonLogMessages.OkConstructor);

        }


        
        #endregion
    }
}