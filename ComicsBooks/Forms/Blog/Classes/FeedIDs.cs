using System;
using System.Collections.Generic;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Applications.ComicsBooks.Forms.Blog.Classes
{
	/// <summary>
	///		IDs eliminados
	/// </summary>
	public class FeedIDs
	{ // Constantes privadas
			private const int cnstIntMaxIDs = 800;
			private const string cnstStrTagRoot = "IDs";
			private const string cnstStrTagID = "ID";
		// Variables privadas 
			private string strFileName = null;
			
		public FeedIDs()
		{ ListIDs = new List<string>();
		}
		
		/// <summary>
		///		Carga del archivo los IDs
		/// </summary>
		public void Load(string strFileName)
		{ // Guarda el nombre de archivo
				this.strFileName = strFileName;
			// Carga los datos
				if (System.IO.File.Exists(strFileName))
					{ MLFile objFile = new XMLParser().Load(strFileName);

							foreach (MLNode objNode in objFile.Nodes)
								if (objNode.Name == cnstStrTagRoot)
									foreach (MLNode objChild in objNode.Nodes)
										if (objChild.Name == cnstStrTagID)
											ListIDs.Add(objChild.Value);
					}
		}
		
		/// <summary>
		///		Graba los IDs
		/// </summary>
		public void Save()
		{ MLFile objFile = new MLFile();
			MLNode objNode = objFile.Nodes.Add(cnstStrTagRoot);
			
				// Elimina los sobrantes
					while (ListIDs.Count > cnstIntMaxIDs)
						ListIDs.RemoveAt(0);
				// Asigna los IDs
					foreach (string strID in ListIDs)
						objNode.Nodes.Add(cnstStrTagID, strID);
				// Graba el archivo
					new Bau.Libraries.LibMarkupLanguage.Services.XML.XMLWriter().Save(objFile, strFileName);
		}
		
		/// <summary>
		///		Lista de IDs
		/// </summary>
		public List<string> ListIDs { get; private set; }
	}
}
