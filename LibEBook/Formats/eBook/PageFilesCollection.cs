using System;

namespace Bau.Libraries.LibEBook.Formats.eBook
{
	/// <summary>
	///		Colección de <see cref="PageFile"/>
	/// </summary>
	public class PageFilesCollection : Base.eBookBaseCollection<PageFile>
	{
		/// <summary>
		///		Añade un archivo
		/// </summary>
		public void Add(string strID, string strName, string strFileName, string strMediaType)
		{ Add(new PageFile(strID, strName, strFileName, strMediaType));
		}

		/// <summary>
		///		Busca una página a partir de la URL
		/// </summary>
		internal PageFile SearchByURL(string strURL)
		{ // Busca la página a partir de la URL
				foreach (PageFile objPage in this)
					if (!string.IsNullOrEmpty(objPage.FileName))
						{ string [] arrStrURL = objPage.FileName.Split('#');
						
								if (arrStrURL[0].Equals(strURL) || objPage.FileName.Equals(strURL))
									return objPage;
						}
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}

		/// <summary>
		///		Busca una página a partir de un nombre de archivo
		/// </summary>
		internal PageFile SearchByFileName(string strFileName)
		{ // Busca la página a partir de la URL
				foreach (PageFile objPage in this)
					if (!string.IsNullOrEmpty(objPage.FileName) && (objPage.FileName.Equals(strFileName) ||
																													System.IO.Path.GetFileName(objPage.FileName).Equals(strFileName)))
						return objPage;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}

		/// <summary>
		///		Normaliza los IDs de las páginas
		/// </summary>
		internal void NormalizeID()
		{ int intIndex = 1;

				foreach (PageFile objFile in this)
					objFile.ID = "Page" + (intIndex++).ToString();
		}
	}
}
