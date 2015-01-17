using System;

using Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Yahoo.Data;
using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Yahoo.Transforms
{
	/// <summary>
	///		Escribe los datos de <see cref="YahooMedia"/> sobre un archivo XML
	/// </summary>
	internal class YahooMediaWriter
	{
		/// <summary>
		///		Escribe los datos de un <see cref="YahooMedia"/>
		/// </summary>
		internal static void AddNodesExtension(MLNode objParent, YahooMedia objYahoo)
		{ MLNode objNode = objParent.Nodes.Add(YahooMediaConstTags.cnstStrXMLDefaultPrefix, 
																					 YahooMediaConstTags.cnstStrYahooMediaThumbnail, null, false);
				
				// Atributos
					objNode.Attributes.Add(YahooMediaConstTags.cnstStrYahooMediaThumbnailAttrUrl, objYahoo.Thumbnail.Url);
					objNode.Attributes.Add(YahooMediaConstTags.cnstStrYahooMediaThumbnailAttrWidth, objYahoo.Thumbnail.Width);
					objNode.Attributes.Add(YahooMediaConstTags.cnstStrYahooMediaThumbnailAttrHeight, objYahoo.Thumbnail.Height);
		}
	}
}
