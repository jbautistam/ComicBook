using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibFeeds.Syndication
{
	/// <summary>
	///		Colección de <see cref="FeedEntryBase"/>
	/// </summary>
	public class FeedEntriesBaseCollection<TypeData> : List<TypeData> where TypeData : FeedEntryBase
	{
		/// <summary>
		///		Elimina una entrada a partir de su ID
		/// </summary>
		public void Remove(string strID)
		{ for (int intIndex = Count - 1; intIndex >= 0; intIndex--)
				if (this[intIndex].ID.Equals(strID))
					RemoveAt(intIndex);			
		}

		/// <summary>
		///		Comprueba si existe un ID
		/// </summary>
		public bool Exists(string strID)
		{ return Search(strID) != null;
		}

		/// <summary>
		///		Busca un elemento
		/// </summary>
		public TypeData Search(string strID)
		{ // Recorre los elementos buscando el ID
				foreach (TypeData objEntry in this)
					if (objEntry.ID == strID)
						return objEntry;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}
	}
}
