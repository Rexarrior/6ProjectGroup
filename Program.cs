using System;

namespace CyberLife
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
			
		/// <summary>
		/// Геном-код бота
		/// </summary>	
		public byte[] Genom = // ? Достать из метаданных бота с проверкой на наличие
	
	
			
		/// <summary>
		/// УТК - указатель текущей команды
		/// </summary>	
		public byte YTK = // ? Достать из метаданных бота с проверкой на наличие
			
		
		/// <summary>
		/// Кол-во энергии бота
		/// </summary>	
		public int EnergyState=  // ? Достать из метаданных бота
		
		
		/// <summary>
		/// Конструктор 
		/// </summary>	
		public GenotypeState(){
			
			Commands cod;
			
			//Если геном еще не сгенерирован
			Genom[]={cod.Photosynthes, cod.WhatEnergy, ,};
		
		}

		

		/// <summary>
		/// Просчет следующего УТК
		/// </summary>
		public void NextYTK()
		{
			
		}
	}
}
