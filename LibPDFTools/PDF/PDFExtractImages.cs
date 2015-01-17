using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using Dotnet = System.Drawing.Image;
using System.Drawing;
using System.IO;

using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;

namespace Bau.Libraries.LibPDFTools.PDF
{
	/// <summary>
	///		Extrae imágenes de un PDF
	/// </summary>
	public class PDFExtractImages
	{ // Eventos
			public event EventHandler<EventArguments.PDFExtractProgressEventArgs> Progress;
			public event EventHandler<EventArguments.PDFExtractErrorEventArgs> ProcessError;

		/// <summary>
		///		Extrae las imágenes de un archivo
		/// </summary>
    public List<string> Extract(string strFileName, string strTargetPath)
    { List<string> objColFileNames = new List<string>();
			PdfReader objPdfReader = new PdfReader(strFileName);

				// Crea el directorio de salida
					Bau.Libraries.LibHelper.Files.HelperFiles.MakePath(strTargetPath);
				// Recorre las páginas
					for (int intPage = 1; intPage <= objPdfReader.NumberOfPages; intPage++)
						try
							{ string strFileTarget = GetFileName(strTargetPath, intPage);

									// Graba la página
										if (SaveImageFromPDF(strFileName, strFileTarget, intPage))
											objColFileNames.Add(strFileTarget);
									// Lanza el evento de progreso
										OnProgress(intPage, objPdfReader.NumberOfPages, strFileTarget);
							}
						catch (Exception objException)
							{ OnError(objException);
							}
				// Devuelve la lista de archivos creados
					return objColFileNames;
		}

		/// <summary>
		///		Graba la imagen de una página de un PDF
		/// </summary>
		private bool SaveImageFromPDF(string strFileName, string strFileTarget, int intPage)
		{	bool blnSaved = false;

				// Graba la imagen
					try
						{	PdfReader objPdfReader = new PdfReader(strFileName);
							PdfDictionary objPdfPage = objPdfReader.GetPageN(intPage);
							PdfDictionary res = (PdfDictionary) PdfReader.GetPdfObject(objPdfPage.Get(PdfName.RESOURCES));
							PdfDictionary xobj = (PdfDictionary) PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));

								// Recorre los objetos de la página
									foreach (PdfName strKey in xobj.Keys)
										{ PdfObject obj = xobj.Get(strKey);

												if (obj.IsIndirect())
													{	PdfDictionary tg = (PdfDictionary) PdfReader.GetPdfObject(obj);
														string strWidth = tg.Get(PdfName.WIDTH).ToString();
														string strHeight = tg.Get(PdfName.HEIGHT).ToString();
														ImageRenderInfo imgRI = ImageRenderInfo.CreateForXObject(new Matrix(float.Parse(strWidth), float.Parse(strHeight)), (PRIndirectReference) obj, tg);

															// Render de la imagen
																if (RenderImage(imgRI, strFileTarget))
																	blnSaved = true;
													}
										}
						}
					catch {}
				// Devuelve el valor que indica si se ha grabado correctamente
					return blnSaved;
		}

		/// <summary>
		///		Graba la imagen
		/// </summary>
    private bool RenderImage(ImageRenderInfo objImgRenderInfo, string strFileName)
    { bool blnRender = false;
			PdfImageObject objPdfImage = objImgRenderInfo.GetImage();

				// Obtiene la imagen
					using (Dotnet objDotnetImage = objPdfImage.GetDrawingImage())
						{	// Si realmente existía una imagen
								if (objDotnetImage != null)
									using (MemoryStream stmMemory = new MemoryStream())
										{ Bitmap bmpTarget;

												// Vuelca la imagen en el stream en memoria
													objDotnetImage.Save(stmMemory, ImageFormat.Jpeg);
												// Copia la imagen
													bmpTarget = new Bitmap(objDotnetImage);
												// Graba la imagen
													bmpTarget.Save(strFileName);
												// Indica que se ha grabado
													blnRender = true;
										}
						}
				// Devuelve el valor que indica si se ha grabado
					return blnRender;
    }
		
		/// <summary>
		///		Lanza el evento <see cref="Progress"/>
		/// </summary>
		private void OnProgress(int intActual, int intTotal, string strFileName)
		{ if (Progress != null)
				Progress(this, new EventArguments.PDFExtractProgressEventArgs(intActual, intTotal, strFileName));
		}
		
		/// <summary>
		///		Lanza el evento <see cref="ProcessError"/>
		/// </summary>
		private void OnError(Exception objException)
		{ OnError(objException.Message);
		}
		
		/// <summary>
		///		Lanza el evento <see cref="ProcessError"/>
		/// </summary>
		private void OnError(string strMessage)
		{ if (ProcessError != null)
				ProcessError(this, new EventArguments.PDFExtractErrorEventArgs(strMessage));
		}

		///// <summary>
		/////		Extrae las imágenes de un PDF
		///// </summary>
		//public List<string> Extract(string strFileName, string strTargetPath)
		//{ List<string> objColFileNames = new List<string>();
		//	PdfReader objPDF = new PdfReader(strFileName);

		//		// Extrae las imágenes
		//			for (int intPage = 1; intPage <= objPDF.NumberOfPages; intPage++)
		//				try
		//					{ string strFileTarget = GetFileName(strTargetPath, intPage);
		//						string strProcessOutput;
							
		//							// Graba la página
		//								if (SaveImageFromPDF(strFileName, strFileTarget, intPage, "", out strProcessOutput))
		//									objColFileNames.Add(strFileTarget);
		//							// Lanza el evento
		//								base.OnProgress(intPage, objPDF.NumberOfPages);
		//					}
		//				catch (Exception objException)
		//					{	base.OnError(objException);
		//					}
		//		// Devuelve la lista de archivos creador
		//			return objColFileNames;
		//}
		
		///// <summary>
		/////		Obtiene una página de un PDF
		///// </summary>
		//private bool SaveImageFromPDF(string strFileSource, string strFileImage, int intPageNumber, string strPassword,
		//															out string strProcessOutput)
		//{ GhostScript.GhostScriptProcess objProcessor = new GhostScriptProcess();
		//	ParametersConversion objParameters = new ParametersConversion();

		//		// Inicializa las propiedades del conversor		
		//			objParameters.OutputToMultipleFile = false;
		//			objParameters.MaxBitmap = 100000000;
		//			objParameters.MaxBuffer = 200000000;
		//			objParameters.JPEGQuality = 70;
		//		// Formato de salida
		//			objParameters.OutputFormat = GhostScriptApi.COLOR_JPEG;
		//		// Convierte la imagen
		//			return objProcessor.ProcessData(GetGeneratedArgs(strFileSource, strFileImage, 
		//																											 intPageNumber, base.Process, base.Page, objParameters),	
		//																			base.Process.RedirectIO, out strProcessOutput);
		//}

		///// <summary>
		/////		Crea la lista de parámetros para enviárselo a la DLL
		///// </summary>
		//private List<string> GetGeneratedArgs(string strSourceFile, string strTargetFile, int intPage,
		//																			ParametersProcess objProcess,
		//																			ParametersPage objPage,
		//																			ParametersConversion objParameters)
		//{	List<string> objColArguments = base.GetArguments(objParameters.OutputFormat, true);
			
		//		// Asigna la calidad
		//			if (objParameters.OutputFormat.Equals("jpeg", StringComparison.CurrentCultureIgnoreCase) && 
		//					objParameters.JPEGQuality > 0 && objParameters.JPEGQuality < 101)
		//				objColArguments.Add(string.Format(GhostScriptApi.GS_JpegQualityFormat, objParameters.JPEGQuality));
		//		// Buffers máximos
		//			if (objParameters.MaxBitmap > 0)
		//				objColArguments.Add(string.Format(GhostScriptApi.GS_MaxBitmap, objParameters.MaxBitmap));
		//			if (objParameters.MaxBuffer > 0)
		//				objColArguments.Add(string.Format(GhostScriptApi.GS_BufferSpace, objParameters.MaxBuffer));
		//		// Número de página a extraer
		//			objColArguments.Add(string.Format(GhostScriptApi.GS_FirstPageFormat, intPage));
		//			objColArguments.Add(string.Format(GhostScriptApi.GS_LastPageFormat, intPage));
		//		// Si se desea crear un archivo por página se debe añadir el carácter % al nombre de archivo de salida
		//			if (objParameters.OutputToMultipleFile && !strTargetFile.Contains(GhostScriptApi.GS_MultiplePageCharacter)) 
		//				{	int intLastDotIndex = strTargetFile.LastIndexOf('.');
						
		//						if (intLastDotIndex > 0)
		//							strTargetFile = strTargetFile.Insert(intLastDotIndex, "%d");
		//				}
		//		// Los dos últimos argumentos son los nombres de archivo de salida y origen
		//			objColArguments.Add(string.Format(GhostScriptApi.GS_OutputFileFormat, strTargetFile));
		//			objColArguments.Add(strSourceFile);
		//		// Devuelve los argumentos
		//			return objColArguments;
		//}

		/// <summary>
		///		Obtiene el nombre de archivo
		/// </summary>
		private string GetFileName(string strPath, int intPage)
		{ return System.IO.Path.Combine(strPath, string.Format("{0:00000000}.jpg", intPage));
		}
	}
}