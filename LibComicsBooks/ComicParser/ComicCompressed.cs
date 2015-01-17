using System;

using Bau.Libraries.LibCompression;
using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibComicsBooks.ComicParser
{
	/// <summary>
	///		Lector de cómic a partir de un archivo CBZ, CBR, CBT...
	/// </summary>
	internal class ComicCompressed : ComicBase
	{ // Variables privadas
			private static string [] arrStrFilesTar = new string [] { ".cbt", ".tar"};
			private static string [] arrStrFilesRar = new string [] { ".cbr", ".rar"};
			private static string [] arrStrFilesZip = new string [] { ".cbz", ".zip" };

		/// <summary>
		///		Limpia las páginas
		/// </summary>
		public override void Clear()
		{ // Elimina los archivos de imagen
				Pages.Delete();
			// Limpia la colección de imágenes
				base.Pages.Clear();
		}

		/// <summary>
		///		Comrpueba si un archivo es de este tipo de cómic
		/// </summary>
		internal static bool CheckIsComic(string strFileName)
		{ return new ComicCompressed().GetComicType(strFileName) != ComicBook.ComicType.Unknown;
		}

		/// <summary>
		///		Carga el cómic
		/// </summary>
		internal override void Load(string strFileName)
		{	Compressor objCompressor = new Compressor();
			System.Collections.Generic.List<string> objColFiles = new System.Collections.Generic.List<string>();

				// Guarda el nombre de archivo
					FileName = strFileName;
				// Obtiene los nombres de archivos comprimidos
					objColFiles = objCompressor.ListFiles(FileName, GetCompressType());
				// Añade los archivos a la colección de páginas
					foreach (string strFile in objColFiles)
						if (IsImage(strFile))
							Pages.Add(strFile);
		}

		/// <summary>
		///		Obtiene el tipo de cómic
		/// </summary>
		private ComicBook.ComicType GetComicType(string strFileName)
		{ // Obtiene el tipo de cómic
				if (!strFileName.IsEmpty())
					{ if (ComicBase.IsFileType(strFileName, arrStrFilesTar))
							return ComicBook.ComicType.CBT;
						else if (ComicBase.IsFileType(strFileName, arrStrFilesRar))
							return ComicBook.ComicType.CBR;
						else if (ComicBase.IsFileType(strFileName, arrStrFilesZip))
							return ComicBook.ComicType.CBZ;
					}
			// Si ha llegado hasta aquí es porque no sabe el tipo de cómic
				return ComicBook.ComicType.Unknown;
		}

		/// <summary>
		///		Obtiene el tipo de compresión
		/// </summary>
		private Compressor.CompressType GetCompressType()
		{ if (GetComicType(FileName) == ComicBook.ComicType.CBT)
				return Compressor.CompressType.Tar;
			else if (GetComicType(FileName) == ComicBook.ComicType.CBR)
				return Compressor.CompressType.Rar;
			else if (GetComicType(FileName) == ComicBook.ComicType.CBZ)
				return Compressor.CompressType.Zip;
			else
				return Compressor.CompressType.Unknown;
		}

		/// <summary>
		///		Carga la información del cómic
		/// </summary>
		internal override void LoadInfo()
		{ 
		}
		
		/// <summary>
		///		Descomprime un archivo
		/// </summary>
		public override void Uncompress(string strPath)
		{	Compressor objCompressor = new Compressor();

				// Asigna el manejador de eventos
					objCompressor.Progress += (objSender, objEventProgress) =>
																				{ // Añade la imagen a la colección de páginas
																						if (IsImage(objEventProgress.FileName))
																							{ base.Pages.Add(objEventProgress.FileName);
																								base.Pages[base.Pages.Count - 1].Uncompressed  = true;
																							}
																					// Lanza el evento
																						base.RaiseEvent(EventComicArgs.ActionType.Uncompress, base.Pages.Count, 
																														objEventProgress.Actual + 2);
																				};
				// Descomprime el archivo
					objCompressor.Uncompress(FileName, strPath, GetCompressType());
				// Manda el mensaje de fin
					base.RaiseEvent(EventComicArgs.ActionType.End, base.Pages.Count, base.Pages.Count);
		}
		
		/// <summary>
		///		Guarda los archivos del cómic en un archivo comprimido
		/// </summary>
		internal override void Save(string strFileName, ComicPagesCollection objColPages, Definition.ComicInfo objComicInfo)
		{ Compressor.CompressType intType = GetCompressType();

				// Comprime el archivo
					if (intType == Compressor.CompressType.Zip)
						{ Compressor objCompressor = new Compressor();
				
								// Graba el archivo comprimido
									objCompressor.Compress(strFileName, objColPages.GetFiles(), intType);
						}
		}
				
		/// <summary>
		///		Tipo de cómic
		/// </summary>
		public override ComicBook.ComicType Type 
		{ get { return GetComicType(FileName); }
		}
	}
}
