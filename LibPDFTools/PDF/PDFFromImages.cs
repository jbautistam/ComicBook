using System;
using System.Collections.Generic;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Bau.Libraries.LibPDFTools.PDF 
{
	/// <summary>
	///		Crea PDFs a partir de imágenes
	/// </summary>
	public static class PDFFromImages 
	{
		/// <summary>
		///		Crea un PDF a partir de una colección de archivos de imagen
		/// </summary>
		public static void Create(string strFileTarget, List<string> objColFilesImage)
		{ Document objPDF = new Document(PageSize.A4, 0, 0, 0, 0);
			PdfWriter objPDFWriter = PdfWriter.GetInstance(objPDF, new FileStream(strFileTarget, FileMode.Create));

				// Abre el documento para escritura
					objPDF.Open();
				// Escribe una imagen en cada página
					foreach (string strFileName in objColFilesImage)
						AddImage(objPDF, objPDFWriter, LoadImage(strFileName));
				// Cierra el PDF (y el PdfWriter, si se ejecuta objPDFWriter.Close() da un error en el stream de escritura)
					objPDF.Close();
		}
		
		/// <summary>
		///		Crea un PDF a partir de los datos recibidos de un documento
		/// </summary>
		public static void Create(string strFileName, List<System.Drawing.Image> objColImages)
		{ Document objPDF = new Document(PageSize.A4, 0, 0, 0, 0);
			PdfWriter objPDFWriter = PdfWriter.GetInstance(objPDF, new FileStream(strFileName, FileMode.Create));

				// Abre el documento para escritura
					objPDF.Open();
				// Escribe una imagen en cada página
					foreach (System.Drawing.Image objImageSource in objColImages)
						AddImage(objPDF, objPDFWriter, objImageSource);
				// Cierra el PDF (y el PdfWriter, si se ejecuta objPDFWriter.Close() da un error en el stream de escritura)
					objPDF.Close();
		}

		/// <summary>
		///		Añade una imagen a un PDF
		/// </summary>
		private static void AddImage(Document objPDF, PdfWriter objPDFWriter, System.Drawing.Image objImageSource) 
		{	Image objImage = GetImage(objImageSource);
						
				// Escala la imagen para que ocupe toda la página
					objImage.ScaleToFit(objPDFWriter.PageSize.Width, objPDFWriter.PageSize.Height);
				// Alinea la imagen
					objImage.Alignment = Element.ALIGN_MIDDLE | Element.ALIGN_CENTER;
				// Añade la imagen al PDF
					objPDF.Add(objImage);
		}
		
		/// <summary>
		///		Carga una imagen de un archivo
		/// </summary>
		private static System.Drawing.Image LoadImage(string strFileName)
		{ return System.Drawing.Image.FromFile(strFileName);
		}
		
		/// <summary>
		///		Obtiene una imagen para el PDF a partir de los una imagen de System.Drawing
		/// </summary>
		private static Image GetImage(System.Drawing.Image objImage)
		{ return Image.GetInstance(objImage, System.Drawing.Imaging.ImageFormat.Jpeg);
		}
	}
}
