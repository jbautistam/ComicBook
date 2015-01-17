using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Controls.Forms;
using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data;

namespace Bau.Applications.ComicsBooks.Forms.Blog
{
	/// <summary>
	///		Formulario para mostrar las propiedades de un blog
	/// </summary>
	public partial class frmPropertiesBlog : Form
	{
		public frmPropertiesBlog()
		{ InitializeComponent();
		}
		
		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ LoadBlog();
		}
		
		/// <summary>
		///		Carga los datos del blog
		/// </summary>
		private void LoadBlog()
		{ if (Entry != null)
				{ txtName.Text = Entry.Text;
					txtDescription.Text = Entry.Description;
					txtURL.Text = Entry.URL;
					txtUser.Text = Entry.User;
					txtPassword.Text = Entry.Password;
					chkEnabled.Checked = Entry.Enabled;
				}
		}
		
		/// <summary>
		///		Comprueba si los datos son correctos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false; // ... supone que los datos no son correctos
		
				// Comprueba los datos
					if (string.IsNullOrEmpty(txtName.Text.Trim()))
						Helper.ShowMessage(this, "Introduzca el nombre del blog");
					else if (string.IsNullOrEmpty(txtURL.Text.Trim()))
						Helper.ShowMessage(this, "Introduzca la URL del blog");
					else
						blnValidate = true;
				// Devuelve el valor que indica si los datos son correctos
					return blnValidate;
		}
		
		/// <summary>
		///		Graba los datos
		/// </summary>
		private void Save()
		{ if (ValidateData())
				{ bool blnIsUpdated = (Entry != null && !Entry.URL.Equals(txtURL.Text));
				
						// Crea la entrada si es necesario
							if (Entry == null)
								Entry = new DesktopFilesEntry();
						// Pasa los datos del formulario al objeto
							Entry.Text = txtName.Text;
							Entry.URL = txtURL.Text;
							Entry.Description = txtDescription.Text;
							Entry.User = txtUser.Text;
							Entry.Password = txtPassword.Text;
							Entry.Enabled = chkEnabled.Checked;
						// Muestra un mensaje al usuario indicando que al cambier la URL se van a perder los otros feeds
							if (blnIsUpdated)
								Helper.ShowMessage(this, "Al cambiar el nombre de archivo se pierden los feeds anteriores");
						// Cierra el formulario indicando que se han realizado modificaciones
							DialogResult = DialogResult.OK;
							Close();
				}
		}
		
		/// <summary>
		///		Canal al que se asocia la entrada
		/// </summary>
		public DesktopFilesChannel Channel { get; set; }
		
		/// <summary>
		///		Entrada
		/// </summary>
		public DesktopFilesEntry Entry { get; set; }

		private void frmPropertiesBlog_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}
	}
}