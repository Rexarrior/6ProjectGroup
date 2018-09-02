using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberLife.Simple2DWorld
{

        enum Commands : byte
        {
            WhatEnergy, // = ? решить с какого индекса начать
            SeeAround,
            Go,
            Photosynthes,
            Eat,
            TurnAround,
            DoClone,
            ShareEnergy
        }


        public class GenotypeState
        {
            private const int CommandsCount = 8;



            /// <summary>
            /// Геном-код бота
            /// </summary>	
            public int[] Genom; // ? Достать из метаданных бота с проверкой на наличие



            /// <summary>
            /// УТК - указатель текущей команды
            /// </summary>	
            public byte YTK;// ? Достать из метаданных бота с проверкой на наличие


            /// <summary>
            /// Кол-во энергии бота
            /// </summary>	
            public int EnergyState;  // ? Достать из метаданных бота


            /// <summary>
            /// Конструктор 
            /// </summary>	
            public GenotypeState()
            {

                Commands cod;

                //Если геном еще не сгенерирован
                Genom = new int[CommandsCount] { (int)Commands.DoClone, (int)Commands.Eat, (int)Commands.Go,
                    (int)Commands.Photosynthes, (int)Commands.SeeAround, (int)Commands.ShareEnergy, (int)Commands.TurnAround,
                    (int)Commands.WhatEnergy
                };

            }



            /// <summary>
            /// Просчет следующего УТК
            /// </summary>
            public void NextYTK()
            {

            }
        }
    
}
