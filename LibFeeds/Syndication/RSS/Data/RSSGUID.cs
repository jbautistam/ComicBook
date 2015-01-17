using System;

namespace Bau.Libraries.LibFeeds.Syndication.RSS.Data
{
	/// <summary>
	///		Datos del GUID de un elemento RSS
	/// </summary>
	public class RSSGuid
	{
		public RSSGuid() : this(null, false) {}
		
		public RSSGuid(string strID, bool blnIsPermalink)
		{ ID = strID;
			IsPermaLink = blnIsPermalink;
		}
		
		/// <summary>
		///		ID del elemeto
		/// </summary>
		public string ID { get; set; }
		
		/// <summary>
		///		Atributo que indica si es permanente
		/// </summary>
		public bool IsPermaLink { get; set; }
	}
}
