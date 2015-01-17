using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibComicsBooks.Definition
{
	/// <summary>
	///		Colecci�n de <see cref="ComicInfoProperty"/>
	/// </summary>
	public class ComicInfoPropertiesCollection : List<ComicInfoProperty>
	{
		/// <summary>
		///		A�ade una propiedad a la colecci�n
		/// </summary>
		internal ComicInfoProperty Add(string strName, string strValue)
		{ ComicInfoProperty objProperty = new ComicInfoProperty(strName, strValue);
		
				// A�ade la propiedad
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
			// Si ha llegado hasta aqu� es porque no exist�a as� que la a�ade
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
