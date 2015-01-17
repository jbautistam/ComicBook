using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibEBook.Base
{
	/// <summary>
	///		Colección de <see cref="ePubBase"/>
	/// </summary>
	public class eBookBaseCollection<TypeData> : List<TypeData> where TypeData : eBookBase
	{
		/// <summary>
		///		Busca un elemento por su ID
		/// </summary>
		public TypeData Search(string strID)
		{ // Busca el elemento
				foreach (TypeData objData in this)
					if (objData.ID == strID)
						return objData;
			// Si llega hasta aquí es porque no ha encontrado nada
				return null;
		}
	}
}
