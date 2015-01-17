using System;

namespace Bau.Applications.ComicsBooks.Classes.ComicWeb
{
	/// <summary>
	///		Clase para almacenamiento de los datos de los cómics que se descargan de la Web
	/// </summary>
	public class clsComicWeb
	{ // Variables locales
			private string strID, strName, strWeb;
			private string strWebPath, strLocalPath;
			private string strExtension;
		
		/// <summary>
		///		Obtiene el nombre del archivo en la Web
		/// http://images.ucomics.com/comics/tmntf/2006/tmntf060426.gif
		/// http://images.ucomics.com/comics/crbc/2006/crbc060426.gif
		/// </summary>
		public string GetWebFileName(DateTime dtmDate)
		{ return Web + "/" + WebPath + "/" + dtmDate.Year + "/" + 
						 WebPath + string.Format("{0:yyMMdd}", dtmDate) + "." + Extension;
		}
		
		/// <summary>
		///		Elimina el último carácter de una cadena si coincide con el pasado como parámetro
		/// </summary>
		private string DropLastCharacter(string strGeneral, string strChar)
		{ // Si termina con el carácter pasado como parámetro, lo elimina
				if (strGeneral.EndsWith(strChar))
					strGeneral = strGeneral.Substring(0, strGeneral.Length - 1);
			// Devuelve la cadena cortada
				return strGeneral;
		}
		
		public string ID
		{ get 
				{ // Crea el ID si no lo tenía
						if (string.IsNullOrEmpty(strID))
							strID = Guid.NewGuid().ToString();
					// Devuelve el ID
						return strID;
				}
			set { strID = value; }
		}
		
		public string Name
		{ get { return strName; }
			set { strName = value.Trim(); }
		}
		
		public string Web
		{ get { return strWeb; }
			set { strWeb = DropLastCharacter(value.Trim(), "/"); }
		}
		
		public string WebPath
		{ get { return strWebPath; }
			set { strWebPath = DropLastCharacter(value.Trim(), "/"); }
		}
		
		public string LocalPath
		{ get { return strLocalPath; }
			set { strLocalPath = DropLastCharacter(value.Trim(), "\\"); }
		}
		
		public string Extension
		{ get { return strExtension; }
			set { strExtension = value.Trim(); }
		}
	}
}
