using System;
using System.IO;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;

namespace Bau.Libraries.LibCompression.Formats.Zip
{
	/// <summary>
	///		Librerías de compresión y decompresión sobre archivos ZIP
	/// </summary>
	internal class ZipCompressor : BaseCompressor
	{
		/// <summary>
		///		Comprime una serie de archivos
		/// </summary>
		public override void Compress(string strFileTarget, string[] arrStrFiles)
		{ using (ZipOutputStream stmZip = new ZipOutputStream(File.Create(strFileTarget)))
				{ // Indica el nivel de compresión (0 a 9)
						stmZip.SetLevel(5);
					// Añade los archivos
						foreach (string strFile in arrStrFiles)
							if (Directory.Exists(strFile))
								AddPathToZip(stmZip, strFile, "");
							else if (File.Exists(strFile))
								AddFileToZip(stmZip, Path.GetDirectoryName(strFile), strFile);
					// Cierra el stream
						stmZip.Finish();
						stmZip.Close();
				}
		}

		/// <summary>
		///		Añade un directorio al Zip
		/// </summary>
		private void AddPathToZip(ZipOutputStream stmZip, string strPath, string strPathBase)
		{ // Añade los archivos
				foreach (string strFile in Directory.GetFiles(strPath))
					AddFileToZip(stmZip, strFile, strPathBase);
			// Añade los directorios
				foreach (string strFile in Directory.GetDirectories(strPath))
					AddPathToZip(stmZip, strFile, GetPathToBase(strPathBase, strFile));
		}

		/// <summary>
		///		Añade un archivo al Zip
		/// </summary>
		private void AddFileToZip(ZipOutputStream stmZip, string strFileName, string strPath)
		{ using (FileStream stmFile = File.OpenRead(strFileName))
				{ ZipEntry objEntry = new ZipEntry(GetPathToBase(strPath,	Path.GetFileName(strFileName)));
					byte [] arrBytBuffer = new byte[stmFile.Length];
				
						// Lee el archivo sobre el buffer
							stmFile.Read(arrBytBuffer, 0, arrBytBuffer.Length);
						// Añade el archivo al zip
							stmZip.PutNextEntry(objEntry);
						// Escribe el archivo en el zip
							stmZip.Write(arrBytBuffer, 0, arrBytBuffer.Length);
				}
		}
		
		/// <summary>
		///		Añade un directorio al base
		/// </summary>
		private string GetPathToBase(string strPath, string strFileName)
		{ if (string.IsNullOrEmpty(strPath))	
				return Path.GetFileName(strFileName);
			else
				return strPath + "/" + strFileName;
		}
		
		/// <summary>
		///		Descomprime un archivo
		/// </summary>
		public override void Uncompress(string strFileSource, string strPathTarget)
		{ int intFilesNumber = CountFilesNumber(strFileSource);

				// Descomprime el archivo
					using (ZipInputStream objZipStream = new ZipInputStream(File.Open(strFileSource, FileMode.Open)))
						{	ZipEntry objZipEntry;
							int intFile = 0;
					
								// Crea las páginas con los archivos descomprimidos
									while ((objZipEntry = objZipStream.GetNextEntry()) != null) 
										if (objZipEntry.IsFile)
											{ string strFileTarget;

													// Descomprime el archivo
														UncompressZipEntry(objZipStream, objZipEntry, strPathTarget, out strFileTarget);
													// Lanza el evento
														base.RaiseProgressEvent(++intFile, intFilesNumber, strFileTarget);
											}
								// Cierra el stream
									objZipStream.Close();	
						}
		}

		/// <summary>
		///		Cuenta el número de archivos de un ZIP
		/// </summary>
		private int CountFilesNumber(string strFileSource)
		{ int intNumber = 0;

				// Cuenta el número de archivos
					using (ZipInputStream objZipStream = new ZipInputStream(File.Open(strFileSource, FileMode.Open)))
						{ ZipEntry objZipEntry;

								// Recorre los archivos contando las entradas
									while ((objZipEntry = objZipStream.GetNextEntry()) != null)
										if (objZipEntry.IsFile)
											intNumber++;
						}
				// Devuelve el número de archivos
					return intNumber;
		}
		
		/// <summary>
		///		Descomprime una entrada de un archivo ZIP
		/// </summary>
		private void UncompressZipEntry(ZipInputStream objZipStream, ZipEntry objZipEntry, string strPath, out string strFileName)
		{ // Obtiene el nombre del archivo de salida
				strFileName = Path.Combine(strPath, base.NormalizeFileName(objZipEntry.Name));
			// Crea el directorio
				Bau.Libraries.LibHelper.Files.HelperFiles.MakePath(System.IO.Path.GetDirectoryName(strFileName));
			// Borra el archivo de salida (por si acaso)
				Bau.Libraries.LibHelper.Files.HelperFiles.KillFile(strFileName);
			// Graba el archivo a partir del stream
				using (FileStream stmOutput = File.Create(strFileName))
					{	int intSize = 2048;
						byte [] arrBytBuffer = new byte[intSize];
										
						// Escribe los datos
							while (intSize > 0) 
								{ // Lee del zip
										intSize = objZipStream.Read(arrBytBuffer, 0, arrBytBuffer.Length);
									// Escribe en el archivo de salida
										if (intSize > 0)
											stmOutput.Write(arrBytBuffer, 0, intSize);
								}
						// Cierra el stream de salida
							stmOutput.Close();
					}
		}

		public override System.Collections.Generic.List<string> ListFiles(string strFileName)
		{
		throw new NotImplementedException();
		}
	}
}