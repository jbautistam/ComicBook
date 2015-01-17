using System;

namespace Bau.Libraries.LibEBook.Formats.ePub.NCX
{
	/// <summary>
	///		Constantes de los archivos NCX
	/// </summary>
	internal static class NCXConstants
	{ // Constantes para el XML del nodo raíz
			internal const string cnstStrTagRoot = "ncx";
			internal const string cnstStrTagRootAttrNameSpace = "xmlns";
			internal const string cnstStrTagRootAttrNameSpaceValue = "http://www.daisy.org/z3986/2005/ncx/";
			internal const string cnstStrTagRootAttrVersion = "version";
			internal const string cnstStrTagRootAttrVersionValue = "2005-1";
			internal const string cnstStrTagRootAttrLanguage = "xml:lang";
			internal const string cnstStrTagRootAttrLanguageSpanish = "es";
		// Constantes para la cabecera
			internal const string cnstStrTagHead = "head";
			internal const string cnstStrTagHeadMeta = "meta";
			internal const string cnstStrTagHeadMetaAttrContent = "content";
			internal const string cnstStrTagHeadMetaAttrName = "name";
			internal const string cnstStrTagHeadMetaAttrNameIDValue = "dtb:uid";
			internal const string cnstStrTagHeadMetaAttrNameDepthValue = "dtb:depth";
			internal const string cnstStrTagHeadMetaAttrNameGeneratorValue = "dtb:generator";
			internal const string cnstStrTagHeadMetaAttrNameTotalPageCountValue = "dtb:totalPageCount";
			internal const string cnstStrTagHeadMetaAttrNameMaxPageNumberValue = "dtb:maxPageNumber";
		// Constantes para el título
			internal const string cnstStrTagDocTitle = "docTitle";
			internal const string cnstStrTagText = "text";
		// Constantes para el navMap
			internal const string cnstStrTagNavMap = "navMap";
			internal const string cnstStrTagNavPoint = "navPoint";
			internal const string cnstStrTagNavPointID = "id";
			internal const string cnstStrTagNavPointOrder = "playOrder";
			internal const string cnstStrTagNavPointLabel = "navLabel";
			internal const string cnstStrTagNavPointContent = "content";
			internal const string cnstStrTagNavPointContentSrc = "src";
		// Otras constantes
			internal const string cnstStrMediaType = "application/x-dtbncx+xml";
	}
}
