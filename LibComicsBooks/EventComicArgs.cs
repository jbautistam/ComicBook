using System;

namespace Bau.Libraries.LibComicsBooks
{
	/// <summary>
	///		Definición de eventos
	/// </summary>
	public class EventComicArgs
	{ // Enumerados públicos
			public enum ActionType
				{ Unknown,
					Read,
					Compress,
					Error,
					Uncompress,
					End
				}
			
		public EventComicArgs(ActionType intAction, int intActual, int intTotal) : this(intAction, intActual, intTotal, "") {}

		public EventComicArgs(ActionType intAction, int intActual, int intTotal, string strMessage)
		{ Action = intAction;
			Actual = intActual;
			Total = intTotal;
			Message = strMessage;
		}
		
		/// <summary>
		///		Tipo de acción
		/// </summary>
		public ActionType Action { get; set; }

		/// <summary>
		///		Página actual
		/// </summary>
		public int Actual { get; set; }

		/// <summary>
		///		Número total de páginas
		/// </summary>
		public int Total { get; set; }

		/// <summary>
		///		Mensaje
		/// </summary>
		public string Message { get; set; }
	}
}
