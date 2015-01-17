using System;

using Bau.Libraries.LibEBook.Formats.eBook;

namespace Bau.Libraries.LibEBook.Formats.ePub.Creator
{
	/// <summary>
	///		Convierte un objeto ePub en un objeto eBook
	/// </summary>
	internal class ePubConvertEBook
	{
		/// <summary>
		///		Convierte un <see cref="ePubBook"/> en un <see cref="Book"/>
		/// </summary>
		internal Book Convert(ePubEBook objEPub)
		{ Book objEBook = new Book();
		
				// Asigna los metadatos
					AssignMetadata(objEPub.Container.RootFiles[0].Packages[0].Metadata, objEBook);
				// Añade los archivos
					AddPages(objEPub, objEBook);
				// Añade el índice
					AddIndex(objEPub, objEBook);
				// Indexa las páginas
					IndexPagesNumber(objEBook);
				// Devuelve el libro
					return objEBook;
		}

		
		/// <summary>
		///		Asigna los metadatos de un ePub a un eBook
		/// </summary>
		private void AssignMetadata(OPF.Metadata objMetadata, Book objEBook)
		{	objEBook.Author = objMetadata.Author;
			objEBook.DateOriginalPublished = objMetadata.DateOriginalPublished;
			objEBook.DatePublished = objMetadata.DatePublished;
			objEBook.Language = objMetadata.Language;
			objEBook.Publisher = objMetadata.Publisher;
			objEBook.Rights = objMetadata.Rights;
			objEBook.Source = objMetadata.Source;
			objEBook.Subject = objMetadata.Subject;
			objEBook.Title = objMetadata.Title;
		}
		
		/// <summary>
		///		Añade los archivos
		/// </summary>
		private void AddPages(ePubEBook objEPub, Book objEBook)
		{ foreach (Container.RootFile objRootFile in objEPub.Container.RootFiles)
				foreach (OPF.OPFPackage objPackage in objRootFile.Packages)
					foreach (OPF.Item objItem in objPackage.Manifest)
						objEBook.Files.Add(objItem.ID, objItem.ID, 
															 System.IO.Path.Combine(System.IO.Path.GetDirectoryName(objRootFile.URL), objItem.URL), 
															 objItem.MediaType);
		}
		
		/// <summary>
		///		Añade los índices
		/// </summary>
		private void AddIndex(ePubEBook objEPub, Book objEbook)
		{ foreach (Container.RootFile objRootFile in objEPub.Container.RootFiles)
				foreach (OPF.OPFPackage objPackage in objRootFile.Packages)
					{ // Añade la tabla de contenidos
							AddIndex(System.IO.Path.GetDirectoryName(objRootFile.URL), objPackage.TablesOfContents, 
											 objEbook.TableOfContent);
						// Añade el índice
							AddIndex(objPackage.Spine, objEbook);
					}
		}

		/// <summary>
		///		Añade un índice
		/// </summary>
		private void AddIndex(string strPathBase, NCX.NCXFilesCollection objColNCXFiles, 
													IndexItemsCollection objColIndexItems)
		{ foreach (NCX.NCXFile objNCXFile in objColNCXFiles)
				{ IndexItem objItem = new IndexItem(objNCXFile.Title, objNCXFile.ID, null);
				
						// Añade los puntos de navegación
							foreach (NCX.NavPoint objNavPoint in objNCXFile.Pages)
								AddIndex(strPathBase, objNavPoint, objItem);
						// Añade el elemento a la colección
							objColIndexItems.Add(objItem);
				}
		}

		/// <summary>
		///		Añade el elemento
		/// </summary>
		private void AddIndex(string strPathBase, NCX.NavPoint objNavPoint, IndexItem objItemParent)
		{ IndexItem objItem = new IndexItem(objNavPoint.Title, objNavPoint.ID, 
																				System.IO.Path.Combine(strPathBase, objNavPoint.URL));
		
				// Añade el elemento 
					objItemParent.Items.Add(objItem);
				// Añade los hijos
					foreach (NCX.NavPoint objNavChild in objNavPoint.Pages)
						AddIndex(strPathBase, objNavChild, objItem);
		}

		/// <summary>
		///		Añade un índice
		/// </summary>
		private void AddIndex(OPF.ItemsRefCollection objColItemsRefs, Book objBook)
		{ int intIndex = 1;
		
				foreach (OPF.ItemRef objItemRef in objColItemsRefs)
					{ PageFile objPage = objBook.Files.Search(objItemRef.IDRef);
					
							if (objPage != null)
								{ // Añade la página
										objBook.Index.Add("Capítulo " + intIndex.ToString(), objItemRef.ID, objPage.FileName);
									// Incrementa el índice
										intIndex++;
								}
					}
		}

		/// <summary>
		///		Indexa el número de páginas
		/// </summary>
		private void IndexPagesNumber(Book objEBook)
		{ int intPage = 0;

				// Indexa las páginas
					IndexPagesNumber(objEBook.Index, ref intPage);
				// Guarda el número de páginas
					objEBook.MaxPageNumber = intPage;
		}

		/// <summary>
		///		Crea los números de páginas del índice
		/// </summary>
		private void IndexPagesNumber(IndexItemsCollection objColIndexItems, ref int intPage)
		{ foreach (IndexItem objIndexItem in objColIndexItems)
				{ // Asigna el número de página
						objIndexItem.PageNumber = ++intPage;
					// Asigna el número de páginas hijas
						if (objIndexItem.Items != null && objIndexItem.Items.Count > 0)
							IndexPagesNumber(objIndexItem.Items, ref intPage);
				}
		}
	}
}
