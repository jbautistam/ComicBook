using System;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Controls.WebExplorer.Common
{
	/// <summary>
	///		Variables globales para los controles
	/// </summary>
	public static class Globals
	{ // Constantes privadas
			private static string cnstStrFileLastLinks = "LastLinks.xml";
		// Variables privadas
			private static LinksCollection objColLastLinks = null;
		
		/// <summary>
		///		Carga los vínculos
		/// </summary>
		private static void Load()
		{ if (System.IO.File.Exists(GetFileNameLastLinks()))
				{ MLFile objFile = new XMLParser(false).Load(GetFileNameLastLinks());
				
						foreach (MLNode objMLNode in objFile.Nodes)
							if (objMLNode.Name == LinksCollection.cnstStrTagRoot)
								LastLinks.Load(objMLNode);
				}
		}
		
		/// <summary>
		///		Graba el vínculo
		/// </summary>
		private static void Save()
		{ MLFile objMLFile = new MLFile();
		
				// Añade los nodos
					objMLFile.Nodes.Add(LastLinks.GetXML());		
				// Graba el archivo
					new MLSerializer().Save(MLSerializer.SerializerType.XML, objMLFile, GetFileNameLastLinks());
		}
		
		/// <summary>
		///		Obtiene el nombre de archivo donde se guardan los últimos vínculos
		/// </summary>
		private static string GetFileNameLastLinks()
		{ return System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
																		cnstStrFileLastLinks);
		}
		
		/// <summary>
		///		Realiza las acciones de añadir un vínculo y grabación
		/// </summary>
		public static void AddLink(string strURL)
		{ // Quita el último vínculo
				if (LastLinks.Count > 100)
					LastLinks.RemoveAt(0);
			// Añade el vínculo
				LastLinks.Add(strURL);
			// Guarda el archivo
				Save();
		}
		
		/// <summary>
		///		Ultimos vínculos
		/// </summary>
		public static LinksCollection LastLinks
		{ get
				{ // Crea la colección si no estaba en memoria
						if (objColLastLinks == null)
							{ // Crea la colección
									objColLastLinks = new LinksCollection();
								// Carga los vínculos
									Load();
							}
					// Devuelve la colección
						return objColLastLinks;
				}
		}
	}
}
