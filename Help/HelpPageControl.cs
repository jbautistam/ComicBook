using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bau.Controls.Help
{
	/// <summary>
	///		Control para mostrar una página de ayuda
	/// </summary>
	public partial class HelpPageControl : UserControl
	{	
		public HelpPageControl()
		{	InitializeComponent();
		}
		
		/// <summary>
		///		Carga la página de ayuda
		/// </summary>
		public void ShowURL(string strURL)
		{ brwBrowser.LoadURL(strURL);
		}
	}
}