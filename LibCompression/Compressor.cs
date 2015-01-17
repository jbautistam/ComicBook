using System;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibCompression
{
	/// <summary>
	///		Compresor de archivos
	/// </summary>
	public class Compressor
	{ 
		/// <summary>
		///		Tipo de compresión
		/// </summary>
		public enum CompressType
			{ Unknown,
				Zip,
				Rar,
				GZip,
				Tar
			}
		// Eventos públicos
			public event EventHandler<CompressionEventArgs.ProgressEventArgs> Progress;

		/// <summary>
		///		Comprime un directorio
		/// </summary>
		public void Compress(string strFileTarget, string strPath, CompressType intType)
		{ GetInstance(intType).Compress(strFileTarget, strPath);
		}

		/// <summary>
		///		Comprime un archivo
		/// </summary>
		public void Compress(string strFileTarget, System.Collections.Generic.List<string> objColFiles, CompressType intType)
		{ string [] arrStrFiles = new string [objColFiles.Count];
		
				// Asigna los archivos
					for (int intIndex = 0; intIndex < objColFiles.Count; intIndex++)
						arrStrFiles[intIndex] = objColFiles[intIndex];
				// Comprime los archivos
					Compress(strFileTarget, arrStrFiles, intType);
		}

		/// <summary>
		///		Comprime un archivo
		/// </summary>
		public void Compress(string strFileTarget, string [] arrStrFiles, CompressType intType)
		{ GetInstance(intType).Compress(strFileTarget, arrStrFiles);
		}

		/// <summary>
		///		Lista los archivos de un archivo comprimido
		/// </summary>
		public System.Collections.Generic.List<string> ListFiles(string strFileName, CompressType intType)
		{ Formats.ICompressor objCompressor = GetInstace(strFileName, intType);

				// Lista los archivos
					return objCompressor.ListFiles(strFileName);
		}

		/// <summary>
		///		Descomprime un archivo
		/// </summary>
		public void Uncompress(string strFileSource, string strPath, CompressType intType = CompressType.Unknown)
		{ Formats.ICompressor objCompressor = GetInstace(strFileSource, intType);

				// Crea el directorio de salida de los archivos
					Bau.Libraries.LibHelper.Files.HelperFiles.MakePath(strPath);
				// Decomprime los archivos
					objCompressor.Uncompress(strFileSource, strPath);
		}

		/// <summary>
		///		Obtiene una instancia del compresor
		/// </summary>
		private Formats.ICompressor GetInstace(string strFileSource, CompressType intType)
		{ Formats.ICompressor objCompressor;

				// Obtiene el compresor adecuado
					if (intType == CompressType.Unknown)
						objCompressor = GetInstance(GetTypeFromExtension(System.IO.Path.GetExtension(strFileSource)));
					else
						objCompressor = GetInstance(intType);
				// Asigna el manejador de eventos
					objCompressor.Progress += (objSender, objEventArgs) => RaiseEventProgess(objEventArgs);
				// Devuelve el compresor
					return objCompressor;
		}

		/// <summary>
		///		Obtiene un tipo a partir de una extensión
		/// </summary>
		private CompressType GetTypeFromExtension(string strExtension)
		{ if (strExtension.EqualsIgnoreCase(".ZIP"))
				return CompressType.Zip;
			else if (strExtension.EqualsIgnoreCase(".GZ"))
				return CompressType.GZip;
			else if (strExtension.EqualsIgnoreCase(".RAR"))
				return CompressType.Rar;
			else if (strExtension.EqualsIgnoreCase(".TAR"))
				return CompressType.Tar;
			else
				throw new NotImplementedException("No se reconoce el tipo de archivo");
		}

		/// <summary>
		///		Obtiene un compresor
		/// </summary>
		private Formats.ICompressor GetInstance(CompressType intType)
		{ switch (intType)
				{ case CompressType.Zip:
						return new Formats.Zip.ZipCompressor();
					case CompressType.Rar:
						return new Formats.Rar.RarCompressor();
					case CompressType.Tar:
						return new Formats.Tar.TarCompressor();
					default:
						throw new NotImplementedException();
				}
		}

		/// <summary>
		///		Lanza el evento de progreso
		/// </summary>
		private void RaiseEventProgess(CompressionEventArgs.ProgressEventArgs objEventArgs)
		{ if (Progress != null)
				Progress(this, objEventArgs);
		}
	}
}
