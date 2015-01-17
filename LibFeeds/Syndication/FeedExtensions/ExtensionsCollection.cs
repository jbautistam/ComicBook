using System;
using System.Collections.Generic;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibFeeds.Syndication.FeedExtensions
{
	/// <summary>
	///		Colección de <see cref="ExtensionRootBase"/>
	/// </summary>
	public class ExtensionsCollection : List<ExtensionBase>
	{ 
		public ExtensionsCollection(FeedBase objParent)
		{ Parent = objParent;
		}

		/// <summary>
		///		Añade una colección de extensiones
		/// </summary>
		public void Add(ExtensionsCollection objColExtensions)
		{ foreach (ExtensionBase objExtension in objColExtensions)
				Add(objExtension);
		}

		/// <summary>
		///		Interpreta un nodo
		/// </summary>
		internal void Parse(MLNode objNode, FeedBase objFeed, ExtensionParsersCollection objDictionary)
		{ if (objDictionary != null)
		    { ExtensionParserBase objParser = objDictionary.GetParser(objNode);
				
		        if (objParser != null)
		          objParser.Parse(objNode, objFeed);
		    }
		}

		/// <summary>
		///		Añade los nodos de extensión
		/// </summary>
		internal void AddNodesExtension(MLNode objNode)
		{ foreach (ExtensionBase objExtension in this)
				if (objExtension is Yahoo.Data.YahooMedia)
					Yahoo.Transforms.YahooMediaWriter.AddNodesExtension(objNode, (objExtension as Yahoo.Data.YahooMedia));
				else if (objExtension is Desktop.Data.FeedDesktop)
					Desktop.Transforms.FeedDesktopWriter.AddNodesExtension(objNode, (objExtension as Desktop.Data.FeedDesktop));
		}
		
		/// <summary>
		///		Busca una extensión
		/// </summary>
		internal ExtensionBase Search(string strXMLNameSpace)
		{ // Recorre las extensiones buscando el espacio de nombres
				foreach (ExtensionBase objExtension in this)
					if (objExtension.NameSpace.Equals(strXMLNameSpace, StringComparison.CurrentCultureIgnoreCase))
						return objExtension;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}

		/// <summary>
		///		Obtiene los espacios de nombres
		/// </summary>
		internal MLNameSpacesCollection GetNameSpaces<TypeData>(FeedChannelBase<TypeData> objChannel) where TypeData : FeedEntryBase
		{ MLNameSpacesCollection objColNameSpaces = new MLNameSpacesCollection();
		
				// Añade los espacios de nombres de las extensiones del canal
					foreach (ExtensionBase objExtension in objChannel.Extensions)
						objColNameSpaces.Add(objExtension.Prefix, objExtension.NameSpace);
				// Añade los espacios de nombres de las extensiones de las entradas
					foreach (TypeData objData in objChannel.Entries)
						foreach (ExtensionBase objExtension in objData.Extensions)
							objColNameSpaces.Add(objExtension.Prefix, objExtension.NameSpace);
				// Devuelve la colección de espacios de nombres
					return objColNameSpaces;
		}
				
		/// <summary>
		///		Elemento padre de las extensiones
		/// </summary>
		public FeedBase Parent { get; private set; }
	}
}
