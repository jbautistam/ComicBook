using System;

namespace Bau.Libraries.LibDownloader.Proxy
{
	/// <summary>
	///		Parámetros del proxy
	/// </summary>
	public class ProxyParameters
	{
		public ProxyParameters() : this(false, null, null, null, 8080) {}
		
		public ProxyParameters(bool blnEnabled, string strName, string strUser, string strPassword, int intPort)
		{	Enabled = blnEnabled;
			Name = strName;
			User = strUser;
			Password = strPassword;
			Port = intPort;
		}
		
		/// <summary>
		///		Indica si el proxy está activo o no
		/// </summary>
		public bool Enabled { get; set; }
		
		/// <summary>
		///		Nombre del proxy
		/// </summary>
		public string Name { get; set; }
		
		/// <summary>
		///		Usuario del proxy
		/// </summary>
		public string User { get; set; }
		
		/// <summary>
		///		Contraseña del proxy
		/// </summary>
		public string Password { get; set; }
		
		/// <summary>
		///		Puerto del proxy
		/// </summary>
		public int Port { get; set; }
	}
}
