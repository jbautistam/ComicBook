﻿using System;

namespace Bau.Libraries.LibFeeds.Syndication.OPML
{
	/// <summary>
	///		Constantes con las etiquetas de los archivos OPML
	/// </summary>
	internal static class OPMLConstTags
	{	// Etiqueta de la raíz de un archivo OPML
			internal const string cnstStrRoot = "opml"; 
		// Etiqueta de los datos de canal
			internal const string cnstStrHead = "head";
			internal const string cnstStrTitle = "title";
			internal const string cnstStrDateCreated = "dateCreated";
			internal const string cnstStrDateModified = "dateModified";
			internal const string cnstStrOwnerName = "ownerName";
			internal const string cnstStrOwnerEMail = "ownerEmail";
		// Etiqueta de los datos de elemento
			internal const string cnstStrBody = "body";
			internal const string cnstStrOutline = "outline";
			internal const string cnstStrText = "text";
			internal const string cnstStrTitleEntry = "title";
			internal const string cnstStrType = "type";
			internal const string cnstStrUrl = "url";
			internal const string cnstStrXMLUrl = "xmlUrl";
			internal const string cnstStrCreated = "created";
	}
}
