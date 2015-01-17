using System;

using Bau.Libraries.LibEBook.Formats.ePub.Container;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Libraries.LibEBook.Formats.ePub.Parser
{
	/// <summary>
	///		Intérprete del archivo Container.XML
	/// </summary>
	/// <example>
	///		<?xml version='1.0' encoding='utf-8'?>
	///		<container xmlns="urn:oasis:names:tc:opendocument:xmlns:container" version="1.0">
	///			<rootfiles>
	///				<rootfile media-type="application/oebps-package+xml" full-path="25640/content.opf"/>
	///			</rootfiles>
	///		</container>
	/// </example>
	internal static class ePubParserContainer
	{
		/// <summary>
		///		Interpreta el archivo container.xml. Devuelve una colección de cadenas con los nombres de los
		///	archivos de índice
		/// </summary>
		internal static ContainerFile Parse(string strPathBase)
		{ ContainerFile objContainer = new ContainerFile();
			MLFile objMLFile = new XMLParser().Load(System.IO.Path.Combine(System.IO.Path.Combine(strPathBase, "META-INF"),
																																		 "container.xml"));
																														 
				// Carga los datos del archivo
					foreach (MLNode objMLNode in objMLFile.Nodes)
						if (objMLNode.Name == ContainerConstants.cnstStrTagRoot)
							foreach (MLNode objMLChild in objMLNode.Nodes)
								if (objMLChild.Name == ContainerConstants.cnstStrTagRootFilesRoot)
									foreach (MLNode objMLRootFile in objMLChild.Nodes)
										if (objMLRootFile.Name == ContainerConstants.cnstStrTagRootFileRoot)
											{ RootFile objFile = new RootFile();
											
													// Interpreta los datos
														objFile.MediaType = objMLRootFile.Attributes[ContainerConstants.cnstStrTagRootFileMediaType].Value;
														objFile.URL = objMLRootFile.Attributes[ContainerConstants.cnstStrTagRootFilePath].Value;
													// Añade el archivo raíz a la colección
														if (!string.IsNullOrEmpty(objFile.URL))
															objContainer.RootFiles.Add(objFile);
											}
				// Devuelve los datos del archivo contenedor
					return objContainer;
		}
	}
}
