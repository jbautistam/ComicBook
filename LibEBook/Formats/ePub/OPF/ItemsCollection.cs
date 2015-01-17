using System;

namespace Bau.Libraries.LibEBook.Formats.ePub.OPF
{
	/// <summary>
	///		Colección de <see cref="Item"/>
	/// </summary>
	public class ItemsCollection : Base.eBookBaseCollection<Item>
	{
		/// <summary>
		///		Obtiene los elementos de determinado tipo
		/// </summary>
		internal ItemsCollection SearchMediaType(string strMediaType)
		{ ItemsCollection objColItems = new ItemsCollection();
		
				// Obtiene los elementos con ese tipo de medio
					foreach (Item objItem in this)
						if (objItem.MediaType.Equals(strMediaType, StringComparison.CurrentCultureIgnoreCase))
							objColItems.Add(objItem);
				// Devuelve la colección de elementos
					return objColItems;
		}
	}
}
