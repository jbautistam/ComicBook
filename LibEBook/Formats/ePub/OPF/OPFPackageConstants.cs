using System;

namespace Bau.Libraries.LibEBook.Formats.ePub.OPF
{
	/// <summary>
	///		Constantes con las etiquetas de un archivo OPF
	/// </summary>
	internal static class OPFPackageConstants
	{ // Nodo principal
			internal const string cnstStrTagRoot = "package";
			internal const string cnstStrTagRootNameSpacePrefix = "opf";
			internal const string cnstStrTagRootNameSpace = "http://www.idpf.org/2007/opf";
			internal const string cnstStrTagRootUniqueIdentifier = "unique-identifier";
			internal const string cnstStrTagRootUniqueIdentifierValue = "EPB-UUID";
			internal const string cnstStrTagRootVersion = "version";
			internal const string cnstStrTagRootVersionValue = "2.0";
		// Metadatos
			internal const string cnstStrTagMetadata = "metadata";
		// Manifiesto
			internal const string cnstStrTagManifest = "manifest";
			internal const string cnstStrTagManifestItem = "item";
			internal const string cnstStrTagManifestID = "id";
			internal const string cnstStrTagManifestHref = "href";
			internal const string cnstStrTagManifestMediatype = "media-type";
		// Orden
			internal const string cnstStrTagSpine = "spine";
			internal const string cnstStrTagSpineToc = "toc";
			internal const string cnstStrTagSpineTocValue = "ncx";
			internal const string cnstStrTagSpineItemRef = "itemref";
			internal const string cnstStrTagSpineIdRef = "idref";
			internal const string cnstStrTagSpineLinear = "linear";
	}
}
