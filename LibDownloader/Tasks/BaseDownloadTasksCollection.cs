using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibDownloader.Tasks
{
	/// <summary>
	///		Colección de <see cref="BaseDownloadTask"/>
	/// </summary>
	public class BaseDownloadTasksCollection : List<BaseDownloadTask>
	{
		/// <summary>
		///		Elimina una tarea
		/// </summary>
		public void Remove(string strID)
		{ for (int intIndex = Count - 1; intIndex >= 0; intIndex--)
				if (this[intIndex].ID == strID)
					RemoveAt(intIndex);
		}
	}
}
