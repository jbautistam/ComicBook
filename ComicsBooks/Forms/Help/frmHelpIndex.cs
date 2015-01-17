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
	///		Formulario para mostrar el �ndice de la ayuda
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
		{ // Carga la colecci�n de p�ginas de ayuda
				udtHelpIndex.LoadPages(System.IO.Path.Combine(Application.StartupPath, "Data\\Help"), "hlp");
		}
		
		/// <summary>
		///		Ejecuta una acci�n del programa principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{	// ... no hace nada, es s�lo para cumplir con la interface
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acci�n
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