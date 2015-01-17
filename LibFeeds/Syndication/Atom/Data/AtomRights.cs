using System;

namespace Bau.Libraries.LibFeeds.Syndication.Atom.Data
{
	/// <summary>
	///		Derechos para un elemento Atom
	/// </summary>
	public class AtomRights
	{
		public AtomRights() : this(null, null) {}
		
		public AtomRights(string strType, string strCopyright)
		{ Type = strType;
			Copyright = strCopyright;
		}
		
		/// <summary>
		///		Tipo
		/// </summary>
		public string Type { get; set; }
		
		/// <summary>
		///		Derechos de copia
		/// </summary>
		public string Copyright { get; set; }
	}
}
