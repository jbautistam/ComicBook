using System;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Colección de <see cref="LibraryItem"/>
	/// </summary>
	public class LibraryItemsCollection : BaseCollectorCollection<LibraryItem>
	{ 	
		/// <summary>
		///		Añade un elemento 
		/// </summary>
		public LibraryItem Add(string strFileName)
		{ LibraryItem objLibrary = new LibraryItem();
		
				// Asigna los parámetros
					objLibrary.FileName = strFileName;
				// Añade el objeto a la colección
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
												// Añade el elemento a la colección
													Add(objItem);
											}
										catch {}
								}
				}
		}

		/// <summary>
		///		Graba los elementos de una librería
		/// </summary>
		internal void Save(string strPath)
		{ foreach (LibraryItem objItem in this)
				objItem.Save(System.IO.Path.Combine(strPath, 
																						System.IO.Path.GetFileName(objItem.FileName) + "." + LibraryItem.cnstStrFileExtension));
		}		
		
		/// <summary>
		///		Busca un elemento por nombre de archivo y si no lo encuentra, lo añade
		/// </summary>
		private LibraryItem SearchByFileName(string strFileName)
		{ // Recorre la colección buscando el elemento
				foreach (LibraryItem objLibrary in this)
					if (objLibrary.FileName.Equals(strFileName, StringComparison.CurrentCultureIgnoreCase))
						return objLibrary;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return Add(strFileName);
		}
		
		public LibraryItem this[string strFileName]
		{ get { return SearchByFileName(strFileName); }
		}
	}
}
