using System;

using Bau.Libraries.LibCompression;
namespace Bau.Libraries.LibEBook.Formats.ePub.Parser
{
	/// <summary>
	///		Intérprete de archivos OPF
	/// </summary>
	internal class ePubParser
	{ 
		/// <summary>
		///		Interpreta un archivo OPF
		/// </summary>
		internal ePubEBook Parse(string strFileName, string strPathTarget)
		{ ePubEBook objBook = new ePubEBook();
			Compressor objCompressor = new Compressor();
		
				// Descomprime el libro
					objCompressor.Uncompress(strFileName, strPathTarget, Compressor.CompressType.Zip);
				// Interpreta el archivo container.xml
					objBook.Container = ePubParserContainer.Parse(strPathTarget);
				// Interpreta los metadatos
					ePubParserPackage.Parse(objBook, strPathTarget);
				// Devuelve el libro
					return objBook;
		}
	}
}