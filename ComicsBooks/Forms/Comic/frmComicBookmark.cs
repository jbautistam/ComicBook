using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bau.Applications.ComicsBooks.Forms.Comic
{
	/// <summary>
	///		Formulario para la definición de marcadores
	/// </summary>
	public partial class frmComicBookmark : Form
	{
		public frmComicBookmark()
		{	InitializeComponent();
		}

		private void InitForm()
		{
		}
		
		private void Save()
		{
		}
		
		private void frmComicBookmark_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}
	}
}