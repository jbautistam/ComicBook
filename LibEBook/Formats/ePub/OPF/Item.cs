using System;

namespace Bau.Libraries.LibEBook.Formats.ePub.OPF
{
	/// <summary>
	///		Elemento de un libro (página, archivo de estilo, imagen ...)
	/// </summary>
	public class Item : Base.eBookBase
	{ // Variables privadas
			private string strURL;
			
		/// <summary>
		///		URL del archivo
		/// </summary>
		public string	URL 
		{ get { return strURL; } 
			set 
				{ // Asigna la cadena
						strURL = value;
					// Reemplaza las barras
						if (!string.IsNullOrEmpty(strURL))
							strURL = strURL.Replace('/', '\\');
				}
		}
		
		/// <summary>
		///		Tipo del archivo
		/// </summary>
		public string	MediaType { get; set; }
	}
}
