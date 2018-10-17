﻿using System.Collections.Generic;
using System;
namespace CyberLife
{
    public interface IPhenomen
    {
        /// <summary>
        /// Вызывает обновление этого природного явления на основании
        /// метаданных окружающей среды.
        /// </summary>
        /// <param name="worldMetadata">Метаданные окружающей среды.</param>
        void Update(World world);

        /// <summary>
        /// Получает эффекты воздействия этого феномена на точку пространства.
        /// Использует метаданные попавшей под воздействия формы жизни для корректировки 
        /// эффектов.
        /// </summary>
        /// <param name="point">Точка пространства</param>
        /// <param name="lifeFormMetadata">Метаданные формы жизни</param>
        /// <returns></returns>
        void GetEffects(LifeForm lifeForm);

        /// <summary>
        /// проверяет, попадает ли точка под воздействие этого природного явления
        /// </summary>
        /// <param name="point">Точка пространства</param>
        /// <returns>Попадает?</returns>
        bool isIn(Point point);


        /// <summary>
        /// Получает пространство, на котором действует это природное явление
        /// </summary>
        /// <returns></returns>
        Place GetItPlace();
        
    }
}