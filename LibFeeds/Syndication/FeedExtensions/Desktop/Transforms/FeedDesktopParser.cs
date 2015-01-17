using System;

using Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Desktop.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Desktop.Transforms
{
	/// <summary>
	///		Parser para los elementos de <see cref="FeedDesktop"/>
	/// </summary>
	internal class FeedDesktopParser : ExtensionParserBase
	{
		internal FeedDesktopParser(string strXMLNameSpace, string strPrefix) : base(strXMLNameSpace, strPrefix) {}
		
		/// <summary>
		///		Interpreta los datos de un nodo XML
		/// </summary>
		internal override void Parse(MLNode objNode, FeedBase objFeed)
		{ FeedDesktop objDesktop = (FeedDesktop) objFeed.Extensions.Search(FeedDesktopConstTags.cnstStrXMLDefaultNameSpace);
			
				// Si no la encuentra la crea
					if (objDesktop == null)
						{ // Crea la extensión
								objDesktop = new FeedDesktop();
							// ... y la añade a la colección
								objFeed.Extensions.Add(objDesktop);
						}
				// Interpreta la extensión
					Parse(objNode, objDesktop);					
		}

		/// <summary>
		///		Interpreta un nodo
		/// </summary>
		private void Parse(MLNode objNode, FeedDesktop objDesktop)
		{ if (objNode.Prefix.Equals(base.Prefix))
				switch (objNode.Name)
					{ case FeedDesktopConstTags.cnstStrRead:
								objDesktop.IsRead = objNode.GetValue(false);
							break;
						case FeedDesktopConstTags.cnstStrPriority:
								objDesktop.Priority = objNode.GetValue(0);
							break;
						case FeedDesktopConstTags.cnstStrEnabled:
								objDesktop.Enabled = objNode.GetValue(true);
							break;
					}
		}
	}
}
