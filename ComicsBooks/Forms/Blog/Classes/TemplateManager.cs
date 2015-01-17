using System;
using System.IO;

using Bau.Applications.ComicsBooks.Classes;
using Bau.Libraries.LibHelper.Files;

namespace Bau.Applications.ComicsBooks.Forms.Blog.Classes
{
	/// <summary>
	///		Manager para las plantillas de los feeds
	/// </summary>
	public static class TemplateManager
	{
		/// <summary>
		///		Copia los archivos de la plantilla predeterminada
		/// </summary>
		public static void CopyFiles()
		{ Template objTemplate = new Template();
			string strTemplate = clsConfiguration.TemplateFeedsFileName;
		
				// Carga la plantilla configurada
					objTemplate.Load(strTemplate);
				// Si no ha cargado nada carga la plantilla predeterminada
					if (string.IsNullOrEmpty(objTemplate.Html))
						{ // Cambia el archivo de la plantilla
								strTemplate = clsConfiguration.TemplateFeedsFileNameDefault;
							// Carga la plantilla
								objTemplate.Load(strTemplate);
						}
				// Copia los archivos
					foreach (string strFileName in objTemplate.FileNames)
						HelperFiles.CopyFile(Path.Combine(Path.GetDirectoryName(strTemplate), strFileName),
																 Path.Combine(clsConfiguration.PathBaseFeedTemplates, strFileName));
		}
	}
}
