using System;

namespace Bau.Libraries.LibCollector
{
	/// <summary>
	///		Clase base para las clases de laboratorio
	/// </summary>
	public abstract class BaseCollector
	{ // Constantes privadas
			internal const string cnstStrXMLTagID = "ID";
		
		public BaseCollector()
		{ ID = Guid.NewGuid().ToString();
		}
		
		public string ID { get; set; }
		
		public static string StringNull
		{	get { return string.Empty; }
		}

		public static int IntNull
		{	get { return int.MinValue; }
		}

		public static double DoubleNull
		{	get { return double.MinValue; }
		}

		public static DateTime DateNull
		{	get { return new DateTime(1900, 1, 1); }
		}

		public static bool BoolNull
		{	get { return false; }
		}		
	}
}
