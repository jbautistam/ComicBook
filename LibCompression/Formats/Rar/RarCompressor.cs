using System;

using SharpCompress.Archive;
using SharpCompress.Archive.Rar;

namespace Bau.Libraries.LibCompression.Formats.Rar
{
	/// <summary>
	///		Compresor para archivos RAR
	/// </summary>
	internal class RarCompressor : BaseCompressor
	{
		public override void Compress(string strFileTarget, string[] arrStrFiles)
		{ throw new NotImplementedException("No se puede comprimir en formato rar");
		}

		/// <summary>
		///		Descomprime un archivo en un directorio
		/// </summary>
		public override void Uncompress(string strFileSource, string strPathTarget)
		{	IArchive objArchive = ArchiveFactory.Open(strFileSource);
			int intFile = 0;

				// Descomprime los archivos
					foreach (IArchiveEntry objEntry in objArchive.Entries)
						if (!objEntry.IsDirectory)
							{ string strFileTarget;

									// Descomprime un archivo
										UncompressFile(objEntry, strPathTarget, out strFileTarget);
									// Lanza el evento
										base.RaiseProgressEvent(++intFile, intFile, strFileTarget);
							}
		}
		
		/// <summary>
		///		Descomprime un archivo
		/// </summary>
		private void UncompressFile(IArchiveEntry objUnrar, string strPath, out string strFileTarget)
		{ // Obtiene el nombre del archivo de salida
				strFileTarget = System.IO.Path.Combine(strPath, base.NormalizeFileName(objUnrar.Key));
			// Crea el directorio
				Bau.Libraries.LibHelper.Files.HelperFiles.MakePath(System.IO.Path.GetDirectoryName(strFileTarget));
			// Borra el archivo de salida (por si acaso)
				Bau.Libraries.LibHelper.Files.HelperFiles.KillFile(strFileTarget);
			// Descomprime el archivo
				objUnrar.WriteToFile(strFileTarget);
		}

		/// <summary>
		///		Carga la lista de archivos
		/// </summary>
		public override System.Collections.Generic.List<string> ListFiles(string strFileName)
		{	IArchive objRarArchive = ArchiveFactory.Open(strFileName);
			System.Collections.Generic.List<string> objColFiles = new System.Collections.Generic.List<string>();
			int intFile = 0;

				// Lista los archivos
					foreach (IArchiveEntry objRarEntry in objRarArchive.Entries)
						if (!objRarEntry.IsDirectory)
							{ // Añade un archivo
									objColFiles.Add(base.NormalizeFileName(objRarEntry.Key));
								// Lanza el evento
									base.RaiseProgressEvent(intFile++, intFile + 2, objColFiles[objColFiles.Count - 1]);
							}
				// Devuelve la colección de archivos
					return objColFiles;
		}
	}
}
