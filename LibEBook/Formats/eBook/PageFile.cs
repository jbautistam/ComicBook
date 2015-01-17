using System;

namespace Bau.Libraries.LibEBook.Formats.eBook
{
	/// <summary>
	///		Archivo del libro
	/// </summary>
	public class PageFile : Base.eBookBase
	{
		public PageFile() : this(null, null, null, null) {}
		
		public PageFile(string strID, string strName, string strFileName, string strMediaType)
		{ ID = strID;
			Name = strName;
			FileName = strFileName;
			MediaType = strMediaType;
		}
		
		/// <summary>
		///		Nombre de la página
		/// </summary>
		public string Name { get; set; }
		
		/// <summary>
		///		Nombre del archivo
		/// </summary>
		public string FileName { get; set; }
		
		/// <summary>
		///		Tipo de archivo
		/// </summary>
		public string MediaType { get; set; }
	}
}
