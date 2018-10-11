using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace CyberLife.Simple2DWorld
{
    public class Simple2dVisualizer : IVisualizer
    {
        #region fields

        private Bitmap map;
        int i = 0;


        #endregion


        #region properties

        public Bitmap Map { get { return map; } }

        #endregion


        #region methods

        /// <summary>
        /// Вызывает обновление цветов форм жизни
        /// </summary>
        /// <param name="metadata"></param>
        public void Update(WorldMetadata metadata)
        {
            map = new Bitmap(metadata.EnvironmentMetadata.Size.Width, metadata.EnvironmentMetadata.Size.Height);            
            map = new Bitmap(metadata.EnvironmentMetadata.Size.Width, metadata.EnvironmentMetadata.Size.Height);
            foreach (var pair in metadata)
            {
                Color color = ColorTranslator.FromHtml(pair.Value["ColorState"]["Color"]);
                map.SetPixel(pair.Value.Place.Points[0].X, pair.Value.Place.Points[0].Y, color);
            }
            // form.UpdatePicture(map);
            if (i % 10 == 0)
            {
                map.Save(@"D:\" + i.ToString() + ".jpg");
             }
             i ++;

        }



        /// <summary>
        /// Получает текущую карту
        /// </summary>
        /// <returns></returns>
        public Bitmap GetMap()
        {
            return map;
        }

        #endregion


        #region constructors

        #endregion
    }
}