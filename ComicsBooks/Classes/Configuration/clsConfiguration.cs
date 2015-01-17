using System;

namespace Bau.Applications.ComicsBooks.Classes
{
	/// <summary>
	///		Clase de configuración
	/// </summary>
	public class clsConfiguration
	{	
		/// <summary>
		///		Graba la configuración
		/// </summary>
		public static void Save()
		{ Properties.Settings.Default.Save();
		}

		/// <summary>
		///		Obtiene el directorio donde se encuentran las ayudas
		/// </summary>
		public static string PathHelp
		{ get { return Properties.Settings.Default.PathHelp; }
			set { Properties.Settings.Default.PathHelp = value; }
		}
		
		/// <summary>
		///		Directorio base de los datos
		/// </summary>
		public static string PathBaseData
		{ get { return System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data"); }
		}
		
		/// <summary>
		///		Archivo de configuración de los cómics de Web
		/// </summary>
		public static string FileComicsWeb
		{ get 
				{ return System.IO.Path.Combine(PathBaseComicsWeb, "ComicsWeb.xml");
				}
		}
		
		/// <summary>
		///		Directorio base para los cómics de Web
		/// </summary>
		public static string PathBaseComicsWeb
		{ get { return System.IO.Path.Combine(PathBaseData, "Web"); }
		}
		
		/// <summary>
		///		Nombre de archivo de la base de datos
		/// </summary>
		public static string FileNameDataBase
		{ get { return System.IO.Path.Combine(PathBaseData, "DBLibrary.db"); }
		}

		/// <summary>
		///		Directorio donde se almacenan los thumbs
		/// </summary>
		public static string PathThumbs
		{ get { return System.IO.Path.Combine(PathBaseData, "Thumbs"); }
		}		
		
		/// <summary>
		///		Indice del último zoom en el combo
		/// </summary>
		public static int LastZoom
		{ get { return Properties.Settings.Default.LastZoom; }
			set { Properties.Settings.Default.LastZoom = value; }
		}
		
		/// <summary>
		///		Muestra o no las páginas en el formulario de cómics
		/// </summary>
		public static bool ShowPages
		{ get { return Properties.Settings.Default.ShowPages; }
			set { Properties.Settings.Default.ShowPages = value; }
		}
		
		/// <summary>
		///		Muestra o no el thumb en el formulario de cómics
		/// </summary>
		public static bool ShowThumbs
		{ get { return Properties.Settings.Default.ShowThumb; }
			set { Properties.Settings.Default.ShowThumb = value; }
		}
		
		/// <summary>
		///		Ancho de los thumbnails
		/// </summary>
		public static int WidthThumbs
		{ get { return Properties.Settings.Default.WidthThumb; }
			set { Properties.Settings.Default.WidthThumb = value; }
		}
		
		/// <summary>
		///		Ancho del spliter de los thumbnails del cómic
		/// </summary>
		public static int WidthSplitter
		{ get { return Properties.Settings.Default.WidthSplitThumb; }
			set { Properties.Settings.Default.WidthSplitThumb = value; }
		}
		
		/// <summary>
		///		URL donde se encuentra el archivo de anuncios
		/// </summary>
		public static string URLAdvertising
		{ get { return Properties.Settings.Default.URLAdvertising; }
		}
		
		/// <summary>
		///		Tiempo entre anuncios
		/// </summary>
		public static int TimeAdvertising
		{ get { return Properties.Settings.Default.TimeAdvertising; }
		}
		
		/// <summary>
		///		Directorio de datos del usuario
		/// </summary>
		public static string PathUserData
		{ get
				{ if (string.IsNullOrEmpty(Properties.Settings.Default.PathUserData))
						return PathBaseData;
					else
						return Properties.Settings.Default.PathUserData;
				}
			set { Properties.Settings.Default.PathUserData = value; }
		}
		
		/// <summary>
		///		Nombre del archivo OPML
		/// </summary>
		public static string OPMLFileName
		{ get { return System.IO.Path.Combine(PathUserData, "OPML.xml"); }
		}

		/// <summary>
		///		Directorio base para los archivos con los blogs
		/// </summary>
		public static string PathBaseBlogs
		{ get { return System.IO.Path.Combine(PathUserData, "Blogs"); }
		}
		
		/// <summary>
		///		Directorio base para los archivos de plantillas para feeds
		/// </summary>
		public static string PathBaseFeedTemplates
		{ get { return System.IO.Path.Combine(PathBaseData, "BlogTemplates"); }
		}

		/// <summary>
		///		Indica si se deben descargar los blogs automáticamente
		/// </summary>
		public static bool DownloadBlogsAuto
		{ get { return Properties.Settings.Default.DownloadBlogsAuto; }
			set { Properties.Settings.Default.DownloadBlogsAuto = value; }
		}
		
		/// <summary>
		///		Tiempo entre descargas (en minutos)
		/// </summary>
		public static int DownloadInterval
		{ get { return Properties.Settings.Default.TimeDownload; }
			set { Properties.Settings.Default.TimeDownload = value; }
		}
		
		/// <summary>
		///		Indica si se debe marcar un blog como leído al previsualizarlo
		/// </summary>
		public static bool MarkReadPreview
		{ get { return Properties.Settings.Default.MarkReadPreview; }
			set { Properties.Settings.Default.MarkReadPreview = value; }
		}

		/// <summary>
		///		Tiempo en segundos utilizados para marcar como leído en la pantalla de previsualización
		/// </summary>
		public static int MarkReadInterval
		{ get { return Properties.Settings.Default.MarkReadInterval; }
			set { Properties.Settings.Default.MarkReadInterval = value; }
		}

		/// <summary>
		///		Tiempo en días para marcar un blog como "no modificado"
		/// </summary>
		public static int MarkNotUpdatesInterval
		{ get { return Properties.Settings.Default.MarkNotUpdatesInterval; }
			set { Properties.Settings.Default.MarkNotUpdatesInterval = value; }
		}

		/// <summary>
		///		Indica si se debe utilizar un proxy
		/// </summary>
		public static bool UseProxy
		{ get { return Properties.Settings.Default.UseProxy; }
			set { Properties.Settings.Default.UseProxy = value; }
		}
		
		/// <summary>
		///		Dirección o nombre del proxy
		/// </summary>
		public static string ProxyIP
		{ get { return Properties.Settings.Default.ProxyIP; }
			set { Properties.Settings.Default.ProxyIP = value; }
		}
		
		/// <summary>
		///		Puerto del proxy
		/// </summary>
		public static int ProxyPort
		{ get { return Properties.Settings.Default.ProxyPort; }
			set { Properties.Settings.Default.ProxyPort = value; }
		}
		
		/// <summary>
		///		Usuario del proxy
		/// </summary>
		public static string ProxyUser
		{ get { return Properties.Settings.Default.ProxyUser; }
			set { Properties.Settings.Default.ProxyUser = value; }
		}
		
		/// <summary>
		///		Contraseña del proxy
		/// </summary>
		public static string ProxyPassword		
		{ get { return Properties.Settings.Default.ProxyPassword; }
			set { Properties.Settings.Default.ProxyPassword= value; }
		}
		
		/// <summary>
		///		Nombre del archivo de plantilla para los feeds
		/// </summary>
		public static string TemplateFeedsFileName
		{ get { return Properties.Settings.Default.TemplateFeeds; }
			set { Properties.Settings.Default.TemplateFeeds = value; }
		}
		
		/// <summary>
		///		Nombre del archivo de plantilla predeterminado para los feeds
		/// </summary>
		public static string TemplateFeedsFileNameDefault
		{ get { return System.IO.Path.Combine(PathBaseFeedTemplates, "News\\Definition.xml"); }
		}
		
		/// <summary>
		///		Indica si se deben mostrar los elementos leídos
		/// </summary>		
		public static bool ShowRead 
		{ get { return Properties.Settings.Default.ShowEntriesRead; }
			set { Properties.Settings.Default.ShowEntriesRead = value; }
		}
		
		/// <summary>
		///		Indica si se deben mostrar los elementos no leídos
		/// </summary>		
		public static bool ShowNoRead
		{ get { return Properties.Settings.Default.ShowEntriesNoRead; }
			set { Properties.Settings.Default.ShowEntriesNoRead = value; }
		}

		/// <summary>
		///		Indica si se deben mostrar los elementos interesantes
		/// </summary>		
		public static bool ShowInteresting
		{ get { return Properties.Settings.Default.ShowEntriesInteresting; }
			set { Properties.Settings.Default.ShowEntriesInteresting = value; }
		}
	}
}