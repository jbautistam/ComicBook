using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace  Bau.Applications.ComicsBooks.Forms.Comic
{
	/// <summary>
	///		Formulario para mostrar los datos de un informe
	/// </summary>
	public partial class frmComicPreview : WeifenLuo.WinFormsUI.Docking.DockContent
	{ // Variables privadas
			private Bau.Controls.ImageControls.Print.ImagePrinter objImagePrinter;
			
		public frmComicPreview()
		{	InitializeComponent();
		}

		/// <summary>
		///   Inicializa el formulario
		/// </summary>
		private void InitForm()
		{	udtPreview.Document = objImagePrinter;
		}

		/// <summary>
		///		Nombre del informe
		/// </summary>
		public string IDData
		{ get { return Text; }
			set 
				{ Text = value; 
					TabText = value;
				}
		}

		public Bau.Controls.ImageControls.Print.ImagePrinter Document
		{ get { return objImagePrinter; }
			set { objImagePrinter = value; }
		}
		
		private void frmReport_Load(object sender, EventArgs e)
		{ InitForm();
		}
	}
}