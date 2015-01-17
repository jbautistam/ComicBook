using System;

namespace Bau.Applications.ComicsBooks.Classes
{
	/// <summary>
	///		Interface que deben suscribir los documentos (ventanas) que se adapten a BauCentral
	/// </summary>
	public interface IPluginDocument
	{ 
		/// <summary>
		///		Rutina a la que se llama cuando se pulsa sobre un bot�n o men� de acci�n
		/// </summary>
		void ExecuteAction(clsEnums.TypeAction intAction);
		
		/// <summary>
		///		Comprueba si puede realizar una acci�n
		/// </summary>
		bool CanExecuteAction(clsEnums.TypeAction intAction);
	}
}
