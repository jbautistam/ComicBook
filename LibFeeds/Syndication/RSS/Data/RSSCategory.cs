using System;

namespace Bau.Libraries.LibFeeds.Syndication.RSS.Data
{
	/// <summary>
	///		Clase con los datos de una categoría
	/// </summary>
	public class RSSCategory
	{
		public RSSCategory(string strText)
		{ Text = strText;
		}
		
		/// <summary>
		///		Texto de la categoría
		/// </summary>
		public string Text { get; set; }
	}
}
