using System;

using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Libraries.LibFeeds.Syndication.Atom.Transforms
{
	/// <summary>
	///		Intérprete de un archivo Atom
	/// </summary>
	public static class AtomParser
	{
		/// <summary>
		///		Interpreta un archivo
		/// </summary>
		public static AtomChannel Parse(string strFileName)
		{ MLFile objFile = new XMLParser().Load(strFileName);
			AtomChannel objAtom = null;
		
				// Recorre los nodos del documento
					foreach (MLNode objNode in objFile.Nodes)
						if (objNode.Name.Equals(AtomConstTags.cnstStrChannelRoot))
							{ // Crea el objeto
									objAtom = new AtomChannel();
								// Lee los datos
									ParseChannel(objNode, objAtom);
							}
				// Devuelve el objeto Atom
					return objAtom;
		}
		
		/// <summary>
		///		Interpreta los datos del canal
		/// </summary>
		private static void ParseChannel(MLNode objNode, AtomChannel objAtom)
		{ foreach (MLNode objChild in objNode.Nodes)
				switch (objChild.Name)
					{ case AtomConstTags.cnstStrChannelId:
								objAtom.ID = objChild.Value;
							break;
						case AtomConstTags.cnstStrChannelTitle:
								objAtom.Title = ParseText(objChild);
							break;
						case AtomConstTags.cnstStrChannelTagline:
								objAtom.TagLine = ParseText(objChild);
							break;
						case AtomConstTags.cnstStrSubtitle:
								objAtom.Subtitle = ParseText(objChild);
							break;
						case AtomConstTags.cnstStrIcon:
								objAtom.Icon = objChild.Value;
							break;
						case AtomConstTags.cnstStrLogo:
								objAtom.Logo = objChild.Value;
							break;
						case AtomConstTags.cnstStrRights:
								objAtom.Rights = ParseRights(objChild);
							break;
						case AtomConstTags.cnstStrChannelGenerator:
								objAtom.Generator = ParseGenerator(objChild);
							break;
						case AtomConstTags.cnstStrChannelConvertLineBreaks:
								objAtom.ConvertLineBreaks = objChild.GetValue(false);
							break;
						case AtomConstTags.cnstStrChannelInfo:
								objAtom.Info = ParseText(objChild);
							break;
						case AtomConstTags.cnstStrItemLink:
								objAtom.Links.Add(ParseLink(objChild));
							break;
						case AtomConstTags.cnstStrItemModified:
								objAtom.LastUpdated = objChild.GetValue(DateTime.Now);
							break;
						case AtomConstTags.cnstStrChannelCategory:
								objAtom.Categories.Add(ParseCategory(objChild));
							break;
						case AtomConstTags.cnstStrItemRoot:
								objAtom.Entries.Add(ParseEntry(objChild, objAtom));
							break;
						default:
								objAtom.Extensions.Parse(objChild, objAtom, objAtom.Dictionary);
							break;
					}
		}

		/// <summary>
		///		Interpreta un texto de Atom
		/// </summary>
		private static AtomText ParseText(MLNode objNode)
		{ return new AtomText(objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrMode),
													objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrType),
													objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrLanguage),
													objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrXMLBase),
													objNode.Value);
		}

		/// <summary>
		///		Interpreta el generador de Atom
		/// </summary>
		private static AtomGenerator ParseGenerator(MLNode objNode)
		{ return new AtomGenerator(objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrURL),
															 objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrVersion),
															 objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrLanguage),
															 objNode.Value);
		}
		
		/// <summary>
		///		Interpreta un vínculo de Atom
		/// </summary>
		private static AtomLink ParseLink(MLNode objNode)
		{ AtomLink objLink = new AtomLink(objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrHref),
																			objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrRel),
																			objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrTitle),
																			objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrType));
												
				// Si no se ha recogido ninguna refencia mira en el InnerText
					if (string.IsNullOrEmpty(objLink.Href) && !string.IsNullOrEmpty(objNode.Value))
						objLink.Href = objNode.Value;
				// Devuelve el vínculo
					return objLink;
		}

		/// <summary>
		///		Interpreta una categoría de Atom
		/// </summary>
		private static AtomCategory ParseCategory(MLNode objNode)
		{ return new AtomCategory(objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrTerm));
		}

		/// <summary>
		///		Interpreta una entrada de un archivo Atom
		/// </summary>
		private static AtomEntry ParseEntry(MLNode objMLEntry, AtomChannel objAtom)
		{ AtomEntry objEntry = new AtomEntry();
		
				// Recorre los nodos
					foreach (MLNode objNode in objMLEntry.Nodes)
						switch (objNode.Name)
							{ case AtomConstTags.cnstStrItemID:
										objEntry.ID = objNode.Value;
									break;
								case AtomConstTags.cnstStrItemTitle:
										objEntry.Title = ParseText(objNode);
									break;
								case AtomConstTags.cnstStrItemContent:
										objEntry.Content = ParseText(objNode);
									break;
								case AtomConstTags.cnstStrSummary:
										objEntry.Summary = ParseText(objNode);
									break;
								case AtomConstTags.cnstStrItemIssued:
										objEntry.DateIssued = objNode.GetValue(DateTime.MinValue);
									break;
								case AtomConstTags.cnstStrItemModified:
										objEntry.DateModified = objNode.GetValue(DateTime.MinValue);
									break;
								case AtomConstTags.cnstStrItemCreated:
										objEntry.DateCreated = objNode.GetValue(DateTime.MinValue);
									break;
								case AtomConstTags.cnstStrItemUpdated:
										objEntry.DateUpdated = objNode.GetValue(DateTime.MinValue);
									break;
								case AtomConstTags.cnstStrItemPublished:
										objEntry.DatePublished = objNode.GetValue(DateTime.MinValue);
									break;
								case AtomConstTags.cnstStrItemLink:
										objEntry.Links.Add(ParseLink(objNode));									
									break;
								case AtomConstTags.cnstStrItemAuthor:
										objEntry.Authors.Add(ParsePeople(objNode));
									break;
								case AtomConstTags.cnstStrItemContributor:
										objEntry.Contributors.Add(ParsePeople(objNode));
									break;
								case AtomConstTags.cnstStrChannelCategory:
										objEntry.Categories.Add(ParseCategory(objNode));
									break;
								case AtomConstTags.cnstStrSource:
										objEntry.Source = ParseSource(objNode);
									break;
								case AtomConstTags.cnstStrRights:
										objEntry.Rights = ParseRights(objNode);
									break;
								default:
										objEntry.Extensions.Parse(objNode, objEntry, objAtom.Dictionary);
									break;
							}
				// Actualiza la fecha de creación
					if (objEntry.DateCreated.Date == DateTime.MinValue.Date)
						{ objEntry.DateCreated = objEntry.DatePublished;
							if (objEntry.DateCreated.Date == DateTime.MinValue.Date)
								objEntry.DateCreated = DateTime.Now;
						}
				// Devuelve la entrada
					return objEntry;
		}

		/// <summary>
		///		Interpreta un nodo con derechos
		/// </summary>
		private static AtomRights ParseRights(MLNode objNode)
		{ return new AtomRights(objNode.Attributes.GetValue(AtomConstTags.cnstStrAttrType), objNode.Value);
		}

		/// <summary>
		///		Interpreta el origen de un nodo
		/// </summary>
		private static AtomSource ParseSource(MLNode objMLSource)
		{ AtomSource objSource = new AtomSource();
		
				// Interpreta los datos del nodo
					foreach (MLNode objNode in objMLSource.Nodes)
						switch (objNode.Name)
							{ case AtomConstTags.cnstStrChannelId:
										objSource.ID = objNode.Value;
									break;
								case AtomConstTags.cnstStrChannelTitle:
										objSource.Title = objNode.Value;
									break;
								case AtomConstTags.cnstStrItemUpdated:
										objSource.DateUpdated = objNode.GetValue(DateTime.Now);
									break;
								case AtomConstTags.cnstStrRights:
										objSource.Copyright = objNode.Value;
									break;
							}
				// Devuelve los datos
					return objSource;
		}

		/// <summary>
		///		Interpreta un nodo XML para obtener los datos de una persona
		/// </summary>
		private static AtomPeople ParsePeople(MLNode objMLPeople)
		{ AtomPeople objPeople = new AtomPeople();
		
				// Recorre los nodos
					foreach (MLNode objNode in objMLPeople.Nodes)
						switch (objNode.Name)
							{ case AtomConstTags.cnstStrItemPeopleName:
										objPeople.Name = objNode.Value;
									break;
								case AtomConstTags.cnstStrItemPeopleUrl:
										objPeople.URL = objNode.Value;
									break;
								case AtomConstTags.cnstStrItemPeopleEMail:
										objPeople.EMail = objNode.Value;
									break;
							}
				// Devuelve el objeto
					return objPeople;
		}
	}
}