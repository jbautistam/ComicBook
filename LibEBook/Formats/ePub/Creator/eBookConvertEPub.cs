using System;

using Bau.Libraries.LibEBook.Formats.eBook;

namespace Bau.Libraries.LibEBook.Formats.ePub.Creator
{
	/// <summary>
	///		Conversor del formato eBook al formato ePub
	/// </summary>
	internal class eBookConvertEPub
	{
		/// <summary>
		///		Convierte un archivo eBook al formato ePub
		/// </summary>
		internal ePubEBook Convert(Book objEBook)
		{ ePubEBook objEPub = new ePubEBook();
			OPF.OPFPackage objPackage = CreatePackage(objEPub);
			NCX.NCXFile objNCXFile = new NCX.NCXFile();
			
				// Asigna los metadatos
					objPackage.Metadata.Author = objEBook.Author;
					objPackage.Metadata.DateOriginalPublished = objEBook.DateOriginalPublished;
					objPackage.Metadata.DatePublished = objEBook.DatePublished;
					objPackage.Metadata.Language = objEBook.Language;
					objPackage.Metadata.Publisher = objEBook.Publisher;
					objPackage.Metadata.Rights = objEBook.Rights;
					objPackage.Metadata.Source = objEBook.Source;
					objPackage.Metadata.Subject = objEBook.Subject;
					objPackage.Metadata.Title = objEBook.Title;
				// Normaliza los IDs de páginas
					NormalizePagesID(objEBook);
				// Añade las páginas
					foreach (PageFile objPage in objEBook.Files)
						{ OPF.Item objItem = new OPF.Item();
						
								// Asigna los datos
									objItem.ID = objPage.ID;
									objItem.MediaType = objPage.MediaType;
									objItem.URL = objPage.FileName;
								// Añade la página
									objPackage.Manifest.Add(objItem);
						}
				// Añade el spine
					objPackage.Spine.AddRange(GetSpine(objEBook, objEBook.Index));
				// Añade las tablas de contenido al índice
					objNCXFile.Pages.AddRange(GetNavPoints(objEBook.TableOfContent));
				// Añade el índice al paquete
					objPackage.TablesOfContents.Add(objNCXFile);
				// Devuelve el archivo en formato ePub
					return objEPub;
		}

		/// <summary>
		///		Normaliza los IDs de las páginas
		/// </summary>
		private void NormalizePagesID(Book objEBook)
		{ int intIndex = 1;

				// Recorre las páginas
					foreach (PageFile objPage in objEBook.Files)
						{ string strNewID = "Page" + (intIndex++).ToString();

								// Cambia los IDs de los índices
									ChangeIndexID(objPage.ID, strNewID, objEBook.Index);
									ChangeIndexID(objPage.ID, strNewID, objEBook.TableOfContent);
								// Cambia el ID de la página
									objPage.ID = strNewID;
						}
		}

		/// <summary>
		///		Cambia el índice de una página
		/// </summary>
		private void ChangeIndexID(string strID, string strNewID, IndexItemsCollection objColIndex)
		{ foreach (IndexItem objIndex in objColIndex)
				{ // Cambia el ID de la página
						if (objIndex.IDPage.Equals(strID, StringComparison.CurrentCultureIgnoreCase))
							objIndex.IDPage = strNewID;
					// Cambia el ID de los índices internos
						ChangeIndexID(strID, strNewID, objIndex.Items);
				}
		}

		/// <summary>
		///		Obtiene los elementos para el índice principal
		/// </summary>
		private OPF.ItemsRefCollection GetSpine(Book objEBook, IndexItemsCollection objColIndex)
		{	OPF.ItemsRefCollection objColItemsRef = new OPF.ItemsRefCollection();

				// Añade los elementos del índice
					foreach (IndexItem objIndex in objColIndex)
						{ PageFile objPage = objEBook.Files.SearchByFileName(objIndex.URL);
						
								// Añade la página al índice
									if (objPage != null)
										{ OPF.ItemRef objItemRef = new OPF.ItemRef();
									
												// Asigna los datos
													objItemRef.ID = objIndex.ID;
													objItemRef.IDRef = objPage.ID;
													objItemRef.IsLinear = true;
												// Añade la referencia al archivo
													objColItemsRef.Add(objItemRef);
										}
								// Añade las páginas hija
									objColItemsRef.AddRange(GetSpine(objEBook, objIndex.Items));
						}
				// Devuelve la colección
					return objColItemsRef;
		}

		/// <summary>
		///		Crea los puntos de navegación
		/// </summary>
		private NCX.NavPointsCollection GetNavPoints(IndexItemsCollection objColIndex)
		{ NCX.NavPointsCollection objColNavPoints = new NCX.NavPointsCollection();
		
				// Crea los índices
					for (int intIndex = 0; intIndex < objColIndex.Count; intIndex++)
						{ NCX.NavPoint objNavPoint = new NCX.NavPoint();
						
								// Asigna las propiedades
									objNavPoint.ID = objColIndex[intIndex].ID;
									objNavPoint.Order = intIndex + 1;
									objNavPoint.Title = objColIndex[intIndex].Name;
									objNavPoint.URL = objColIndex[intIndex].URL;
								// Añade los índices
									objNavPoint.Pages.AddRange(GetNavPoints(objColIndex[intIndex].Items));
								// Añade el navPoint a la colección
									objColNavPoints.Add(objNavPoint);
						}
				// Devuelve el índice
					return objColNavPoints;
		}
		
		/// <summary>
		///		Crea el paquete
		/// </summary>
		private OPF.OPFPackage CreatePackage(ePubEBook objEPub)
		{ Container.RootFile objRootFile = new Container.RootFile();
			OPF.OPFPackage objPackage = new Bau.Libraries.LibEBook.Formats.ePub.OPF.OPFPackage();
			
				// Añade el paquete al rootFile
					objRootFile.Packages.Add(objPackage);
				// Añade el rootFile
					objEPub.Container.RootFiles.Add(objRootFile);
				// Devuelve el paquete
					return objPackage;
		}
	}
}
