using System;

namespace Bau.Libraries.LibEBook.Base
{
	/// <summary>
	///		Elemento base de los objetos de la librería
	/// </summary>
	public class eBookBase
	{ // Variables privadas
			private string strID;
			
		/// <summary>
		///		ID del elemento
		/// </summary>
		public string ID
		{ get 
				{ // Obtiene el ID si no existía
						if (string.IsNullOrEmpty(strID))
							strID = Guid.NewGuid().ToString();
					// Devuelve el ID	
						return strID;
				}
			set { strID	= value; }
		}
	}
}
