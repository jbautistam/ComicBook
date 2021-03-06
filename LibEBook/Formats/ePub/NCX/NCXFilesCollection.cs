﻿using System;

namespace Bau.Libraries.LibEBook.Formats.ePub.NCX
{
	/// <summary>
	///		Colección de <see cref="NCXFile"/>
	/// </summary>
	public class NCXFilesCollection : Base.eBookBaseCollection<NCXFile>
	{
		/// <summary>
		///		Comprueba si hay puntos de navegación en la tabla de contenidos
		/// </summary>
		public bool ExistsNavPoints()
		{ // Comprueba si alguno de los archivos tiene puntos de navegación
				foreach (NCXFile objFile in this)	
					if (objFile.Pages.Count > 0)
						return true;
			// Si ha llegado hasta aquí es porque no hay puntos de navegación
				return false;
		}
	}
}
