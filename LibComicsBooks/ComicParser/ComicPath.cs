using System;

namespace Bau.Libraries.LibComicsBooks.ComicParser
{
	/// <summary>
	///		Lector de c�mic a partir de un directorio
	/// </summary>
	internal class ComicPath : ComicBase
	{
		/// <summary>
		///		Limpia las p�ginas
		/// </summary>
		public override void Clear()
		{ Pages.Clear();
		}

		/// <summary>
		///		Comprueba si un archivo es de este tipo de c�mic
		/// </summary>
		internal static bool CheckIsComic(string strFileName)
		{ return System.IO.Directory.Exists(strFileName); 
		}
		
		/// <summary>
		///		Carga el c�mic
		/// </summary>
		internal override void Load(string strFileName)
		{ // Limpia la colecci�n de p�ginas
				Clear();
			// Cambia el nombre de archivo
				base.FileName = strFileName;
			// Carga las p�ginas
				LoadFiles(strFileName, false);
		}

		/// <summary>
		///		Carga la informaci�n del c�mic
		/// </summary>
		internal override void LoadInfo()
		{	base.Info.Title = base.FileName;
			base.Info.ComicFileName = base.FileName;
		}
		
		/// <summary>
		///		Carga los archivos de un directorio
		/// </summary>
		private void LoadFiles(string strPath, bool blnRecursive)
		{ string [] arrStrMask = new string [] {".jpg", ".gif", ".bmp", ".tif", ".png"};
		
				// Carga los archivos a partir de la m�scara
					foreach (string strMaskFile in arrStrMask)
						{ string [] arrStrFiles = System.IO.Directory.GetFiles(strPath, "*" + strMaskFile);
						
								foreach (string strFile in arrStrFiles)
									{ Pages.Add(strFile);
										Pages[Pages.Count - 1].Uncompressed = true;
									}
						}
		}

		/// <summary>
		///		Descomprime un archivo (no hace nada, simplemente implementa el interface)
		/// </summary>
		public override void Uncompress(string strPath)
		{
		}
		
		/// <summary>
		///		Tipo de c�mic
		/// </summary>
		public override ComicBook.ComicType Type 
		{ get { return ComicBook.ComicType.Path; }
		}
	}
}
