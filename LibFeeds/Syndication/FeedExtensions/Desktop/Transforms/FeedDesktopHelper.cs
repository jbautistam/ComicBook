using System;

using Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Desktop.Data;

namespace Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Desktop.Transforms
{
	/// <summary>
	///		Clase de ayuda para tratamiento de extensiones <see cref="FeedDesktop"/>
	/// </summary>
	public static class FeedDesktopHelper
	{
		/// <summary>
		///		Busca la entrada del tipo de extensión <see cref="FeedDesktop"/> entre las extensiones de la entrada
		/// </summary>
		private static FeedDesktop Search(FeedEntryBase objEntry)
		{ // Recorre las extensiones buscando las del tipo FeedDesktop
				foreach	(ExtensionBase objExtension in objEntry.Extensions)
					if (objExtension is FeedDesktop)
						return objExtension as FeedDesktop;
			// Si ha llegado hasta aquí es porque no ha encontrado la extensión
				return null;
		}
		
		/// <summary>
		///		Comprueba las extensiones de la entrada comprobando si se ha leído
		/// </summary>
		public static bool IsRead(FeedEntryBase objEntry)
		{ FeedDesktop objExtension = Search(objEntry);
		
				return objExtension != null && objExtension.IsRead;
		}
		
		/// <summary>
		///		Marca una entrada como leída
		/// </summary>
		public static void MarkEntryRead(FeedEntryBase objEntry, bool blnIsRead)
		{ FeedDesktop objExtension = Search(objEntry);
		
				// Si no se ha encontrado, añade una nueva
					if (objExtension == null)
						{ // Crea la extensión
								objExtension = new FeedDesktop();
							// La añade a la colección de extensiones de la entrada
								objEntry.Extensions.Add(objExtension);
						}
				// Marca la extensión como leída o no
					objExtension.IsRead = blnIsRead;
		}

		/// <summary>
		///		Cuenta el número de elementos no leídos de un canal
		/// </summary>
		public static int CountNotRead<TypeData>(FeedChannelBase<TypeData> objChannel) where TypeData : FeedEntryBase
		{ int intNumber = 0;
		
				// Recorre las entradas
					foreach (TypeData objEntry in objChannel.Entries)
						if (!IsRead(objEntry))
							intNumber++;
				// Devuelve el número de elementos no leídos
					return intNumber;
		}

		/// <summary>
		///		Obtiene la fecha de última modificación de un canal
		/// </summary>
		public static DateTime GetLastUpdated<TypeData>(FeedChannelBase<TypeData> objChannel) where TypeData : FeedEntryBase
		{ DateTime dtmLastUpdated = DateTime.MinValue;
		
				// Recorre las entradas
					foreach (FeedEntryBase objEntry in objChannel.Entries)
						if (objEntry.DateCreated > dtmLastUpdated)
							dtmLastUpdated = objEntry.DateCreated;
				// Devuelve la fecha de última modificación
					return dtmLastUpdated;
		}

		/// <summary>
		///		Obtiene la prioridad de una entrada
		/// </summary>
		public static int GetPriority(FeedEntryBase objEntry)
		{ FeedDesktop objExtension = Search(objEntry);
		
				if (objExtension != null)
					return objExtension.Priority;
				else
					return 0;
		}

		/// <summary>
		///		Asigna la prioridad a una entrada
		/// </summary>
		public static void SetPriority(FeedEntryBase objEntry, int intPriority)
		{ FeedDesktop objExtension = Search(objEntry);
		
				if (objExtension != null)
					{ // Marca el elemento como leído
							if (intPriority != 0)
								objExtension.IsRead = true;
						// Cambia la prioridad
							objExtension.Priority = intPriority;
					}
		}
	}
}
