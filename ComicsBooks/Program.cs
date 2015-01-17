using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Bau.Applications.ComicsBooks.Classes;
using Bau.Applications.ComicsBooks.Forms;

using Bau.Controls.Forms;

namespace Bau.Applications.ComicsBooks
{
	/// <summary>
	///		Clase global con los datos del programa
	/// </summary>
	static class Program
	{	// Variables privadas
			private static frmMain frmNewMain;
			private static colDockedForms objColDockedForms = new colDockedForms();
			private static Classes.ComicFiles.colComicLastOpenFiles objColLastFiles = new Classes.ComicFiles.colComicLastOpenFiles();
			private static Classes.ComicFiles.colComicBookmarks objColBookmarks = new Classes.ComicFiles.colComicBookmarks();
			private static Classes.ComicFiles.clsComicLibrary objLibrary = new Classes.ComicFiles.clsComicLibrary();
			private static Classes.ComicWeb.colComicWeb objColComicsWeb = new Classes.ComicWeb.colComicWeb();
			private static Forms.Blog.Classes.OPMLManager objBlogManager;

			
		/// <summary>
		///		Punto de entrada a la aplicación
		/// </summary>
		[STAThread]
		private static void Main(string [] arrStrFileNames)
		{	// Captura las excepciones de aplicación
				//Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
			// Asigna las propiedades de la aplicación
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
			// Genera el formulario
				frmNewMain = new frmMain();
			// Pasa los archivos pasados desde Windows al formulario principal
				frmNewMain.FileNames = arrStrFileNames;
			// Abre el formulario
				Application.Run(frmNewMain);
		}

		/// <summary>
		///		Inserta un mensaje en el log
		/// </summary>
		public static void Log(string strMessage)
		{ // Bau.Libraries.Helper.clsHelperLog.Add("", strMessage);
		}
		
		/// <summary>
		///		Muestra un mensaje en la barra de tareas
		/// </summary>
		public static void ShowTaskBarMessage(string strMessage)
		{ Bau.Controls.TaskbarNotifier.TaskbarNotifier frmNewTaskBar = new Bau.Controls.TaskbarNotifier.TaskbarNotifier();
		
				// Cambia la imagen de fondo
					frmNewTaskBar.SetBackgroundBitmap(Properties.Resources.SkinNotify, System.Drawing.Color.Magenta);
				// Muestra el formulario
					frmNewTaskBar.Show("Proyectos", strMessage, 1000, 10000, 1000);
		}

		/// <summary>
		///		Obtiene el directorio donde se dejan los archivos temporales de la aplicación
		/// </summary>
		public static string GetTempPath()
		{ return System.IO.Path.Combine(Application.StartupPath, "Temp");
		}
		
		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{	Helper.ShowError(null, "Excepción no controlada", e.Exception);
		}
			
		internal static frmMain MainWindow
		{ get { return frmNewMain; }
		}
		
		public static colDockedForms DockedForms
		{ get { return objColDockedForms; }
		}
		
		public static Classes.ComicFiles.colComicLastOpenFiles LastFiles
		{ get { return objColLastFiles; }
		}
		
		public static Classes.ComicFiles.colComicBookmarks Bookmarks
		{ get { return objColBookmarks; }
		}
		
		public static Classes.ComicFiles.clsComicLibrary ComicsLibrary
		{ get { return objLibrary; }
		}
		
		public static Classes.ComicWeb.colComicWeb ComicsWeb
		{ get { return objColComicsWeb; }
		}
		
		/// <summary>
		///		Manager de los archivos de blogs
		/// </summary>
		public static Forms.Blog.Classes.OPMLManager BlogsManager
		{ get
				{ // Obtiene el objeto si no existía
						if (objBlogManager == null)
							objBlogManager = new Forms.Blog.Classes.OPMLManager();
					// Devuelve el objeto
						return objBlogManager;
				}
		}
	}
}