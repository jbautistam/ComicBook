using System;

namespace Bau.Libraries.LibCompression.Formats
{
	/// <summary>
	///		Clase base para las clases de compresión / decompresión de archivos
	/// </summary>
	internal abstract class BaseCompressor : ICompressor
	{
		/// <summary>Evento de progreso</summary>
		public event EventHandler<CompressionEventArgs.ProgressEventArgs> Progress;

		/// <summary>
		///		Normaliza un nombre de archivo
		/// </summary>
		protected string NormalizeFileName(string strFileName)
		{ // Reemplaza los caracteres extraños
				strFileName = strFileName.Replace('/', '\\');
			// Devuelve el nombre de archivo
				return strFileName;
		}

		/// <summary>
		///		Lanza el evento de progreso
		/// </summary>
		protected void RaiseProgressEvent(int intActual, int intTotal, string strFileName)
		{ if (Progress != null)
				Progress(this, new CompressionEventArgs.ProgressEventArgs(intActual, intTotal, strFileName));
		}

		/// <summary>
		///		Compresión de archivos de un directorio
		/// </summary>
		public virtual void Compress(string strFileTarget, string strPath)
		{ Compress(strFileTarget, new string[] { strPath });
		}

		/// <summary>
		///		Método abstracto para compresión de archivos
		/// </summary>
		public abstract void Compress(string strFileTarget, string[] arrStrFiles);

		/// <summary>
		///		Método abstracto para decompresión de archivos
		/// </summary>
		public abstract void Uncompress(string strFileSource, string strPathTarget);

		/// <summary>
		///		Lista los archivos de un archivo comprimido
		/// </summary>
		public abstract System.Collections.Generic.List<string> ListFiles(string strFileName);
	}
}
