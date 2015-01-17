using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibComicsBooks.Definition;

namespace Bau.Applications.ComicsBooks.Forms.Comic
{
	/// <summary>
	///		Información sobre un cómic
	/// </summary>
	public partial class frmComicInfo : Form
	{ // Variables privadas
			private string strFileName;
			private ComicInfo objComicInfo;
			
		public frmComicInfo()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Cambia el título
				Text = "Información de " + System.IO.Path.GetFileName(strFileName);
			// Carga la información
				LoadInfo(Info);
		}

		/// <summary>
		///		Carga la información
		/// </summary>
		private void LoadInfo(ComicInfo objComicInfo)
		{ // Datos generales
				txtTitle.Text = objComicInfo.Title;
				txtSerie.Text = objComicInfo.Serie;
				txtNumber.Text = objComicInfo.Number;
				txtTotal.Text = objComicInfo.NumberTotal;
				txtDate.Text = objComicInfo.DatePublish;
				txtGenre.Text = objComicInfo.Genre;
				txtAuthor.Text = objComicInfo.Author;
				txtEditorial.Text = objComicInfo.Editorial;
				txtDraw.Text = objComicInfo.Drawer;
				txtEditor.Text = objComicInfo.Editor;
				txtCategories.Text = objComicInfo.Categories;
			// Notas
				txtSummary.Text = objComicInfo.Summary;
				txtNotes.Text = objComicInfo.Notes;
		}		
		
		/// <summary>
		///		Graba la información
		/// </summary>
		private void Save()
		{ // Pasa los datos al objeto
				Info.ComicFileName = FileName;
				Info.Title = txtTitle.Text;
				objComicInfo.Serie = txtSerie.Text;
				objComicInfo.Number = txtNumber.Text;
				objComicInfo.NumberTotal = txtTotal.Text;
				objComicInfo.DatePublish = txtDate.Text;
				objComicInfo.Genre = txtGenre.Text;
				objComicInfo.Author = txtAuthor.Text;
				objComicInfo.Editorial = txtEditorial.Text;
				objComicInfo.Drawer = txtDraw.Text;
				objComicInfo.Editor = txtEditor.Text;
				objComicInfo.Categories = txtCategories.Text;
				Info.Summary = txtSummary.Text;
				Info.Notes = txtNotes.Text;
			// Cierra el formulario
				DialogResult = DialogResult.OK;
				Close();
		}
		
		public string FileName
		{ get { return strFileName; }
			set { strFileName = value; }
		}
		
		public ComicInfo Info
		{ get { return objComicInfo; }
			set { objComicInfo = value; }
		}

		private void frmComicInfo_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}
	}
}