using System;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Libraries.LibCollector.Collector
{
	/// <summary>
	///		Colección de <see cref="ParameterName"/>
	/// </summary>
	public class ParameterNamesCollection : BaseCollectorCollection<ParameterName>
	{ 			
		/// <summary>
		///		Añade un elemento 
		/// </summary>
		public ParameterName Add(string strName)
		{ return SearchByName(strName);
		}
		
		/// <summary>
		///		Busca un elemento si no lo encuentra, lo añade
		/// </summary>
		private ParameterName SearchByName(string strName)
		{ // Recorre la colección buscando el elemento
				foreach (ParameterName objParameter in this)
					if (objParameter.Name.Equals(strName, StringComparison.CurrentCultureIgnoreCase))
						return objParameter;
			// Si ha llegado hasta aquí es porque no ha encontrado nada (y lo crea)
				ParameterName objNewParameter = new ParameterName(strName);
			
					Add(objNewParameter);
			// Devuelve el parámetro
					return objNewParameter;
		}

		/// <summary>
		///		Carga los nombres de parámetros de un directorio
		/// </summary>
		internal void Load(string strPath)
		{	if (System.IO.Directory.Exists(strPath))
				{	string [] arrStrFileNames = System.IO.Directory.GetFiles(strPath, "*." + ParameterName.cnstStrFileExtension);
				
						foreach (string strFileName in arrStrFileNames)
							LoadParameters(strFileName);
				}
		}
		
		/// <summary>
		///		Carga los nombres de parámetros de un archivo
		/// </summary>
		private void LoadParameters(string strFileName)
		{ try
				{	MLFile objMLFile = new XMLParser().Load(strFileName);

						// Crea los parámetros encontrados en el archivo
							foreach (MLNode objXMLNode in objMLFile.Nodes)
								if (objXMLNode.Name == ParameterName.cnstStrXMLTagRoot)
									{ ParameterName objParameter = new ParameterName(null);
									
											// Carga los datos del parámetro
												objParameter.LoadXML(objXMLNode);
											// Añade el parámetro a la colección
												Add(objParameter);
									}
				}
			catch {}
		}

		/// <summary>
		///		Graba los elementos de una librería
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
