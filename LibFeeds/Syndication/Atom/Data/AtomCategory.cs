using System;

namespace Bau.Libraries.LibFeeds.Syndication.Atom.Data
{
	/// <summary>
	///		Datos de una categoría para Atom
	/// </summary>
	public class AtomCategory
	{ 
		public AtomCategory() : this(null) {}
		
		public AtomCategory(string strName)
		{ Name = strName;
		}
		
		/// <summary>
		///		Nombre de la categoría
		/// </summary>
		public string Name { get; set; }
	}
}
