using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Bau.Applications.ComicsBooks.Classes;

namespace Bau.Applications.ComicsBooks.Forms.Help
{
	/// <summary>
	///		Formulario para mostrar el índice de la ayuda
	/// </summary>
	public partial class frmHelpIndex : WeifenLuo.WinFormsUI.Docking.DockContent, IPluginDocument
	{ 
		public frmHelpIndex()
		{	InitializeComponent();
		}
	
		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Carga la colección de páginas de ayuda
				udtHelpIndex.LoadPages(System.IO.Path.Combine(Application.StartupPath, "Data\\Help"), "hlp");
		}
		
		/// <summary>
		///		Ejecuta una acción del programa principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{	// ... no hace nada, es sólo para cumplir con la interface
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acción
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ return false;
		}

		private void frmHelpIndex_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void udtHelpIndex_PageClick(object objSender, Bau.Controls.Help.HelpPages.HelpPage objPage)
		{ Program.DockedForms.OpenFormAdmon(colDockedForms.FormType.Help, objPage.FileName);
		}
	}
}