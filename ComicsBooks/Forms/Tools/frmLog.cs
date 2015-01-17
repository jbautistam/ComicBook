using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Bau.Controls.TextBox;
using Bau.Libraries.LibHelper;
using Bau.Controls.Forms;

namespace Bau.Applications.ComicsBooks.Forms.Tools
{
	/// <summary>
	///		Formulario para mostrar el log de acciones del usuario
	/// </summary>
	public partial class frmLog : WeifenLuo.WinFormsUI.Docking.DockContent
	{	// Delegados
			// private delegate void ShowLogItemCallback(clsLogItem objLogItem); // Permite llamadas asíncronas para añadir un elemento
			
		public frmLog()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{	// Añade la rutina de tratamiento del log a la clase Helper
			//	clsHelperLog.FunctionCallback = LogItemAddCallback;
		}
/*						
		/// <summary>
		///		Muestra los registros de log
		/// </summary>
		private void ShowLog()
		{ // Vacía el log
				rtfLog.Text = "";
			// Recorre la colección mostrando los elementos
				for (int intIndex = clsHelperLog.LogItems.Count - 1; intIndex >= 0; intIndex--)
					ShowLogItem(clsHelperLog.LogItems[intIndex]);
		}

		/// <summary>
		///		Rutina que trata los eventos de añadir un elemento al log
		/// </summary>
		private void LogItemAddCallback(clsLogItem objLogItem)
		{ ShowLogItem(objLogItem);
		}

		/// <summary>
		///		Muestra un evento de log
		/// </summary>
		private void ShowLogItem(clsLogItem objLogItem)
		{ // InvokeRequired compara el ID del hilo llamante con el ID del hilo creador, si son diferentes devuelve True
				if (this.InvokeRequired)
					{	ShowLogItemCallback fncCallback = new ShowLogItemCallback(ShowLogItem);
					
							Invoke(fncCallback, new object[] { objLogItem });
					}
				else
					{	// Añade un salto de línea
							rtfLog.AppendText("\n");
						// Dependiendo del tipo cambia el icono y el color
							switch (objLogItem.Type)
								{ case clsHelperLog.LogItemType.Debug:
											rtfLog.InsertImage(global::Bau.Applications.ComicsBooks.Properties.Resources.information);
										break;
									case clsHelperLog.LogItemType.Error:
											rtfLog.InsertImage(global::Bau.Applications.ComicsBooks.Properties.Resources.exclamation);
										break;
								}
						// Añade la fecha
							rtfLog.AppendTextAsRtf(string.Format("{0:dd-MM-yyyy HH:mm}", objLogItem.DateLog) + "\n", 
																		 RtfColor.Gray);
						// Añade la descripción
							rtfLog.AppendTextAsRtf(objLogItem.Description);
						// Añade la excepción
							if (objLogItem.ExceptionLog != null)
								{ rtfLog.AppendTextAsRtf(objLogItem.ExceptionLog.Message + "\n", RtfColor.Red);
									rtfLog.AppendTextAsRtf(objLogItem.ExceptionLog.StackTrace.ToString() + "\n", RtfColor.Red);
								}
						// Se coloca al final
							rtfLog.Select(rtfLog.TextLength, 0);
					}
		}
		
		/// <summary>
		///		Graba el log
		/// </summary>
		private void Save()
		{ string strFileName;
		
				// Obtiene el nombre del archivo
					strFileName = Helper.GetFileNameSave("Archivos rtf (*.rtf)|*.rtf|Todos los archivos (*.*)|*.*");
				// Graba el archivo RTF
					if (strFileName != "")
						rtfLog.SaveFile(strFileName, RichTextBoxStreamType.RichText);
		}
*/		
		private void frmLog_Load(object sender, EventArgs e)
		{ // Inicializa el formulario
				InitForm();
			// ... y carga el log
			//	ShowLog();
		}

		private void cmdTlbClear_Click(object sender, EventArgs e)
		{ rtfLog.Text = "";
		}

		private void cmdTlbSave_Click(object sender, EventArgs e)
		{ // Save();
		}
	}
}