using System;
using System.IO;

using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Checksums;

namespace Bau.Libraries.LibCompression.Formats.Tar
{
	/// <summary>
	///		Compresor de archivos tar
	/// </summary>
	internal class TarCompressor : BaseCompressor
	{
		/// <summary>
		///		Comprime una serie de archivos
		/// </summary>
		public override void Compress(string strFileTarget, string[] arrStrFiles)
		{ throw new NotImplementedException();
		}

		/// <summary>
		///		Descomprime un archivo
		/// </summary>
		public override void Uncompress(string strFileSource, string strPathTarget)
		{ using (TarInputStream objTarStream = new TarInputStream(File.Open(strFileSource, FileMode.Open)))
				{	TarEntry objTarEntry;
					int intFile = 0;
					
						// Crea las páginas con los archivos descomprimidos
							while ((objTarEntry = objTarStream.GetNextEntry()) != null) 
								{ string strFileTarget;

										// Descomprime la página
											UncompressTarEntry(objTarStream, objTarEntry, strPathTarget, out strFileTarget);
										// Lanza el evento
											base.RaiseProgressEvent(++intFile, intFile + 2, strFileSource);
								}
						// Cierra el stream
							objTarStream.Close();	
				}
		}
		
		/// <summary>
		///		Descomprime una entrada de un archivo Tar
		/// </summary>
		private bool UncompressTarEntry(TarInputStream objTarStream, TarEntry objTarEntry, string strPath, out string strFileName)
		{ bool blnUncompress = false;
		
				// Inicializa los valores de salida
					strFileName = null;
				// Intenta descomprimir el archivo
					try
						{	// Obtiene el nombre del archivo de salida
								strFileName = Path.Combine(strPath, GetFileNameFromTarEntry(objTarEntry.Name));
							// Borra el archivo de salida (por si acaso)
								Bau.Libraries.LibHelper.Files.HelperFiles.KillFile(strFileName);
							// Graba el archivo a partir del stream
								using (FileStream stmOutput = File.Create(strFileName))
									{	int intSize = 2048;
										byte [] arrBytBuffer = new byte[intSize];
										
										// Escribe los datos
											while (intSize > 0) 
												{ // Lee del zip
														intSize = objTarStream.Read(arrBytBuffer, 0, arrBytBuffer.Length);
													// Escribe en el archivo de salida
														if (intSize > 0)
															stmOutput.Write(arrBytBuffer, 0, intSize);
												}
										// Cierra el stream de salida
											stmOutput.Close();
									}
							// Si ha llegado hasta aquí es porque se ha descomprimido correctamente
								blnUncompress = true;
						}
					catch {}
				// Devuelve el valor que indica si se ha descomprimido correctamente
					return blnUncompress;
		}
		
		/// <summary>
		///		Obtiene el nombre de archivo a partir de una entrada en el zip
		///		Los nombres que se almacenan en las entradas del zip almacenan también el directorio separado por /
		/// </summary>
		private string GetFileNameFromTarEntry(string strFileEntry)
		{	string strOutput = "";

				// Recorre el nombre desde el final buscando la primera vez que aparezca /		
					for (int intIndex = strFileEntry.Length - 1; intIndex >= 0; intIndex--)
						if (strFileEntry[intIndex] == '/')
							return strOutput;
						else
							strOutput = strFileEntry[intIndex] + strOutput;
				// Devuelve la cadena de salida
					return strOutput;
		}

		public override System.Collections.Generic.List<string> ListFiles(string strFileName)
		{
		throw new NotImplementedException();
		}
	}
}
