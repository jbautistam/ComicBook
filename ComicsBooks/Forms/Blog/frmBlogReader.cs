using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Applications.ComicsBooks.Classes;
using Bau.Applications.ComicsBooks.Forms.Blog.Classes;
using Bau.Controls.Forms;
using Bau.Libraries.LibFeeds.Syndication;
using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data;
using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Transforms;
using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibFeeds.Syndication.Atom.Transforms;
using Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Desktop.Transforms;

namespace Bau.Applications.ComicsBooks.Forms.Blog
{
	/// <summary>
	///		Lector de blogs
	/// </summary>
	public partial class frmBlogReader : WeifenLuo.WinFormsUI.Docking.DockContent, IFormAdmon<DesktopFilesEntry>
	{ // Constantes privadas
			private const string cnstStrJavaScriptSetRead = "SetRead";
			private const string cnstStrJavaScriptSetReadFixed = "SetReadFixed";
			private const string cnstStrJavaScriptSetInteresting = "SetInteresting";
			private const string cnstStrTagItemSeparator = "{##__##}";
		// Variables privadas
			private bool blnLoaded = false, blnLoadingEntries = false;
			private DateTime dtmLastChange = DateTime.Now;
			private BlogReaderFilesCollection objColBlogFiles = new BlogReaderFilesCollection();
			
		public frmBlogReader()
		{ InitializeComponent();
		}
		
		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Inicializa los temporizadores
				tmrMarkRead.Enabled = clsConfiguration.MarkReadPreview;
				tmrMarkRead.Interval = 10000;
				tmrSelectedChanged.Enabled = false;
				tmrStopWindowsOpen.Enabled = false;
			// Elimina los errores del explorador
				wbExplorer.ScriptErrorsSuppressed = true;
				wbExplorer.AllowWebBrowserDrop = false;
			// Carga la colección de blogs
				LoadBlogsCollection(IDData);
			// Indica si se ha cargado correctamente
				blnLoaded = objColBlogFiles.Count > 0;
			// Muestra un mensaje al usuario si no se ha cargado
				if (!blnLoaded)
					Helper.ShowMessage(this, "Aún no existen datos para estos blogs");
				else
					{ // Cambia el título del formulario y de la etiqueta con el nombre del blog
							ToolTipText = TabText = Text = IDData.Text;
							lblBlog.Text = IDData.Text;
						// Muestra los blogs
							ShowBlogs();
					}
		}
		
		/// <summary>
		///		Carga la colección de blogs
		/// </summary>
		private void LoadBlogsCollection(DesktopFilesEntry objDesktopFile)
		{ // Añade el blog del archivo principal
				AddBlog(objDesktopFile);
			// Añade los blogs hijo
				foreach (DesktopFilesEntry objChild in objDesktopFile.Entries)
					LoadBlogsCollection(objChild);
		}
		
		/// <summary>
		///		Añade un blog y sus IDs de borrados a la colección
		/// </summary>
		private void AddBlog(DesktopFilesEntry objDesktopFile)
		{ try
				{ if (!objDesktopFile.IsFolder)
						{	AtomChannel objAtom = FeedMerger.GetAtom(FeedMerger.GetBlogFileName(objDesktopFile.LocalFileName));
							
									if (objAtom != null)
										{ FeedIDs objIDsDeleted = new FeedIDs();
										
												// Carga el archivo de borrados
													objIDsDeleted.Load(FeedMerger.GetBlogFileName(objDesktopFile.LocalFileNameDeleted));
												// Añade los archivos a la colección de blogs del lector
													objColBlogFiles.Add(objAtom, objIDsDeleted, objDesktopFile);
										}
						}
				}
			catch {}
		}

		/// <summary>
		///		Muestra los blogs
		/// </summary>
		private void ShowBlogs()
		{ // Carga la lista de entradas
				LoadListEntries();
			// Carga el texto de las entradas en el Explorer
				LoadExplorerEntries();
		}
				
		/// <summary>
		///		Inicializa la lista de entradas
		/// </summary>
		private void InitListEntries()
		{ // Limpia la lista
				lswEntries.Clear();
			// Inicializa las propiedades
				lswEntries.LargeImageList = clsListImagesUI.Images;
				lswEntries.SmallImageList = clsListImagesUI.Images;
			// Añade las columnas
				lswEntries.AddColumn(500, "Título");
				lswEntries.AddColumn(150, "Fecha", Bau.Controls.List.ListViewExtended.ListViewColumnType.Date);
				lswEntries.AddColumn(150, "Blog");
				lswEntries.AddColumn(150, "Estado");
		}
		
		/// <summary>
		///		Carga la lista de entradas
		/// </summary>
		private void LoadListEntries()
		{ // Comienza la modificación de la lista
				lswEntries.BeginUpdate();
			// Inicializa la lista
				InitListEntries();
			// Añade los elementos de las entradas
				foreach (BlogReaderFile objBlogReader in objColBlogFiles)
					foreach (AtomEntry objEntry in objBlogReader.Channel.Entries)
						{ ListViewItem lsiItem = lswEntries.AddItem(GetKey(objBlogReader.ID, objEntry.ID), 
																															 objEntry.Title.Content);
							bool blnIsRead = IsRead(objEntry);
							bool blnIsInteresting = IsInteresting(objEntry);
						
								// Añade el resto de las columnas
									lsiItem.SubItems.Add(clsFormat.Format(objEntry.DateCreated, true));
									lsiItem.SubItems.Add(objBlogReader.Channel.Title.Content);
									lsiItem.SubItems.Add("No leído");
								// Cambia la presentación del elemento según si se ha leído o no
									UpdateListItem(lsiItem, blnIsRead, blnIsInteresting);
						}
			// Finaliza la modificación de la lista
				lswEntries.EndUpdate();
		}

		/// <summary>
		///		Cambia las propiedades del elemento según si se ha leído o no
		/// </summary>
		private void UpdateListItem(ListViewItem lsiItem, bool blnIsRead, bool blnIsInteresting)
		{	string strIDBlogReader, strIDEntry;
		
				// Obtiene las claves
					ComputeKeys(lsiItem.Tag as string, out strIDBlogReader, out strIDEntry);
				// Cambia el color del texto
					lsiItem.ForeColor = Color.Black;
				// Cambia los datos
					if (blnIsInteresting)
						{ lsiItem.Font = new Font(lsiItem.Font, FontStyle.Italic | FontStyle.Regular);
							lsiItem.ForeColor = Color.Blue;
							lsiItem.ImageIndex = (int) clsListImagesUI.ImagesIndex.HighPriority;
						}
					else if (blnIsRead)
						{ lsiItem.Font = new Font(lsiItem.Font, FontStyle.Regular);
							lsiItem.ImageIndex = (int) clsListImagesUI.ImagesIndex.eMailRead;
						}
					else
						{ lsiItem.Font = new Font(lsiItem.Font, FontStyle.Bold);
							lsiItem.ImageIndex = (int) clsListImagesUI.ImagesIndex.eMailNotRead;
						}
				// Cambia el valor del último elemento
					if (blnIsInteresting)
						lsiItem.SubItems[lsiItem.SubItems.Count - 1].Text = "Marcado";
					else if (blnIsRead)
						lsiItem.SubItems[lsiItem.SubItems.Count - 1].Text = "Leído";
					else
						lsiItem.SubItems[lsiItem.SubItems.Count - 1].Text = "No leído";
				// Cambia la imagen en el explorador
					if (Visible && IsActivated)
						wbExplorer.ExecuteScript("UpdateImageEntry", new object [] { strIDEntry, blnIsRead, blnIsInteresting} );
		}

		/// <summary>
		///		Carga en el explorador la lista de entradas seleccionadas
		/// </summary>
		private void LoadExplorerEntries()
		{ Template objTemplate = new Template();
			string strHTML = "";
		
				// Carga la plantilla
					objTemplate.Load(clsConfiguration.TemplateFeedsFileName);
					if (string.IsNullOrEmpty(objTemplate.Html))
						objTemplate.Load(clsConfiguration.TemplateFeedsFileNameDefault);
				// Si no hay plantilla crea una predeterminada
					if (string.IsNullOrEmpty(objTemplate.Html))
						{ objTemplate.Html = "<html><head></head><body>$Content</body></html>";
							objTemplate.TemplateChannel = "<h1>$Channel</h1>";
							objTemplate.TemplateEntry = "<h2><a href=\"$Link\">$Title</a></h2><div>$Content</div>";
						}
				// Si no hay plantilla, crea una cadena con los datos predeterminados
					strHTML = objTemplate.Html.Replace("$Content", GetHTMLEntries(objTemplate));
				// Carga la cadena de texto en el explorador
					InitExplorer(strHTML);
		}

		/// <summary>
		///		Obtiene el HTML de las entradas
		/// </summary>
		private string GetHTMLEntries(Template objTemplate)
		{	string strHTML = "";
		
				// Crea el HTML de las entradas
					foreach (BlogReaderFile objBlogReader in objColBlogFiles)
						{ bool blnHeaderAdded = false;

								// Añade el HTML con las entradas
									foreach (AtomEntry objEntry in objBlogReader.Channel.Entries)
										if (IsSelected(objEntry) && MustShow(objEntry))
											{ // Añade el HTML con el nombre del canal
													if (!blnHeaderAdded && !string.IsNullOrEmpty(objTemplate.TemplateChannel))
														{ // Añade el nombre del canal
																strHTML += objTemplate.TemplateChannel.Replace("$Channel", objBlogReader.Channel.Title.Content);
															// Indica que se ha añadido el nombre del canal
																blnHeaderAdded = true;
														}
												// Añade el HTML con la entrada
													strHTML += GetHTMLEntry(objEntry, objTemplate.TemplateEntry);
											}
							}
				// Devuelve el HTML de las entradas
					return strHTML;
		}

		/// <summary>
		///		Comprueba si una entrada está seleccionada
		/// </summary>
		private bool IsSelected(AtomEntry objEntry)
		{ bool blnIsSelected = false;
		
				// Comprueba si está seleccionada la entrada
					if (lswEntries.SelectedItems.Count == 0)
						blnIsSelected = true;
					else
						foreach (ListViewItem lsiItem in lswEntries.SelectedItems)
							if (lsiItem.Tag != null && lsiItem.Tag is string)
								{ string strIDBlogReader, strIDEntry;
								
										// Separa las claves
											ComputeKeys(lsiItem.Tag as string, out strIDBlogReader, out strIDEntry);
										// Comprueba si está seleccionada
											if (strIDEntry.Equals(objEntry.ID))
												blnIsSelected = true;
								}
				// Devuelve el valor que indica si está seleccionada
					return blnIsSelected;
		}

		/// <summary>
		///		Indica si se debe mostrar una entrada
		/// </summary>
		private bool MustShow(AtomEntry objEntry)
		{ bool blnIsRead = IsRead(objEntry);
			bool blnIsInteresting = IsInteresting(objEntry);
			
				return (lswEntries.SelectedItems != null && lswEntries.SelectedItems.Count > 0) ||
							 (blnIsRead && !blnIsInteresting && clsConfiguration.ShowRead) ||
							 (!blnIsRead && clsConfiguration.ShowNoRead) ||
							 (blnIsInteresting && clsConfiguration.ShowInteresting);
		}
		
		/// <summary>
		///		Carga el texto de las entradas
		/// </summary>
		private string GetHTMLEntry(AtomEntry objEntry, string strTemplate)
		{ string strHTML;

				// Obtiene el HTML de la entrada
					strHTML = strTemplate;
					strHTML = strHTML.Replace("$IdEntry", objEntry.ID);
					strHTML = strHTML.Replace("$Link", SearchRefLink(objEntry.Links).Href);
					strHTML = strHTML.Replace("$Title", objEntry.Title.Content);
					strHTML = strHTML.Replace("$Content", GetHTML(objEntry.Content.Content));
					if (objEntry.DatePublished.Year < 2000)
						strHTML = strHTML.Replace("$DatePublish", clsFormat.Format(objEntry.DateCreated, true));
					else
						strHTML = strHTML.Replace("$DatePublish", clsFormat.Format(objEntry.DatePublished, true));
				// Cambia los iconos
					if (IsRead(objEntry))
						strHTML = strHTML.Replace("$IconRead", "read.gif");
					else
						strHTML = strHTML.Replace("$IconRead", "unread.gif");
					if (IsInteresting(objEntry))
						strHTML = strHTML.Replace("$IconInteresting", "flag.blue.gif");
					else
						strHTML = strHTML.Replace("$IconInteresting", "flag.clear.gif");
				// Devuelve la cadena HTML
					return strHTML;
		}

		/// <summary>
		///		Obtiene el HTML de una cadena XML codificada
		/// </summary>
		private string GetHTML(string strXML)
		{ string strHTML;
		
				// Asigna la cadena XML
					strHTML = strXML;
				// Quita los caracteres codificados
					strHTML = strHTML.Replace("&lt;", "<");
					strHTML = strHTML.Replace("&gt;", ">");
					strHTML = strHTML.Replace("&quot;", "\"");
					strHTML = strHTML.Replace("&acute;", "á");
					strHTML = strHTML.Replace("&ecute;", "é");
					strHTML = strHTML.Replace("&icute;", "í");
					strHTML = strHTML.Replace("&ocute;", "ó");
					strHTML = strHTML.Replace("&ucute;", "ú");
					strHTML = strHTML.Replace("&amp;", "&");
				// Reemplaza los saltos de línea y tabuladores
					//strHTML = strHTML.Replace("\r\n", "<br>");
					//strHTML = strHTML.Replace("\r", "<br>");
					//strHTML = strHTML.Replace("\n", "<br>");
					strHTML = strHTML.Replace("\t", "&nbsp;&nbsp;");
				// Quita los saltos de línea duplicados
					strHTML = strHTML.Replace("<br> <br>", "<br>");
					strHTML = strHTML.Replace("<br><br>", "<br>");
					strHTML = strHTML.Replace("<br><br>", "<br>");
					strHTML = strHTML.Replace("<br><br>", "<br>");
				// Devuelve la cadena HTML
					return strHTML;
		}
		
		/// <summary>
		///		Busca el vínculo de referencia a una entrada
		/// </summary>
		private AtomLink SearchRefLink(AtomLinksCollection objColLinks)
		{ AtomLinksCollection objColRefLinks = objColLinks.Search(AtomLink.AtomLinkType.Self);
		
				// Si no ha encontrado ningún vínculo de tipo Self busca entre los Alternate
					if (objColRefLinks.Count == 0)
						objColRefLinks = objColLinks.Search(AtomLink.AtomLinkType.Alternate);
				// Devuelve el vínculo (si ha encontrado alguno)
					if (objColRefLinks.Count > 0)
						return objColRefLinks[0];
					else
						return null;
		}
		
		/// <summary>
		///		Inicializa el explorador
		/// </summary>
		private void InitExplorer(string strHTML)
		{ string strFileName = GetFileNameHTML();
		
				// Indica que está cargando
					blnLoadingEntries = true;
				// Graba el archivo
					Libraries.LibHelper.Files.HelperFiles.SaveTextFile(strFileName, strHTML);
				// Inicializa las propiedades
					wbExplorer.AllowWebBrowserDrop = false;
					wbExplorer.ScriptErrorsSuppressed = true;
				// Carga el archivo
					wbExplorer.Url = new Uri(strFileName, UriKind.Absolute);
		}
		
		/// <summary>
		///		Obtiene el nombre del archivo XML
		/// </summary>
		private string GetFileNameHTML()
		{ return System.IO.Path.Combine(clsConfiguration.PathBaseFeedTemplates, "Feeds" + TagDocument + ".html");
		}
		
		/// <summary>
		///		Comprueba si un elemento se ha leído
		/// </summary>
		private bool IsRead(AtomEntry objEntry)
		{ return FeedDesktopHelper.IsRead(objEntry);
		}
		
		/// <summary>
		///		Comprueba si un elemento se ha marcado como interesante
		/// </summary>
		private bool IsInteresting(AtomEntry objEntry)
		{ return FeedDesktopHelper.GetPriority(objEntry) > 0;
		}
		
		/// <summary>
		///		Muestra el menú
		/// </summary>
		private bool ShowMenu()
		{ bool blnShowTop = false, blnShowBottom = false;
		
				// Comprueba si debe mostrar los elementos del menú superior
					blnShowTop |= mnuEntrySetRead.Visible = lswEntries.SelectedItems.Count > 0;
				// Comprueba si debe mostrar los elementos del menú inferior
					blnShowBottom |= mnuEntryDelete.Visible = CanExecuteAction(clsEnums.TypeAction.Remove);
				// Muestra el separador
					mnuEntrySeparator.Visible = blnShowTop && blnShowBottom;
				// Devuelve el valor que indica si se debe mostrar el menú
					return blnShowTop || blnShowBottom;
		}
		
		/// <summary>
		///		Obtiene la clave de un listItem
		/// </summary>
		private string GetKey(string strIDBlogReader, string strIDEntry)
		{ return strIDBlogReader + cnstStrTagItemSeparator + strIDEntry;
		}
		
		/// <summary>
		///		Separa dos claves
		/// </summary>
		private void ComputeKeys(string strID, out string strIDBlogReader, out string strIDEntry)
		{ int intIndex = strID.IndexOf(cnstStrTagItemSeparator);
		
				// Vacía las variables de salida
					strIDBlogReader = "";
					strIDEntry = "";
				// Separa los valores
					if (intIndex > 0)
						{ strIDBlogReader = strID.Substring(0, intIndex);
							strIDEntry = strID.Substring(intIndex + cnstStrTagItemSeparator.Length);
						}
		}
		
		/// <summary>
		///		Obtiene una entrada a partir de un listItem
		/// </summary>
		private AtomEntry GetAtomEntry(ListViewItem lsiItem)
		{	if (lsiItem.Tag != null && lsiItem.Tag is string)
				return GetAtomEntry(lsiItem.Tag as string);
			else
				return null;
		}
		
		/// <summary>
		///		Obtiene una entrada a partir de un ID
		/// </summary>
		private AtomEntry GetAtomEntry(string strID)
		{	string strIDBlogReader, strIDEntry;
		
				// Separa las claves
					if (strID.IndexOf(cnstStrTagItemSeparator) >= 0)
						ComputeKeys(strID, out strIDBlogReader, out strIDEntry);
					else
						strIDEntry = strID;
				// Recorre la colección de canales buscando el elemento
					foreach (BlogReaderFile objBlogReader in objColBlogFiles)
						{ AtomEntry objEntry = objBlogReader.Channel.Entries.Search(strIDEntry);
						
								if (objEntry != null)
									return objEntry;
						}
				// Si ha llegado hasta aquí es porque no ha encontrado nada
					return null;
		}
		
		/// <summary>
		///		Marca las entradas como leídas en la ventana de previsualización
		/// </summary>
		private void MarkEntriesReadPreview()
		{ if (IsActivated)
				{ if (clsConfiguration.MarkReadPreview && 
							DateTime.Now > dtmLastChange.AddSeconds(clsConfiguration.MarkReadInterval) &&
							NeedMarkEntriesRead())
						{ // Marca las entradas seleccionadas como leídas
								MarkEntriesRead(true);
							// Cambia la hora de última modificación
								dtmLastChange = DateTime.Now;
						}
				}
			else
			  dtmLastChange = DateTime.Now;
		}

		/// <summary>
		///		Comprueba si se deben marcar las entradas seleccionadas como leídas
		/// </summary>
		private bool NeedMarkEntriesRead()
		{ // Comprueba si alguna de las entradas seleccionadas está marcada como no leída
				foreach (ListViewItem lsiItem in lswEntries.Items)
					if ((lswEntries.SelectedItems == null || lswEntries.SelectedItems.Count == 0) || lsiItem.Selected)
						{ AtomEntry objEntry = GetAtomEntry(lsiItem);
						
								if (!IsRead(objEntry))
									return true;
						}
			// No se necesita marcar nada como leído
				return false;
		}
		
		/// <summary>
		///		Marca como leídas las entradas seleccionadas
		/// </summary>
		private void MarkEntriesRead(bool blnIsRead)
		{ BlogReaderFilesCollection objColBlogReaderUpdated = new BlogReaderFilesCollection();
		
				// Marca las entradas como leídas
					foreach (ListViewItem lsiItem in lswEntries.Items)
						if (lsiItem.Tag != null && lsiItem.Tag is string &&
								((lswEntries.SelectedItems == null || lswEntries.SelectedItems.Count == 0) ||
								 lsiItem.Selected))
							{	string strIDBlogReader, strIDEntry;
								AtomEntry objEntry;
							
									// Obtiene las claves del elemento
										ComputeKeys(lsiItem.Tag as string, out strIDBlogReader, out strIDEntry);
									// Obtiene la entrada
										objEntry = GetAtomEntry(lsiItem);
									// Marca la entrada como leída
										if (objEntry != null)
											{ // Marca el elemento como no leído
													MarkEntryRead(objEntry, blnIsRead);
												// Añade el blog a la colección de elementos modificados
													objColBlogReaderUpdated.Add(objColBlogFiles.Search(strIDBlogReader));
												// Cambia la marca del listItem
													UpdateListItem(lsiItem, blnIsRead, IsInteresting(objEntry));
											}
							}
				// Realiza las modificaciones
					if (objColBlogReaderUpdated.Count > 0)
						{	// Modifica el número de elementos leídos
								UpdateNumberNotRead();
							// Graba el archivo Atom
								SaveAtom(objColBlogReaderUpdated);
						}
		}
		
		/// <summary>
		///		Marca una entrada como leída o no
		/// </summary>
		private void MarkEntryRead(AtomEntry objEntry, bool blnIsRead)
		{ FeedDesktopHelper.MarkEntryRead(objEntry, blnIsRead);
		}
		
		/// <summary>
		///		Trata una función JavaScript
		/// </summary>
		private void TreatJavaScriptFunction(string strArgument)
		{ AtomEntry objEntry = null;
			bool blnUpdated = true;
		
				// Cambia el estado dependiendo del argumento de la llamada
					if (strArgument.StartsWith(cnstStrJavaScriptSetRead, StringComparison.CurrentCultureIgnoreCase) &&
							!strArgument.StartsWith(cnstStrJavaScriptSetReadFixed, StringComparison.CurrentCultureIgnoreCase))
						{ // Obtiene el objeto Atom
								objEntry = GetAtomEntry(GetIDArgument(cnstStrJavaScriptSetRead, strArgument));
							// Marca el elemento como leído
								if (objEntry != null)
									MarkEntryRead(objEntry, !IsRead(objEntry));
						}
					//else if (strArgument.StartsWith(cnstStrJavaScriptSetReadFixed, StringComparison.CurrentCultureIgnoreCase))
					//  { // Obtiene el objeto Atom
					//      objEntry = GetAtomEntry(GetIDArgument(cnstStrJavaScriptSetReadFixed, strArgument));
					//    // Marca el elemento como leído
					//      if (objEntry != null && !IsRead(objEntry))
					//        MarkEntryRead(objEntry, true);
					//      else
					//        blnUpdated = false;
					//  }
					else if (strArgument.StartsWith(cnstStrJavaScriptSetInteresting, StringComparison.CurrentCultureIgnoreCase))
						{ // Obtiene el elemento
								objEntry = GetAtomEntry(GetIDArgument(cnstStrJavaScriptSetInteresting, strArgument));
							// Cambia la prioridad del elemento
								if (objEntry != null)
									MarkEntryInteresting(objEntry);
						}
				// Actualiza la lista y el árbol y graba el Atom
					if (objEntry != null && blnUpdated)
						{ BlogReaderFile objBlogReader = objColBlogFiles.SearchByIDAtom(objEntry.ID);
						
								// Actualiza la lista
									foreach (ListViewItem lsiItem in lswEntries.Items)
										if (lsiItem.Tag != null && lsiItem.Tag is string)
											{ string strIDBlogReader, strIDEntry;
											
													// Separa las claves
														ComputeKeys(lsiItem.Tag as string, out strIDBlogReader, out strIDEntry);
													// Si es la misma clave modifica los valores
														if (objEntry.ID.Equals(strIDEntry, StringComparison.CurrentCultureIgnoreCase))
															UpdateListItem(lsiItem, IsRead(objEntry), IsInteresting(objEntry));
											}
								// Actualiza el árbol
									UpdateNumberNotRead();
								// Graba el Atom
									SaveAtom(objBlogReader);
						}
		}

		/// <summary>
		///		Obtiene el ID de un argumento de una llamada JavaScript
		/// </summary>
		private string GetIDArgument(string strPrefix, string strArgument)
		{ return strArgument.Substring(strPrefix.Length).Trim();
		}
		
		/// <summary>
		///		Marca / desmarca como interesantes las entradas seleccionadas
		/// </summary>
		private void MarkEntriesInteresting()
		{ BlogReaderFilesCollection objColBlogUpdated = new BlogReaderFilesCollection();
		
				// Marca las entradas seleccionadas como interesantes
					foreach (ListViewItem lsiItem in lswEntries.SelectedItems)
						if (lsiItem.Tag != null && lsiItem.Tag is string)
							{	string strIDBlogReader, strIDEntry;
								AtomEntry objEntry;
								
									// Calcula las claves
										ComputeKeys(lsiItem.Tag as string, out strIDBlogReader, out strIDEntry);
									// Obtiene la entrada
										objEntry = GetAtomEntry(lsiItem);
									// Marca la entrada como interesante
										if (objEntry != null)
											{ // Marca el elemento como interesante o no
													MarkEntryInteresting(objEntry);
												// Cambia la marca del listItem
													UpdateListItem(lsiItem, true, IsInteresting(objEntry));
												// Añade el elemento a la colección de archivos a grabar
													objColBlogUpdated.Add(objColBlogFiles.Search(strIDBlogReader));
											}
							}
				// Graba los archivo Atom
					SaveAtom(objColBlogUpdated);
		}
		
		/// <summary>
		///		Marca una entrada como interesante o no
		/// </summary>
		private void MarkEntryInteresting(AtomEntry objEntry)
		{ if (FeedDesktopHelper.GetPriority(objEntry) > 0)
				FeedDesktopHelper.SetPriority(objEntry, 0);
			else
				{ // Marca el elemento como leído
						FeedDesktopHelper.MarkEntryRead(objEntry, true);
					// Marca el elemento como interesante
						FeedDesktopHelper.SetPriority(objEntry, 1);
				}
		}
		
		/// <summary>
		///		Elimina las entradas seleccionadas
		/// </summary>
		private void DeleteEntries()
		{ if ((lswEntries.SelectedItems.Count > 0 &&
					 Helper.ShowQuestion(this, "¿Realmente desea borrar las entradas?")) ||
					(lswEntries.SelectedItems.Count == 0 &&
					 Helper.ShowQuestion(this, "¿Desea borrar todos los elementos leídos?")))
				{ BlogReaderFilesCollection objColBlogUpdated = new BlogReaderFilesCollection();

						// Recorre la colección de canales borrando los seleccionados
							foreach (BlogReaderFile objBlogReader in objColBlogFiles)
								foreach (ListViewItem lsiItem in lswEntries.Items)
									if (lsiItem.Tag != null && lsiItem.Tag is string)
										{ string strIDBlogReader, strIDEntry;
											AtomEntry objEntry;
											
												// Separa las claves
													ComputeKeys(lsiItem.Tag as string, out strIDBlogReader, out strIDEntry);
												// Obtiene el elemento
													objEntry = objBlogReader.Channel.Entries.Search(strIDEntry);
												// Borra el elemento
													if (objEntry != null && (lsiItem.Selected ||
																									 (IsRead(objEntry) && !IsInteresting(objEntry) &&		
																										lswEntries.SelectedItems.Count == 0)))
														{ // Añade la entrada al archivo de entradas borradas
																objBlogReader.FileIDs.ListIDs.Add(objEntry.ID);
															// Elimina la entrada
																objBlogReader.Channel.Entries.Remove(objEntry.ID);
															// Añade el archivo a la colección de archivos a borrar
																objColBlogUpdated.Add(objBlogReader);
														}
										}
						// Si se ha borrado algo, actualiza
							if (objColBlogUpdated.Count > 0)
								{	// Graba los archivos de elementos borrados
										foreach (BlogReaderFile objBlogReader in objColBlogUpdated)
											objBlogReader.FileIDs.Save();
									// Modifica el número de elementos leídos
										UpdateNumberNotRead();
									// Graba los archivos atom
										SaveAtom(objColBlogUpdated);
									// Muestra los blogs
										ShowBlogs();
								}
					}
		}
		
		/// <summary>
		///		Cuenta el número de elementos no leídos
		/// </summary>
		private int GetNumberNotRead(AtomChannel objAtom)
		{ int intNumberNotRead = 0;
		
				// Cuenta el número de elementos no leídos
					foreach (AtomEntry objEntry in objAtom.Entries)
						if (!IsRead(objEntry))
							intNumberNotRead++;
				// Devuelve el número de elementos no leídos
					return intNumberNotRead;
		}
		
		/// <summary>
		///		Cuenta el número de elementos no leídos y avisa al manager si ha cambiado
		/// </summary>
		private void UpdateNumberNotRead()
		{ foreach (BlogReaderFile objBlogReader in objColBlogFiles)
				Program.BlogsManager.UpdateNumberNotRead(objBlogReader.DesktopFile, GetNumberNotRead(objBlogReader.Channel));
		}

		/// <summary>
		///		Graba los archivos Atom modificados
		/// </summary>
		private void SaveAtom(BlogReaderFilesCollection objColBlogReader)
		{ foreach (BlogReaderFile objBlogReader in objColBlogReader)
				SaveAtom(objBlogReader);
		}

		/// <summary>
		///		Graba los archivos Atom modificados
		/// </summary>
		private void SaveAtom(BlogReaderFile objBlogReader)
		{ AtomWriter.Save(objBlogReader.Channel, FeedMerger.GetBlogFileName(objBlogReader.DesktopFile.LocalFileName));
		}
		
		/// <summary>
		///		Abre el HTML en un explorador externo
		/// </summary>
		private void OpenExplorer()
		{ Libraries.LibHelper.Files.HelperFiles.OpenDocumentShell(GetFileNameHTML());
		}
		
		/// <summary>
		///		Ejecuta una acción desde el menú principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Refresh:
					case clsEnums.TypeAction.ShowBlogItems:
							ShowBlogs();
						break;
					case clsEnums.TypeAction.Save:
							wbExplorer.ShowSaveAsDialog();
						break;
					case clsEnums.TypeAction.Remove:
							DeleteEntries();
						break;
					case clsEnums.TypeAction.OpenExplorer:
							OpenExplorer();
						break;
					case clsEnums.TypeAction.Print:
							wbExplorer.ShowPrintDialog();
						break;
					case clsEnums.TypeAction.PrintPreview:
							wbExplorer.ShowPrintPreviewDialog();
						break;
					case clsEnums.TypeAction.PrintWithDialog:
							wbExplorer.ShowPageSetupDialog();
						break;
				}
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acción
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Print:
					case clsEnums.TypeAction.PrintPreview:
					case clsEnums.TypeAction.PrintWithDialog:
					case clsEnums.TypeAction.Refresh:
					case clsEnums.TypeAction.ShowBlogItems:
					case clsEnums.TypeAction.Save:
						return true;
					case clsEnums.TypeAction.Remove:
						return lswEntries.Items.Count > 0;
					default:
						return false;
				}
		}

		/// <summary>
		///		Rutina de tratamiento del evento Changed de los controles
		/// </summary>
		public void Changed(object sender, EventArgs e)
		{ // ... no hace nada
		}

		public DesktopFilesEntry IDData { get; set; }

		/// <summary>
		///		Identificador del documento
		/// </summary>
		public string TagDocument
		{ get { return "BLOG_" + IDData.ID; }
		}
		
		private void frmBlogReader_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void frmBlogReader_Shown(object sender, EventArgs e)
		{	// Si no se ha cargado, cierra el formulario
				if (!blnLoaded)
					Close();
		}

		private void frmBlogReader_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{ // Desactiva los timers
				tmrMarkRead.Enabled = false;
				tmrSelectedChanged.Enabled = false;
				tmrStopWindowsOpen.Enabled = false;
			// Al cerrar el formulario se borra el archivo intermedio
				Libraries.LibHelper.Files.HelperFiles.KillFile(GetFileNameHTML());
		}

		private void lswEntries_SelectedIndexChanged(object sender, EventArgs e)
		{ if (!tmrSelectedChanged.Enabled)
				{ tmrSelectedChanged.Interval = 1000;
					tmrSelectedChanged.Enabled = true;
				}
		}

		private void mnuEntry_Opening(object sender, CancelEventArgs e)
		{ e.Cancel = !ShowMenu();
		}

		private void mnuEntrySetRead_Click(object sender, EventArgs e)
		{ MarkEntriesRead(true);
		}

		private void mnuEntryDelete_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Remove);
		}

		private void mnuEntrySetNotRead_Click(object sender, EventArgs e)
		{ MarkEntriesRead(false);
		}

		private void mnuEntrySetInteresting_Click(object sender, EventArgs e)
		{ MarkEntriesInteresting();
		}

		private void wbExplorer_ChangeProgress(object sender, Bau.Controls.WebExplorer.WebExplorerProgressEventArgs e)
		{ if (e.Progress == e.Total)
				Program.MainWindow.HideProgressBar();
			else
				Program.MainWindow.ShowProgressBar("Cargando ...", (int) e.Progress, (int) e.Total);
		}

		private void wbExplorer_ChangeNavigationStatus(object sender, Bau.Controls.WebExplorer.WebExplorerNavigationEventArgs e)
		{ if (!blnLoadingEntries &&
					(e.Action == Bau.Controls.WebExplorer.WebExplorerNavigationEventArgs.ExplorerAction.NewWindow ||
						(e.Action == Bau.Controls.WebExplorer.WebExplorerNavigationEventArgs.ExplorerAction.Navigating && 
						 !e.URL.StartsWith("file://", StringComparison.CurrentCultureIgnoreCase))))
				{ Help.frmHelp frmNewHelp = new Help.frmHelp();
				
						// Asigna las propiedades
							frmNewHelp.IDData = e.URL;
						// Abre el explorador
							Program.MainWindow.OpenWindowDocument(frmNewHelp);
						// Cancela la acción
							e.Cancel = true;
				}
			else if (e.Action == Bau.Controls.WebExplorer.WebExplorerNavigationEventArgs.ExplorerAction.Navigated)
				{	tmrStopWindowsOpen.Enabled = false;
					tmrStopWindowsOpen.Interval = 5000;
					tmrStopWindowsOpen.Enabled = true;
				}
		}

		private void wbExplorer_ChangeStatus(object sender, EventArgs e)
		{ Program.MainWindow.ShowPanelStatus(wbExplorer.StatusText);
		}

		private void lswEntries_KeyDown(object sender, KeyEventArgs e)
		{ if (e.KeyCode == Keys.Delete)
				DeleteEntries();
		}

		private void tmrMarkRead_Tick(object sender, EventArgs e)
		{ MarkEntriesReadPreview();
		}

		private void tmrSelectedChanged_Tick(object sender, EventArgs e)
		{	// Desactiva el temporizador
				tmrSelectedChanged.Enabled = false;
			// Carga las entradas del explorador
				LoadExplorerEntries();
			// Indica a la ventana principal que modifique los botones
				Program.MainWindow.RefreshWindow();
		}

		private void tmrStopWindowsOpen_Tick(object sender, EventArgs e)
		{ tmrStopWindowsOpen.Enabled = false;
			blnLoadingEntries = false;
		}

		private void wbExplorer_JavaScriptFunctionCalled(object sender, Bau.Controls.WebExplorer.WebExplorerJavaScriptFunctionEventArgs e)
		{ TreatJavaScriptFunction(e.Argument);
		}
	}
}
