using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Bau.Controls.Forms;
using Bau.Libraries.LibComicsBooks;

namespace Bau.Applications.ComicsBooks.Forms.Comic
{
	public partial class frmComicGalleryHTML : Form
	{ // Variables privadas
			private ComicPagesCollection objColPages;
			
		public frmComicGalleryHTML()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{
		}		
		
		/// <summary>
		///		Graba las páginas como HTML
		/// </summary>
		private void Save()
		{ if (!System.IO.Directory.Exists(udtPath.PathName))
				Helper.ShowMessage(this, "Introduzca el nombre de archivo");
			else if (string.IsNullOrEmpty(txtTitle.Text))
				Helper.ShowMessage(this, "Introduzca el título de la galería");
			else
				{ // Graba el HTML
						SaveHTML();
					// Graba las imágenes
						SaveImages();
					// Mensaje al usuario
						Helper.ShowMessage(this, "Finalizada la generación de archivo");
					// Muestra la galería en el explorador
						if (chkSeeResult.Checked)
							Bau.Libraries.LibHelper.Files.HelperFiles.OpenDocumentShell(System.IO.Path.Combine(udtPath.PathName, 
																																																 "Gallery.htm"));
					// Cierra el formulario
						DialogResult = DialogResult.OK;
						Close();
				}
		}
		
		/// <summary>
		///		Graba el archivo HTML
		/// </summary>
		private void SaveHTML()
		{ string strHTML;
			int intPhoto = 0, intColumn = 0;
			bool blnClosed = true;
		
				// Crea la cabecera HTML
					strHTML = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN'" +
											" 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>\n";
					strHTML += "<html xmlns='http://www.w3.org/1999/xhtml' dir='ltr'>\n";
					strHTML = "<html>\n";
					strHTML += "<head>\n";
					strHTML += "<title>" + txtTitle.Text + "</title>\n";
					strHTML += "</head>\n";
					strHTML += "<body>\n";
					strHTML += "<table width='100%' border='0'>\n";
				// Recorre la lista de imágenes
					foreach (ComicPage objPage in Pages)
						{ // Crea la cabecera de fila
								if (intPhoto == 0 || intColumn >= nudColumns.Value)
									{	if (!blnClosed)
											{ strHTML += "</tr>\n";
												blnClosed = true;
											}
										strHTML += "<tr>\n";
										intColumn = 0;
									}
							// Crea la celda
								strHTML += "<td style='width:" + ((int) (100 / nudColumns.Value)).ToString() + "%'>\n";
								strHTML += "<h2>Página " + (intPhoto + 1).ToString() + "</h2>\n";
								strHTML += "<p>\n";
								strHTML += "<a href='" + GetImageName(intPhoto, false) + 
															"' target='_blank'>\n";
								strHTML += "<img src='" + GetImageName(intPhoto, true) + 
															"' alt = 'Página " + (intPhoto + 1).ToString() + "' /></a>\n";
								strHTML += "</p>\n";
								strHTML += "</td>\n";
							// Indica que no se ha cerrado la fila
								blnClosed = false;
							// Incrementa el número de foto y columna
								intPhoto++;
								intColumn++;
						}
				// cierra la última fila
					if (!blnClosed)
						strHTML += "</tr>\n";
				// Crea el fin HTML
					strHTML += "</table>\n";
					strHTML += "</body>\n";
					strHTML += "</html>\n";
				// Graba el archivo
					SaveFile(Path.Combine(udtPath.PathName, "Gallery.htm"), strHTML);
		}
		
		/// <summary>
		///		Obtiene el nombre de archivo de una imagen para el HTML
		/// </summary>
		private string GetImageName(int intPhoto, bool blnThumb)
		{ return (blnThumb ? "th" : "") + "Page " + string.Format("{0:00000}", intPhoto) + 
								Path.GetExtension(Pages[intPhoto].FileName);
		}
				
		/// <summary>
		///		Graba un archivo de texto
		/// </summary>
		private void SaveFile(string strFileName, string strHTML)
		{ // Elimina el archivo
				Bau.Libraries.LibHelper.Files.HelperFiles.KillFile(strFileName);
			// Graba el archivo
				try
					{ Bau.Libraries.LibHelper.Files.HelperFiles.SaveTextFile(strFileName, strHTML);
					}
				catch (Exception objException)
					{ Helper.ShowMessage(this, "Error al grabar el archivo.\n" + objException.Message);
					}
		}
		
		/// <summary>
		///		Crea la galería
		/// </summary>
		private void SaveImages()
		{ int intPhoto = 0;
		
			// Crea las imágenes
				foreach (ComicPage objPage in Pages)
					{ // Muestra la barra de progreso
							Program.MainWindow.ShowProgressBar("Creando galería de imágenes", Pages.Count, intPhoto);
						// Crea el thumbnail
							CreateThumbnail(objPage.FileName, Path.Combine(udtPath.PathName, GetImageName(intPhoto, true)),
															(int) nudWidth.Value);
						// Copia la página original en la ubicación
							if (nudWidthPage.Value == 0)
								{ if (!CopyFile(objPage.FileName, Path.Combine(udtPath.PathName, GetImageName(intPhoto, false))))
										Helper.ShowMessage(this, "Error al copiar la página " + intPhoto);
								}
							else
								CreateThumbnail(objPage.FileName, Path.Combine(udtPath.PathName, GetImageName(intPhoto, false)),
																							(int) nudWidthPage.Value);
						// Incrementa el índice de fotos
							intPhoto++;
					}
			// Cierra la barra de progreso
				Program.MainWindow.HideProgressBar();
		}

		/// <summary>
		///		Copia un archivo
		/// </summary>
		private bool CopyFile(string strFileSource, string strFileTarget)
		{ return Bau.Libraries.LibHelper.Files.HelperFiles.CopyFile(strFileSource, strFileTarget);
		}		
				
		/// <summary>
		///		Obtiene el nombre de archivo de una imagen
		/// </summary>
		private string GetFileName(string strFileSource, int intPhoto, bool blnThumb)
		{ return Path.Combine(udtPath.PathName, GetImageName(intPhoto, blnThumb));
		}
		
		/// <summary>
		/// 	Crea los thumbs de las imágenes
		/// </summary>
		private void CreateThumbnail(string strFileNameSource, string strFileNameTarget, int intWidthThumbnail)
		{ try
				{ // Elimina el archivo de salida
						Bau.Libraries.LibHelper.Files.HelperFiles.KillFile(strFileNameTarget);
					// Si existe el archivo de entrada crea el de salida
						if (File.Exists(strFileNameSource))
							{	Image imgSource = Image.FromFile(strFileNameSource);

								//	Crea el thumbnail
									imgSource = CreateThumbnail(imgSource, intWidthThumbnail);
								// Y lo graba
									imgSource.Save(strFileNameTarget);
							}
				}
			catch (Exception objException)
				{ MessageBox.Show("Error al crear el thumbnail de: " + strFileNameSource + "\n" + objException.Message);
				}
		}
	
		/// <summary>
		///		Crea un thumbNail de una imagen
		/// </summary>
		private Bitmap CreateThumbnail(Image imgSource, int intThumbnailWidth)
		{ int intThumbnailHeight = (int) (((double) imgSource.Height) / ((double) imgSource.Width) * intThumbnailWidth);
			Bitmap bmpImage = new Bitmap(intThumbnailWidth, intThumbnailHeight);
			
				// Dibuja el thumbnail de la imagen en un nuevo gráfico
					using (Graphics grCanvas = Graphics.FromImage(bmpImage))
						{	// Inicializa las propiedades del canvas
								grCanvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
								grCanvas.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
								grCanvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
							// Dibuja la imagen origen en la destino			
								grCanvas.DrawImage(imgSource, new Rectangle(0, 0, intThumbnailWidth, intThumbnailHeight), 
																	 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
						}
				// Devuelve la imagen	 
					return bmpImage;
		}
				
		public ComicPagesCollection Pages
		{ get { return objColPages; }
			set { objColPages = value; }
		}

		public string Title
		{ get { return txtTitle.Text; }
			set { txtTitle.Text = value; }
		}
		
		private void frmComicGalleryHTML_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}
	}
}