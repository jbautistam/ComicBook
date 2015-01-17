using System;

namespace Bau.Libraries.LibPDFTools.EventArguments
{
	/// <summary>
	///		Argumentos del evento de errores
	/// </summary>
	public class PDFExtractErrorEventArgs : EventArgs
	{
		public PDFExtractErrorEventArgs(string strMessage)
		{ ErrorMessage = strMessage;
		}
		
		/// <summary>
		///		Mensaje de error
		/// </summary>
		public string ErrorMessage { get; set; }
	}
}
