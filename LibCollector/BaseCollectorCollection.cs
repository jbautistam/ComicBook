using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibCollector
{
	/// <summary>
	///		Clase base para las colecciones de <see cref="BaseCollector"/>
	/// </summary>
	public class BaseCollectorCollection<TypeData> : List<TypeData> where TypeData: BaseCollector
	{ 
		/// <summary>
		///		Busca un objeto en la colecci�n
		/// </summary>
		public TypeData Search(string strID)
		{ // Recorre la colecci�n
				foreach (TypeData objBase in this)
					if (objBase.ID == strID)
						return objBase;
			// Si ha llegado hasta aqu� es porque no ha encontrado nada
				return null;
		}
	}
}