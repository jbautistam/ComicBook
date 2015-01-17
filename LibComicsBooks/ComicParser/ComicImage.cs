using System;

namespace Bau.Libraries.LibComicsBooks.ComicParser
{
	/// <summary>
	///		Lector de cómic a partir de una imagen
	/// </summary>
	internal class ComicImage : ComicBase
	{
		/// <summary>
		///		Limpia las páginas
		/// </summary>
		public override void Clear()
		{
		}

		/// <summary>
		///		Comrpueba si un archivo es de este tipo de cómic
		/// </summary>
		internal static bool CheckIsComic(string strFileName)
		{ return ComicBase.IsFileType(strFileName, new string [] {".jpg", ".png", ".gif", ".bmp", ".tiff", ".tif" });
		}
		
		/// <summary>
		///		Carga el cómic
		/// </summary>
		internal override void Load(string strFileName)
		{ // Limpia la colección de páginas
				Clear();
			// Cambia el nombre de archivo
				base.FileName = strFileName;
			// Carga las páginas
				if (base.IsImage(strFileName))
					Pages.Add(strFileName);
		}

		/// <summary>
		///		Carga la información del cómic
		/// </summary>
		internal override void LoadInfo()
		{	base.Info.Title = System.IO.Path.GetFileName(base.FileName);
			base.Info.ComicFileName = base.FileName;
		}

		/// <summary>
		///		Descomprime un archivo (no hace nada, simplemente implementa el interface)
		/// </summary>
		public override void Uncompress(string strPath)
		{ 
		}
		
		public override ComicBook.ComicType Type 
		{ get { return ComicBook.ComicType.Path; }
		}
	}
}
