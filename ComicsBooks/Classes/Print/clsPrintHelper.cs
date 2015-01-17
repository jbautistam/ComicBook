using System;
using System.Windows.Forms;

using Bau.Libraries.LibComicsBooks;

namespace Bau.Applications.ComicsBooks.Classes.Print
{
	/// <summary>
	///		Clase de ayuda para la impresi�n de c�mics
	/// </summary>
	public class clsPrintHelper
	{ 
		/// <summary>
		///		Imprime un c�mic
		/// </summary>
		internal static void Print(clsEnums.TypeAction intAction, string strFileName, ComicPagesCollection objColPages)
		{ Bau.Controls.ImageControls.Print.ImagePrinter objImagePrinter = new Bau.Controls.ImageControls.Print.ImagePrinter();
		
				// Asigna las im�genes
					foreach (ComicPage objPage in objColPages)
						if (System.IO.File.Exists(objPage.FileName))
							try
								{ objImagePrinter.Images.Add(System.Drawing.Image.FromFile(objPage.FileName));
								}
							catch {}
				// Imprime
					switch (intAction)
						{ case clsEnums.TypeAction.PrintPreview:
									PrintPreview(strFileName, objImagePrinter);
								break;
							case clsEnums.TypeAction.Print:
							    objImagePrinter.Print();
							  break;
							case clsEnums.TypeAction.PrintWithDialog:
							    objImagePrinter.PrintWithDialog();
							  break;
						}
		}
		
		/// <summary>
		///		Previsualiza
		/// </summary>
		private static void PrintPreview(string strFileName, Bau.Controls.ImageControls.Print.ImagePrinter objImagePrinter)
		{ Forms.Comic.frmComicPreview frmNewReport = new Forms.Comic.frmComicPreview();
		
				// Asigna los par�metros
					frmNewReport.IDData = strFileName;
					frmNewReport.Document = objImagePrinter;
				// Muestra el formulario
					Program.MainWindow.OpenWindowDocument(frmNewReport);
		}
	}
}
