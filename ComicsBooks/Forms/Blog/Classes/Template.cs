using System;
using System.Collections.Generic;

using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;

namespace Bau.Applications.ComicsBooks.Forms.Blog.Classes
{
	/// <summary>
	///		Plantilla de presentación
	/// </summary>
	public class Template
	{ // Constantes privadas
			private const string cnstStrTagRoot = "TemplateDefinition";
			private const string cnstStrTagName = "Name";
			private const string cnstStrTagDescription = "Description";
			private const string cnstStrTagHtml = "Html";
			private const string cnstStrTagTemplateChannel = "TemplateChannel";
			private const string cnstStrTagTemplateEntry = "TemplateEntry";
			private const string cnstStrTagFiles = "Files";
			private const string cnstStrTagFileName = "File";
			
		public Template()
		{ FileNames = new List<string>();
		}
		
		/// <summary>
		///		Carga la plantilla de un archivo
		/// </summary>
		public void Load(string strFileName)
		{ if (System.IO.File.Exists(strFileName))
				{ MLFile objFile = new XMLParser().Load(strFileName);
					MLNode objNode = objFile.Nodes[cnstStrTagRoot];
					
							if (objNode != null)
								{ // Datos básicos
										Name = objNode.Nodes[cnstStrTagName].Value;
										Description = objNode.Nodes[cnstStrTagDescription].Value;
										Html = objNode.Nodes[cnstStrTagHtml].Value;
										TemplateChannel = objNode.Nodes[cnstStrTagTemplateChannel].Value;
										TemplateEntry = objNode.Nodes[cnstStrTagTemplateEntry].Value;
									// Obtiene los archivos
										objNode = objNode.Nodes[cnstStrTagFiles];
										if (objNode != null)
											foreach (MLNode objChild in objNode.Nodes)
												if (objChild.Name == cnstStrTagFileName)
													FileNames.Add(objChild.Value);
								}
					}
		}
		
		/// <summary>
		///		Nombre de la plantilla
		/// </summary>
		public string Name { get; set; }
		
		/// <summary>
		///		Descripción de la plantilla
		/// </summary>
		public string Description { get; set; }
		
		/// <summary>
		///		Código HTML
		/// </summary>
		public string Html { get; set; }
		
		/// <summary>
		///		Código HTML del canal
		/// </summary>
		public string TemplateChannel { get; set; }
		
		/// <summary>
		///		Código HTML del contenido
		/// </summary>
		public string TemplateEntry { get; set; }
		
		/// <summary>
		///		Nombres de archivos
		/// </summary>
		public List<string> FileNames { get; set; }
	}
}
