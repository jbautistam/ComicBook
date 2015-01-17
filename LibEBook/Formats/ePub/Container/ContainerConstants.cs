using System;

namespace Bau.Libraries.LibEBook.Formats.ePub.Container
{
	/// <summary>
	///		Constantes del archivo container.xml
	/// </summary>
	internal static class ContainerConstants
	{	// Raíz
			internal const string cnstStrTagRoot = "container";
			internal const string cnstStrTagRootNameSpace = "xmlns";
			internal const string cnstStrTagRootNameSpaceValue = "urn:oasis:names:tc:opendocument:xmlns:container";
			internal const string cnstStrTagRootVersion = "version";
			internal const string cnstStrTagRootVersionValue ="1.0";
		// RootFiles
			internal const string cnstStrTagRootFilesRoot = "rootfiles";
			internal const string cnstStrTagRootFileRoot = "rootfile";
			internal const string cnstStrTagRootFileMediaType = "media-type";
			internal const string cnstStrTagRootFileMediaTypeValue ="application/oebps-package+xml";
			internal const string cnstStrTagRootFilePath = "full-path";
	}
}
