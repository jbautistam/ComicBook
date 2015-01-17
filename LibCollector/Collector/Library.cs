using System;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Librería con una colección
	/// </summary>
	public class Library
	{ // Variables privadas
			private LibraryItemsCollection objColLibraryItems;
			private ParameterNamesCollection objColParameterNames;
		
		/// <summary>
		///		Carga una biblioteca a partir de un directorio
		/// </summary>
		public void Load(string strPath)
		{ // Carga los elementos de la librería
				LibraryItems.Load(strPath);
			// Carga los parámetros
				ParameterNames.Load(strPath);
		}	
		
		/// <summary>
		///		Graba una biblioteca en un directorio
		/// </summary>
		public void Save(string strPath)
		{ // Graba los elementos de la librería
				LibraryItems.Save(strPath);
			// Graba los parámetros
				ParameterNames.Save(strPath);
		}
		
		/// <summary>
		///		Limpia los elementos de la biblioteca
		/// </summary>
		public void Clear()
		{ LibraryItems.Clear();
			ParameterNames.Clear();
		}

		/// <summary>
		///		Buca los elementos de la colección con un valor para un parámetro determinado
		/// </summary>
		public LibraryItemsCollection SearchItems(string strIDParameterName, string strIDParameterValue)
		{ LibraryItemsCollection objColItems = new LibraryItemsCollection();
		
				// Si no se le ha pasado ningún valor, se busca en la colección los que no tienen nada con ese nombre de parámetro
					if (string.IsNullOrEmpty(strIDParameterValue))
						{ // Recorre la colección buscando los que no tienen ningún valor de ese parámetro
								foreach (LibraryItem objItem in LibraryItems)
									if (!objItem.Keys.Exists(strIDParameterName))
										objColItems.Add(objItem);
						}
					else
						{	// Recorre la colección buscando los que tienen ese valor
								foreach (LibraryItem objItem in LibraryItems)
									if (objItem.Keys.Exists(strIDParameterName, strIDParameterValue))
										objColItems.Add(objItem);
						}
				// Devuelve la colección
					return objColItems;
		}
		
		public LibraryItemsCollection LibraryItems
		{ get 
				{ // Si no existen los elementos, los crea
						if (objColLibraryItems == null)
							objColLibraryItems = new LibraryItemsCollection();
					// Devuelve la colección
						return objColLibraryItems;
				}
			set { objColLibraryItems = value; }
		}
			
		public ParameterNamesCollection ParameterNames
		{ get 
				{ // Si no existen los elementos, los crea
						if (objColParameterNames == null)
							objColParameterNames = new ParameterNamesCollection();
					// Devuelve la colección
						return objColParameterNames;
				}
			set { objColParameterNames = value; }
		}
	}
}
