using System;
using System.Collections.Generic;
using System.Xml;

namespace Bau.Applications.ComicsBooks.Classes.ComicWeb
{
	/// <summary>
	///		Colecci�n de <see cref="clsComicWeb"/>
	/// </summary>
	public class colComicWeb : List<clsComicWeb>
	{
		/// <summary>
		///		Carga la colecci�n de c�mics de un archivo
		/// </summary>
		public void Load(string strFileName)
		{ XmlDocument objXMLDocument = new XmlDocument();
			clsComicWeb objComic;
		
				// Carga el documento
					objXMLDocument.Load(strFileName);
				// Recorre el documento buscando la cabecera
					foreach (XmlNode objXMLComicsWeb in objXMLDocument.ChildNodes)
						if (objXMLComicsWeb.Name == "ComicsWeb")
							foreach (XmlNode objXMLComic in objXMLComicsWeb.ChildNodes)
								if (objXMLComic.Name == "Comic")
									{ // Crea un nuevo objeto para almacenar los datos del c�mic
											objComic = new clsComicWeb();
										// Lee los valores del c�mic
											foreach (XmlNode objXMLNode in objXMLComic.ChildNodes)
												switch (objXMLNode.Name)
													{ case "Name":
																objComic.Name = objXMLNode.InnerText;
															break;
														case "Web":
																objComic.Web = objXMLNode.InnerText;
															break;
														case "WebPath":
																objComic.WebPath = objXMLNode.InnerText;
															break;
														case "LocalPath":
																objComic.LocalPath = objXMLNode.InnerText;
															break;
														case "Extension":
																objComic.Extension = objXMLNode.InnerText;
															break;
													}
										// A�ade el c�mic a la colecci�n
											Add(objComic);
									}
		}

		/// <summary>
		///		Busca un c�mic en la colecci�n a partir de su ID
		/// </summary>
		internal clsComicWeb SearchByID(string strID)
		{ // Busca el c�mic en la colecci�n
				foreach (clsComicWeb objComic in this)
					if (objComic.ID.Equals(strID, StringComparison.CurrentCultureIgnoreCase))
						return objComic;
			// Si ha llegado hasta aqu� es porque no ha encontrado nada
				return null;
		}
	}
}
