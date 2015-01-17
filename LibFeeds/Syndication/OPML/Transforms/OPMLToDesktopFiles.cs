using System;

using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data;

namespace Bau.Libraries.LibFeeds.Syndication.OPML.Transforms
{
	/// <summary>
	///		Conversor de <see cref="OPMLCahnnel"/ a <see cref="DesktopFilesChannel"/> >
	/// </summary>
	public static class OPMLToDesktopFiles
	{
		/// <summary>
		///		Convierte un canal OPML a un canal DestopFiles
		/// </summary>
		public static DesktopFilesChannel Convert(Data.OPMLChannel objOpmlChannel)
		{ DesktopFilesChannel objDesktopChannel = new DesktopFilesChannel();
		
				// Asigna las propiedades al canal
					objDesktopChannel.DateCreated = objOpmlChannel.DateCreated;
					objDesktopChannel.DateModified = objOpmlChannel.DateModified;
					objDesktopChannel.Title = objOpmlChannel.Title;
				// Añade las entradas
					AddOpmlEntries(objDesktopChannel, null, objOpmlChannel.Entries);
				// Devuelve el canal
					return objDesktopChannel;
		}

		/// <summary>
		///		Añade las entradas OPML a las categorías
		/// </summary>
		private static void AddOpmlEntries(DesktopFilesChannel objChannel, DesktopFilesEntry objParent, 
																			 Data.OPMLEntriesCollection objColOpmlEntries)
		{ foreach (Data.OPMLEntry objOpmlEntry in objColOpmlEntries)
				{	DesktopFilesEntry objEntry = new DesktopFilesEntry();
				
						// Asigna las propiedades
							objEntry.Text = objOpmlEntry.Title;
							if (string.IsNullOrEmpty(objEntry.Text))
								objEntry.Text = objOpmlEntry.Text;
							objEntry.URL = objOpmlEntry.URL;
							objEntry.NumberNotRead = 0;
						// Añade la entrada
							if (objParent == null)
								objChannel.Entries.Add(objEntry);
							else
								objParent.Entries.Add(objEntry);
						// Añade las entradas OPML hijas
							AddOpmlEntries(objChannel, objEntry, objOpmlEntry.Entries);
					}
		}
	}
}
