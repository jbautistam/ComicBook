using System;

using Bau.Libraries.LibFeeds.Syndication.RSS.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.RSS.Transforms
{
	/// <summary>
	///		Clase para escritura de un objeto RSS en un archivo XML
	/// </summary>
	public static class RSSWriter
	{
		/// <summary>
		///		Obtiene el XML de un canal RSS
		/// </summary>
		public static string GetXML(RSSChannel objRss)
		{ return GetFile(objRss).ToString();
		}

		/// <summary>
		///		Graba los datos de un objeto RSS en un archivo XML
		/// </summary>
		public static void Save(RSSChannel objRss, string strFileName)
		{ new XMLWriter().Save(GetFile(objRss), strFileName);
		}

		/// <summary>
		///		Obtiene el builder XML de un objeto RSS
		/// </summary>
		private static MLFile GetFile(RSSChannel objRss)
		{ MLFile objFile = new MLFile();
			MLNode objNode = objFile.Nodes.Add(RSSConstTags.cnstStrRoot);
		
				// Añade los atributos de la cabecera
					objNode.NameSpaces.AddRange(objRss.Extensions.GetNameSpaces(objRss));
					objNode.Attributes.Add("version", "2.0");
				// Añade los datos del canal
					objNode = objNode.Nodes.Add(RSSConstTags.cnstStrChannel);
				// Obtiene el XML de los datos
					objNode.Nodes.Add(RSSConstTags.cnstStrChannelTitle, objRss.Title);
					objNode.Nodes.Add(RSSConstTags.cnstStrChannelLink, objRss.Link);
					objNode.Nodes.Add(RSSConstTags.cnstStrChannelLanguage, objRss.Language);
					objNode.Nodes.Add(RSSConstTags.cnstStrChannelCopyright, objRss.Copyright);
					objNode.Nodes.Add(RSSConstTags.cnstStrChannelDescription, objRss.Description);
					objNode.Nodes.Add(RSSConstTags.cnstStrChannelLastBuildDate, 
														DateTimeHelper.ToStringRfc822(objRss.LastBuildDate));
				// Obtiene el XML de la imagen
					AddImage(objNode, objRss.Logo);
				// Obtiene el XML de las extensiones
					objRss.Extensions.AddNodesExtension(objNode);
				// Obtiene el XML de los elementos
					AddItems(objNode, objRss.Entries);
				// Devuelve los datos
					return objFile;
		}
		
		/// <summary>
		///		Añade los datos de la imagen
		/// </summary>
		private static void AddImage(MLNode objParent, RSSImage objImage)
		{ if (!string.IsNullOrEmpty(objImage.Url))
				{ MLNode objNode = objParent.Nodes.Add(RSSConstTags.cnstStrChannelImage);
				
						// Atributos
							objNode.Attributes.Add(RSSConstTags.cnstStrChannelImageUrl,objImage.Url);
							objNode.Attributes.Add(RSSConstTags.cnstStrChannelImageTitle, objImage.Title);
							objNode.Attributes.Add(RSSConstTags.cnstStrChannelImageLink, objImage.Link);
				}
		}

		/// <summary>
		///		Añade los elementos al XML
		/// </summary>
		private static void AddItems(MLNode objParent, FeedEntriesBaseCollection<RSSEntry> objColEntries)
		{	foreach (RSSEntry objEntry in objColEntries)
				{ MLNode objNode = objParent.Nodes.Add(RSSConstTags.cnstStrItem);
					MLNode objID;
				
						// Datos básicos
							objNode.Nodes.Add(RSSConstTags.cnstStrItemTitle, objEntry.Title);
							objNode.Nodes.Add(RSSConstTags.cnstStrItemLink, objEntry.Link);
							objNode.Nodes.Add(RSSConstTags.cnstStrItemDescription, objEntry.Content);
							AddDate(objNode, RSSConstTags.cnstStrItemPubDate, objEntry.DateCreated);
						// ID
							objID = objNode.Nodes.Add(RSSConstTags.cnstStrItemGuid, objEntry.GUID.ID);
							objID.Attributes.Add(RSSConstTags.cnstStrItemAttrPermaLink, objEntry.GUID.IsPermaLink);
						// Categorías
							foreach (RSSCategory objCategory in objEntry.Categories)
								objNode.Nodes.Add(RSSConstTags.cnstStrItemCategory, objCategory.Text);
						// Adjuntos
							AddEnclosures(objNode, objEntry.Enclosures);
						// Autores
							foreach (RSSAuthor objAuthor in objEntry.Authors)
								objNode.Nodes.Add(RSSConstTags.cnstStrItemAuthor, objAuthor.Name);
						// Obtiene el XML de las extensiones
							objEntry.Extensions.AddNodesExtension(objNode);
				}
		}

		/// <summary>
		///		Añade los adjuntos
		/// </summary>
		private static void AddEnclosures(MLNode objParent, 
																			RSSEnclosureCollections objColEnclosures)
		{ foreach (RSSEnclosure objEnclosure in objColEnclosures)
				{ MLNode objNode = objParent.Nodes.Add(RSSConstTags.cnstStrItemEnclosure);
				
						// Atributos
							objNode.Attributes.Add(RSSConstTags.cnstStrItemAttrUrl, objEnclosure.Url);
							objNode.Attributes.Add(RSSConstTags.cnstStrItemAttrLength, objEnclosure.Length);
							objNode.Attributes.Add(RSSConstTags.cnstStrItemAttrType, objEnclosure.Type);
				}
		}

		/// <summary>
		///		Añade una fecha formateada
		/// </summary>
		private static void AddDate(MLNode objNode, string strTag, DateTime dtmValue)
		{ objNode.Nodes.Add(strTag, DateTimeHelper.ToStringRfc822(dtmValue));
		}
	}
}
