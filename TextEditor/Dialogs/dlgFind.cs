using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Bau.Controls.Text.Dialogs
{
	/// <summary>
	///		Diálog de búsqueda
	/// </summary>
  public partial class dlgFind : Form
  {	// Variables privadas
			RtfTextEditor ctlEditor;
			int intLastStop = 0;

    public dlgFind()
    {	InitializeComponent();
    }

		/// <summary>
		///		Obtiene las opciones de búsqueda
		/// </summary>
		private RichTextBoxFinds GetOptions()
		{	RichTextBoxFinds rtbf = new RichTextBoxFinds();

				// Inicializa a ninguna opción de búsqueda
				rtbf = RichTextBoxFinds.None;
				// Añade la opción de coincidencia de mayúsculas y minúsculas
					if (chkMatchCase.Checked)
						rtbf = rtbf | RichTextBoxFinds.MatchCase;
				// Añade la opción de búsqueda de palabras completas
					if (this.chkWholeWord.Checked == true)
						rtbf = rtbf | RichTextBoxFinds.WholeWord;
				// Devuelve las opciones de búsqueda
					return rtbf;
		}

		/// <summary>
		///		Busca la siguiente aparición de una cadena
		/// </summary>
		private void SearchNext(string strFind)
		{ // Inicializa la posición
				if (intLastStop == -1) 
					intLastStop = 0;
			// Busca la cadena	
				intLastStop = ctlEditor.rtfEditor.Find(strFind, intLastStop, GetOptions());
			// Guarda la posición para la siguiente búsqueda
				if (intLastStop == -1)
          MessageBox.Show("Búsqueda finalizada");
        else
					intLastStop = intLastStop + strFind.Length; 
		}
		
    internal RtfTextEditor Editor
    {	set { ctlEditor = value; }
    }

    private void btnFindNext_Click(object sender, EventArgs e)
    { SearchNext(txtFindThis.Text);
    }
  }
}
