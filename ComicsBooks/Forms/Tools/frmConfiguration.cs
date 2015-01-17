using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Applications.ComicsBooks.Classes;
using Bau.Libraries.LibHelper.API;

namespace Bau.Applications.ComicsBooks.Forms.Tools
{
	/// <summary>
	///		Formulario de configuración
	/// </summary>
	public partial class frmConfiguration : Form
	{
		public frmConfiguration()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Carga los datos asociados a la información del cómic
				chkAddFiles.Checked = Properties.Settings.Default.AddComicInfo;
			// Carga las extensiones vinculadas
				LoadLinkedExtensions();
			// Carga la configuración asociada al blog
				if (!string.IsNullOrEmpty(clsConfiguration.TemplateFeedsFileName))
					fnTemplateFeed.FileName = clsConfiguration.TemplateFeedsFileName;
				else
					fnTemplateFeed.FileName = clsConfiguration.TemplateFeedsFileNameDefault;
				chkDownloadBlog.Checked = clsConfiguration.DownloadBlogsAuto;
				nudDownloadInterval.Value = (decimal) clsConfiguration.DownloadInterval;
				chkMarkReadAuto.Checked = clsConfiguration.MarkReadPreview;
				nudMarkRead.Value = (decimal) clsConfiguration.MarkReadInterval;
				nudMarkNotUpdated.Value = (decimal) clsConfiguration.MarkNotUpdatesInterval;
			// Carga los datos del proxy
				chkUseProxy.Checked = Properties.Settings.Default.UseProxy;
				txtServer.Text = Properties.Settings.Default.ProxyIP;
				nudPort.Value = Properties.Settings.Default.ProxyPort;
				txtUser.Text = Properties.Settings.Default.ProxyUser;
				txtPassword.Text = Properties.Settings.Default.ProxyPassword;
				EnableProxyControls();
		}

		/// <summary>
		///		Habilita / inhabilita los controles de proxy
		/// </summary>
		private void EnableProxyControls()
		{	txtServer.Enabled = nudPort.Enabled = txtUser.Enabled = txtPassword.Enabled = chkUseProxy.Checked;
		}
		
		/// <summary>
		///		Carga las extensiones vinculadas
		/// </summary>
		private void LoadLinkedExtensions()
		{ chkLinkCBR.Checked = clsRegistry.ExistsLink(".cbr");
			chkLinkCBZ.Checked = clsRegistry.ExistsLink(".cbz");
			chkLinkCBT.Checked = clsRegistry.ExistsLink(".cbt");
			chkLinkEPub.Checked = clsRegistry.ExistsLink(".ePub");
		}
		
		/// <summary>
		///		Graba la configuración
		/// </summary>
		public void Save()
		{ // Asigna las propiedades de configuración
				Properties.Settings.Default.AddComicInfo = chkAddFiles.Checked;
			// Asigna las propiedades de los blogs
				if (!string.IsNullOrEmpty(fnTemplateFeed.FileName))
					clsConfiguration.TemplateFeedsFileName = fnTemplateFeed.FileName;
				else
					clsConfiguration.TemplateFeedsFileName = clsConfiguration.TemplateFeedsFileNameDefault;
				clsConfiguration.DownloadBlogsAuto = chkDownloadBlog.Checked;
				clsConfiguration.DownloadInterval = (int) nudDownloadInterval.Value;
				clsConfiguration.MarkReadPreview = chkMarkReadAuto.Checked;
				clsConfiguration.MarkReadInterval = (int) nudMarkRead.Value;
				clsConfiguration.MarkNotUpdatesInterval = (int) nudMarkNotUpdated.Value;
			// Asigna las propiedades del proxy
				Properties.Settings.Default.UseProxy = chkUseProxy.Checked;
				Properties.Settings.Default.ProxyIP = txtServer.Text;
				Properties.Settings.Default.ProxyPort = (int) nudPort.Value;
				Properties.Settings.Default.ProxyUser = txtUser.Text;
				Properties.Settings.Default.ProxyPassword = txtPassword.Text;
			// Graba la configuración del usuario
				Properties.Settings.Default.Save();
			// Vincula las extensiones
				SaveLinkedExtensions();
			// Copia la plantilla inicial
				Forms.Blog.Classes.TemplateManager.CopyFiles();
			// Cierra el formulario
				Close();
		}

		/// <summary>
		///		Graba la extensiones vinculadas
		/// </summary>
		private void SaveLinkedExtensions()
		{ LinkExtension(".cbr", chkLinkCBR.Checked);
			LinkExtension(".cbz", chkLinkCBZ.Checked);
			LinkExtension(".cbt", chkLinkCBT.Checked);
			LinkExtension(".ePub", chkLinkEPub.Checked);
		}
		
		/// <summary>
		///		Vincula una extensión
		/// </summary>
		private void LinkExtension(string strExtension, bool blnLink)
		{ try
				{	if (blnLink)
						clsRegistry.LinkExtension(strExtension, Application.ExecutablePath, "Bau.Applications.ComicBooks", "open", "ComicBook");
					else
						clsRegistry.DeleteLinkProgramExtension(strExtension);
				}
			catch (Exception objException)
				{ Program.Log("Error al asociar la extensión '" + strExtension + "'\n\tError:" + objException.Message);
				}
		}
		
		private void frmConfiguration_Load(object sender, EventArgs e)
		{ InitForm();
		}
		
		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}

		private void chkUseProxy_CheckedChanged(object sender, EventArgs e)
		{ EnableProxyControls();
		}
	}
}