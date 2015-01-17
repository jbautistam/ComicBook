using System;

namespace Bau.Libraries.LibEBook.Formats.ePub.Container
{
	/// <summary>
	///		Datos de un elemento RootFile de un archivo contenedor
	/// </summary>
	public class RootFile : Base.eBookBase
	{ // Variables privadas
			private string strURL;
		
		public RootFile()
		{ Packages = new OPF.OPFPackagesCollection();
		}	
		
		/// <summary>
		///		Tipo de medio
		/// </summary>
		public string MediaType { get; set; }
		
		/// <summary>
		///		Nombre de archivo
		/// </summary>
		public string URL
		{ get { return strURL; }
			set
				{ // Asigna el valor
						strURL = value;
					// Quita las barras
						if (!string.IsNullOrEmpty(strURL))
							strURL = strURL.Replace('/', '\\');
				}
		}
		
		/// <summary>
		///		Paquetes con los archivos
		/// </summary>
		public OPF.OPFPackagesCollection Packages { get; internal set; }
	}
}
