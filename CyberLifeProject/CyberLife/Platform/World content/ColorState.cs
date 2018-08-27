using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberLife.Platform.World_content
{
    public class ColorState
    {
        #region  Fields

        private int ColorToF; //Color Type of Food значение цвета по типу питания (1 - делает фотосинтез,2 - питается минералами , 3 - хищник,4 - промежуточны)

        private int ColorToE; //Color Type of Energy значение цвета по кол-ву энергии 

        #endregion

        #region Methods
        // Задает цвет клетки в зависимости от типа питания
        public void SetColorToF(int a, int b, int c)// a,b,c - то чем питались последние три хода
        {
            if ((a * b * c) == 1) ColorToF = 1; // a1 b1 c1
            else if ((a * b * c) == 2 || (a * b * c) % 4 == 0) ColorToF = 2;
            else if ((a * b * c) == 3 || (a * b * c) % 9 == 0) ColorToF = 3;
            else if ((a * b * c) == 6) ColorToF = 4;

        }
        public void SetColorToE(int en)
        {
            ColorToE = en; // в зависимости от кол-ва энергии в клетке,цветом клетки будет какая-нибудь часть градиента от желтого до ярко красного
        }

        #endregion

        #region Constructors



        #endregion

    }
}