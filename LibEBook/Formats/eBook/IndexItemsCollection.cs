using System;

namespace Bau.Libraries.LibEBook.Formats.eBook
{
	/// <summary>
	///		Colección de <see cref="IndexItem"/>
	/// </summary>
	public class IndexItemsCollection : Base.eBookBaseCollection<IndexItem>
	{
		/// <summary>
		///		Añade un elemento al índice
		/// </summary>
		public void Add(string strName, string strIDPage, string strURL)
		{ Add(new IndexItem(strName, strIDPage, strURL));
		}
	}
}
