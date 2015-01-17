using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibComicsBooks.Definition
{
	/// <summary>
	///		Colección de <see cref="ComicInfoProperty"/>
	/// </summary>
	public class ComicInfoPropertiesCollection : List<ComicInfoProperty>
	{
		/// <summary>
		///		Añade una propiedad a la colección
		/// </summary>
		internal ComicInfoProperty Add(string strName, string strValue)
		{ ComicInfoProperty objProperty = new ComicInfoProperty(strName, strValue);
		
				// Añade la propiedad
					Add(objProperty);
				// ... y la devuelve
					return objProperty;
		}
		
		/// <summary>
		///		Busca una propiedad entr los valores
		/// </summary>
		private ComicInfoProperty Search(string strName)
		{ // Busca una propiedad
				foreach (ComicInfoProperty objProperty in this)
					if (objProperty.Name.Equals(strName))
						return objProperty;
			// Si ha llegado hasta aquí es porque no existía así que la añade
				return Add(strName, "");
		}
		
		internal ComicInfoProperty this[string strName]
		{ get { return Search(strName); }
			set 
				{ ComicInfoProperty objProperty = Search(strName);
						
						objProperty.Value = value.Value;
				}
		}
	}
}
