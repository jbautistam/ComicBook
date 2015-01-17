using System;

namespace Bau.Libraries.LibFeeds.Syndication
{
	/// <summary>
	///		Base para las entradas de un archivo 
	/// </summary>
	public abstract class FeedEntryBase : FeedBase
	{ // Variables privadas
			private string strID = null;
		
		public FeedEntryBase()
		{ DateCreated = DateTime.Now;
		}	
		
		/// <summary>
		///		ID de la entrada
		/// </summary>
		public virtual string ID 
		{ get
				{ // Obtiene el ID si no existía
						if (string.IsNullOrEmpty(strID))
							strID = Guid.NewGuid().ToString();
					// Devuelve el ID
						return strID;
				}
			set { strID = value; }
		}
		
		/// <summary>
		///		Fecha de creación de la entrada
		/// </summary>
		public virtual DateTime DateCreated { get; set; }
	}
}
