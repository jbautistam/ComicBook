using System;

using System.Windows.Forms;

namespace Bau.Applications.ComicsBooks.Classes
{
	/// <summary>
	///		Clase con la lista con las imágenes que se utilizan en la aplicación
	/// </summary>
	public class clsListImagesUI
	{ // Enumerados públicos
			public enum ImagesIndex
				{	ApplicationRoot,
					Application,
					DeploymentRoot,
					Document,
					eMailRead,
					eMailNotRead,
					Error,
					Folder,
					Forum,
					Help,
					HighPriority,
					ItemProjectRoot,
					ItemProject,
					Iteration,
					Lock,
					Menu,
					MenuRoot,
					Message,
					Messenger,
					Module,
					PageHelp,
					Project,
					ProjectRoot,
					ProjectState,
					Requirement,
					ServerRoot,
					Server,
					TablesRoot,
					Tables,
					Task,
					TaskTypeUnknown,
					Unlock,
					URL,
					User,
					UserRoot,
					WorkGroupRoot,
					WorkGroup
				}
		// Variables privadas
			private static ImageList imlImages = new ImageList();
	
			public static ImageList Images
			{ get 
					{ // Carga la lista de imágenes
							if (imlImages.Images.Count == 0)
								{ imlImages.Images.Add(Properties.Resources.Application); // ImagesIndex.ApplicationRoot
									imlImages.Images.Add(Properties.Resources.Application); // ImagesIndex.Application
									imlImages.Images.Add(Properties.Resources.Deployment); // ImagesIndex.DeploymentRoot
									imlImages.Images.Add(Properties.Resources.Document); // ImagesIndex.Document
									imlImages.Images.Add(Properties.Resources.EMailOpen); // eMailRead
									imlImages.Images.Add(Properties.Resources.EMail); // eMailNotRead
									imlImages.Images.Add(Properties.Resources.Error); // ImagesIndex.Error
									imlImages.Images.Add(Properties.Resources.Folder); // ImagesIndex.Folder
									imlImages.Images.Add(Properties.Resources.EMail); // ImagesIndex.Forum
									imlImages.Images.Add(Properties.Resources.help); // ImagesIndex.Help
									imlImages.Images.Add(Properties.Resources.exclamation); // HighPriority
									imlImages.Images.Add(Properties.Resources.ItemProject); // ImagesIndex.ItemProjectRoot
									imlImages.Images.Add(Properties.Resources.ItemProject); // ImagesIndex.ItemProject
									imlImages.Images.Add(Properties.Resources.Iteration); // ImagesIndex.Iteration
									imlImages.Images.Add(Properties.Resources.Lock); // ImagesIndex.Lock
									imlImages.Images.Add(Properties.Resources.Menu); // ImagesIndex.Menu
									imlImages.Images.Add(Properties.Resources.MenuRoot); // ImagesIndex.MenuRoot
									imlImages.Images.Add(Properties.Resources.EMail); // ImagesIndex.Message
									imlImages.Images.Add(Properties.Resources.Messenger); // ImagesIndex.Messenger
									imlImages.Images.Add(Properties.Resources.NewDocument); // ImagesIndex.Module
									imlImages.Images.Add(Properties.Resources.information); // ImagesIndex.PageHelp
									imlImages.Images.Add(Properties.Resources.project); // ImagesIndex.Project
									imlImages.Images.Add(Properties.Resources.project); // ImagesIndex.ProjectRoot
									imlImages.Images.Add(Properties.Resources.Status); // ImagesIndex.ProjectState
									imlImages.Images.Add(Properties.Resources.Requirement); // ImagesIndex.Requirement
									imlImages.Images.Add(Properties.Resources.Server); // ImagesIndex.ServerRoot
									imlImages.Images.Add(Properties.Resources.Server); // ImagesIndex.Server
									imlImages.Images.Add(Properties.Resources.Table); // ImagesIndexTablesRoot
									imlImages.Images.Add(Properties.Resources.Table); // ImagesIndexTables
									imlImages.Images.Add(Properties.Resources.Task); // ImagesIndex.Task
									imlImages.Images.Add(Properties.Resources.TaskUnknown); // ImagesIndex.TaskTypeUnknown
									imlImages.Images.Add(Properties.Resources.Unlock); // ImagesIndex.Unlock
									imlImages.Images.Add(Properties.Resources.Web); // ImagesIndex.URL
									imlImages.Images.Add(Properties.Resources.WorkGroup); // ImagesIndex.WorkGroupRoot
									imlImages.Images.Add(Properties.Resources.WorkGroup); // ImagesIndex.WorkGroup
								}
						// Devuelve la lista de imágenes
							return imlImages; 
					}
			}
	}
}
