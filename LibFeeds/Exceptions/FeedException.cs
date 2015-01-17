using System;

namespace Bau.Libraries.LibFeeds.Exceptions
{
	/// <summary>
	///		Clase de excepción
	/// </summary>
	public class FeedException : Exception
	{	// Enumerados
			public enum ExceptionType
				{ DataNotRecognized
				}
		// Variables privadas
			private ExceptionType intType;
			
		public FeedException(ExceptionType intType, string strMessage) : base(strMessage)
		{ this.intType = intType;
		}
		
		public ExceptionType Type
		{ get { return intType; }
		}
	}
}