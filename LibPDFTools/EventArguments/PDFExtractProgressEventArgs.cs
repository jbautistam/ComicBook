using System;

namespace Bau.Libraries.LibPDFTools.EventArguments
{
	/// <summary>
	///		Argumentos del evento de progreso
	/// </summary>
	public class PDFExtractProgressEventArgs : EventArgs
	{
		public PDFExtractProgressEventArgs(int intActualPage, int intPagesTotal, string strFileName)
		{ ActualPage = intActualPage;
			PagesTotal = intPagesTotal;
			FileName = strFileName;
		}
		
		/// <summary>
		///		Página actual
		/// </summary>
		public int ActualPage { get; set; }
		
		/// <summary>
		///		Total de páginas
		/// </summary>
		public int PagesTotal { get; set; }

		/// <summary>
		///		Nombre de archivo
		/// </summary>
		public string FileName { get; private set; }
	}
}
