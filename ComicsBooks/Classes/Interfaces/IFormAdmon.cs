using System;

namespace Bau.Applications.ComicsBooks.Classes
{
	/// <summary>
	///		Interface que deben suscribir los documentos (ventanas) que muestren datos para su administración 
	/// </summary>
	public interface IFormAdmon <TypeData> : IPluginDocument
	{ 
		/// <summary>
		///		Rutina de tratamiento de eventos a la que se llama cuando se ha modificado un control
		/// </summary>
		void Changed(object sender, EventArgs e);
	
		/// <summary>
		///		ID de los datos del formulario
		/// </summary>
		TypeData IDData { get; set; }
	}
}
