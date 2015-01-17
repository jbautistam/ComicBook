using System;

using Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Desktop.Data;
using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Desktop.Transforms
{
	/// <summary>
	///		Escribe los datos de <see cref="FeedDesktop"/> sobre un archivo XML
	/// </summary>
	internal class FeedDesktopWriter
	{
		/// <summary>
		///		Escribe los datos de un <see cref="FeedDesktop"/>
		/// </summary>
		internal static void AddNodesExtension(MLNode objNode, FeedDesktop objDesktop)
		{ objNode.Nodes.Add(FeedDesktopConstTags.cnstStrXMLPrefix, FeedDesktopConstTags.cnstStrRead, objDesktop.IsRead);
			objNode.Nodes.Add(FeedDesktopConstTags.cnstStrXMLPrefix, FeedDesktopConstTags.cnstStrPriority, objDesktop.Priority);
			objNode.Nodes.Add(FeedDesktopConstTags.cnstStrXMLPrefix, FeedDesktopConstTags.cnstStrEnabled, objDesktop.Enabled);
		}
	}
}
