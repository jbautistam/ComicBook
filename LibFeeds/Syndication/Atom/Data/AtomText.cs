using System;

namespace Bau.Libraries.LibFeeds.Syndication.Atom.Data
{
	/// <summary>
	///		Clase con los datos de un texto para Atom
	/// </summary>
	public class AtomText
	{
		public AtomText() : this(null, null, null, null, null) {}
		
		public AtomText(string strMode, string strType, string strContent) : this(strMode, strType, null, null, strContent)
		{
		}
		
		public AtomText(string strMode, string strType, string strLanguage, string strXMLBase, string strContent)
		{ Mode = strMode;
			Type = strType;
			Language = strLanguage;
			XmlBase = strXMLBase;
			Content = strContent;
		}
		
		/// <summary>
		///		Modo (escaped, xml, ...)
		/// </summary>
		public string Mode { get; set; }
		
		/// <summary>
		///		Tipo (text/html ...)
		/// </summary>
		public string Type { get; set; }
		
		/// <summary>
		///		Idioma (en-US ...)
		/// </summary>
		public string Language { get; set; }
		
		/// <summary>
		///		XML base
		/// </summary>
		public string	XmlBase { get; set; }
		
		/// <summary>
		///		Contenido
		/// </summary>
		public string Content { get; set; }
	}
}
