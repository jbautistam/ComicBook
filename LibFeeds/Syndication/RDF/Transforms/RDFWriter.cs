using System;

using Bau.Libraries.LibFeeds.Syndication.RDF.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.RDF.Transforms
{
	/// <summary>
	///		Clase para escritura de un objeto RDF en un archivo XML
	/// </summary>
	public static class RDFWriter
	{
		/// <summary>
		///		Obtiene el XML de un canal RDF
		/// </summary>
		public static string GetXML(RDFChannel objRDF)
		{ return GetFile(objRDF).ToString();
		}

		/// <summary>
		///		Graba los datos de un objeto RDF en un archivo XML
		/// </summary>
		public static void Save(RDFChannel objRDF, string strFileName)
		{ new XMLWriter().Save(GetFile(objRDF), strFileName);
		}

		/// <summary>
		///		Obtiene el builder XML de un objeto RDF
		/// </summary>
		private static MLFile GetFile(RDFChannel objRDF)
		{ MLFile objFile = new MLFile();
			MLNode objNode = objFile.Nodes.Add(RDFConstTags.cnstStrRoot);
		
				// Añade los atributos de la cabecera
					objNode.NameSpaces.AddRange(objRDF.Extensions.GetNameSpaces(objRDF));
				// Añade los datos del canal
					objNode = objNode.Nodes.Add(RDFConstTags.cnstStrChannel);
				// Obtiene el XML de los datos del canal
					objNode.Nodes.Add(RDFConstTags.cnstStrChannelTitle, objRDF.Title);
					objNode.Nodes.Add(RDFConstTags.cnstStrChannelLink, objRDF.Link);
					objNode.Nodes.Add(RDFConstTags.cnstStrChannelDescription, objRDF.Description);
				// Obtiene el XML de las extensiones
					objRDF.Extensions.AddNodesExtension(objNode);
				// Obtiene el XML de los elementos
					AddItems(objNode, objRDF.Entries);
				// Devuelve los datos
					return objFile;
		}

		/// <summary>
		///		Añade los elementos al XML
		/// </summary>
		private static void AddItems(MLNode objParent, FeedEntriesBaseCollection<RDFEntry> objColEntries)
		{	foreach (RDFEntry objEntry in objColEntries)
				{ MLNode objNode = objParent.Nodes.Add(RDFConstTags.cnstStrItem);
				
						// Datos básicos
							objNode.Nodes.Add(RDFConstTags.cnstStrItemTitle, objEntry.Title);
							objNode.Nodes.Add(RDFConstTags.cnstStrItemLink, objEntry.Link);
							objNode.Nodes.Add(RDFConstTags.cnstStrItemDescription, objEntry.Content);
						// Obtiene el XML de las extensiones
							objEntry.Extensions.AddNodesExtension(objNode);
				}
		}
	}
}
