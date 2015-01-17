using System;

namespace Bau.Libraries.LibCollector
{
	/// <summary>
	///		Clase de configuración de la librería de laboratorio
	/// </summary>
	public static class clsGlobalCollector
	{ // Variables privadas
			private static string strPath = null;
			
		public static string PathBase
		{ get { return strPath; }
			set { strPath = value; }
		}
	}
}
