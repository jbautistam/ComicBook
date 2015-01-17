using System;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Librer�a con una colecci�n
	/// </summary>
	public class Library
	{ // Variables privadas
			private LibraryItemsCollection objColLibraryItems;
			private ParameterNamesCollection objColParameterNames;
		
		/// <summary>
		///		Carga una biblioteca a partir de un directorio
		/// </summary>
		public void Load(string strPath)
		{ // Carga los elementos de la librer�a
				LibraryItems.Load(strPath);
			// Carga los par�metros
				ParameterNames.Load(strPath);
		}	
		
		/// <summary>
		///		Graba una biblioteca en un directorio
		/// </summary>
		public void Save(string strPath)
		{ // Graba los elementos de la librer�a
				LibraryItems.Save(strPath);
			// Graba los par�metros
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
		///		Buca los elementos de la colecci�n con un valor para un par�metro determinado
		/// </summary>
		public LibraryItemsCollection SearchItems(string strIDParameterName, string strIDParameterValue)
		{ LibraryItemsCollection objColItems = new LibraryItemsCollection();
		
				// Si no se le ha pasado ning�n valor, se busca en la colecci�n los que no tienen nada con ese nombre de par�metro
					if (string.IsNullOrEmpty(strIDParameterValue))
						{ // Recorre la colecci�n buscando los que no tienen ning�n valor de ese par�metro
								foreach (LibraryItem objItem in LibraryItems)
									if (!objItem.Keys.Exists(strIDParameterName))
										objColItems.Add(objItem);
						}
					else
						{	// Recorre la colecci�n buscando los que tienen ese valor
								foreach (LibraryItem objItem in LibraryItems)
									if (objItem.Keys.Exists(strIDParameterName, strIDParameterValue))
										objColItems.Add(objItem);
						}
				// Devuelve la colecci�n
					return objColItems;
		}
		
		public LibraryItemsCollection LibraryItems
		{ get 
				{ // Si no existen los elementos, los crea
						if (objColLibraryItems == null)
							objColLibraryItems = new LibraryItemsCollection();
					// Devuelve la colecci�n
						return objColLibraryItems;
				}
			set { objColLibraryItems = value; }
		}
			
		public ParameterNamesCollection ParameterNames
		{ get 
				{ // Si no existen los elementos, los crea
						if (objColParameterNames == null)
							objColParameterNames = new ParameterNamesCollection();
					// Devuelve la colecci�n
						return objColParameterNames;
				}
			set { objColParameterNames = value; }
		}
	}
}
