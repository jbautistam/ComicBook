using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Bau.Controls.Forms;
using Bau.Libraries.LibComicsBooks;
using Bau.Libraries.LibEBook.Formats.eBook;
using Bau.Libraries.LibEBook.Formats.ePub.Creator;
using Bau.Libraries.LibHelper.Files;
using Bau.Libraries.ImageFilters.Helper;

namespace Bau.Applications.ComicsBooks.Forms.Comic
{
	/// <summary>
	///		Formulario de exportación de cómics a ePub
	/// </summary>
	public partial class frmComicEPub : Form
	{ 			
		public frmComicEPub()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Asigna el nombre de archivo
				udtFile.FileName = Title + ".ePub";
				if (!string.IsNullOrEmpty(IDSource))
					{ if (Directory.Exists(IDSource))
							udtFile.FileName = Path.Combine(IDSource, "eBook.ePub");
						else if (File.Exists(IDSource))
							udtFile.FileName = Path.Combine(Path.GetDirectoryName(IDSource),
																							Path.GetFileNameWithoutExtension(IDSource) + ".ePub");
					}
		}		
		
		/// <summary>
		///		Graba las páginas como HTML
		/// </summary>
		private void Save()
		{ if (string.IsNullOrEmpty(udtFile.FileName))
				Helper.ShowMessage(this, "Seleccione el nombre de archivo");
			else if (string.IsNullOrEmpty(txtTitle.Text))
				Helper.ShowMessage(this, "Introduzca el título del libro");
			else
				{ string strTempPath = CreateNextPath();
				
						// Graba el HTML
							CreateEBook(strTempPath, udtFile.FileName);
						// Mensaje al usuario
							Helper.ShowMessage(this, "Finalizada la generación de archivo");
						// Muestra la galería en el explorador
							if (chkSeeResult.Checked)
								{ // Añade el archivo a la lista de últimos archivos abiertos
										Program.MainWindow.AddLastFile(udtFile.FileName);
									// Abre el archivo
										Program.DockedForms.OpenFormAdmon(Bau.Applications.ComicsBooks.Classes.colDockedForms.FormType.ePub,
																											udtFile.FileName);
								}
						// Cierra el formulario
							DialogResult = DialogResult.OK;
							Close();
				}
		}
		
		/// <summary>
		///		Crea el eBook
		/// </summary>
		private void CreateEBook(string strPath, string strFileNameEBook)
		{ int intPhoto = 0;
			Book objEBook = new Book();
		
				// Asigna los metadatos
					objEBook.Title = txtTitle.Text;
				// Crea los archivos
					foreach (ComicPage objPage in Pages)
						{ string strURLImage = GetImageName(intPhoto);
							string strFileImage = Path.Combine(strPath, strURLImage);
							string strFileHTML = Path.Combine(strPath, Path.GetFileNameWithoutExtension(strURLImage) + ".htm");
							string strPageName = "Página " + (intPhoto + 1).ToString();
							PageFile objPageFile = new PageFile(strPageName, strPageName, strFileHTML, "html");
						
								// Muestra la barra de progreso
									Program.MainWindow.ShowProgressBar("Creando eBook", Pages.Count, intPhoto);
								// Crea la imagen
									CreateImage(objPage.FileName, strFileImage,
															(int) nudWidthPage.Value, chkWhiteAndBlack.Checked);
								// Crea el HTML
									SaveHTML(strFileHTML, txtTitle.Text + " - " + strPageName, strURLImage);
								// Agrega los archivos al libro
									objEBook.Files.Add(objPageFile);
									objEBook.Files.Add(strPageName, strPageName, strFileImage, 
																		 "image/" + Path.GetExtension(strFileImage).Substring(1));
								// Agrega la referencia a los índices
									objEBook.Index.Add(strPageName, objPageFile.ID, objPageFile.FileName);
									objEBook.TableOfContent.Add(strPageName, objPageFile.ID, objPageFile.FileName);
								// Incrementa el índice de imágenes
									intPhoto++;
						}
				// Crea el eBook
					new ePubCreator().Create(strFileNameEBook, objEBook);
				// Cierra la barra de progreso
					Program.MainWindow.HideProgressBar();
		}

		/// <summary>
		///		Crea el siguiente directorio
		/// </summary>
		private string CreateNextPath()
		{ string strPath = HelperFiles.GetConsecutivePath(Program.GetTempPath(), "0000000");
		
				// Crea el directorio
					HelperFiles.MakePath(strPath);
				// Devuelve el directorio
					return strPath;
		}
		
		/// <summary>
		///		Crea una imagen
		/// </summary>
		private void CreateImage(string strFileSource, string strFileTarget, int intWidth, bool blnWhiteBlack)
		{ Image objImage = FiltersHelpers.Load(strFileSource);
		
				//  Redimensiona la imagen
					if (intWidth != 0)
						objImage = FiltersHelpers.Resize(objImage, intWidth);
				// Cambia a blanco y negro
					if (blnWhiteBlack)
						objImage = FiltersHelpers.WhiteAndBlack(objImage, true);
				// Graba la imagen
					FiltersHelpers.Save(objImage, strFileTarget);
		}
		
		/// <summary>
		///		Graba el archivo HTML
		/// </summary>
		private void SaveHTML(string strFileHTML, string strTitle, string strURLImage)
		{ string strHTML;
		
				// Crea la cabecera HTML
					strHTML = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN'" +
											" 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>\n";
					strHTML += "<html xmlns='http://www.w3.org/1999/xhtml' dir='ltr'>\n";
					strHTML = "<html>\n";
					strHTML += "<head>\n";
					strHTML += "<title>" + strTitle + "</title>\n";
					strHTML += "</head>\n";
				// Crea el cuerpo
					strHTML += "<body>\n";
					strHTML += "<p><img src='" + strURLImage + "'></p>\n";
				// Crea el fin HTML
					strHTML += "</body>\n";
					strHTML += "</html>\n";
				// Graba el archivo
					HelperFiles.SaveTextFile(strFileHTML, strHTML);
		}
		
		/// <summary>
		///		Obtiene el nombre de archivo de una imagen para el HTML
		/// </summary>
		private string GetImageName(int intPhoto)
		{ return "Page " + string.Format("{0:00000}", intPhoto) + Path.GetExtension(Pages[intPhoto].FileName);
		}
		
		/// <summary>
		///		Nombre del archivo o directorio que se va a exportar
		/// </summary>
		public string IDSource { get; set; }
		
		/// <summary>
		///		Páginas que componen el cómic
		/// </summary>
		public ComicPagesCollection Pages { get ; set; }

		/// <summary>
		///		Título del libro
		/// </summary>
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