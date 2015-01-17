using System;

using Bau.Libraries.LibCollector.Collector;

namespace Bau.Applications.ComicsBooks.Classes.ComicFiles
{
	/// <summary>
	///		Clase con los datos de una colección de cómics
	/// </summary>
	public class clsComicLibrary
	{ // Variables privadas
			private const string cnstStrPath = "Data\\Library";
		// Eventos públicos
			public event EventHandler Updated;
		// Variables privadas
			private bool blnLoaded = false;
			private Library objLibrary = new Library();
		
		/// <summary>
		///		Obtiene el directorio base
		/// </summary>
		private string GetBasePath()
		{ return System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, cnstStrPath);
		}
		
		/// <summary>
		///		Carga los datos de una colección
		/// </summary>
		internal void Load()
		{ if (!blnLoaded)
				{ // Carga los datos de la colección
						objLibrary.Load(GetBasePath());
					// Indica que se ha cargado correctamente
						blnLoaded = true;
				}
		}
		
		/// <summary>
		///		Graba la información de los cómics
		/// </summary>
		internal void Save()
		{ objLibrary.Save(GetBasePath());
		}
		
		/// <summary>
		///		Limpia la información de los cómics
		/// </summary>
		internal void Clear()
		{ // Limpia la colección
				objLibrary.Clear();
			// Indica que no está cargada en memoria
				blnLoaded = false;
		}
		
		/// <summary>
		///		Añade la información de un cómic
		/// </summary>
		internal void AddComicInfo(Bau.Libraries.LibComicsBooks.Definition.ComicInfo objComicInfo)
		{ if (Properties.Settings.Default.AddComicInfo)
				{	// Carga los datos de la biblioteca
						Load();
					// Añade los datos
						AddComicInfo(objLibrary.LibraryItems[objComicInfo.ComicFileName], objLibrary.ParameterNames, objComicInfo);
					// Graba los datos de la biblioteca
						Save();
					// Lanza el evento de modificación
						RaiseEventUpdated();
					// Limpia la memoria
						Clear();
				}
		}

		/// <summary>
		///		Añade la información del elemento a un elemento de la biblioteca
		/// </summary>
		private void AddComicInfo(LibraryItem objLibraryItem, ParameterNamesCollection objColParametersNames,
															Bau.Libraries.LibComicsBooks.Definition.ComicInfo objComicInfo)
		{ // Guarda el nombre de archivo
				objLibraryItem.FileName = objComicInfo.ComicFileName;
			// Guarda los parámetros generales
				AddParameterInfo(objLibraryItem, objColParametersNames, "Author", objComicInfo.Author);
				AddParameterInfo(objLibraryItem, objColParametersNames, "DatePublish", objComicInfo.DatePublish);
				AddParameterInfo(objLibraryItem, objColParametersNames, "Drawer", objComicInfo.Drawer);
				AddParameterInfo(objLibraryItem, objColParametersNames, "Editor", objComicInfo.Editor);
				AddParameterInfo(objLibraryItem, objColParametersNames, "Editorial", objComicInfo.Editorial);
				AddParameterInfo(objLibraryItem, objColParametersNames, "Genre", objComicInfo.Genre);
				AddParameterInfo(objLibraryItem, objColParametersNames, "Notes", objComicInfo.Notes);
				AddParameterInfo(objLibraryItem, objColParametersNames, "Number", objComicInfo.Number);
				AddParameterInfo(objLibraryItem, objColParametersNames, "NumberTotal", objComicInfo.NumberTotal);
				AddParameterInfo(objLibraryItem, objColParametersNames, "Serie", objComicInfo.Serie);
				AddParameterInfo(objLibraryItem, objColParametersNames, "Summary", objComicInfo.Summary);
				AddParameterInfo(objLibraryItem, objColParametersNames, "Title", objComicInfo.Title);
			// Añade las categorías
				string [] arrStrCategories = objComicInfo.Categories.Split(';');
				
					foreach (string strCategory in arrStrCategories)
						AddParameterInfo(objLibraryItem, objColParametersNames, "Category", strCategory);
		}

		/// <summary>
		///		Añade la información de los parámetros
		/// </summary>
		private void AddParameterInfo(LibraryItem objLibraryItem, ParameterNamesCollection objColParametersNames, 
																	string strParameterName, string strParameterValue)
		{ if (!string.IsNullOrEmpty(strParameterValue))
				{	ParameterName objParameterName = objColParametersNames.Add(strParameterName);
					ParameterValue objParameterValue = objParameterName.Values.Add(strParameterValue);
					
						objLibraryItem.Keys.Add(new ParameterKey(objParameterName.ID, objParameterValue.ID));
				}
		}
		
		public ParameterValuesCollection GetParameterValues(string strParameterName)
		{ return objLibrary.ParameterNames[strParameterName].Values;
		}

		/// <summary>
		///		Obtiene los cómics de una categoría
		/// </summary>
		internal LibraryItemsCollection SearchByParameter(string strParameterName, string strIDParameterValue)
		{ return objLibrary.SearchItems(objLibrary.ParameterNames[strParameterName].ID, strIDParameterValue);
		}

		/// <summary>
		///		Busca el valor de un parámetro para un elemento de la biblioteca
		/// </summary>
		internal string SearchValue(LibraryItem objLibraryItem, string strParameterName)
		{ string strValue = "";
			ParameterName objParameterName = objLibrary.ParameterNames[strParameterName];

				// Obtiene el / los valores asociados con el parámetro		
					if (objParameterName != null)
						{ ParameterKeysCollection objColKeys = objLibraryItem.Keys.SearchByParameterNameID(objParameterName.ID);
						
								// Recorre la colección de claves añadiendo los valores
									foreach (ParameterKey objKey in objColKeys)
										{ ParameterValue objValue = objParameterName.Values[objKey.IDParameterValue];
										
												if (objValue != null && !string.IsNullOrEmpty(objValue.Value))
													{ // Añade un punto y coma si es necesario
															if (!string.IsNullOrEmpty(strValue))
																strValue += "; ";
														// Añade el valor encontrado en la colección
															strValue += objValue.Value;
													}
										}
						}
				// Devuelve el / los valores asociados
					return strValue;
		}

		/// <summary>
		///		Elimina un cómic de la colección
		/// </summary>
		internal void Remove(string strFileName)
		{ // Elimina el archivo de la librería
				for (int intIndex = objLibrary.LibraryItems.Count - 1; intIndex >= 0; intIndex--)
					if (objLibrary.LibraryItems[intIndex].FileName.Equals(strFileName, StringComparison.CurrentCultureIgnoreCase))
						objLibrary.LibraryItems.RemoveAt(intIndex);
			// Elimina los datos del disco
				Bau.Libraries.LibHelper.Files.HelperFiles.KillFile(System.IO.Path.Combine(GetBasePath(), 
																																									System.IO.Path.GetFileName(strFileName) + ".clml"));
		}

		/// <summary>
		///		Lanza el evento de modificación
		/// </summary>
		private void RaiseEventUpdated()
		{ if (Updated != null)
				Updated(this, EventArgs.Empty);
		}
		
		public LibraryItemsCollection Comics
		{ get { return objLibrary.LibraryItems; }
		}
	}
}
