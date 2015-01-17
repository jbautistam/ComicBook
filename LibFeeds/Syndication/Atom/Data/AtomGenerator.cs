using System;

namespace Bau.Libraries.LibFeeds.Syndication.Atom.Data
{
	/// <summary>
	///		Generador de Atom
	/// </summary>
	public class AtomGenerator
	{
		public AtomGenerator() : this(null, null, null, null) {}
		
		public AtomGenerator(string strURL, string strVersion, string strName) : this(strURL, strVersion, null, strName)
		{
		}
		
		public AtomGenerator(string strURL, string strVersion, string strLanguage, string strName)
		{ URL = strURL;
			Version = strVersion;
			Language = strLanguage;
			Name = strName;
		}
		
		/// <summary>
		///		URL
		/// </summary>
		public string URL { get; set; }
		
		/// <summary>
		///		Versión
		/// </summary>
		public string Version { get; set; }
		
		/// <summary>
		///		Lenguaje
		/// </summary>
		public string Language { get; set; }
		
		/// <summary>
		///		Nombre
		/// </summary>
		public string Name { get; set; }
	}
}
