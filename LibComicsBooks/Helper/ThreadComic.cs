using System;

namespace Bau.Libraries.LibComicsBooks.Helper
{
	/// <summary>
	///		Clase para descompresión 
	/// </summary>
	internal class ThreadComic
	{
		internal ThreadComic(ComicParser.ComicBase objComic, string strPath)
		{ Comic = objComic;
			Path = strPath;
		}
		
		/// <summary>
		///		Ejecuta el hilo de descompresión del archivo
		/// </summary>
		internal static void Execute(object objInfo)
		{ if (objInfo is ThreadComic)
				{ ThreadComic objComic = objInfo as ThreadComic;
				
						if (objComic != null)
							objComic.Comic.Uncompress(objComic.Path);
				}
		}
		
		/// <summary>
		///		Cómic
		/// </summary>
		internal ComicParser.ComicBase Comic { get; private set; }
		
		/// <summary>
		///		Directorio
		/// </summary>
		internal string Path { get; private set; }
	}
}
