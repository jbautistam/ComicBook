using System;

namespace Bau.Libraries.LibComicsBooks.Definition
{
	/// <summary>
	///		Propiedad de informaci�n de un c�mic
	/// </summary>
	public class ComicInfoProperty
	{ 	
		public ComicInfoProperty(string strName, string strValue)
		{ Name = strName;
			Value = strValue;
		}
		
		public string Name { get; set; }

		public string Value { get; set; }
	}
}
