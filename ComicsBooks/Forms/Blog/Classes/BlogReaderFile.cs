using System;

using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data;

namespace Bau.Applications.ComicsBooks.Forms.Blog.Classes
{
	/// <summary>
	///		Unión de elementos utilizados en <see cref="frmBlogReader"/>
	/// </summary>
	public class BlogReaderFile
	{	// Variables privadas
			private string strID;
			
		public BlogReaderFile(AtomChannel objChannel, FeedIDs objFileIDs, DesktopFilesEntry objDesktopFile)
		{ Channel = objChannel;
			FileIDs = objFileIDs;
			DesktopFile = objDesktopFile;
		}
		
		/// <summary>
		///		ID
		/// </summary>
		public string ID
		{ get
				{ // Asigna el ID si no existía
						if (string.IsNullOrEmpty(strID))
							strID = Guid.NewGuid().ToString();
					// Devuelve el ID
						return strID;
				}
			set { strID = value; }
		}
		
		/// <summary>
		///		Archivo con los datos de un Atom
		/// </summary>
		public DesktopFilesEntry DesktopFile { get; set; }
		
		/// <summary>
		///		Canal atom
		/// </summary>
		public AtomChannel Channel { get; set; }
		
		/// <summary>
		///		Archivo de elementos borrados
		/// </summary>
		public FeedIDs FileIDs { get; set; }
	}
}