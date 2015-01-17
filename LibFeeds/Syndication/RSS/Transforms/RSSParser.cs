using System;

using Bau.Libraries.LibFeeds.Syndication.RSS.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.RSS.Transforms
{
	/// <summary>
	///		Parser para un archivo RSS
	/// </summary>
	public static class RSSParser
	{ 
		/// <summary>
		///		Interpreta un archivo
		/// </summary>
		public static RSSChannel Parse(string strFileName)
		{ RSSChannel objRSS = null;
			MLFile objFile = new XMLParser().Load(strFileName);
			
				// Recorre los nodos del documento
					foreach (MLNode objNode in objFile.Nodes)
						if (objNode.Name.Equals(RSSConstTags.cnstStrRoot))
							{ // Crea el objeto
									objRSS = new RSSChannel();
								// Lee los espacios de nombres de las extensiones
									objRSS.Dictionary.LoadNameSpaces(objNode);
								// Lee los datos
									foreach (MLNode objChannel in objNode.Nodes)
										if (objChannel.Name.Equals(RSSConstTags.cnstStrChannel))
											ParseChannel(objChannel, objRSS);
							}
				// Devuelve el objeto RSS
					return objRSS;
		}
		
		/// <summary>
		///		Interpreta los datos del canal
		/// </summary>
		private static void ParseChannel(MLNode objChannel, RSSChannel objRSS)
		{ foreach (MLNode objNode in objChannel.Nodes)
				switch (objNode.Name)
					{ case RSSConstTags.cnstStrChannelTitle:
								objRSS.Title = objNode.Value;
							break;
						case RSSConstTags.cnstStrChannelDescription:
								objRSS.Description = objNode.Value;
							break;
						case RSSConstTags.cnstStrChannelLink:
								objRSS.Link = objNode.Value;
							break;
						case RSSConstTags.cnstStrChannelLanguage:
								objRSS.Language = objNode.Value;
							break;
						case RSSConstTags.cnstStrChannelCopyright:
								objRSS.Copyright = objNode.Value;
							break;
						case RSSConstTags.cnstStrChannelPubDate:
								objRSS.PubDate = objNode.GetValue(DateTime.Now);
							break;
						case RSSConstTags.cnstStrChannelLastBuildDate:
								objRSS.LastBuildDate = objNode.GetValue(DateTime.Now);
							break;
						case RSSConstTags.cnstStrChannelManagingEditor:
								objRSS.Editor = objNode.Value;
							break;
						case RSSConstTags.cnstStrChannelManagingWebMaster:
								objRSS.WebMaster = objNode.Value;
							break;
						case RSSConstTags.cnstStrChannelGenerator:
								objRSS.Generator = objNode.Value;
							break;
						case RSSConstTags.cnstStrChannelImage:
								objRSS.Logo = ParseImage(objNode);
							break;
						case RSSConstTags.cnstStrItem:
								objRSS.Entries.Add(ParseEntry(objNode, objRSS));
							break;
						default:
								objRSS.Extensions.Parse(objNode, objRSS, objRSS.Dictionary);
							break;
					}
		}

		/// <summary>
		///		Interpreta los nodos de una imagen
		/// </summary>
		private static RSSImage ParseImage(MLNode objMLImage)
		{ RSSImage objImage = new RSSImage();
		
				// Lee los datos de la imagen
					foreach (MLNode objNode in objMLImage.Nodes)
						switch (objNode.Name)
							{ case RSSConstTags.cnstStrChannelImageUrl:
										objImage.Url = objNode.Value;
									break;
								case RSSConstTags.cnstStrChannelImageTitle:
										objImage.Title = objNode.Value;
									break;
								case RSSConstTags.cnstStrChannelImageLink:
										objImage.Link = objNode.Value;
									break;
							}
				// Devuelve la imagen
					return objImage;
		}

		/// <summary>
		///		Interpreta los nodos de un elemento
		/// </summary>
		private static RSSEntry ParseEntry(MLNode objMLEntry, RSSChannel objChannel)
		{ RSSEntry objEntry = new RSSEntry();
		
				// Interpreta los nodos
					foreach (MLNode objNode in objMLEntry.Nodes)
						switch (objNode.Name)
							{ case RSSConstTags.cnstStrItemTitle:
										objEntry.Title = objNode.Value;
									break;
								case RSSConstTags.cnstStrItemLink:
										objEntry.Link = objNode.Value;
									break;
								case RSSConstTags.cnstStrItemDescription:
										objEntry.Content = objNode.Value;
									break;
								case RSSConstTags.cnstStrItemCategory:
										objEntry.Categories.Add(ParseCategory(objNode));
									break;
								case RSSConstTags.cnstStrItemPubDate:
										objEntry.DateCreated = objNode.GetValue(DateTime.Now);
									break;
								case RSSConstTags.cnstStrItemGuid:
										objEntry.GUID = ParseGuid(objNode);
									break;
								case RSSConstTags.cnstStrItemEnclosure:
										objEntry.Enclosures.Add(ParseEnclosure(objNode));
									break;
								case RSSConstTags.cnstStrItemAuthor:
										objEntry.Authors.Add(ParseAuthor(objNode));
									break;
								default:
										objEntry.Extensions.Parse(objNode, objEntry, objChannel.Dictionary);
									break;
							}
				// Devuelve la entrada
					return objEntry;
		}

		/// <summary>
		///		Interpreta el ID
		/// </summary>
		private static RSSGuid ParseGuid(MLNode objNode)
		{ RSSGuid objGuid = new RSSGuid();
		
				// Interpreta el XML
					objGuid.IsPermaLink = objNode.Attributes.GetValue(RSSConstTags.cnstStrItemAttrPermaLink, false);
					objGuid.ID = objNode.Value;
				// Devuelve el objeto
					return objGuid;
		}

		/// <summary>
		///		Interpreta los datos del autor
		/// </summary>
		private static RSSAuthor ParseAuthor(MLNode objNode)
		{ return new RSSAuthor(objNode.Value);
		}

		/// <summary>
		///		Interpreta la categoría
		/// </summary>
		private static RSSCategory ParseCategory(MLNode objNode)
		{ return new RSSCategory(objNode.Value);
		}

		/// <summary>
		///		Interpreta un adjunto
		/// </summary>
		private static RSSEnclosure ParseEnclosure(MLNode objNode)
		{ RSSEnclosure objEnclosure = new RSSEnclosure();
		
				// Recoge los datos
					objEnclosure.Url = objNode.Attributes.GetValue(RSSConstTags.cnstStrItemAttrUrl);
					objEnclosure.Length = objNode.Attributes.GetValue(RSSConstTags.cnstStrItemAttrLength, 0);
					objEnclosure.Type = objNode.Attributes.GetValue(RSSConstTags.cnstStrItemAttrType);
				// Devuelve el objeto
					return objEnclosure;
		}
	}
}