 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberLife.Platform.Logging.LogMessages;

namespace CyberLife.Simple2DWorld
{
    class Simple2DWorldMetadata: WorldMetadata
    {
        #region fields

        public Dictionary<Int64, LifeFormMetadata> OrganicMetadata;
        #endregion

        #region properties

        #endregion

        #region methods



        #endregion


        #region constructors
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="environmentMetadata"></param>
        /// <param name="lifeFormsMetadata"></param>
        /// <param name="organicMetadata">Умершие живые формы, которые все еще являются органикой.</param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Simple2DWorldMetadata(EnvironmentMetadata environmentMetadata,
            Dictionary<long, LifeFormMetadata> lifeFormsMetadata,
            Dictionary<long, LifeFormMetadata> organicMetadata, string name, int age) : base(environmentMetadata, lifeFormsMetadata, name, age)
        {
            log.Trace(LogMetadataMessages.Constructor, "Simple2DWorldMetadata");
            if (organicMetadata == null)
            {
                ArgumentNullException ex = new ArgumentNullException(nameof(lifeFormsMetadata));
                log.Error(LogMetadataMessages.NullArgument, "Dictionary<long, LifeFormMetadata> lifeFormsMetadata", ex);
                throw ex;
            }


            OrganicMetadata = organicMetadata;
            log.Info($"Количество органики: {OrganicMetadata.Count}");
            log.Trace(LogMetadataMessages.OkConstructor, "Simple2DWorldMetadata");

        }

        public Simple2DWorldMetadata(Protobuff.Simple2DWorld.Simple2DWorldMetadata protoMetadata) : base(protoMetadata.Worldmetadata)
        {
            log.Trace(LogMetadataMessages.Constructor, "Simple2DWorldMetadata");
            OrganicMetadata = new Dictionary<long, LifeFormMetadata>(protoMetadata.OrganicMetadata.Count);
            foreach (var lifeFormMetadata in protoMetadata.OrganicMetadata)
            {
                OrganicMetadata.Add(lifeFormMetadata.Id, new LifeFormMetadata(lifeFormMetadata));
            }

            log.Info($"Количество органики: {OrganicMetadata.Count}");
            log.Trace(LogMetadataMessages.OkConstructor, "Simple2DWorldMetadata");

        }

        #endregion

    }
}
