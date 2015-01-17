using System;

using Bau.Libraries.LibFeeds.Syndication.RDF.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.RDF.Transforms
{
	/// <summary>
	///		Parser para un archivo RDF
	/// </summary>
	public static class RDFParser
	{ 
		/// <summary>
		///		Interpreta un archivo
		/// </summary>
		public static RDFChannel Parse(string strFileName)
		{ RDFChannel objRDF = null;
			MLFile objFile = new XMLParser().Load(strFileName);
			MLNode objNode = objFile.Nodes[RDFConstTags.cnstStrRoot];
			
					if (objNode != null && objNode.Name == RDFConstTags.cnstStrRoot)
						{ // Crea el objeto
								objRDF = new RDFChannel();
							// Lee los espacios de nombres de las extensiones
								objRDF.Dictionary.LoadNameSpaces(objNode);
							// Lee los datos del canal
								foreach (MLNode objChannel in objNode.Nodes)
									if (objChannel.Name.Equals(RDFConstTags.cnstStrChannel))
										ParseChannel(objChannel, objRDF);
							// Lee los elementos
								foreach (MLNode objItem in objNode.Nodes)
									if (objItem.Name.Equals(RDFConstTags.cnstStrItem))
										objRDF.Entries.Add(ParseEntry(objItem, objRDF));
						}
				// Devuelve el objeto RDF
					return objRDF;
		}
		
		/// <summary>
		///		Interpreta los datos del canal
		/// </summary>
		private static void ParseChannel(MLNode objChannel, RDFChannel objRDF)
		{ foreach (MLNode objNode in objChannel.Nodes)
				switch (objNode.Name)
					{ case RDFConstTags.cnstStrChannelTitle:
								objRDF.Title = objNode.Value;
							break;
						case RDFConstTags.cnstStrChannelDescription:
								objRDF.Description = objNode.Value;
							break;
						case RDFConstTags.cnstStrChannelLink:
								objRDF.Link = objNode.Value;
							break;
						default:
								objRDF.Extensions.Parse(objNode, objRDF, objRDF.Dictionary);
							break;
					}
		}

		/// <summary>
		///		Interpreta los nodos de un elemento
		/// </summary>
		private static RDFEntry ParseEntry(MLNode objMLEntry, RDFChannel objChannel)
		{ RDFEntry objEntry = new RDFEntry();
		
				// Interpreta los nodos
					foreach (MLNode objNode in objMLEntry.Nodes)
						switch (objNode.Name)
							{ case RDFConstTags.cnstStrItemTitle:
										objEntry.Title = objNode.Value;
									break;
								case RDFConstTags.cnstStrItemLink:
										objEntry.Link = objNode.Value;
									break;
								case RDFConstTags.cnstStrItemDescription:
										objEntry.Content = objNode.Value;
									break;
								default:
										objEntry.Extensions.Parse(objNode, objEntry, objChannel.Dictionary);
									break;
							}
				// Devuelve la entrada
					return objEntry;
		}
	}
}