using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibComicsBooks
{
	/// <summary>
	///		Colección de <see cref="ComicPage"/>
	/// </summary>
	public class ComicPagesCollection : List<ComicPage>
	{
		/// <summary>
		///		Añade un elemento a la colección
		/// </summary>
		public void Add(string strFileName)
		{ Add(new ComicPage(strFileName));
		}
		
		/// <summary>
		///		Borra los archivos de las páginas
		/// </summary>
		internal void Delete()
		{	foreach (ComicPage objPage in this)
				Bau.Libraries.LibHelper.Files.HelperFiles.KillFile(objPage.FileName);
		}

		/// <summary>
		///		Obtiene el índice de una página
		/// </summary>
		internal int GetPageIndex(string strFileName)
		{ for (int intIndex = 0; intIndex < Count; intIndex++)
				if (this[intIndex].FileName.Equals(strFileName))
					return intIndex;
			return -1;
		}

		/// <summary>
		///		Obtiene los archivos
		/// </summary>
		internal List<string> GetFiles()
		{ List<string> objColFiles = new List<string>();

				// Añade los archivos
					foreach (ComicPage objPage in this)
						if (!objPage.MarkAsDeleted)
							objColFiles.Add(objPage.FileName);
				// Devuelve la colección de archivos
					return objColFiles;
		}
	}
}
