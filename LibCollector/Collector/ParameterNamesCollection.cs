using System;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Colecci�n de <see cref="ParameterName"/>
	/// </summary>
	public class ParameterNamesCollection : BaseCollectorCollection<ParameterName>
	{ 			
		/// <summary>
		///		A�ade un elemento 
		/// </summary>
		public ParameterName Add(string strName)
		{ return SearchByName(strName);
		}
		
		/// <summary>
		///		Busca un elemento si no lo encuentra, lo a�ade
		/// </summary>
		private ParameterName SearchByName(string strName)
		{ // Recorre la colecci�n buscando el elemento
				foreach (ParameterName objParameter in this)
					if (objParameter.Name.Equals(strName, StringComparison.CurrentCultureIgnoreCase))
						return objParameter;
			// Si ha llegado hasta aqu� es porque no ha encontrado nada (y lo crea)
				ParameterName objNewParameter = new ParameterName(strName);
			
					Add(objNewParameter);
			// Devuelve el par�metro
					return objNewParameter;
		}

		/// <summary>
		///		Carga los nombres de par�metros de un directorio
		/// </summary>
		internal void Load(string strPath)
		{	if (System.IO.Directory.Exists(strPath))
				{	string [] arrStrFileNames = System.IO.Directory.GetFiles(strPath, "*." + ParameterName.cnstStrFileExtension);
				
						foreach (string strFileName in arrStrFileNames)
							LoadParameters(strFileName);
				}
		}
		
		/// <summary>
		///		Carga los nombres de par�metros de un archivo
		/// </summary>
		private void LoadParameters(string strFileName)
		{ try
				{	MLFile objMLFile = new XMLParser().Load(strFileName);

						// Crea los par�metros encontrados en el archivo
							foreach (MLNode objXMLNode in objMLFile.Nodes)
								if (objXMLNode.Name == ParameterName.cnstStrXMLTagRoot)
									{ ParameterName objParameter = new ParameterName(null);
									
											// Carga los datos del par�metro
												objParameter.LoadXML(objXMLNode);
											// A�ade el par�metro a la colecci�n
												Add(objParameter);
									}
				}
			catch {}
		}

		/// <summary>
		///		Graba los elementos de una librer�a
		/// </summary>
		internal void Save(string strPath)
		{ foreach (ParameterName objItem in this)
				objItem.Save(System.IO.Path.Combine(strPath, GetNormalizeName(objItem.Name) + "." + ParameterName.cnstStrFileExtension));
		}	

		/// <summary>
		///		Obtiene un nombre normalizado
		/// </summary>
		private string GetNormalizeName(string strName)
		{ string strChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			string strNormalize = "";
			
				// Recorre la cadena con el nombre y quita los caracteres que no sean correctos
					for (int intIndex = 0; intIndex < strName.Length; intIndex++)
						if (strChars.IndexOf(strName[intIndex]) < 0)
							strNormalize += "_";
						else
							strNormalize += strName[intIndex];
				// Devuelve el nombre normalizado
					return strNormalize;
		}
		
		public ParameterName this[string strName]
		{ get { return SearchByName(strName); }
		}
	}
}
