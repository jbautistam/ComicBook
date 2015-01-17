using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Controls.Forms;
using Bau.Applications.ComicsBooks.Classes;
using Bau.Libraries.LibComicsBooks;

namespace Bau.Applications.ComicsBooks.Forms.Comic
{
	/// <summary>
	///		Formulario para mostrar un cómic
	/// </summary>
	public partial class frmComic : WeifenLuo.WinFormsUI.Docking.DockContent, IFormAdmon<string>
	{ // Delegados
			private delegate void ShowThumbCallback(int intPage); // Permite llamadas asíncronas para cambiar la lista de thumbs
		// Enumerados
			private enum IndexZoom
				{ ZoomFitPage,
					ZoomFitWidth,
					ZoomFitHeight,
					Zoom25,
					Zoom50,
					Zoom75,
					Zoom100,
					Zoom125,
					Zoom150,
					Zoom175,
					Zoom200
				}
			private enum IndexRotation
				{ NoRotation,
					Rotation90,
					Rotation180,
					Rotation270
				}
			private enum IndexFlip
				{ NoFlip,
					FlipHorizontal,
					FlipVertical,
					FlipHorizontalVertical
				}
		// Variables privadas
			private string strFileName = null;
			private ComicBook objComicBook = new ComicBook();
			private int intPage = -1;
			private string strTempPath = null;
			private Bau.Controls.ImageControls.Picture.PictureTrack imgTrack = new Bau.Controls.ImageControls.Picture.PictureTrack();
			private IndexRotation intRotation = IndexRotation.NoRotation;
			private IndexFlip intIndexFlip = IndexFlip.NoFlip;
			private bool blnUpdated = false, blnLoaded = false;
			
		public frmComic()
		{	InitializeComponent();
		}
		
		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{	// Inicializa las etiquetas de la pantalla (por los posibles errores)
				lblMarkAsDeleted.Text = "";
				lblInfo.Text = "";
			// Crea el directorio intermedio
				CreateTempPath();
			// Cambia el tag y tabs del formulario (lo hace después de cambiar el temporal porque la
			// rutina de creación obtiene el nombre del directorio cuando es un nuevo archivo)
				ToolTipText = TabText = Text = System.IO.Path.GetFileName(IDData);
				Tag = colDockedForms.GetTag(colDockedForms.FormType.Comic, IDData);
			// Inicializa el control que sirve para poner el thumb de la imagen
				InitImageTrack();
			// Inicializa la lista de páginas
				trbWidthThumbs.Value = clsConfiguration.WidthThumbs;
			// Carga el cómic e inicializa el formulario
				try
					{ // Carga el cómic
							LoadComic();
							cmdShowPages.Checked = clsConfiguration.ShowPages;
							cmdShowThumb.Checked = clsConfiguration.ShowThumbs;
							SetLayout();
						// Indica que se ha cargado correctamente
							blnLoaded = true;
					}
				catch (Exception objExcepction)
					{	Helper.ShowMessage(this, "Error al cargar el archivo\n" + objExcepction.Message);
					}
		}
		
		/// <summary>
		///		Crea el directorio temporal
		/// </summary>
		private void CreateTempPath()
		{ // Si lo que se le pasa no es un nombre de directorio
				if (string.IsNullOrEmpty(IDData) || !System.IO.Directory.Exists(IDData))
					{ // Obtiene el nombre del directorio temporal
							strTempPath = GetNextPath(Program.GetTempPath());
						// Crea el directorio temporal
							Bau.Libraries.LibHelper.Files.HelperFiles.MakePath(strTempPath);
						// Si no ha creado el directorio temporal, deja los archivos en el directorio actual de la aplicación
							if (!System.IO.Directory.Exists(strTempPath))
								strTempPath = Application.StartupPath;
						// Si estamos en una imagen, la copiamos al directorio temporal
							if (string.IsNullOrEmpty(IDData))
								IDData = strTempPath;
							else if (ComicBook.GetComicType(IDData) == ComicBook.ComicType.Image)
								{ string strTargetFileName = System.IO.Path.Combine(strTempPath, System.IO.Path.GetFileName(strFileName));
								
										// Copia el archivo
											System.IO.File.Copy(IDData, strTargetFileName);
										// Cambia el nombre de archivo a cargar para que recoja el archivo cargado
											IDData = strTargetFileName;
								}
					}
				else
					strTempPath = IDData;
		}

		/// <summary>
		///		Obtiene un nombre de directorio consecutivo
		/// </summary>
		private string GetNextPath(string strPath)
		{ string strNewPath;
			int intIndex = 0;
		
				// Mientras que exista el nombre de directorio, busca otro
					do
						{ strNewPath = System.IO.Path.Combine(strPath, string.Format("{0:0000000}", intIndex++));
						}
					while (System.IO.Directory.Exists(strNewPath));
				// Devuelve el nombre del directorio encontrado
					return strNewPath;
		}
		
		/// <summary>
		///		Inicializa el control que sirve para mostrar un thumb de la imagen principal
		/// </summary>
		private void InitImageTrack()		
		{ imgTrack.Width = 125;
			imgTrack.Height = 150;
			imgTrack.Top = Height - imgTrack.Height - 65;
			imgTrack.Left = Width - imgTrack.Width - 50;
			imgTrack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			imgTrack.Visible = true;
			imgTrack.Parent = this;
			tableLayoutPanel1.SendToBack();
		}
		
		/// <summary>
		///		Carga el cómic
		/// </summary>
		private void LoadComic()
		{ int intPages = 0;

				// Cambia el cursor
					Cursor.Current = Cursors.WaitCursor;
				// Carga el cómic
					objComicBook.Load(IDData);
					objComicBook.ComicAction += new ComicBook.ComicActionHandler(objComicBook_ComicAction);
				// Guarda el número de páginas porque al descomprimir se borran las páginas iniciales
					intPages = objComicBook.Pages.Count;
				// Descomprime el cómic
					objComicBook.Uncompress(strTempPath, true);
				// Añade el cómic a la biblioteca
					Program.ComicsLibrary.AddComicInfo(objComicBook.Info);
				// Carga la lista de thumbs inicial
					lstThumbs.BeginUpdate();
					lstThumbs.Clear();
					for (int intIndex = 0; intIndex < intPages; intIndex++)
						lstThumbs.Thumbnails.Add(null);
					lstThumbs.EndUpdate();
				// Carga el combo de páginas
					cboPages.Items.Clear();
					for (int intIndex = 0; intIndex < intPages; intIndex++)
						cboPages.Items.Add((intIndex + 1).ToString());
				// Cambia el cursor
					Cursor.Current = Cursors.Default;
				// Cambia el foco al control de páginas
					imgPage.Select();
				// Muestra la última página leída
					GoPage(Program.LastFiles.GetLastPage(IDData), true);
		}

		/// <summary>
		///		Muestra una página
		/// </summary>
		private void GoPage(int intNewPage, bool blnReload)
		{ // Pasa a la página indicada
				if ((intNewPage != intPage || blnReload) && intNewPage >= 0 && intNewPage < objComicBook.Pages.Count)
					{ // Cambia la página actual
							intPage = intNewPage;
						// Carga el gráfico
							ShowImage(intPage);
						// Carga y selecciona el thumb
							ShowThumb(intPage);
							lstThumbs.Select(intPage);
						// Guarda la última página leída
							Program.LastFiles.SetLastPage(IDData, intPage);
						// Muestra si está marcada para borrar
							ShowMarkAsDeleted(intPage);
					}
			// Habilita / inhabilita los controles
				EnableControls(intPage);
		}

		/// <summary>
		///		Muestra una página
		/// </summary>
		private void ShowImage(int intPage)
		{ // Cambia el cursor
				Cursor.Current = Cursors.WaitCursor;
			// Carga la página y la muestra
				try
					{ // Si no existe la página, muestra la imagen por defecto ...
							if (!System.IO.File.Exists(objComicBook.Pages[intPage].FileName))
								imgPage.Picture = lstThumbs.Thumbnails[intPage].Thumbnail;
							else
								{	// Carga la imagen de la página
										imgPage.Picture = Image.FromFile(objComicBook.Pages[intPage].FileName);
									// Cambia la rotación
										imgPage.Rotate(GetFlipType(intRotation, intIndexFlip));
									// Cambia el zoom
										SetZoom((IndexZoom) clsConfiguration.LastZoom);
									// Carga la imagen en el control de zoom
										imgTrack.Picture = imgPage.Picture;
								}
					}
				catch (Exception objException)
					{ Helper.ShowMessage(this, "Error al cargar la página: " + (intPage + 1).ToString() + "\n" + 
																			 objException.Message); 
					}
			// Deja el cursor como estaba
				Cursor.Current = Cursors.Default;
		}

		/// <summary>
		///		Obtiene el tipo de rotación
		/// </summary>
		private RotateFlipType GetFlipType(IndexRotation intRotation, IndexFlip intIndexFlip)
		{ RotateFlipType intFlipType = RotateFlipType.RotateNoneFlipNone;
		
				// Obtiene la rotación
					switch (intIndexFlip)
						{ case IndexFlip.NoFlip:
									switch (intRotation)
										{ case IndexRotation.NoRotation:
													intFlipType = RotateFlipType.RotateNoneFlipNone;
												break;
											case IndexRotation.Rotation90:
													intFlipType = RotateFlipType.Rotate90FlipNone;
												break;
											case IndexRotation.Rotation180:
													intFlipType = RotateFlipType.Rotate180FlipNone;
												break;
											case IndexRotation.Rotation270:
													intFlipType = RotateFlipType.Rotate270FlipNone;
												break;
										}
								break;
							case IndexFlip.FlipHorizontal:
									switch (intRotation)
										{ case IndexRotation.NoRotation:
													intFlipType = RotateFlipType.RotateNoneFlipX;
												break;
											case IndexRotation.Rotation90:
													intFlipType = RotateFlipType.Rotate90FlipX;
												break;
											case IndexRotation.Rotation180:
													intFlipType = RotateFlipType.Rotate180FlipX;
												break;
											case IndexRotation.Rotation270:
													intFlipType = RotateFlipType.Rotate270FlipX;
												break;
										}
								break;
							case IndexFlip.FlipVertical:
									switch (intRotation)
										{ case IndexRotation.NoRotation:
													intFlipType = RotateFlipType.RotateNoneFlipY;
												break;
											case IndexRotation.Rotation90:
													intFlipType = RotateFlipType.Rotate90FlipY;
												break;
											case IndexRotation.Rotation180:
													intFlipType = RotateFlipType.Rotate180FlipY;
												break;
											case IndexRotation.Rotation270:
													intFlipType = RotateFlipType.Rotate270FlipY;
												break;
										}
								break;
							case IndexFlip.FlipHorizontalVertical:
									switch (intRotation)
										{ case IndexRotation.NoRotation:
													intFlipType = RotateFlipType.RotateNoneFlipXY;
												break;
											case IndexRotation.Rotation90:
													intFlipType = RotateFlipType.Rotate90FlipXY;
												break;
											case IndexRotation.Rotation180:
													intFlipType = RotateFlipType.Rotate180FlipXY;
												break;
											case IndexRotation.Rotation270:
													intFlipType = RotateFlipType.Rotate270FlipXY;
												break;
										}
								break;
						}
				// Devuelve la rotación
					return intFlipType;
		}
		
		/// <summary>
		///		Muestra el thumbnail de una página
		/// </summary>
		private void ShowThumb(int intThumbPage)
		{ if (this.InvokeRequired)
				{	ShowThumbCallback fncCallback = new ShowThumbCallback(ShowThumb);
					
						Invoke(fncCallback, new object[] { intThumbPage });
				}
			else
				{	if (intThumbPage >= 0 && intThumbPage < lstThumbs.Thumbnails.Count)
						lstThumbs.Thumbnails[intThumbPage].FileName = objComicBook.Pages[intThumbPage].FileName;
					if (intPage < 0)
						GoPage(0, true);
				}		
		}
		
		/// <summary>
		///		Muestra la etiqueta que indica si está marcada para borrar
		/// </summary>
		private void ShowMarkAsDeleted(int intPage)
		{ if (objComicBook.Pages[intPage].MarkAsDeleted)
				lblMarkAsDeleted.Text = "  Marcada para borrar";
			else
				lblMarkAsDeleted.Text = "";
		}
		
		/// <summary>
		///		Cambia el zoom de la imagen
		/// </summary>
		private void SetZoom(IndexZoom intZoom)
		{ // Dechequea todos los elementos del zoom
				for (int intIndex = 0; intIndex < ctxComicZoomOptions.Items.Count; intIndex++)
					if (ctxComicZoomOptions.Items[intIndex] is ToolStripMenuItem)
						(ctxComicZoomOptions.Items[intIndex] as ToolStripMenuItem).Checked = false;
			// Obtiene el zoom
				switch (intZoom)
					{ case IndexZoom.ZoomFitPage:
								imgPage.ZoomView = Bau.Controls.ImageControls.Picture.PictureZoom.ZoomMode.FitPage;
								mnuComicZoomOptionsFitWindow.Checked = true;
							break;
						case IndexZoom.ZoomFitHeight:
								imgPage.ZoomView = Bau.Controls.ImageControls.Picture.PictureZoom.ZoomMode.FitHeight;
								mnuComicZoomOptionsFitHeight.Checked = true;
							break;
						case IndexZoom.ZoomFitWidth:
								imgPage.ZoomView = Bau.Controls.ImageControls.Picture.PictureZoom.ZoomMode.FitWidth;
								mnuComicZoomOptionsFitWidth.Checked = true;
							break;
						case IndexZoom.Zoom25:
								imgPage.Zoom = 0.25;
								mnuComicZoomOptions25.Checked = true;
							break;
						case IndexZoom.Zoom50:
								imgPage.Zoom = 0.5;
								mnuComicZoomOptions50.Checked = true;
							break;
						case IndexZoom.Zoom75:
								imgPage.Zoom = 0.75;
								mnuComicZoomOptions75.Checked = true;
							break;
						case IndexZoom.Zoom100:
								imgPage.Zoom = 1;
								mnuComicZoomOptions100.Checked = true;
							break;
						case IndexZoom.Zoom125:
								imgPage.Zoom = 1.25;
								mnuComicZoomOptions125.Checked = true;
							break;
						case IndexZoom.Zoom150:
								imgPage.Zoom = 1.5;
								mnuComicZoomOptions150.Checked = true;
							break;
						case IndexZoom.Zoom175:
								imgPage.Zoom = 1.75;
								mnuComicZoomOptions175.Checked = true;
							break;
						case IndexZoom.Zoom200:
								imgPage.Zoom = 2;
								mnuComicZoomOptions200.Checked = true;
							break;
					}
				// Graba el zoom
					clsConfiguration.LastZoom = (int) intZoom;
		}
		
		/// <summary>
		///		Cambia la orientación
		/// </summary>
		private void SetFlip()
		{ IndexFlip intIndexFlip = IndexFlip.NoFlip;
		
				// Obtiene el tipo de orientación a partir de los menús seleccionados
					if (mnuRotateFlipVertical.Checked && mnuRotateFlipHorizontal.Checked)
						intIndexFlip = IndexFlip.FlipHorizontalVertical;
					else if (mnuRotateFlipVertical.Checked)
						intIndexFlip = IndexFlip.FlipVertical;
					else if (mnuRotateFlipHorizontal.Checked)
						intIndexFlip = IndexFlip.FlipHorizontal;
				// Cambia la orientación
					SetRotation(intRotation, intIndexFlip);				
		}

		/// <summary>
		///		Cambia la rotación
		/// </summary>
		private void SetRotation(IndexRotation intNewRotation, IndexFlip intNewIndexFlip)
		{ if (intNewRotation != intRotation || intNewIndexFlip != intIndexFlip)
				{	// Cambia el índice de rotación y espejo
						intRotation = intNewRotation;
						intIndexFlip = intNewIndexFlip;
					// Dechequea todos los menús
						mnuRotateNoRotation.Checked = false;
						mnuRotate90.Checked = false;
						mnuRotate180.Checked = false;
						mnuRotate270.Checked = false;
					// Cambia el menú
						switch (intRotation)
							{ case IndexRotation.NoRotation:
										mnuRotateNoRotation.Checked = true;
									break;
								case IndexRotation.Rotation90:
										mnuRotate90.Checked = true;
									break;
								case IndexRotation.Rotation180:
										mnuRotate180.Checked = true;
									break;
								case IndexRotation.Rotation270:
										mnuRotate270.Checked = true;
									break;
							}
					// Cambia la rotación
						GoPage(intPage, true);
				}
		}

		/// <summary>
		///		Cambia la posición de la imagen en el thumb
		/// </summary>
		private void SetTrackPosition(int intLeft, int intTop)
		{ imgTrack.ZoomLeft = intLeft;
			imgTrack.ZoomTop = intTop;
			imgTrack.Zoom = imgPage.Zoom;
		}
		
		/// <summary>
		///		Habilita / inhabilita los controles
		/// </summary>
		private void EnableControls(int intPage)
		{ cmdGoFirstPage.Enabled = cmdGoPreviousPage.Enabled = intPage > 0;
			cmdGoLastPage.Enabled = cmdGoNextPage.Enabled = intPage < objComicBook.Pages.Count - 1;
			cboPages.SelectedIndex = intPage;
			lblInfo.Text = " de " + objComicBook.Pages.Count.ToString();
		}
		
		/// <summary>
		///		Cambia el aspecto del formulario
		/// </summary>
		private void SetLayout()
		{ bool blnColapsed = splMain.Panel1Collapsed;
		
				// Muestra / oculta el control de página
					splMain.Panel1Collapsed = !cmdShowPages.Checked;
					if (blnColapsed && !splMain.Panel1Collapsed)
						if (clsConfiguration.WidthSplitter != 0)
							splMain.SplitterDistance = clsConfiguration.WidthSplitter;
						else
							splMain.SplitterDistance = 2 * lstThumbs.ThumbnailWidth + 40;
				// Muestra / oculta el control de thumb
					imgTrack.Visible = cmdShowThumb.Checked;
				// Guarda los datos de configuración
					clsConfiguration.ShowPages = cmdShowPages.Checked;
					clsConfiguration.ShowThumbs = cmdShowThumb.Checked;
		}
		
		/// <summary>
		///		Mueve una página arriba / abajo
		/// </summary>
		private void MovePage(int intPage, bool blnMoveUp)
		{ int intNextPage = intPage;
		
				// Asigna el valor de la siguiente página
					if (blnMoveUp)
						intNextPage = intPage - 1;
					else
						intNextPage = intPage + 1;
				// Si está en los límites ...
					if (intNextPage >= 0 && intNextPage < objComicBook.Pages.Count)
						{ ComicPage objPage = objComicBook.Pages[intPage];
						
								// Intercambia las páginas
									objComicBook.Pages[intPage] = objComicBook.Pages[intNextPage];
									objComicBook.Pages[intNextPage] = objPage;
								// Intercambia los thumbs
									lstThumbs.BeginUpdate();
									lstThumbs.Thumbnails[intPage].FileName = objComicBook.Pages[intPage].FileName;
									lstThumbs.Thumbnails[intNextPage].FileName = objComicBook.Pages[intNextPage].FileName;
									lstThumbs.EndUpdate();
								// Recarga la página
									GoPage(intNextPage, false);
								// Indica que se ha modificado
									blnUpdated = true;
						}
		}

		/// <summary>
		///		Crea una nueva página
		/// </summary>
		private void NewPage()
		{ string strNewFileName = Helper.GetFileNameOpen("JPG|*.jpg|GIF|*.gif|BMP|*.bmp|Tiff|*.tif|PNG|*.png|Todos los archivos|*.*");
		
				if (!string.IsNullOrEmpty(strNewFileName))
					{ if (IsImage(strNewFileName))
							{ string strFileCopied = System.IO.Path.Combine(strTempPath, System.IO.Path.GetFileName(strNewFileName));
							
									if (Bau.Libraries.LibHelper.Files.HelperFiles.CopyFile(strNewFileName, strFileCopied))
										{ // Añade el archivo al final
												AddFile(strFileCopied);
											// Indica que se ha modificado
												blnUpdated = true;
										}
									else
										Helper.ShowMessage(this, "No se ha podido copiar el archivo");
							}
						else
							Helper.ShowMessage(this, "No se puede leer el archivo o no es un archivo de imagen");
					}
		}
		
		/// <summary>
		///		Pega una página
		/// </summary>
		private void PastePage()
		{ Image imgClipboard = Clipboard.GetImage();
		
				if (imgClipboard != null)
					{ string strFileName = string.Format("{0:0000000}", objComicBook.Pages.Count + 1) + ".jpg";
					
							try
								{	// Graba el archivo
										imgClipboard.Save(strFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
									// Añade el archivo a la colección
										AddFile(strFileName);
									// Indica que se ha descomprimido la página
										if (objComicBook.Pages.Count > 0)
											objComicBook.Pages[objComicBook.Pages.Count - 1].Uncompressed = true;
									// Indica que se ha modificado
										blnUpdated = true;
								}
							catch (Exception objException)
								{ Helper.ShowMessage(this, "Error al grabar el archivo del portapapeles\n" + objException.Message);
									Program.Log("Error al grabar el archivo del portapapeles\n" + objException.Message);
								}
					}
		}

		/// <summary>
		///		Añade una página al cómic a partir del archivo
		/// </summary>
		private void AddFile(string strFileName)
		{	// Añade el archivo al final
				objComicBook.Pages.Add(strFileName);
			// Añade la página al combo y al thumb
				cboPages.Items.Add(objComicBook.Pages.Count);
				lstThumbs.Thumbnails.Add(strFileName);
			// Muestra la última página
				GoPage(objComicBook.Pages.Count - 1, false);
		}
		
		/// <summary>
		///		Comprueba si es un archivo de imagen
		/// </summary>
		private bool IsImage(string strFileName)
		{ bool blnIsImage = false;
		
				// Intenta cargar la imagen
					if (System.IO.File.Exists(strFileName))
						try
							{ Image objImage = Image.FromFile(strFileName);
									
									// Indica que es una imagen
										blnIsImage = true;
							}
						catch {}
				// Devuelve el valor que indica si es una imagen
					return blnIsImage;
		}
		
		/// <summary>
		///		Comprueba si todas las páginas están descomprimidas
		/// </summary>
		private bool IsAllUncompress()
		{	// Comprueba las páginas
				for (int intIndex = 0; intIndex < objComicBook.Pages.Count; intIndex++)	
					if (!objComicBook.Pages[intIndex].Uncompressed)
						return false;
			// Si ha llegado hasta aquí es porque todo está descomprimido
				return true;
		}
		
		/// <summary>
		///		Graba el archivo como CBZ
		/// </summary>
		private void Save()
		{ if (!IsAllUncompress())
				Helper.ShowMessage(this, "Aún no se han descomprimido todas las páginas");
			else
				{	string strNewFileName = Helper.GetFileNameSave("Archivo CBZ|*.cbz|Archivo PDF|*.pdf");
			
						if (!string.IsNullOrEmpty(strNewFileName))
							{ bool blnSave = false;
								
									// Cambia el cursor
										Cursor.Current = Cursors.WaitCursor;
									// Cambia el directorio de trabajo
										Environment.CurrentDirectory = Application.StartupPath;
									// Graba el archivo
										try
											{ // Graba el archivo
													objComicBook.Save(strNewFileName, objComicBook.Pages, objComicBook.Info);
												// Indica que se ha grabado
													blnSave = true;
											}
										catch (Exception objException)
											{ Helper.ShowMessage(this, "Error en la creación del archivo\n" + objException.Message);
											}
									// Cambia el cursor 
										Cursor.Current = Cursors.Default;
									// Muestra un mensaje al usuario e indica que ya no quedan modificaciones pendientes y añade el nombre
									// de archivo a la lista de últimos archivos grabados
										if (blnSave)
											{	Helper.ShowMessage(this, "Se ha finalizado la grabación del archivo");
												Program.MainWindow.AddLastFile(strNewFileName);
												blnUpdated = false;
											}
							}
				}
		}
		
		/// <summary>
		///		Exporta el archivo a HTML
		/// </summary>
		private void ExportToHTML()
		{	if (!IsAllUncompress())
				Helper.ShowMessage(this, "Aún no se han descomprimido todas las páginas");
			else
				{	frmComicGalleryHTML frmNewGallery = new frmComicGalleryHTML();
		
						// Cambia el cursor
							Cursor.Current = Cursors.WaitCursor;
						// Cambia el directorio de trabajo
							Environment.CurrentDirectory = Application.StartupPath;
						// Pasa los parámetros al formulario
							frmNewGallery.Pages = objComicBook.Pages;
							frmNewGallery.Title = System.IO.Path.GetFileName(IDData);
						// Abre el formulario que genera la galería
							frmNewGallery.ShowDialog();
				}
		}
		
		/// <summary>
		///		Exporta el archivo a ePub
		/// </summary>
		private void ExportToEPub()
		{	if (!IsAllUncompress())
				Helper.ShowMessage(this, "Aún no se han descomprimido todas las páginas");
			else
				{	frmComicEPub frmNewEPub = new frmComicEPub();
		
						// Cambia el cursor
							Cursor.Current = Cursors.WaitCursor;
						// Cambia el directorio de trabajo
							Environment.CurrentDirectory = Application.StartupPath;
						// Pasa los parámetros al formulario
							frmNewEPub.IDSource = IDData;
							frmNewEPub.Pages = objComicBook.Pages;
							frmNewEPub.Title = System.IO.Path.GetFileNameWithoutExtension(IDData);
						// Abre el formulario que genera el archivo ePub
							frmNewEPub.ShowDialog();
				}
		}
		
		/// <summary>
		///		Elimina la página
		/// </summary>
		private void Delete(int intPage)
		{ if (objComicBook.Pages.Count > 0 && (intPage >= 0 && intPage < objComicBook.Pages.Count))
				{	if (objComicBook.Type == ComicBook.ComicType.Path)
							{ if (Helper.ShowQuestion(this, "¿Realmente desea eliminar esta imagen?"))
									{ // Libera la imagen
											imgPage.Picture = null;
										// Borra la imagen
											if (Bau.Libraries.LibHelper.Files.HelperFiles.KillFile(objComicBook.Pages[intPage].FileName))
												{ // Elimina la página de memoria
														objComicBook.Pages.RemoveAt(intPage);
													// Elimina el thumb de la lista
														lstThumbs.Thumbnails.RemoveAt(intPage);
													// Pasa a la página anterior
														if (intPage < objComicBook.Pages.Count)
															GoPage(intPage, true);
														else
															GoPage(intPage - 1, false);
												}
											else
												Helper.ShowMessage(this, "Error al eliminar el archivo");
									}
							}
						else
							{ // Marca / desmarca la página
									objComicBook.Pages[intPage].MarkAsDeleted = !objComicBook.Pages[intPage].MarkAsDeleted;
								// Muestra si está marcada para borrar
									ShowMarkAsDeleted(intPage);
								// Indica que se ha modificado
									blnUpdated = true;
							}
				}
		}
		
		/// <summary>
		///		Imprime el cómic
		/// </summary>
		private void Print(clsEnums.TypeAction intAction)
		{ if (!IsAllUncompress())
				Helper.ShowMessage(this, "Aún no se han descomprimido todas las páginas");
			else
				Classes.Print.clsPrintHelper.Print(intAction, "Preliminar " + Text, objComicBook.Pages);
		}

		/// <summary>
		///		Abre el formulario de información
		/// </summary>
		private void OpenFormInfo()
		{ frmComicInfo frmNewComic = new frmComicInfo();
		
				// Asigna las propiedades
					frmNewComic.FileName = objComicBook.FileName;
					frmNewComic.Info = objComicBook.Info;
				// Muestra el formulario
					frmNewComic.ShowDialog();
				// Indica si se ha modificado y en su caso añade el cómic a la biblioteca
					if (frmNewComic.DialogResult == DialogResult.OK)
						{ // Añade el cómic a la biblioteca
								Program.ComicsLibrary.AddComicInfo(objComicBook.Info);
							// Indica que no se ha modificado
								blnUpdated = true;
						}
		}

		/// <summary>
		///		Muestra la lupa
		/// </summary>
		private void ShowMagnifier()
		{ Bau.Controls.ImageControls.Magnifier.MagnifierController objMagnifier = new Bau.Controls.ImageControls.Magnifier.MagnifierController();
		
				objMagnifier.Show();
		}
		
		/// <summary>
		///		Ejecuta una acción desde el menú principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Copy:
							Clipboard.SetImage(imgPage.Picture);
						break;
					case clsEnums.TypeAction.Cut:
						break;
					case clsEnums.TypeAction.Paste:
							PastePage();
						break;
					case clsEnums.TypeAction.NewPage:
							NewPage();
						break;
					case clsEnums.TypeAction.Print:
					case clsEnums.TypeAction.PrintPreview:
					case clsEnums.TypeAction.PrintWithDialog:
							Print(intAction);
						break;
					case clsEnums.TypeAction.Save:
							Save();
						break;
					case clsEnums.TypeAction.ExportHTML:
							ExportToHTML();
						break;
					case clsEnums.TypeAction.ExportEPub:
							ExportToEPub();
						break;
					case clsEnums.TypeAction.Remove:
							Delete(intPage);
						break;
				}
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acción
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Copy:
					case clsEnums.TypeAction.ExportHTML:
					case clsEnums.TypeAction.ExportEPub:
					case clsEnums.TypeAction.Paste:
					case clsEnums.TypeAction.NewPage:
					case clsEnums.TypeAction.Print:
					case clsEnums.TypeAction.PrintPreview:
					case clsEnums.TypeAction.PrintWithDialog:
					case clsEnums.TypeAction.Save:
					case clsEnums.TypeAction.Remove:
						return true;
					default:
						return false;
				}
		}

		/// <summary>
		///		Rutina de tratamiento del evento Changed de los controles
		/// </summary>
		public void Changed(object sender, EventArgs e)
		{ // ... no hace nada, se crea para soportar el interface
		}

		public string IDData
		{ get { return strFileName; }
			set { strFileName = value; }
		}

		private void frmHelp_Load(object sender, EventArgs e)
		{ InitForm();
		}
		
		/// <summary>
		///		Manejador de los eventos del cómic
		/// </summary>
		private void objComicBook_ComicAction(object objSender, EventComicArgs evnArgs)
		{ if (evnArgs.Action == EventComicArgs.ActionType.End)
				Program.MainWindow.HideProgressBar();
			else if (evnArgs.Action != EventComicArgs.ActionType.Unknown)
				{ string strTitle = "";
				
						// Obtiene el título
							switch (evnArgs.Action)
								{ case EventComicArgs.ActionType.Error:
											Bau.Controls.Forms.Helper.ShowMessage(this, evnArgs.Message);
										break;
									case EventComicArgs.ActionType.Uncompress:
											strTitle = "Descomprimiendo";
											ShowThumb(evnArgs.Actual - 1);
											lblInfo.Text = evnArgs.Actual.ToString();
										break;
									case EventComicArgs.ActionType.Compress:
											strTitle = "Comprimiendo";
										break;
								}
						// Muestra la barra de estado
							Program.MainWindow.ShowProgressBar(strTitle, evnArgs.Total, evnArgs.Actual);
				}
		}

		private void cmdGoPreviousPage_Click(object sender, EventArgs e)
		{ GoPage(intPage - 1, false);
		}

		private void cmdGoNextPage_Click(object sender, EventArgs e)
		{ GoPage(intPage + 1, false);
		}

		private void cmdGoFirstPage_Click(object sender, EventArgs e)
		{ GoPage(0, false);
		}

		private void cmdGoLastPage_Click(object sender, EventArgs e)
		{ GoPage(objComicBook.Pages.Count - 1, false);
		}

		private void cboPages_SelectedIndexChanged(object sender, EventArgs e)
		{ GoPage(cboPages.SelectedIndex, false);
		}

		private void imgPage_StartPageReached(object sender, EventArgs e)
		{ GoPage(intPage - 1, false);
		}

		private void imgPage_EndPageReached(object sender, EventArgs e)
		{ GoPage(intPage + 1, false);
		}

		private void imgPage_PositionChanged(object objSender, Bau.Controls.ImageControls.Picture.EventPictureArgs objEventPictureArgs)
		{ SetTrackPosition(objEventPictureArgs.Left, objEventPictureArgs.Top);
		}

		private void lstThumbs_SelectedIndexChanged(object sender, EventArgs e)
		{ if (lstThumbs.SelectedItems != null && lstThumbs.SelectedItems.Count > 0)
				GoPage(lstThumbs.SelectedItems[0].Index, false);
		}

		private void cmdShowPages_Click(object sender, EventArgs e)
		{	// Cambia el checked
				((ToolStripButton) sender).Checked = !((ToolStripButton) sender).Checked;
			// Cambia el aspecto del formulario
				SetLayout();
		}

		private void trbWidthThumbs_ValueChanged(object sender, EventArgs e)
		{ lstThumbs.ThumbnailWidth = trbWidthThumbs.Value;
			clsConfiguration.WidthThumbs = lstThumbs.ThumbnailWidth;
		}

		private void cmdNewPage_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.NewPage);
		}

		private void cmdRemovePage_Click(object sender, EventArgs e)
		{	ExecuteAction(clsEnums.TypeAction.Remove);
		}

		private void cmdPageUp_Click(object sender, EventArgs e)
		{ MovePage(intPage, true);
		}

		private void cmdPageDown_Click(object sender, EventArgs e)
		{ MovePage(intPage, false);
		}

		private void frmComic_FormClosing(object sender, FormClosingEventArgs e)
		{ if (blnUpdated && 
					!Helper.ShowQuestion(this, 
															 "Se han realizado modificaciones que no se han grabado\n¿Realmente desea salir?"))
				e.Cancel = true;
		}

		private void mnuComicCopy_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Copy);
		}

		private void mnuComicCut_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Cut);
		}

		private void mnuComicPaste_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Paste);
		}

		private void mnuComicSave_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Save);
		}

		private void mnuComicPrint_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Print);
		}

		private void mnuComicPrintPreview_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.PrintPreview);
		}

		private void mnuComicZoomOptionsFitWindow_Click(object sender, EventArgs e)
		{ SetZoom(IndexZoom.ZoomFitPage);
		}

		private void mnuComicZoomOptionsFitWidth_Click(object sender, EventArgs e)
		{	SetZoom(IndexZoom.ZoomFitWidth);
		}

		private void mnuComicZoomOptionsFitHeight_Click(object sender, EventArgs e)
		{ SetZoom(IndexZoom.ZoomFitHeight);
		}

		private void mnuComicZoomOptions25_Click(object sender, EventArgs e)
		{ SetZoom(IndexZoom.Zoom25);
		}

		private void mnuComicZoomOptions50_Click(object sender, EventArgs e)
		{ SetZoom(IndexZoom.Zoom50);
		}

		private void mnuComicZoomOptions75_Click(object sender, EventArgs e)
		{ SetZoom(IndexZoom.Zoom75);
		}

		private void mnuComicZoomOptions100_Click(object sender, EventArgs e)
		{ SetZoom(IndexZoom.Zoom100);
		}

		private void mnuComicZoomOptions125_Click(object sender, EventArgs e)
		{ SetZoom(IndexZoom.Zoom125);
		}

		private void mnuComicZoomOptions150_Click(object sender, EventArgs e)
		{ SetZoom(IndexZoom.Zoom150);
		}

		private void mnuComicZoomOptions175_Click(object sender, EventArgs e)
		{ SetZoom(IndexZoom.Zoom175);
		}

		private void mnuComicZoomOptions200_Click(object sender, EventArgs e)
		{ SetZoom(IndexZoom.Zoom200);
		}

		private void frmComic_Shown(object sender, EventArgs e)
		{ if (!blnLoaded)
				Close();
		}

		private void cmdInfo_Click(object sender, EventArgs e)
		{ OpenFormInfo();
		}

		private void splMain_SplitterMoved(object sender, SplitterEventArgs e)
		{ clsConfiguration.WidthSplitter = splMain.SplitterDistance;
	}

		private void mnuComicZoomOptionsMagnifier_Click(object sender, EventArgs e)
		{ ShowMagnifier();
		}

		private void mnuRotateLeft_Click(object sender, EventArgs e)
		{ if (intRotation == IndexRotation.NoRotation)
				SetRotation(IndexRotation.Rotation270, intIndexFlip);
			else
				SetRotation((IndexRotation) ((int) intRotation - 1), intIndexFlip);
		}

		private void mnuRotateRight_Click(object sender, EventArgs e)
		{ if (intRotation == IndexRotation.Rotation270)
				SetRotation(IndexRotation.NoRotation, intIndexFlip);
			else
				SetRotation((IndexRotation) ((int) intRotation + 1), intIndexFlip);
		}

		private void mnuRotateNoRotation_Click(object sender, EventArgs e)
		{ SetRotation(IndexRotation.NoRotation, intIndexFlip);
		}

		private void mnuRotate90_Click(object sender, EventArgs e)
		{ SetRotation(IndexRotation.Rotation90, intIndexFlip);
		}

		private void mnuRotate180_Click(object sender, EventArgs e)
		{ SetRotation(IndexRotation.Rotation180, intIndexFlip);
		}

		private void mnuRotate270_Click(object sender, EventArgs e)
		{ SetRotation(IndexRotation.Rotation270, intIndexFlip);
		}

		private void mnuRotateFlipHorizontal_Click(object sender, System.EventArgs e)
		{ ((ToolStripMenuItem) sender).Checked = !((ToolStripMenuItem) sender).Checked;
			SetFlip();
			throw new System.Exception("The method or operation is not implemented.");
		}
	}
}