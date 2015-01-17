using System;
using System.IO;

using Bau.Libraries.LibPDFTools.EventArguments;
using Bau.Libraries.LibPDFTools.PDF;

namespace Bau.Libraries.LibComicsBooks.ComicParser
{
	/// <summary>
	///		Lector de cómic a partir de un archivo PDF
	/// </summary>
	internal class ComicPDF : ComicBase
	{ 
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
		{ return ComicBase.IsFileType(strFileName, new string [] {".pdf" });
		}

		/// <summary>
		///		Carga el cómic
		/// </summary>
		internal override void Load(string strFileName)
		{	int intPages;

				// Limpia las páginas
					Clear();
				// Asigna el nombre de archivo
					base.FileName = strFileName;
				// Obtiene el número de páginas
					intPages = CountPages(strFileName);
				// Crea la colección
					for (int intIndex = 0; intIndex < intPages; intIndex++)
						Pages.Add("Página " + (intIndex + 1).ToString());
		}

		/// <summary>
		///		Cuenta las páginas de un PDF
		/// </summary>
		private int CountPages(string strFileName)
		{ return new PdfHelper().CountPages(strFileName);
		}

		/// <summary>
		///		Carga la información del cómic
		/// </summary>
		internal override void LoadInfo()
		{ // Inicializa el nombre de archivo
				base.Info.ComicFileName = base.FileName;
				base.Info.Title = Path.GetFileName(base.FileName);					
		}
		
		/// <summary>
		///		Descomprime un archivo
		/// </summary>
		public override void Uncompress(string strPath)
		{ PDFExtractImages objPDFExtract = new PDFExtractImages();

				// Limpia las páginas
					Clear();
				// Asigna el evento de tratamiento de proceso
					objPDFExtract.Progress += (objSender, objExtractArgs) =>
																					{ // Carga las páginas
																							Pages.Add(objExtractArgs.FileName);
																							Pages[Pages.Count - 1].Uncompressed = true;
																						// Lanza el evento de progreso
																							base.RaiseEvent(EventComicArgs.ActionType.Uncompress, objExtractArgs.ActualPage, objExtractArgs.PagesTotal);
																					};
					objPDFExtract.ProcessError += (objSender, objExtractArgs) =>
																					{ base.RaiseEventError(objExtractArgs.ErrorMessage);
																					};
				// Extrae las imágenes
					try
						{ objPDFExtract.Extract(FileName, strPath);
						}
					catch (Exception objException)
						{ base.RaiseEventError("Error al descomprimir el archivo " + FileName + Environment.NewLine + objException.Message);
						}
		}
		
		/// <summary>
		///		Guarda los archivos del cómic en un archivo comprimido
		/// </summary>
		internal override void Save(string strFileName, ComicPagesCollection objColPages, Definition.ComicInfo objComicInfo)
		{ System.Collections.Generic.List<string> objColFiles = new System.Collections.Generic.List<string>();
		
				// Pasa las páginas a la colección de archivos
					foreach (ComicPage objPage in objColPages)
						objColFiles.Add(objPage.FileName);
				// Crea el PDF
					PDFFromImages.Create(strFileName, objColFiles);
		}

		/// <summary>
		///		Tipo de archivo de cómic
		/// </summary>
		public override ComicBook.ComicType Type 
		{ get { return ComicBook.ComicType.PDF; }
		}
	}
}
