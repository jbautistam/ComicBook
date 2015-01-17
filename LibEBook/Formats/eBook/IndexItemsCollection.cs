using System;

namespace Bau.Libraries.LibEBook.Formats.eBook
{
	/// <summary>
	///		Colecci�n de <see cref="IndexItem"/>
	/// </summary>
	public class IndexItemsCollection : Base.eBookBaseCollection<IndexItem>
	{
		/// <summary>
		///		A�ade un elemento al �ndice
		/// </summary>
		public void Add(string strName, string strIDPage, string strURL)
		{ Add(new IndexItem(strName, strIDPage, strURL));
		}
	}
}
