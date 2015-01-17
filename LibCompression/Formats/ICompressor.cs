using System;

namespace Bau.Libraries.LibCompression.Formats
{
	/// <summary>
	///		Interface para las librerías de compresión
	/// </summary>
	internal interface ICompressor 
	{
		/// <summary>
		///		Evento de progreso
		/// </summary>
		event EventHandler<CompressionEventArgs.ProgressEventArgs> Progress;

		/// <summary>
		///		Comprime una serie de archivos de un directorio
		/// </summary>
		void Compress(string strFileTarget, string strPath);

		/// <summary>
		///		Comprime una serie de archivos
		/// </summary>
		void Compress(string strFileTarget, string [] arrStrFiles);

		/// <summary>
		///		Descomprime un archivo
		/// </summary>
		void Uncompress(string strFileSource, string strPathTarget);

		/// <summary>
		///		Lista los archivos contenidos en un archivo comprimido
		/// </summary>
		System.Collections.Generic.List<string> ListFiles(string strFileName);
	}
}
