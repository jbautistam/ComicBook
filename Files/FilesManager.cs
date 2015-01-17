using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bau.Controls.Files
{
	/// <summary>
	///		Manager de archivos (para cortar, copiar, pegar, ... archivos)
	/// </summary>
	internal static class FilesManager
	{
		// Enumerados privados
			internal enum ActionCopy
			{ Unknown,
				Copy,
				Cut
			}
		// Variables privadas
			private static ActionCopy intAction = ActionCopy.Unknown;			
			private static FilesInfo.colFiles objColFilesCopy = new FilesInfo.colFiles();
			
		/// <summary>
		///		Limpia los archivos
		/// </summary>
		internal static void Clear()
		{ objColFilesCopy.Clear();
		}
		
		/// <summary>
		///		Añade un archivo a la colección
		/// </summary>
		internal static void Add(FilesInfo.clsFile objFile)
		{ objColFilesCopy.Add(objFile);
		}
		
		/// <summary>
		///		Copia / mueve los archivos
		/// </summary>
		internal static void Paste(string strPathTarget)
		{ // Copia / mueve los archivos
				foreach (FilesInfo.clsFile objFile in objColFilesCopy)
					if (intAction == ActionCopy.Copy)
						objFile.Copy(strPathTarget);
					else
						objFile.Move(strPathTarget);
			// Indica que ha finalizado la copia
				Action = ActionCopy.Unknown;
		}

		/// <summary>
		///		Elimina un archivo o directorio
		/// </summary>
		internal static void Kill(string strFileName)
		{	if (System.IO.Directory.Exists(strFileName))
				KillPath(strFileName);
			else
				KillFile(strFileName);
		}
		
		/// <summary>
		///		Elimina un archivo
		/// </summary>
		private static void KillFile(string strFileName)
		{ try
				{ System.IO.File.Delete(strFileName);
				}
			catch {}
		}
		
		/// <summary>
		///		Elimina un directorio
		/// </summary>
		private static void KillPath(string strPath)
		{ try
				{ System.IO.Directory.Delete(strPath, true);
				}
			catch {}
		}

		/// <summary>
		///		Acción a realizar con los archivos del buffer
		/// </summary>
		internal static ActionCopy Action
		{ get { return intAction; }
			set { intAction = value; }
		}
	}
}
