using System;

using Bau.Libraries.LibEBook.Formats.eBook;
using Bau.Libraries.LibEBook.Formats.ePub;
using Bau.Libraries.LibEBook.Formats.ePub.Creator;
using Bau.Libraries.LibEBook.Formats.ePub.Parser;

namespace Bau.Libraries.LibEBook
{
	/// <summary>
	///		Factory de un libro
	/// </summary>
	public class BookFactory
	{ // Enumerados públicos
			public enum BookType
				{ eBookNeutral,
					ePub
				}
				
		/// <summary>
		///		Carga los datos de un libro
		/// </summary>
		public ePubEBook Load(string strFileName, string strPathTarget)
		{ return new ePubParser().Parse(strFileName, strPathTarget);
		}
		
		/// <summary>
		///		Obtiene un <see cref="Book"/> a partir de un archivo
		/// </summary>
		public Book Load(BookType intType, string strFileName, string strPathTarget)
		{ switch (intType)
				{ case BookType.ePub:
						return new ePubConvertEBook().Convert(new ePubParser().Parse(strFileName, strPathTarget));
					default:
						throw new NotImplementedException("Tipo de eBook desconocido");
				}
		}
		
		/// <summary>
		///		Graba un archivo
		/// </summary>
		public void Save(BookType intType, Book objEBook, string strFileName)
		{ switch (intType)
				{ case BookType.ePub:
							new ePubCreator().Create(strFileName, objEBook);
						break;
					default:
						throw new NotImplementedException("Tipo de eBook desconocido");
				}
		}
	}
}
