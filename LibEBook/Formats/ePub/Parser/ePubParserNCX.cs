using System;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;
using Bau.Libraries.LibEBook.Formats.ePub.OPF;
using Bau.Libraries.LibEBook.Formats.ePub.NCX;

namespace Bau.Libraries.LibEBook.Formats.ePub.Parser
{
	/// <summary>
	///		Intérprete de los archivos NCX
	/// </summary>
	public class ePubParserNCX
	{
		/// <summary>
		///		Interpreta los NCXs de un archivo
		/// </summary>
		internal static void Parse(OPFPackage objPackage, string strPath)
		{ ItemsCollection objColTocs = objPackage.Manifest.SearchMediaType(Extensions.Media.MediaTypeConstants.cnstStrNCX);
		
				// Limpia el archivo NCX
					objPackage.TablesOfContents.Clear();
				// Carga los archivos de contenido
					foreach (Item objItem in objColTocs)
						objPackage.TablesOfContents.Add(Parse(System.IO.Path.Combine(strPath, objItem.URL)));
		}

		/// <summary>
		///		Interpreta el NCX de un elemento 
		/// </summary>
		private static NCXFile Parse(string strFileName)
		{ NCXFile objNCX = new NCXFile();
			MLFile objMLFile = new XMLParser().Load(strFileName);
			MLNode objMLNode = objMLFile.Nodes[NCXConstants.cnstStrTagRoot];
				
				// Carga los datos
					if (objMLNode != null)
						{ // Interpreta la cabecera
								ParseHeader(objNCX, objMLNode);
							// Interpreta el índice
								objNCX.Pages.AddRange(ParseIndex(objMLNode.Nodes[NCXConstants.cnstStrTagNavMap]));
						}
				// Devuelve el objeto
					return objNCX;
		}
		
		/// <summary>
		///		Interpreta la cabecera
		/// </summary>
		private static void ParseHeader(NCXFile objNCX, MLNode objMLNode)
		{ foreach (MLNode objMLChild in objMLNode.Nodes)
				switch (objMLChild.Name)
					{ case NCXConstants.cnstStrTagHead:
								foreach (MLNode objMLMeta in objMLChild.Nodes)
									{ string strValue = objMLMeta.Attributes[NCXConstants.cnstStrTagHeadMetaAttrContent].Value;
										int intValue;
										
											// Asigna el valor numérico
												if (!int.TryParse(strValue, out intValue))
													intValue = 0;
											// Asigna el valor a las propiedades
												switch (objMLMeta.Attributes[NCXConstants.cnstStrTagHeadMetaAttrName].Value)
													{ case NCXConstants.cnstStrTagHeadMetaAttrNameIDValue:
																objNCX.ID = strValue;
															break;
														case NCXConstants.cnstStrTagHeadMetaAttrNameGeneratorValue:
																objNCX.Generator = strValue;
															break;
														case NCXConstants.cnstStrTagHeadMetaAttrNameDepthValue:
																objNCX.Depth = intValue;
															break;
														case NCXConstants.cnstStrTagHeadMetaAttrNameTotalPageCountValue:
																objNCX.PageCount = intValue;
															break;
														case NCXConstants.cnstStrTagHeadMetaAttrNameMaxPageNumberValue:
																objNCX.PageNumber = intValue;
															break;
													}
									}
							break;
						case NCXConstants.cnstStrTagDocTitle:
								objNCX.Title = objMLChild.Nodes[NCXConstants.cnstStrTagText].Value;
							break;
					}
		}

		/// <summary>
		///		Interpreta el índice
		/// </summary>
		private static NavPointsCollection ParseIndex(MLNode objMLNode)
		{ NavPointsCollection objColPages = new NavPointsCollection();
		
				// Carga los datos
					if (objMLNode != null)
						foreach (MLNode objMLChild in objMLNode.Nodes)
							if (objMLChild.Name == NCXConstants.cnstStrTagNavPoint)
								{ NavPoint objPage = new NavPoint();
								
										// Carga los datos básicos
											objPage.ID = objMLChild.Attributes[NCXConstants.cnstStrTagNavPointID].Value;
											objPage.Order = objMLChild.Attributes.GetValue(NCXConstants.cnstStrTagNavPointOrder, 0);
										// Carga el resto de datos
											foreach (MLNode objMLData in objMLChild.Nodes)
												switch (objMLData.Name)
													{ case NCXConstants.cnstStrTagNavPointLabel:
																objPage.Title = objMLData.Nodes[NCXConstants.cnstStrTagText].Value;
															break;
														case NCXConstants.cnstStrTagNavPointContent:
																objPage.URL = objMLData.Attributes[NCXConstants.cnstStrTagNavPointContentSrc].Value;
															break;
													}
										// Carga las páginas hija
											objPage.Pages.AddRange(ParseIndex(objMLChild));
										// Añade la página a la colección
											objColPages.Add(objPage);
								}						
				// Devuelve la colección
					return objColPages;
		}
	}
}
