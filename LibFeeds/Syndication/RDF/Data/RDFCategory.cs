using System;

namespace Bau.Libraries.LibFeeds.Syndication.RDF.Data
{
	/// <summary>
	///		Clase con los datos de una categoría
	/// </summary>
	public class RDFCategory
	{
		public RDFCategory(string strText)
		{ Text = strText;
		}
		
		/// <summary>
		///		Texto de la categoría
		/// </summary>
		public string Text { get; set; }
	}
}
