using System;

namespace Bau.Applications.ComicsBooks.Classes
{
	/// <summary>
	///		Interface que deben suscribir los documentos (ventanas) que se adapten a BauCentral
	/// </summary>
	public interface IPluginDocument
	{ 
		/// <summary>
		///		Rutina a la que se llama cuando se pulsa sobre un botón o menú de acción
		/// </summary>
		void ExecuteAction(clsEnums.TypeAction intAction);
		
		/// <summary>
		///		Comprueba si puede realizar una acción
		/// </summary>
		bool CanExecuteAction(clsEnums.TypeAction intAction);
	}
}
