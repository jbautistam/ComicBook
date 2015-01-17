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
		///		Busca un objeto en la colección
		/// </summary>
		public TypeData Search(string strID)
		{ // Recorre la colección
				foreach (TypeData objBase in this)
					if (objBase.ID == strID)
						return objBase;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}
	}
}