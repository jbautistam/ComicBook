using System;
using System.Collections.Generic;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Bau.Applications.ComicsBooks.Classes
{
	/// <summary>
	///		Clase que almacena los datos de un formulario
	/// </summary>
	public class clsDockedForm
	{ // Variables privadas
			DockContent frmForm;
			DockState intPosition;
			string strMenuName;
			bool blnVisible;
			
		public clsDockedForm(DockContent frmForm, DockState intPosition, string strMenuName)
		{ // Inicializa el formulario
				Form = frmForm;
				Position = intPosition;
				MenuName = strMenuName;
				blnVisible = frmForm.Visible;
			// Añade un manejador de eventos para saber cuando se cierra
				frmForm.FormClosing += new FormClosingEventHandler(frmForm_FormClosing);
		}

		/// <summary>
		///		Muestra la ventana
		/// </summary>
		public void Show()
		{ // Muestra la ventana
				frmForm.Show(Program.MainWindow.DockPanelMain, intPosition);
			// Indica que es visible
				blnVisible = true;
		}			
		
		/// <summary>
		///		Cierra la ventana
		/// </summary>		
		public void Close()
		{ // Oculta la ventana
				frmForm.Hide();
			// Indica que está cerrado
				blnVisible = false;
		}

		private void frmForm_FormClosing(object sender, FormClosingEventArgs e)
		{ e.Cancel = true;
			Close();
		}
		
		public DockContent Form
		{ get { return frmForm; }
			set { frmForm = value; }
		}
		
		public DockState Position
		{ get { return intPosition; }
			set { intPosition = value; }
		}
		
		public string MenuName
		{ get { return strMenuName; }
			set { strMenuName = value; }
		}
		
		public bool Visible
		{ get { return blnVisible; }
		}
	}
}
