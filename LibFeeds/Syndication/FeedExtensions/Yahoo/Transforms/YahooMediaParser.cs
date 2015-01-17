using System;

using Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Yahoo.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Yahoo.Transforms
{
	/// <summary>
	///		Parser para los elementos de Yahoo
	/// </summary>
	internal class YahooMediaParser : ExtensionParserBase
	{
		internal YahooMediaParser(string strXMLNameSpace, string strPrefix) : base(strXMLNameSpace, strPrefix) {}
		
		/// <summary>
		///		Interpreta los datos de un nodo XML
		/// </summary>
		internal override void Parse(MLNode objNode, FeedBase objFeed)
		{ YahooMedia objYahoo = (YahooMedia) objFeed.Extensions.Search(YahooMediaConstTags.cnstStrXMLDefaultNameSpace);
			
				// Si no la encuentra la crea
					if (objYahoo == null)
						{ // Crea la extensión
								objYahoo = new YahooMedia();
							// ... y la añade a la colección
								objFeed.Extensions.Add(objYahoo);
						}
				// Interpreta la extensión
					Parse(objNode, objYahoo);					
		}

		/// <summary>
		///		Interpreta un nodo
		/// </summary>
		private void Parse(MLNode objNode, YahooMedia objYahoo)
		{ if (objNode.Prefix.Equals(base.Prefix))
				switch (objNode.Name)
					{ case YahooMediaConstTags.cnstStrYahooMediaThumbnail:
								objYahoo.Thumbnail = ParseThumbnail(objNode);
							break;
					}
		}

		/// <summary>
		///		Interpreta los datos de un thumbnail
		/// </summary>
		private YahooMediaThumbnail ParseThumbnail(MLNode objNode)
		{ YahooMediaThumbnail objThumbnail = new YahooMediaThumbnail();
		
				// Interpreta el objeto
					objThumbnail.Url = objNode.Attributes.GetValue(YahooMediaConstTags.cnstStrYahooMediaThumbnailAttrUrl);
					objThumbnail.Width = objNode.Attributes.GetValue(YahooMediaConstTags.cnstStrYahooMediaThumbnailAttrWidth, 0);
					objThumbnail.Height = objNode.Attributes.GetValue(YahooMediaConstTags.cnstStrYahooMediaThumbnailAttrHeight, 0);
				// Devuelve el thumbnail
					return objThumbnail;
		}
	}
}
