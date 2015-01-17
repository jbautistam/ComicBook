using System;
using System.IO;

using Bau.Libraries.LibCompression;
using Bau.Libraries.LibEBook.Formats.ePub.Container;
using Bau.Libraries.LibEBook.Formats.ePub.NCX;
using Bau.Libraries.LibEBook.Formats.ePub.OPF;
using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibHelper.Files;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Libraries.LibEBook.Formats.ePub.Creator
{
	/// <summary>
	///		Creador de archivos ePub
	/// </summary>
	public class ePubCreator
	{
		/// <summary>
		///		Crea un archivo ePub a partir de un objeto <see cref="eBook.Book"/>
		/// </summary>
		public void Create(string strFileName, eBook.Book objEBook)
		{ Create(strFileName, new eBookConvertEPub().Convert(objEBook));
		}
		
		/// <summary>
		///		Crea un archivo ePub
		/// </summary>
		public void Create(string strFileName, ePubEBook objEBook)
		{ string strPathTemporal = Path.Combine(Path.GetDirectoryName(strFileName), 
																						"temp" + Path.GetFileNameWithoutExtension(strFileName));
			Compressor objCompressor = new Compressor();
			
		
				// Crea el directorio raíz
					HelperFiles.MakePath(strPathTemporal);
				// Crea el archivo mimeType
					HelperFiles.SaveTextFile(Path.Combine(strPathTemporal, "mimetype"), "application/epub+zip", System.Text.Encoding.Default);
				// Crea el archivo Container.xml
					CreateContainer(strPathTemporal, objEBook);
				// Crea los archivos de contenido
					CreateContent(strPathTemporal, objEBook);
				// Comprime el directorio
					objCompressor.Compress(strFileName, strPathTemporal, Compressor.CompressType.Zip);
				// Elimina el directorio temporal
					HelperFiles.KillPath(strPathTemporal);
		}

		/// <summary>
		///		Crea el archivo contenedor (container.xml) en el directorio META-INF
		/// </summary>
		private void CreateContainer(string strPath, ePubEBook objEBook)
		{ string strPathMeta = Path.Combine(strPath, "META-INF");
			MLFile objMLFile = new MLFile();
			MLNode objMLRoot = objMLFile.Nodes.Add(ContainerConstants.cnstStrTagRoot);
			MLNode objMLRootFiles;
			
				// Asigna la codificación al archivo
					objMLFile.Encoding = MLFile.EncodingMode.UTF8;
				// Añade los atributos al nodo raíz
					objMLRoot.Attributes.Add(ContainerConstants.cnstStrTagRootVersion, ContainerConstants.cnstStrTagRootVersionValue);
					objMLRoot.Attributes.Add(ContainerConstants.cnstStrTagRootNameSpace, ContainerConstants.cnstStrTagRootNameSpaceValue);
				// Añade el nodo de archivos raíz
					objMLRootFiles = objMLRoot.Nodes.Add(ContainerConstants.cnstStrTagRootFilesRoot);
				// Añade los rootFiles
					for (int intIndex = 0; intIndex < objEBook.Container.RootFiles.Count; intIndex++)
						{ MLNode objMLRootFile = objMLRootFiles.Nodes.Add(ContainerConstants.cnstStrTagRootFileRoot);
						
								// Añade los atributos al nodo rootFile
									objMLRootFile.Attributes.Add(ContainerConstants.cnstStrTagRootFilePath, GetRootFileOPFFileName(intIndex));
									objMLRootFile.Attributes.Add(ContainerConstants.cnstStrTagRootFileMediaType,
																							 ContainerConstants.cnstStrTagRootFileMediaTypeValue);
						}
				// Crea el directorio raíz
					HelperFiles.MakePath(strPathMeta);
				// Graba el archivo
					new XMLWriter().Save(objMLFile, Path.Combine(strPathMeta, "container.xml"));
		}

		/// <summary>
		///		Crea los archivos de contenido
		/// </summary>
		private void CreateContent(string strPath, ePubEBook objEBook)
		{ int intIndex = 0;
		
				foreach (RootFile objRootFile in objEBook.Container.RootFiles)
					{ string strPathPackage = Path.Combine(strPath, GetRootFilePath(intIndex).Replace("/", "\\"));
					
							// Crea el directorio
								HelperFiles.MakePath(strPathPackage);
							// Crea el paquete OPF
								foreach (OPFPackage objPackage in objRootFile.Packages)
									{ // Copia los archivos
											CopyFiles(strPathPackage, objPackage.Manifest);
										// Crea el archivo OPF
											CreateOPF(intIndex, strPathPackage, objPackage);
										// Crea el archivo NCX
											CreateNCX(strPathPackage, objPackage);
									}
							// Incrementa el índice de rootFile
								intIndex++;
					}	
		}

		/// <summary>
		///		Copia los archivos
		/// </summary>
		private void CopyFiles(string strPath, ItemsCollection objColItems)
		{ foreach (Item objItem in objColItems)
				HelperFiles.CopyFile(objItem.URL, Path.Combine(strPath, Path.GetFileName(objItem.URL)));
		}

		/// <summary>
		///		Crea el archivo del paquete OPF
		/// </summary>
		private void CreateOPF(int intRootFile, string strPath, OPFPackage objPackage)
		{ MLFile objMLFile = new MLFile();
			MLNode objMLRoot = objMLFile.Nodes.Add(OPFPackageConstants.cnstStrTagRoot);
		
				// Añade los espacios de nombres
					objMLRoot.NameSpaces.Add("", OPFPackageConstants.cnstStrTagRootNameSpace);
				// Añade los atributos
					objMLRoot.Attributes.Add(OPFPackageConstants.cnstStrTagRootVersion, OPFPackageConstants.cnstStrTagRootVersionValue);
					objMLRoot.Attributes.Add(OPFPackageConstants.cnstStrTagRootUniqueIdentifier, 
																	 OPFPackageConstants.cnstStrTagRootUniqueIdentifierValue);																	
				// Añade los metadatos
					objMLRoot.Nodes.Add(GetMetadata(objPackage));
				// Añade el manifiesto con los archivos
					objMLRoot.Nodes.Add(GetManifest(objPackage));
				// Añade el spine
					objMLRoot.Nodes.Add(GetSpine(objPackage));
				// Graba el archivo
					new XMLWriter().Save(objMLFile, Path.Combine(strPath, Path.GetFileName(GetRootFileOPFFileName(intRootFile).Replace("/", "\\"))));
		}

		/// <summary>
		///		Obtiene el nodo con los metadatos del paquete
		/// </summary>
		private MLNode GetMetadata(OPFPackage objPackage)
		{ MLNode objMLNode = new MLNode(OPFPackageConstants.cnstStrTagMetadata);

				// Añade los espacios de nombres
					objMLNode.NameSpaces.Add(OPFPackageConstants.cnstStrTagRootNameSpacePrefix, OPFPackageConstants.cnstStrTagRootNameSpace);
					objMLNode.NameSpaces.Add(Extensions.DC.DublinCoreConstants.cnstStrNameSpacePrefix,
																	 Extensions.DC.DublinCoreConstants.cnstStrNameSpace);
				// Añade los metadatos
					objMLNode.Nodes.Add(Extensions.DC.DublinCoreConstants.cnstStrNameSpacePrefix,
															Extensions.DC.DublinCoreConstants.cnstStrTagRights,
															objPackage.Metadata.Rights, true);
					objMLNode.Nodes.Add(Extensions.DC.DublinCoreConstants.cnstStrNameSpacePrefix,
															Extensions.DC.DublinCoreConstants.cnstStrTagIdentifier,
															objPackage.Metadata.ID, true);
					objMLNode.Nodes.Add(Extensions.DC.DublinCoreConstants.cnstStrNameSpacePrefix,
															Extensions.DC.DublinCoreConstants.cnstStrTagCreator,
															objPackage.Metadata.Author, true);
					objMLNode.Nodes.Add(Extensions.DC.DublinCoreConstants.cnstStrNameSpacePrefix,
															Extensions.DC.DublinCoreConstants.cnstStrTagTitle,
															objPackage.Metadata.Title, true);
					objMLNode.Nodes.Add(Extensions.DC.DublinCoreConstants.cnstStrNameSpacePrefix,
															Extensions.DC.DublinCoreConstants.cnstStrTagLanguage,
															objPackage.Metadata.Language, true);
					objMLNode.Nodes.Add(Extensions.DC.DublinCoreConstants.cnstStrNameSpacePrefix,
															Extensions.DC.DublinCoreConstants.cnstStrTagSubject,
															objPackage.Metadata.Subject, true);
					objMLNode.Nodes.Add(Extensions.DC.DublinCoreConstants.cnstStrNameSpacePrefix,
															Extensions.DC.DublinCoreConstants.cnstStrTagDate,
															ConvertDate(objPackage.Metadata.DateOriginalPublished), false);
					objMLNode.Nodes.Add(Extensions.DC.DublinCoreConstants.cnstStrNameSpacePrefix,
															Extensions.DC.DublinCoreConstants.cnstStrTagDate,
															ConvertDate(objPackage.Metadata.DatePublished), false);
					objMLNode.Nodes.Add(Extensions.DC.DublinCoreConstants.cnstStrNameSpacePrefix,
															Extensions.DC.DublinCoreConstants.cnstStrTagSource,
															objPackage.Metadata.Source, true);
				// Devuelve el nodo
					return objMLNode;
		}

		/// <summary>
		///		Convierte la fecha
		/// </summary>
		private string ConvertDate(string strDate)
		{ DateTime? dtmDate = strDate.GetDateTime();

				// Normaliza la fecha
					if (dtmDate == null)
						dtmDate = DateTime.Now;
				// Devuelve la cadena formateada
					return string.Format("{0:yyyy-MM-dd}", dtmDate);
		}

		/// <summary>
		///		Obtiene el manifiesto
		/// </summary>
		private MLNode GetManifest(OPFPackage objPackage)
		{ MLNode objMLNode = new MLNode(OPFPackageConstants.cnstStrTagManifest);
		
				// Añade los archivos
					foreach (Item objItem in objPackage.Manifest)
						objMLNode.Nodes.Add(GetNodeItem(objItem.ID, Path.GetFileName(objItem.URL), objItem.MediaType));
				// Añade el archivo NCX que se va a crear
					for (int intIndex = 0; intIndex < objPackage.TablesOfContents.Count; intIndex++)
						objMLNode.Nodes.Add(GetNodeItem("ncx", GetNCXFileName(intIndex), NCXConstants.cnstStrMediaType));
				// Devuelve el nodo
					return objMLNode;
		}

		/// <summary>
		///		Obtiene un nodo con un elemento (Item)
		/// </summary>
		private MLNode GetNodeItem(string strID, string strURL, string strMediaType)
		{ MLNode objMLItem = new MLNode(OPFPackageConstants.cnstStrTagManifestItem);
						
				// Añade los atributos
					objMLItem.Attributes.Add(OPFPackageConstants.cnstStrTagManifestID, strID);
					objMLItem.Attributes.Add(OPFPackageConstants.cnstStrTagManifestHref, strURL);
					objMLItem.Attributes.Add(OPFPackageConstants.cnstStrTagManifestMediatype, strMediaType);
				// Devuelve el nodo
					return objMLItem;
		}

		/// <summary>
		///		Obtiene el índice principal
		/// </summary>
		private MLNode GetSpine(OPFPackage objPackage)
		{ MLNode objMLNode = new MLNode(OPFPackageConstants.cnstStrTagSpine);
		
				// Añade los atributos
					objMLNode.Attributes.Add(OPFPackageConstants.cnstStrTagSpineToc, OPFPackageConstants.cnstStrTagSpineTocValue);
				// Añade las referencias
					foreach (ItemRef objItem in objPackage.Spine)
						{ MLNode objMLItem = new MLNode(OPFPackageConstants.cnstStrTagSpineItemRef);
						
								// Añade los atributos
									objMLItem.Attributes.Add(OPFPackageConstants.cnstStrTagSpineIdRef, objItem.IDRef);
									objMLItem.Attributes.Add(OPFPackageConstants.cnstStrTagSpineLinear, objItem.IsLinear);
								// Añade el nodo
									objMLNode.Nodes.Add(objMLItem);
						}
				// Devuelve el nodo
					return objMLNode;
		}

		/// <summary>
		///		Crea el archivo NCX del paquete
		/// </summary>
		private void CreateNCX(string strPath, OPFPackage objPackage)
		{ int intIndex = 0;
		
				foreach (NCXFile objNCXFile in objPackage.TablesOfContents)
					{	MLFile objMLFile = new MLFile();
						MLNode objMLRoot = objMLFile.Nodes.Add(NCXConstants.cnstStrTagRoot);
						MLNode objMLTitle;
						
							// Añade los atributos
								objMLRoot.Attributes.Add(NCXConstants.cnstStrTagRootAttrNameSpace, NCXConstants.cnstStrTagRootAttrNameSpaceValue);
								objMLRoot.Attributes.Add(NCXConstants.cnstStrTagRootAttrVersion, NCXConstants.cnstStrTagRootAttrVersionValue);
								objMLRoot.Attributes.Add(NCXConstants.cnstStrTagRootAttrNameSpace, NCXConstants.cnstStrTagRootAttrLanguage, 
																				 NCXConstants.cnstStrTagRootAttrLanguageSpanish, false);
							// Añade el nodo con la cabecera
								objMLRoot.Nodes.Add(NCXConstants.cnstStrTagHead);
							// Añade el nodo con el título
								objMLTitle = objMLRoot.Nodes.Add(NCXConstants.cnstStrTagDocTitle);
								objMLTitle.Nodes.Add(NCXConstants.cnstStrTagText, objPackage.Metadata.Title);
							// Añade el índice
								objMLRoot.Nodes.Add(NCXConstants.cnstStrTagNavMap).Nodes.Add(GetNodesNavPoint(objNCXFile.Pages));
							// Graba el archivo
								new XMLWriter().Save(objMLFile, Path.Combine(strPath, GetNCXFileName(intIndex)));
							// Incrementa el índice
								intIndex++;
					}
		}

		/// <summary>
		///		Obtiene el nodo de una colección de puntos de navegación
		/// </summary>
		private MLNodesCollection GetNodesNavPoint(NavPointsCollection objColNavPoints)
		{ MLNodesCollection objColNodes = new MLNodesCollection();
		
				// Añade los puntos de navegación
					foreach (NavPoint objNavPoint in objColNavPoints)
						{ MLNode objMLNavPoint = new MLNode(NCXConstants.cnstStrTagNavPoint);
							MLNode objMLContent;
							
								// Añade los atributos
									objMLNavPoint.Attributes.Add(NCXConstants.cnstStrTagNavPointID, objNavPoint.ID);
									objMLNavPoint.Attributes.Add(NCXConstants.cnstStrTagNavPointOrder, objNavPoint.Order.ToString());
								// Añade la etiqueta
									objMLNavPoint.Nodes.Add(NCXConstants.cnstStrTagNavPointLabel).Nodes.Add(NCXConstants.cnstStrTagText,
																																													objNavPoint.Title);
								// Añade el contenido
									objMLContent = objMLNavPoint.Nodes.Add(NCXConstants.cnstStrTagNavPointContent);
									objMLContent.Attributes.Add(NCXConstants.cnstStrTagNavPointContentSrc,
																							Path.GetFileName(objNavPoint.URL));
								// Añade los hijos
									objMLNavPoint.Nodes.Add(GetNodesNavPoint(objNavPoint.Pages));
								// Añade el nodo a la colección
									objColNodes.Add(objMLNavPoint);
						}
				// Devuelve la colección de nodos
					return objColNodes;
		}

		/// <summary>
		///		Obtiene el nombre del directorio para los RootFiles
		/// </summary>
		private string GetRootFilePath(int intIndex)
		{ if (intIndex == 0)
				return "OPS";
			else
				return "OPS" + intIndex.ToString();
		}

		/// <summary>
		///		Obtiene el nombre del archivo OPF
		/// </summary>
		private string GetRootFileOPFFileName(int intIndex)
		{ if (intIndex == 0)
				return "OPS/ebook.opf";
			else
				return "OPS" + intIndex.ToString() + "/ebook.opf";
		}

		/// <summary>
		///		Obtiene el nombre de un archivo NCX
		/// </summary>
		private string GetNCXFileName(int intIndex)
		{ if (intIndex == 0)
				return "toc.ncx";
			else
				return "toc" + intIndex.ToString() + ".ncx";
		}
	}
}
