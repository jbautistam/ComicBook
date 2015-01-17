using System;

using Bau.Libraries.LibFeeds.Syndication.FeedExtensions.RSSContent.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.FeedExtensions.RSSContent.Transforms
{
	/// <summary>
	///		Parser para los elementos de Yahoo
	/// </summary>
	internal class RSSContentParser : ExtensionParserBase
	{
		internal RSSContentParser(string strXMLNameSpace, string strPrefix) : base(strXMLNameSpace, strPrefix) {}
		
		/// <summary>
		///		Interpreta los datos de un nodo XML
		/// </summary>
		internal override void Parse(MLNode objNode, FeedBase objFeed)
		{ RSSContentData objContent = (RSSContentData) objFeed.Extensions.Search(RSSContentConstTags.cnstStrXMLDefaultNameSpace);
			
				// Si no la encuentra la crea
					if (objContent == null)
						{ // Crea la extensión
								objContent = new RSSContentData();
							// ... y la añade a la colección
								objFeed.Extensions.Add(objContent);
						}
				// Interpreta la extensión
					Parse(objNode, objContent);
		}

		/// <summary>
		///		Interpreta un nodo
		/// </summary>
		private void Parse(MLNode objNode, RSSContentData objContent)
		{ if (objNode.Prefix.Equals(base.Prefix))
				switch (objNode.Name)
					{ case RSSContentConstTags.cnstStrRSSContentEncoded:
								objContent.ContentEncoded = objNode.Value;
							break;
					}
		}
	}
}
