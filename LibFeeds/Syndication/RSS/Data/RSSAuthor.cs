﻿using System;

namespace Bau.Libraries.LibFeeds.Syndication.RSS.Data
{	
	/// <summary>
	///		Autor del archivo RSS
	/// </summary>
	public class RSSAuthor
	{
		public RSSAuthor() : this(null) {}
		
		public RSSAuthor(string strName)
		{ Name = strName;
		}
		
		/// <summary>
		///		Nombre del autor
		/// </summary>
		public string Name { get; set; }
	}
}