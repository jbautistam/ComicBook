using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace Bau.Applications.ComicsBooks.Forms.Tools
{
	/// <summary>
	///		Formulario "Acerca de ..."
	/// </summary>
	partial class frmAbout : Form
	{
		public frmAbout()
		{	InitializeComponent();
		}

		#region Descriptores de acceso de atributos de ensamblado

		public string AssemblyTitle
		{
			get
			{
				// Obtener todos los atributos Title en este ensamblado
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				// Si hay al menos un atributo Title
				if (attributes.Length > 0)
				{
					// Seleccione el primero
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute) attributes[0];
					// Si no es una cadena vacía, devuélvalo
					if (titleAttribute.Title != "")
						return titleAttribute.Title;
				}
				// Si no había ningún atributo Title, o si el atributo Title era una cadena vacía, devuelva el nombre del archivo .exe
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				// Obtener todos los atributos de descripción de este ensamblado
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				// Si no hay ningún atributo de descripción, devuelva una cadena vacía
				if (attributes.Length == 0)
					return "";
				// Si hay un atributo de descripción, devuelva su valor
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				// Obtenga todos los atributos del producto de este ensamblado
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				// Si no hay atributos del producto, devuelva una cadena vacía
				if (attributes.Length == 0)
					return "";
				// Si hay un atributo de producto, devuelva su valor
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				// Obtenga todos los atributos de copyright de este ensamblado
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				// Si no hay atributos de copyright, devuelva una cadena vacía
				if (attributes.Length == 0)
					return "";
				// Si hay un atributo de copyright, devuelva su valor
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				// Obtenga todos los atributos de compañía en este ensamblado
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				// Si no hay ningún atributo de compañía, devuelva una cadena vacía
				if (attributes.Length == 0)
					return "";
				// Si hay un atributo de compañía, devuelva su valor
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{	Text = String.Format("Acerca de {0}", AssemblyTitle);
			labelProductName.Text = AssemblyProduct;
			labelVersion.Text = String.Format("Versión {0}", AssemblyVersion);
			labelCopyright.Text = AssemblyCopyright;
			labelCompanyName.Text = AssemblyCompany;
			textBoxDescription.Text = AssemblyDescription;
		}
		
		private void frmAbout_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void lnkWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{ Help.frmHelp frmNewHelp = new Help.frmHelp();
		
				// Asigna la página
					frmNewHelp.IDData = (sender as LinkLabel).Text;
				// Abre la página
					Program.MainWindow.OpenWindowDocument(frmNewHelp);
				// Cierre este formulario
					Close();
		}
	}
}
