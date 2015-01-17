using System;

namespace Bau.Libraries.LibComicsBooks.ComicParser
{
	/// <summary>
	///		Clase base para los int�rpretes de c�mics
	/// </summary>
	internal abstract class ComicBase : IDisposable
	{ // Eventos p�blicos
			internal event ComicBook.ComicActionHandler ComicAction;
			
		public ComicBase()
		{ Pages = new ComicPagesCollection();
			Info = new Definition.ComicInfo();
		}
		
		/// <summary>
		///		Obtiene una instancia del lector de c�mics
		/// </summary>
		internal static ComicBase GetInstance(string strFileName)
		{ if (ComicCompressed.CheckIsComic(strFileName))
				return new ComicCompressed();
			else if (ComicImage.CheckIsComic(strFileName))
				return new ComicImage();
			else if (ComicPath.CheckIsComic(strFileName))
				return new ComicPath();
			else if (ComicPDF.CheckIsComic(strFileName))
				return new ComicPDF();
			else
				throw new Exception("Tipo desconocido");
		}
		
		/// <summary>
		///		Carga el c�mic
		/// </summary>
		internal abstract void Load(string strFileName);

		/// <summary>
		///		Descomprime el archivo
		/// </summary>
		public abstract void Uncompress(string strPath);
		
		/// <summary>
		///		Rutina de grabaci�n de archivos
		/// </summary>
		internal virtual void Save(string strFileName, ComicPagesCollection objColPages, Definition.ComicInfo objComicInfo)
		{
		}

		/// <summary>
		///		Carga la informaci�n del c�mic
		/// </summary>
		internal abstract void LoadInfo();
		
		/// <summary>
		///		Limpia las colecciones
		/// </summary>
		public abstract void Clear();		
		
		/// <summary>
		///		Lanza un evento
		/// </summary>
		protected void RaiseEvent(EventComicArgs.ActionType intAction, int intActual, int intTotal)
		{ if (ComicAction != null)
				ComicAction(this, new EventComicArgs(intAction, intActual, intTotal));
		}

		/// <summary>
		///		Lanza un evento de error
		/// </summary>
		internal void RaiseEventError(string strMessage)
		{ if (ComicAction != null)
				ComicAction(this, new EventComicArgs(EventComicArgs.ActionType.Error, 0, 0, strMessage));
		}

		/// <summary>
		///		Comprueba si un archivo corresponde a un tipo de c�mic
		/// </summary>
		internal static bool IsComic(string strFileName)
		{ return ComicImage.CheckIsComic(strFileName) || ComicCompressed.CheckIsComic(strFileName) ||
						 ComicPath.CheckIsComic(strFileName) || ComicPDF.CheckIsComic(strFileName);
		}

		/// <summary>
		///		Comprueba si un archivo es una imagen (o al menos tiene extensi�n de imagen)
		/// </summary>
		protected bool IsImage(string strFileName)
		{ return ComicImage.CheckIsComic(strFileName);
		}

		/// <summary>
		///		Comprueba si un archivo es de un tipo
		/// </summary>
		internal static bool IsFileType(string strFileName, string [] arrStrMask)
		{ // Recorre las cadenas comprobando si la extensi�n del archivo es la de un c�mic
				foreach (string strMask in arrStrMask)
					if (strFileName.EndsWith(strMask, StringComparison.CurrentCultureIgnoreCase))
						return true;
			// Si ha llegado hasta aqu� es porque no es un c�mic
				return false;
		}

		/// <summary>
		///		Normaliza un nombre de archivo
		/// </summary>
		protected string NormalizeFileName(string strFileName)
		{ string strCharsTarget = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz_0123456789-.";
			string strFileTarget = "";
			
				// Cambia los caracteres extra�os
					foreach (char chrChar in strFileName)
						if (strCharsTarget.IndexOf(chrChar) >= 0)
							strFileTarget += chrChar;
						else
							strFileTarget += "_";
				// Devuelve el nombre de archivo
					return strFileTarget;
		}

		/// <summary>
		///		Nombre de archivo
		/// </summary>
		protected string FileName { get; set; }
		
		/// <summary>
		///		P�ginas
		/// </summary>
		public ComicPagesCollection Pages { get; set; }

		/// <summary>
		///		Informaci�n del c�mic
		/// </summary>
		public Definition.ComicInfo Info { get; private set; }
		
		/// <summary>
		///		Tipo de c�mic
		/// </summary>
		public abstract ComicBook.ComicType Type { get; }
		
		/// <summary>
		///		Libera la memoria
		/// </summary>
		public void Dispose() 
		{	Dispose(true);
			GC.SuppressFinalize(this);
		}
	
		/// <summary>
		///		Libera la memoria
		/// </summary>
		private void Dispose(bool blnDispose) 
		{	if (blnDispose && Pages != null) 
				Clear();
		}

	  ~ComicBase() 
	  {	Dispose(false);
		}
	}
}
