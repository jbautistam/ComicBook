using System;
using System.Collections.Generic;

using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data;

namespace Bau.Applications.ComicsBooks.Forms.Blog.Classes
{
	/// <summary>
	///		Colección de <see cref="BlogReaderFile"/>
	/// </summary>
	public class BlogReaderFilesCollection : List<BlogReaderFile>
	{
		/// <summary>
		///		Añade un BlogReaderFile a la colección (siempre que no exista ya)
		/// </summary>
		public new void Add(BlogReaderFile objBlogReader)
		{ if (Search(objBlogReader.ID) == null)
				base.Add(objBlogReader);
		}
		
		/// <summary>
		///		Añade un elemento a la colección
		/// </summary>
		public void Add(AtomChannel objChannel, FeedIDs objFileIDs, DesktopFilesEntry objDesktopFile)
		{ if (SearchByIDDesktopFile(objDesktopFile.ID) == null)
				Add(new BlogReaderFile(objChannel, objFileIDs, objDesktopFile));
		}
	
		/// <summary>
		///		Busca un elemento en la colección
		/// </summary>
		public BlogReaderFile Search(string strID)
		{ // Recorre la colección
				foreach (BlogReaderFile objBlogReader in this)
					if (objBlogReader.ID.Equals(strID, StringComparison.CurrentCultureIgnoreCase))
						return objBlogReader;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}
		
		/// <summary>
		///		Busca un elemento en la colección a partir del ID de una entrada Atom
		/// </summary>
		public BlogReaderFile SearchByIDAtom(string strID)
		{ // Recorre la colección
				foreach (BlogReaderFile objBlogReader in this)
					foreach (AtomEntry objEntry in objBlogReader.Channel.Entries)
						if (objEntry.ID.Equals(strID, StringComparison.CurrentCultureIgnoreCase))
							return objBlogReader;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}
		
		/// <summary>
		///		Busca un elemento en la colección a partir del ID de un archivo
		/// </summary>
		public BlogReaderFile SearchByIDDesktopFile(string strID)
		{ // Recorre la colección
				foreach (BlogReaderFile objBlogReader in this)
					if (objBlogReader.DesktopFile.ID == strID)
						return objBlogReader;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}
	}
}
