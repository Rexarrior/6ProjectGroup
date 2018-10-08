using System;
using System.Collections.Generic;
using System.Linq;
using  System.IO;
using Google.Protobuf;
using NLog;
using CyberLife.Platform.Logging.LogMessages;

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
        protected string _name;
        protected Environment _environment;
        protected IVisualizer _visualizer;
        protected Dictionary<Int64, LifeForm> _lifeForms;
        protected int _age;

        protected Dictionary<string, ReactionDelegate> _reactions; 

        #endregion


        #region properties
        public string Name { get => _name; set => _name = value; }
        public Dictionary<Int64, LifeForm> LifeForms { get => _lifeForms;  }
        public Environment Environment { get => _environment;  }
        public IVisualizer Visualizer { get => _visualizer; set => _visualizer = value; }//todo

        #endregion


        #region methods
        /// <summary>
        /// Вызывает обновление всех компонентов мира. 
        /// </summary>
        public void Update()
        {
            log.Trace(CommonLogMessages.Update, "World");
            WorldMetadata metadata = GetMetadata();
            log.Trace(CommonLogMessages.SetMetadata, "WorldMetadata", "World");
            _environment.Update(metadata);
            foreach (var lifeForm in LifeForms.Values)
            {
                
                lifeForm.Update(metadata, _environment.GetEffects(lifeForm.GetMetadata()));
            }

            foreach (var reaction in _reactions.Values)
            {
                reaction(this);
            }
            log.Trace("Текущий Age = " + _age.ToString());
            _age++;
            _visualizer?.Update(this.GetMetadata());
            log.Trace(CommonLogMessages.EndMethod, "World.Update");
        }



        /// <summary>
        /// Получает метадату этого мира.
        /// </summary>
        /// <returns></returns>
        public WorldMetadata GetMetadata()
        {
            log.Trace(CommonLogMessages.GetMetadata, "World");
            Dictionary<long, LifeFormMetadata> lifeFormsMetadata = new Dictionary<long, LifeFormMetadata>();
            foreach(var lifeFormRec in _lifeForms)
            {
                lifeFormsMetadata.Add(lifeFormRec.Key, lifeFormRec.Value.GetMetadata());
            }
            return new WorldMetadata(_environment.GetMetadata(), lifeFormsMetadata, _name, _age); 
        }
        

        /// <summary>
        /// Cохраняет этот мир в бинарном формате по протоколу googleProtobuff
        /// </summary>
        /// <param name="fileName">Имя файла для сохранения</param>
        public void SaveToFile(string fileName)
        {
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
        }


        /// <summary>
        /// Загружает мир из бинарного файла в формате googleProtobuff. 
        /// </summary>
        /// <param name="fileName">Имя файла для загрузки</param>
        /// <param name="fabrica">Фабрика природных явлений</param>
        /// <returns>Загруженный мир</returns>
        public static World LoadFromFile(string fileName, IPhenomenaFabrica fabrica)
        {
            ///TODO Fix for other worlds prototype
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
        }

        
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
        public World(string name, Environment environment, IVisualizer visualizer, List<LifeForm> lifeForms)
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
            if(environment ==null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(environment));
                log.Error(CommonLogMessages.NullArgument, "Environment environment");
                throw ex;
            }
            if(visualizer ==null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(visualizer));
                log.Error(CommonLogMessages.NullArgument, "IVisualizer visualizer");
                throw ex;
            }

            _environment = environment;
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


        
        /// <summary>
        /// Инициализирует экземпляр мира из его метадаты 
        /// и фабрики природных явлений
        /// </summary>
        /// <param name="metadata">метаданные мира</param>
        /// <param name="phenomenaFabrica">Фабрика для разбора прородных явлений, содержащихся в метаданных</param>
        public World(WorldMetadata metadata, IPhenomenaFabrica phenomenaFabrica)
        {
            log.Trace(CommonLogMessages.Constructor, "World"); 
            _environment = new Environment(metadata.EnvironmentMetadata, phenomenaFabrica);
            _name = metadata.Name;
            _age = metadata.Age;
            _lifeForms = new Dictionary<long, LifeForm>();
            foreach (var lifeFormMetadata in metadata.Values)
            {
                _lifeForms.Add(lifeFormMetadata.Id, new LifeForm(lifeFormMetadata));
            }


            _reactions = new Dictionary<string, ReactionDelegate>();

            log.Info("Кол-во форм жизни " + _lifeForms.Count.ToString());
            log.Trace(CommonLogMessages.OkConstructor);

        }
        
        #endregion
    }
}