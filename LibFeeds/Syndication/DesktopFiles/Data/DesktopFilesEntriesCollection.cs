using System;

namespace Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data
{
	/// <summary>
	///		Colección de <see cref="DesktopFilesEntry"/>
	/// </summary>
	public class DesktopFilesEntriesCollection : System.Collections.Generic.List<DesktopFilesEntry>
	{
		/// <summary>
		///		Añade una serie de entradas
		/// </summary>
		public void Add(DesktopFilesEntriesCollection objColEntries)
		{ foreach (DesktopFilesEntry objEntry in objColEntries)
				Add(objEntry);
		}

		/// <summary>
		///		Busca un elemento en la colección
		/// </summary>
		public DesktopFilesEntry Search(string strID)
		{ DesktopFilesEntry objFoundEntry = null;
		
				// Recorre la colección
					foreach (DesktopFilesEntry objEntry in this)
						if (objFoundEntry == null)
							{	if (objEntry.ID.Equals(strID))
									return objEntry;
								else
									objFoundEntry = objEntry.Entries.Search(strID);
							}
				// Devuelve la entrada encontrada (si ha habido alguna)
					return objFoundEntry;
		}	
			
		/// <summary>
		///		Comprueba si existe un elemento con este ID
		/// </summary>
		public bool Exists(string strID)
		{ return Search(strID) != null;
		}

		/// <summary>
		///		Elimina un elemento de la entrada
		/// </summary>
		internal bool Remove(string strID)
		{ bool blnDeleted = false;

				// Busca el elemento y lo elimina cuando lo encuentra		
					for (int intIndex = Count - 1; intIndex >= 0 && !blnDeleted; intIndex--)
						if (this[intIndex].ID.Equals(strID))
							{ // Elimina el elemento
									RemoveAt(intIndex);
								// Indica que lo ha borrado
									blnDeleted = true;
							}
						else
							blnDeleted = this[intIndex].Entries.Remove(strID);
				// Devuelve el valor que indica si lo ha borrado
					return blnDeleted;
		}

		/// <summary>
		///		Cuenta el número de elementos no leídos de una entrada
		/// </summary>
		internal int CountNotRead()
		{ int intNotRead = 0;
		
				// Acumula los elementos no leídos
					foreach (DesktopFilesEntry objEntry in this)
						if (objEntry.Enabled)
							intNotRead += objEntry.CountNotRead();
				// Devuelve el número de elementos no leídos
					return intNotRead;
		}
		
		/// <summary>
		///		Ordenación
		/// </summary>
		public new void Sort()
		{ // Ordena la colección
				base.Sort();
			// Ordena las entradas
				foreach (DesktopFilesEntry objEntry in this)
					objEntry.Entries.Sort();					
		}
	}
}
