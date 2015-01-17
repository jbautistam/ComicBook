using System;

using Bau.Libraries.LibEBook.Formats.ePub.OPF;
using Bau.Libraries.LibEBook.Formats.Extensions.DC;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Libraries.LibEBook.Formats.ePub.Parser
{
	/// <summary>
	///		Intérprete de un paquete
	/// </summary>
	internal static class ePubParserPackage
	{
		/// <summary>
		///		Interpreta la información del paquete de un ePub
		/// </summary>
		internal static void Parse(ePubEBook objBook, string strPath)
		{ foreach (Container.RootFile objRootFile in objBook.Container.RootFiles)
				{ // Limpia los paquetes
						objRootFile.Packages.Clear();
					// Añade los paquetes del archivo
						objRootFile.Packages.Add(ParsePackage(System.IO.Path.Combine(strPath, objRootFile.URL)));
				}
		}

		/// <summary>
		///		Interpreta un paquete
		/// </summary>
		private static OPFPackage ParsePackage(string strFileName)
		{ OPFPackage objPackage = new OPFPackage();
			MLFile objMLFile = new XMLParser().Load(strFileName);
			MLNode objMLNode = objMLFile.Nodes[OPFPackageConstants.cnstStrTagRoot];
			
				// Interpreta el paquete
					if (objMLNode != null)
						{ // Interpreta los  metadatos
								objPackage.Metadata = ParseMetadata(objMLNode.Nodes[OPFPackageConstants.cnstStrTagMetadata]);
							// Interpreta el manifiesto
								ParseManifest(objPackage, objMLNode.Nodes[OPFPackageConstants.cnstStrTagManifest]);
							// Interpreta el índice
								ParseSpine(objPackage, objMLNode.Nodes[OPFPackageConstants.cnstStrTagSpine]);
							// Interpreta el NCX
								ePubParserNCX.Parse(objPackage, System.IO.Path.GetDirectoryName(strFileName));
						}
				// Devuelve el paquete
					return objPackage;
		}
		
		/// <summary>
		///		Interpreta los metadatos
		/// </summary>
		private static Metadata ParseMetadata(MLNode objMLNode)
		{ Metadata objMetadata = new Metadata();

				// Carga los datos		
					if (objMLNode != null)
						{ objMetadata.ID = objMLNode.Nodes[DublinCoreConstants.cnstStrTagIdentifier].Value;
							objMetadata.Title = objMLNode.Nodes[DublinCoreConstants.cnstStrTagTitle].Value;
							objMetadata.Author = Search(objMLNode.Nodes,
																					DublinCoreConstants.cnstStrTagCreator,
																					OPFConstants.cnstStrTagAttributesRole,
																					OPFConstants.cnstStrTagValueRoleAut);
							objMetadata.Publisher = objMLNode.Nodes[DublinCoreConstants.cnstStrTagPublisher].Value;
							objMetadata.DateOriginalPublished = Search(objMLNode.Nodes, 
																												 DublinCoreConstants.cnstStrTagDate,
																												 OPFConstants.cnstStrTagAttributesEvent,
																												 OPFConstants.cnstStrTagValueEventOriginalPublication);
							objMetadata.DatePublished = Search(objMLNode.Nodes, 
																								 DublinCoreConstants.cnstStrTagDate,
																								 OPFConstants.cnstStrTagAttributesEvent,
																								 OPFConstants.cnstStrTagValueEventPublication);
							objMetadata.Subject = objMLNode.Nodes[DublinCoreConstants.cnstStrTagSubject].Value;
							objMetadata.Source = objMLNode.Nodes[DublinCoreConstants.cnstStrTagSource].Value;
							objMetadata.Rights = objMLNode.Nodes[DublinCoreConstants.cnstStrTagRights].Value;
							objMetadata.Language = objMLNode.Nodes[DublinCoreConstants.cnstStrTagLanguage].Value;
						}
				// Devuelve los metadatos
					return objMetadata;
		}

		/// <summary>
		///		Obtiene el valor del nodo con una etiqueta y un valor particular en un atributo
		/// </summary>
		private static string Search(MLNodesCollection objColMLNodes, string strTag, 
																 string strAttribute, string strValue)
		{ // Busca la etiqueta en los nodos
				foreach (MLNode objMLNode in objColMLNodes)
					if (objMLNode.Name == strTag)
						{ MLAttribute objAttribute = objMLNode.Attributes.Search(strAttribute);
						
								if (objAttribute != null && objAttribute.Value == strAttribute)
									return objMLNode.Value;
						}
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}
		
		/// <summary>
		///		Interpreta el manifiesto del libro
		/// </summary>
		private static void ParseManifest(OPFPackage objPackage, MLNode objMLNode)
		{ // Limpia el manifiesto
				objPackage.Manifest.Clear();
			// Carga los datos
				if (objMLNode != null)
					foreach (MLNode objMLChild in objMLNode.Nodes)
						if (objMLChild.Name == OPFPackageConstants.cnstStrTagManifestItem)
							{ Item objItem = new Item();
							
									// Interpreta el nodo
										objItem.ID = objMLChild.Attributes[OPFPackageConstants.cnstStrTagManifestID].Value;
										objItem.URL = objMLChild.Attributes[OPFPackageConstants.cnstStrTagManifestHref].Value;
										objItem.MediaType = objMLChild.Attributes[OPFPackageConstants.cnstStrTagManifestMediatype].Value;
									// Añade el elemento
										objPackage.Manifest.Add(objItem);
							}
		}

		/// <summary>
		///		Interpreta el índice del libro
		/// </summary>
		private static void ParseSpine(OPFPackage objPackage, MLNode objMLNode)
		{ // Limpia el índice
				objPackage.Spine.Clear();
			// Carga los datos
				if (objMLNode != null)
					foreach (MLNode objMLChild in objMLNode.Nodes)
						if (objMLChild.Name == OPFPackageConstants.cnstStrTagSpineItemRef)
							{ ItemRef objItem = new ItemRef();
							
									// Interpreta el nodo
										objItem.IDRef = objMLChild.Attributes[OPFPackageConstants.cnstStrTagSpineIdRef].Value;
										objItem.IsLinear = objMLChild.Attributes.GetValue(OPFPackageConstants.cnstStrTagSpineLinear,
																																			true);
									// Añade el elemento
										objPackage.Spine.Add(objItem);
							}
		}
	}
}
