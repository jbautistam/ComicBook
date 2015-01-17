using System;

using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.Atom.Transforms
{
	/// <summary>
	///		Clase para escribir un archivo Atom
	/// </summary>
	public static class AtomWriter
	{
		/// <summary>
		///		Obtiene el XML de un canal Atom
		/// </summary>
		public static string GetXML(AtomChannel objAtom)
		{ return GetFile(objAtom).ToString();
		}

		/// <summary>
		///		Graba los datos de un objeto Atom en un archivo XML
		/// </summary>
		public static void Save(AtomChannel objAtom, string strFileName)
		{	new XMLWriter().Save(GetFile(objAtom), strFileName);
		}

		/// <summary>
		///		Obtiene el builder XML de un objeto Atom
		/// </summary>
		private static MLFile GetFile(AtomChannel objAtom)
		{ MLFile objFile = new MLFile();
			MLNode objNode;
		
				// Añade la cabecera
					objNode = objFile.Nodes.Add(AtomConstTags.cnstStrChannelRoot);
					objNode.Attributes.Add("xmlns", "http://purl.org/atom/ns#");
					objNode.NameSpaces.AddRange(objAtom.Extensions.GetNameSpaces(objAtom));
					objNode.Attributes.Add("version", "0.3");
				// Obtiene el XML de los datos
					objNode.Nodes.Add(AtomConstTags.cnstStrChannelId, objAtom.ID);
					AddText(objNode, AtomConstTags.cnstStrChannelTitle, objAtom.Title);
					AddText(objNode, AtomConstTags.cnstStrChannelTagline, objAtom.TagLine);
					AddText(objNode, AtomConstTags.cnstStrSubtitle, objAtom.Subtitle);
					objNode.Nodes.Add(AtomConstTags.cnstStrIcon, objAtom.Icon);
					objNode.Nodes.Add(AtomConstTags.cnstStrLogo, objAtom.Logo);
					AddRights(objNode, objAtom.Rights);
					AddGenerator(objNode, objAtom.Generator);
					objNode.Nodes.Add(AtomConstTags.cnstStrChannelConvertLineBreaks, objAtom.ConvertLineBreaks);
					AddText(objNode, AtomConstTags.cnstStrChannelInfo, objAtom.Info);
					AddLinks(objNode, objAtom.Links);
					AddDate(objNode, AtomConstTags.cnstStrItemModified, objAtom.LastUpdated);
					AddCategories(objNode, objAtom.Categories);
				// Obtiene el XML de las extensiones
					objAtom.Extensions.AddNodesExtension(objNode);
				// Obtiene el XML de los elementos
					AddItems(objNode, objAtom.Entries);
				// Devuelve los datos
					return objFile;
		}

		/// <summary>
		///		Añade al XML un nodo identificando un texto Atom
		/// </summary>
		private static void AddText(MLNode objParent, string strTag, AtomText objText)
		{ MLNode objNode = objParent.Nodes.Add(strTag, objText.Content);
		
				// Crea la cadena de atributos
					objNode.Attributes.Add(AtomConstTags.cnstStrAttrMode, objText.Mode);
					objNode.Attributes.Add(AtomConstTags.cnstStrAttrType, objText.Type);
					objNode.Attributes.Add(AtomConstTags.cnstStrAttrLanguage, objText.Language);
					objNode.Attributes.Add(AtomConstTags.cnstStrAttrXMLBase, objText.XmlBase);
		}
		
		/// <summary>
		///		Añade al XML un nodo identificando el generador del archivo Atom
		/// </summary>
		private static void AddGenerator(MLNode objParent, AtomGenerator objGenerator)
		{ MLNode objNode = objParent.Nodes.Add(AtomConstTags.cnstStrChannelGenerator, objGenerator.Name);
		
				// Crea la cadena de atributos
					objNode.Attributes.Add(AtomConstTags.cnstStrAttrURL, objGenerator.URL);
					objNode.Attributes.Add(AtomConstTags.cnstStrAttrVersion, objGenerator.Version);
					objNode.Attributes.Add(AtomConstTags.cnstStrAttrLanguage, objGenerator.Language);
		}

		/// <summary>
		///		Añade los datos de los derechos al XML
		/// </summary>
		private static void AddRights(MLNode objParent, AtomRights objRights)
		{ MLNode objNode = objParent.Nodes.Add(AtomConstTags.cnstStrRights,objRights.Copyright);
		
				// Atributos
					objNode.Attributes.Add(AtomConstTags.cnstStrAttrType, objRights.Type);
		}

		/// <summary>
		///		Añade los elementos al XML
		/// </summary>
		private static void AddItems(MLNode objParent, FeedEntriesBaseCollection<AtomEntry> objColEntries)
		{	foreach (AtomEntry objEntry in objColEntries)
				{ MLNode objNode = objParent.Nodes.Add(AtomConstTags.cnstStrItemRoot);
				
						// Datos básicos
							objNode.Nodes.Add(AtomConstTags.cnstStrItemID, objEntry.ID);
							AddText(objNode, AtomConstTags.cnstStrItemTitle, objEntry.Title);
							AddText(objNode, AtomConstTags.cnstStrItemContent, objEntry.Content);
							AddText(objNode, AtomConstTags.cnstStrSummary, objEntry.Summary);
						// Fechas
							AddDate(objNode, AtomConstTags.cnstStrItemIssued, objEntry.DateIssued);
							AddDate(objNode, AtomConstTags.cnstStrItemModified, objEntry.DateModified);
							AddDate(objNode, AtomConstTags.cnstStrItemCreated, objEntry.DateCreated);
							AddDate(objNode, AtomConstTags.cnstStrItemUpdated, objEntry.DateUpdated);
							AddDate(objNode, AtomConstTags.cnstStrItemPublished, objEntry.DatePublished);
						// Vínculos
							AddLinks(objNode, objEntry.Links);
						// Autores
							AddPeople(objNode, AtomConstTags.cnstStrItemAuthor, objEntry.Authors);
							AddPeople(objNode, AtomConstTags.cnstStrItemContributor, objEntry.Contributors);
						// Categorías
							AddCategories(objNode, objEntry.Categories);
						// Origen
							AddSource(objNode, objEntry.Source);
						// Derechos
							AddRights(objNode, objEntry.Rights);
						// Extensiones
							objEntry.Extensions.AddNodesExtension(objNode);
				}
		}

		/// <summary>
		///		Añade una fecha formateada
		/// </summary>
		private static void AddDate(MLNode objNode, string strTag, DateTime dtmValue)
		{ objNode.Nodes.Add(strTag, DateTimeHelper.ToStringRfc822(dtmValue));
		}

		/// <summary>
		///		Añade los adjuntos
		/// </summary>
		private static void AddLinks(MLNode objParent, AtomLinksCollection objColLinks)
		{ foreach (AtomLink objLink in objColLinks)
				{ MLNode objNode = objParent.Nodes.Add(AtomConstTags.cnstStrItemLink);
				
						// Añade los atributos
							if (!string.IsNullOrEmpty(objLink.Href))
								objNode.Attributes.Add(AtomConstTags.cnstStrAttrHref, objLink.Href);
							if (!string.IsNullOrEmpty(objLink.Rel))
								objNode.Attributes.Add(AtomConstTags.cnstStrAttrRel, objLink.Rel);
							if (!string.IsNullOrEmpty(objLink.Type))
								objNode.Attributes.Add(AtomConstTags.cnstStrAttrType, objLink.Type);
							if (!string.IsNullOrEmpty(objLink.Title))
								objNode.Attributes.Add(AtomConstTags.cnstStrAttrTitle, objLink.Title);
				}
		}

		/// <summary>
		///		Añade los nodos de las categorías
		/// </summary>
		private static void AddCategories(MLNode objParent, AtomCategoriesCollection objColCategories)
		{ foreach (AtomCategory objCategory in objColCategories)
				{ MLNode objNode = objParent.Nodes.Add(AtomConstTags.cnstStrChannelCategory);
				
						// Atributos
							objNode.Attributes.Add(AtomConstTags.cnstStrAttrTerm, objCategory.Name);
				}
		}

		/// <summary>
		///		Añade los nodos de autores
		/// </summary>
		private static void AddPeople(MLNode objParent, string strTag, AtomPersonsCollection objColPersons)
		{ foreach (AtomPeople objPeople in objColPersons)
				{ MLNode objNode = objParent.Nodes.Add(strTag);
				
						// Cuerpo
							objNode.Nodes.Add(AtomConstTags.cnstStrItemPeopleName, objPeople.Name);
							objNode.Nodes.Add(AtomConstTags.cnstStrItemPeopleUrl, objPeople.URL);
							objNode.Nodes.Add(AtomConstTags.cnstStrItemPeopleEMail, objPeople.EMail);
				}
		}

		/// <summary>
		///		Añade los datos del origen
		/// </summary>
		private static void AddSource(MLNode objParent, AtomSource objSource)
		{ MLNode objNode = objParent.Nodes.Add(AtomConstTags.cnstStrSource);
		
				// Cuerpo
					objNode.Nodes.Add(AtomConstTags.cnstStrChannelId, objSource.ID);
					objNode.Nodes.Add(AtomConstTags.cnstStrChannelTitle, objSource.Title);
					AddDate(objNode, AtomConstTags.cnstStrItemUpdated, objSource.DateUpdated);
					objNode.Nodes.Add(AtomConstTags.cnstStrRights, objSource.Copyright);
		}
	}
}