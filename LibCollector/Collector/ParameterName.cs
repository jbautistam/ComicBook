using System;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Nombre de un parámetro
	/// </summary>
	public class ParameterName : BaseCollector
	{ // Constantes privadas
			internal const string cnstStrFileExtension = "pnml";
			internal const string cnstStrXMLTagRoot = "ParameterName";
			private const string cnstStrXMLTagName = "Name";
		// Variables privadas
			private ParameterValuesCollection objColValues;

		public ParameterName(string strName)
		{ Name = strName;
		}
		
		/// <summary>
		///		Carga los datos de un nodo XML
		/// </summary>
		internal void LoadXML(MLNode objXMLNode)
		{ if (objXMLNode.Name == cnstStrXMLTagRoot)
				foreach (MLNode objXMLItem in objXMLNode.Nodes)
					switch (objXMLItem.Name)
						{ case BaseCollector.cnstStrXMLTagID:
									base.ID = objXMLItem.Value;
								break;
							case cnstStrXMLTagName:
									Name = objXMLItem.Value;
								break;
							case ParameterValuesCollection.cnstStrXMLTagRoot:
									Values.LoadXML(objXMLItem);
								break;
						}
		}

		/// <summary>
		///		Graba los datos del parámetro
		/// </summary>
		internal void Save(string strFileName)
		{ MLFile objMLFile = new MLFile();
		
				// Obtiene el XML
					objMLFile.Nodes.Add(GetXML());
				// Graba el archivo
					try
						{	new XMLWriter().Save(objMLFile, strFileName);
						}
					catch {}
		}
		
		/// <summary>
		///		Obtiene el XML del elemento
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrXMLTagRoot);

			// Elementos
				objMLNode.Nodes.Add(BaseCollector.cnstStrXMLTagID, base.ID);
				objMLNode.Nodes.Add(cnstStrXMLTagName, Name);
			// Objetos
				objMLNode.Nodes.Add(Values.GetXML());
			// Cierre
				return objMLNode;
		}
			
		public string Name { get; set; }
		
		public ParameterValuesCollection Values
		{ get 
				{ // Inicializa la colección
						if (objColValues == null)
							objColValues = new ParameterValuesCollection();
					// Devuelve la colección
						return objColValues; 
				}
			set { objColValues = value; }
		}
	}
}
