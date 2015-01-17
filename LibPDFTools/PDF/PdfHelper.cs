using System;

using iTextSharp.text.pdf;

namespace Bau.Libraries.LibPDFTools.PDF
{
	/// <summary>
	///		Clase de ayuda para manejo de arcivos PDF
	/// </summary>
	public class PdfHelper
	{
		/// <summary>
		///		Cuenta el número de páginas
		/// </summary>
		public int CountPages(string strFileName)
		{ int intPages = 0;

				// Cuenta el número de páginas
					try
						{ PdfReader objPDF = new PdfReader(strFileName);

								// Obtiene el número de páginas
									intPages = objPDF.NumberOfPages;
								// Cierra el PDf
									objPDF.Close();
						}
					catch {}
				// Devuelve el número de páginas
					return intPages;
		}
	}
}
