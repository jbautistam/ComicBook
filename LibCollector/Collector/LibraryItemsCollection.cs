using System;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Colecci�n de <see cref="LibraryItem"/>
	/// </summary>
	public class LibraryItemsCollection : BaseCollectorCollection<LibraryItem>
	{ 	
		/// <summary>
		///		A�ade un elemento 
		/// </summary>
		public LibraryItem Add(string strFileName)
		{ LibraryItem objLibrary = new LibraryItem();
		
				// Asigna los par�metros
					objLibrary.FileName = strFileName;
				// A�ade el objeto a la colecci�n
					Add(objLibrary);
				// Devuelve el objeto
					return objLibrary;
		}
		
		/// <summary>
		///		Carga los elementos de un directorio
		/// </summary>
		public void Load(string strPath)
		{ if (System.IO.Directory.Exists(strPath))
				{ string [] arrStrFiles = System.IO.Directory.GetFiles(strPath, "*." + LibraryItem.cnstStrFileExtension);
		
						// Carga todos los archivos
							foreach (string strFileName in arrStrFiles)
								{ LibraryItem objItem = new LibraryItem();
								
										try
											{ // Carga el XML
													objItem.LoadXML(strFileName);
												// A�ade el elemento a la colecci�n
													Add(objItem);
											}
										catch {}
								}
				}
		}

		/// <summary>
		///		Graba los elementos de una librer�a
		/// </summary>
		internal void Save(string strPath)
		{ foreach (LibraryItem objItem in this)
				objItem.Save(System.IO.Path.Combine(strPath, 
																						System.IO.Path.GetFileName(objItem.FileName) + "." + LibraryItem.cnstStrFileExtension));
		}		
		
		/// <summary>
		///		Busca un elemento por nombre de archivo y si no lo encuentra, lo a�ade
		/// </summary>
		private LibraryItem SearchByFileName(string strFileName)
		{ // Recorre la colecci�n buscando el elemento
				foreach (LibraryItem objLibrary in this)
					if (objLibrary.FileName.Equals(strFileName, StringComparison.CurrentCultureIgnoreCase))
						return objLibrary;
			// Si ha llegado hasta aqu� es porque no ha encontrado nada
				return Add(strFileName);
		}
		
		public LibraryItem this[string strFileName]
		{ get { return SearchByFileName(strFileName); }
		}
	}
}
