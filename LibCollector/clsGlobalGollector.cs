using System;

namespace Bau.Libraries.LibCollector
{
	/// <summary>
	///		Clase de configuraci�n de la librer�a de laboratorio
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
