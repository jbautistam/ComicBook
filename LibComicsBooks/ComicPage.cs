using System;

namespace Bau.Libraries.LibComicsBooks
{
	/// <summary>
	///		Clase con los datos de una p�gina
	/// </summary>
	public class ComicPage : IComparable<ComicPage>
	{ 	
		public ComicPage(string strFileName)
		{ FileName = strFileName;
			MarkAsDeleted = false;
			Uncompressed = false;
		}
		
		/// <summary>
		///		Nombre del archivo de la p�gina
		/// </summary>
		public string FileName { get; set; }
		
		/// <summary>
		///		Indica si est� marcado como borrado
		/// </summary>
		public bool MarkAsDeleted { get; set; }
		
		/// <summary>
		///		Indica si est� descomprimido 
		/// </summary>
		public bool Uncompressed { get; set; }
		
		/// <summary>
		///		Implementa la interface IComparable
		/// </summary>
		public int CompareTo(ComicPage objPage)
		{ return FileName.CompareTo(objPage.FileName);
		}
	}
}
