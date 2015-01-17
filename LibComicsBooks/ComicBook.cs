using System;

using Bau.Libraries.LibComicsBooks.ComicParser;

namespace Bau.Libraries.LibComicsBooks
{
	/// <summary>
	///		Clase con los datos de un cómic
	/// </summary>
	public class ComicBook
	{ // Enumerados públicos
			public enum ComicType
				{ Unknown,
					CBR,
					CBT,
					CBZ,
					Path,
					Image,
					PDF
				}
		// Delegados públicos
			public delegate void ComicActionHandler(object objSender, EventComicArgs evnArgs);
		// Eventos públicos
			public event ComicActionHandler ComicAction;
		
		/// <summary>
		///		Añade el manejador de eventos
		/// </summary>
		private void AddEventsHandler()
		{ if (Comic != null)
				Comic.ComicAction += new ComicActionHandler(objComic_ComicAction);
		}

		/// <summary>
		///		Trata el evento
		/// </summary>
		private void objComic_ComicAction(object objSender, EventComicArgs evnArgs)
		{ RaiseEvent(evnArgs);
		}

		/// <summary>
		///		Lanza un evento
		/// </summary>
		private void RaiseEvent(EventComicArgs evnArgs)
		{ if (ComicAction != null)
				ComicAction(this, evnArgs);
		}
		
		/// <summary>
		///		Lanza el evento de fin
		/// </summary>
		private void RaiseEventEnd()
		{ RaiseEvent(new EventComicArgs(EventComicArgs.ActionType.End, 0, 0));
		}
		
		/// <summary>
		///		Graba un archivo
		/// </summary>
		public void Save(string strFileName, ComicPagesCollection objColPages, Definition.ComicInfo objComicInfo)
		{ ComicBase objNewComic = ComicBase.GetInstance(strFileName);
		
				// Si no se ha encontrado ningún objeto apropiado para la extensión, lo graba como CBZ
					if (objNewComic is ComicPath)
						objNewComic = new ComicCompressed();
				// Añade el manejador de eventos
					objNewComic.ComicAction += new ComicActionHandler(objComic_ComicAction);
				// Graba el archivo
					objNewComic.Save(strFileName, objColPages, objComicInfo);
				// Lanza el evento de fin
					RaiseEventEnd();
		}
		
		/// <summary>
		///		Carga un archivo de cómic
		/// </summary>
		public void Load(string strFileName)
		{ // Si ya existía un cómic, lo limpia
				if (Comic != null)
					{ Comic.ComicAction -= objComic_ComicAction;
						Comic.Clear();
					}
			// Guarda el nombre de archivo
				FileName = strFileName;
			// Obtiene la instancia del cómic
				Comic = ComicBase.GetInstance(FileName);
				Comic.ComicAction += new ComicActionHandler(objComic_ComicAction);
			// Carga el cómic
				Comic.Load(FileName);
				Comic.Pages.Sort();
			// Carga la información del cómic
				Comic.LoadInfo();
			// Lanza el evento
				RaiseEventEnd();
		}
				
		/// <summary>
		///		Descomprime un archivo
		/// </summary>
		public void Uncompress(string strPath, bool blnAtThread)
		{ // Limpia las páginas del comic
				Comic.Clear();
			// Descomprime
				if (blnAtThread)
					{	Helper.ThreadComic objThread = new Helper.ThreadComic(Comic, strPath);
				
						 if (!System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(Helper.ThreadComic.Execute), 
																																objThread))
							throw new Exception("No se puede añadir el hilo a la cola de procesos");
					}
				else
					Comic.Uncompress(strPath);
		}

		/// <summary>
		///		Comprueba si un archivo es un cómic
		/// </summary>
		public static bool IsComic(string strFileName)
		{ return ComicBase.IsComic(strFileName);
		}

		/// <summary>
		///		Obtiene el tipo de cómic de un archivo
		/// </summary>
		public static ComicType GetComicType(string strFileName)
		{ if (ComicCompressed.IsComic(strFileName))
				return ComicType.CBZ;
			else if (ComicImage.IsComic(strFileName))
				return ComicType.Image;
			else if (ComicPath.IsComic(strFileName))
				return ComicType.Path;
			else
				return ComicType.Unknown;
		}
		
		public string FileName { get; set; }
			
		private ComicBase Comic { get; set; }
		
		public Definition.ComicInfo Info
		{ get 
				{ if (Comic == null)
						return null; 
					else
						return Comic.Info;
				}
		}
		
		public ComicPagesCollection Pages
		{ get
				{ if (Comic != null)
						return Comic.Pages;
					else
						return null;
				}
		}
		
		public ComicType Type
		{ get 
				{ if (Comic == null)
						return ComicType.Unknown;
					else
						return Comic.Type;
				}
		}
	}
}
