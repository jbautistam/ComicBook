using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper;
using Bau.Applications.ComicsBooks.Classes;

namespace Bau.Applications.ComicsBooks.Forms.Help
{
	/// <summary>
	///		Formulario para mostrar las ayudas
	/// </summary>
	public partial class frmHelp : WeifenLuo.WinFormsUI.Docking.DockContent, IFormAdmon<string>
	{ // Variables privadas
			private string strIDHelp = null;
			
		public frmHelp()
		{	InitializeComponent();
		}
		
		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Cambia el tag y tabs del formulario
				ToolTipText = TabText = Text;
				Tag = colDockedForms.GetTag(colDockedForms.FormType.Help, IDData);
			// Carga la ayuda
				LoadHelp();
		}
		
		/// <summary>
		///		Carga la ayuda
		/// </summary>
		private void LoadHelp()
		{ if (IDData.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase))
				udtPage.ShowURL(IDData);
			else
				udtPage.ShowURL(System.IO.Path.Combine(System.IO.Path.Combine(Application.StartupPath, "Data\\Help"), IDData));
		}
		
		/// <summary>
		///		Ejecuta una acción desde el menú principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{ // .. no hace nada, simplemente implementa el interface
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acción
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ return false;
		}

		/// <summary>
		///		Rutina de tratamiento del evento Changed de los controles
		/// </summary>
		public void Changed(object sender, EventArgs e)
		{ // ... no hace nada, se crea para soportar el interface
		}

		public string IDData
		{ get { return strIDHelp; }
			set { strIDHelp = value; }
		}

		private void frmHelp_Load(object sender, EventArgs e)
		{ InitForm();
		}
	}
}