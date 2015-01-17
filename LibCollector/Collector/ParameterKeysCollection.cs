using System;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Colecci�n de <see cref="ParameterKey"/>
	/// </summary>
	public class ParameterKeysCollection : BaseCollectorCollection<ParameterKey>
	{ // Constantes privadas
			internal const string cnstStrXMLTagRoot = "ParameterKeys";
			
		/// <summary>
		///		Carga las claves a partir del XML
		/// </summary>
		internal void LoadXML(MLNode objXMLNode)
		{ if (objXMLNode.Name == cnstStrXMLTagRoot)
				foreach (MLNode objXMLItem in objXMLNode.Nodes)
					if (objXMLItem.Name == ParameterKey.cnstStrXMLTagRoot)
						{ ParameterKey objKey = new ParameterKey(null, null);
						
								// Carga el XML
									objKey.LoadXML(objXMLItem);
								// A�ade el objeto a la colecci�n
									Add(objKey);
						}
		}
			
		/// <summary>
		///		Obtiene el XML de la colecci�n
		/// </summary>
		internal MLNode GetXML()
		{ MLNode objMLNode = new MLNode(cnstStrXMLTagRoot);

				// Elementos
					foreach (ParameterKey objKey in this)
						objMLNode.Nodes.Add(objKey.GetXML());
				// Fin
					return objMLNode;
		}

		/// <summary>
		///		Comprueba si existe una clave
		/// </summary>
		internal bool Exists(string strIDParameterName, string strIDParameterValue)
		{ // Comprueba si existe el par de claves en la colecci�n
				foreach (ParameterKey objKey in this)
					if (objKey.IDParameterName.Equals(strIDParameterName, StringComparison.CurrentCultureIgnoreCase) &&
							objKey.IDParameterValue.Equals(strIDParameterValue, StringComparison.CurrentCultureIgnoreCase))
						return true;
			// Si ha llegado aqu� es porque no ha encontrado nada
				return false;
		}

		/// <summary>
		///		Comprueba si existe un nombre
		/// </summary>
		internal bool Exists(string strIDParameterName)
		{ // Comprueba si existe el nombre
				foreach (ParameterKey objKey in this)
					if (objKey.IDParameterName.Equals(strIDParameterName, StringComparison.CurrentCultureIgnoreCase))
						return true;
			// Si ha llegado aqu� es porque no ha encontrado nada
				return false;
		}

		/// <summary>
		///		Obtiene la colecci�n de claves para el ID del nombre del par�metro
		/// </summary>
		public ParameterKeysCollection SearchByParameterNameID(string strIDParameterName)
		{ ParameterKeysCollection objColKeys = new ParameterKeysCollection();
		
				// Recorre la colecci�n rellenando la colecci�n de salida
					foreach (ParameterKey objKey in this)
						if (objKey.IDParameterName.Equals(strIDParameterName, StringComparison.CurrentCultureIgnoreCase))
							objColKeys.Add(objKey);
				// Devuelve la colecci�n
					return objColKeys;
		}
	}
}
