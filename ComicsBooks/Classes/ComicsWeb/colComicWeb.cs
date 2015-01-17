using System;
using System.Collections.Generic;
using System.Xml;

namespace Bau.Applications.ComicsBooks.Classes.ComicWeb
{
	/// <summary>
	///		Colección de <see cref="clsComicWeb"/>
	/// </summary>
	public class colComicWeb : List<clsComicWeb>
	{
		/// <summary>
		///		Carga la colección de cómics de un archivo
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
									{ // Crea un nuevo objeto para almacenar los datos del cómic
											objComic = new clsComicWeb();
										// Lee los valores del cómic
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
										// Añade el cómic a la colección
											Add(objComic);
									}
		}

		/// <summary>
		///		Busca un cómic en la colección a partir de su ID
		/// </summary>
		internal clsComicWeb SearchByID(string strID)
		{ // Busca el cómic en la colección
				foreach (clsComicWeb objComic in this)
					if (objComic.ID.Equals(strID, StringComparison.CurrentCultureIgnoreCase))
						return objComic;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}
	}
}
