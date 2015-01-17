using System;

namespace Bau.Applications.ComicsBooks.Classes
{
	/// <summary>
	///		Clase de formateo de valores
	/// </summary>
	internal class clsFormat
	{
		/// <summary>
		///		Formatea un valor doble en una cadena (con cinco decimales)
		/// </summary>
		public static string Format(double dblValue)
		{ if (dblValue == double.NegativeInfinity)
				return "-";
			else
				return string.Format("{0:#,##0.00000}", dblValue);
		}
		
		/// <summary>
		///		Formatea un valor entero en una cadena
		/// </summary>
		public static string Format(int intValue)
		{ if (intValue == int.MinValue)
				return "-";
			else
				return string.Format("{0:#,##0}", intValue);
		}
		
		/// <summary>
		///		Formatea un valor lógico en una cadena (Sí / No)
		/// </summary>
		public static string Format(bool blnValue)
		{ return blnValue ? "Sí" : "No";
		}
		
		/// <summary>
		///		Formatea un valor de fecha y hora
		/// </summary>
		public static string Format(DateTime dtmValue, bool blnWithHours)
		{ if (dtmValue == DateTime.MinValue)
				return "-";
			else if (blnWithHours)
				return string.Format("{0:dd-MM-yyyy HH:mm}", dtmValue);
			else
				return string.Format("{0:dd-MM-yyyy}", dtmValue);
		}
	}
}