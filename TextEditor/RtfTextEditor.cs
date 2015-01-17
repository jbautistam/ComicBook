using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bau.Controls.Text
{
	/// <summary>
	///		Control de texto RTF
	/// </summary>
  public partial class RtfTextEditor : UserControl
  {	// Eventos públicos
			public event EventHandler Changed;
		// Enumerados privadas
			private enum FontAssignType
				{ Unknown,
					Assign,
					UnAssign
				}
		// Constantes privadas
			private const string cnstStrMaskFile = "RTF (*.rtf)|*.rtf|TXT (*.txt)|*.txt";
			private const string cnstStrMaskImage = "Imágenes|*.png;*.bmp;*.gif;*.tif;*.tiff,*.wmf;*.emf";
		// Variables privadas
			private string strFileNameEditor = "";
			private int intCheckPrint = 0;

    public RtfTextEditor()
    {	// Iniciailiza el componente
				InitializeComponent();
			// Carga el combo de fuentes
				LoadComboFonts();
			// Inicializa el control
				Clear();
    }

		/// <summary>
		///		Limpia el control
		/// </summary>
    public void Clear()
    {	// Limpia el editor
        rtfEditor.Clear();
			// Establece la indentación a las posiciones predeterminadas
				udtRuler.LeftIndent = 1;
				udtRuler.LeftHangingIndent = 1;
				udtRuler.RightIndent = 1;
      // Limpia las tabulaciones de la regla
				udtRuler.SetTabPositionsInPixels(null);
				rtfEditor.SelectionTabs = null;
			// Limpia el nombre del archivo
				FileName = "";
      // Selecciona el primer carácter (provoca el evento SelectionChange)
				rtfEditor.Select(0, 0);
    }

		/// <summary>
		///		Carga el combo de fuentes
		/// </summary>
		private void LoadComboFonts()
		{	using (System.Drawing.Text.InstalledFontCollection objColFonts = new System.Drawing.Text.InstalledFontCollection())
				{	// Limpia el combo de fuentes
						cboFontName.Items.Clear();
					// Añade el nombre de las fuentes al combo
						foreach (FontFamily ff in objColFonts.Families)
							cboFontName.Items.Add(ff.Name);
				}
		}
		
		/// <summary>
		///		Abre un cuadro de diálogo para solicitar un nombre de archivo a abrir
		/// </summary>
    private string GetFileNameOpen(bool blnImage)
    {	using (OpenFileDialog fdOpen = new OpenFileDialog())
				{	// Asigna las propiedades
						fdOpen.Multiselect = false;
						fdOpen.ShowReadOnly = false;
						fdOpen.ReadOnlyChecked = false;
						if (blnImage)
							fdOpen.Filter = cnstStrMaskImage;
						else
							fdOpen.Filter = cnstStrMaskFile;
					// Solicita el nombre de archivo al usuario
						if (fdOpen.ShowDialog(this) == DialogResult.OK)
							return fdOpen.FileName;
						else
							return "";
				}
    }
    
    /// <summary>
    ///		Abre un cuadro de diálogo para solicitar un nombre de archivo a grabar
    /// </summary>
    private string GetFileNameSave()
    {	SaveFileDialog fdSave = new SaveFileDialog();            
    
				// Asigna las propiedades
					fdSave.Filter = cnstStrMaskFile;
				// Solicita el nombre del archivo al usuario
					if (fdSave.ShowDialog(this) == DialogResult.OK)
						return fdSave.FileName;
					else
						return "";
    }
		
		/// <summary>
		///		Abre un archivo
		/// </summary>
    public void OpenFile()
    {	string strFileName = GetFileNameOpen(false);

        if (!string.IsNullOrEmpty(strFileName))
					OpenFile(strFileName);
    }

		/// <summary>
		///		Abre un archivo
		/// </summary>
		public void OpenFile(string strFileName)
		{ // Limpia el editor
				Clear();
			// Intenta cargar el archivo como un RTF y si no puede intenta cargarlo como texto
				try 
					{	// Carga el archivo
							rtfEditor.Rtf = System.IO.File.ReadAllText(strFileName, System.Text.Encoding.Default);
						// Guarda el nombre del archivo
							FileName = strFileName;
					}
				catch (Exception) 
					{	// Carga el archivo
							rtfEditor.Text = System.IO.File.ReadAllText(strFileName, System.Text.Encoding.Default);
						// Guarda el nombre del archivo
							FileName = strFileName;
					}
		}
		    
    /// <summary>
    ///		Guarda en un archivo el contenido del editor
    /// </summary>
    public void SaveFile(bool blnSaveAs)
    { string strFileName = "";
    
				// Obtiene el archivo si no existía o se desea cambiar el nombre
					if (blnSaveAs || string.IsNullOrEmpty(strFileNameEditor))
						strFileName = GetFileNameSave();
					else
						strFileName = FileName;
				// Graba el archivo (si tenemos nombre)
					if (!string.IsNullOrEmpty(strFileName))
						SaveFile(strFileName);
    }

		/// <summary>
		///		Graba un archivo
		/// </summary>
		public void SaveFile(string strFileName)
		{ // Graba el archivo
				rtfEditor.SaveFile(strFileName, RichTextBoxStreamType.RichText);
			// Guarda el nombre
				FileName = strFileName;
		}
    
    /// <summary>
    ///		Obtiene un color utilizando el cuadro de diálogo
    /// </summary>
    private Color GetColor(Color initColor)
    {	using (ColorDialog fdColor = new ColorDialog())
        {	fdColor.Color = initColor;
          fdColor.AllowFullOpen = true;
          fdColor.AnyColor = true;
          fdColor.FullOpen = true;
          fdColor.ShowHelp = false;
          fdColor.SolidColorOnly = false;
          if (fdColor.ShowDialog() == DialogResult.OK)
						return fdColor.Color;
          else
						return initColor;
        }            
    }
    
    /// <summary>
    ///		Añade texto al control
    /// </summary>
    public void AppendText(string strText)
    {	rtfEditor.AppendText(strText);
    }
    
		/// <summary>
		///		Añade una imagen
		/// </summary>
		public void AppendImage()
		{ AppendImage(GetFileNameOpen(true));
		}

    /// <summary>
    ///		Añade una imagen
    /// </summary>
    public void AppendImage(string strFileName)
    {	if (!string.IsNullOrEmpty(strFileName))
				AppendImage(Image.FromFile(strFileName));
    }
    
    /// <summary>
    ///		Añade una imagen
    /// </summary>
    public void AppendImage(Image imgImage)
    {	using (Image imgTemporal = Clipboard.GetImage())
				{	// Limpia el portapapeles
						Clipboard.Clear();			
					// Pasa la imagen al portapapeles
							Clipboard.SetImage(imgImage);
					// Pasa la imagen al editor
						rtfEditor.Paste(DataFormats.GetFormat(DataFormats.Bitmap));
					// Devuelve la imagen al portapapeles
						if (imgTemporal != null)
								Clipboard.SetImage(imgTemporal);
				}
    }
    
    /// <summary>
    ///		Corta el texto seleccionado del editor
    /// </summary>
		public void Cut()
		{ rtfEditor.Cut();
		}
    
    /// <summary>
    ///		Copia el texto seleccionado del editor
    /// </summary>
    public void Copy()
    { rtfEditor.Copy();
    }

		/// <summary>
		///		Pega el texto seleccionado del editor
		/// </summary>
		public void Paste()
		{ rtfEditor.Paste();
		}

		/// <summary>
		///		Deshace una acción
		/// </summary>
		public void Undo()
		{ rtfEditor.Undo();
		}
		
		/// <summary>
		///		Repite una acción
		/// </summary>
		public void Redo()
		{ rtfEditor.Redo();
		}
		
		/// <summary>
		///		Configura el formato de impresión
		/// </summary>
		public void ConfigurePageSettings()
		{ PageSettings.ShowDialog(this);
		}
		
		/// <summary>
		///		Configura los botones
		/// </summary>
		private void SetButtons()
		{	// Alineación
				cmdAlignLeft.Checked = rtfEditor.SelectionAlignment == HorizontalAlignment.Left;
				cmdAlignCenter.Checked = rtfEditor.SelectionAlignment == HorizontalAlignment.Center;
				cmdAlignRight.Checked = rtfEditor.SelectionAlignment == HorizontalAlignment.Right;
			// Tabulaciones
        udtRuler.SetTabPositionsInPixels(rtfEditor.SelectionTabs);
			// Indentación (convierte los pixels en milímetros)
        if (rtfEditor.SelectionHangingIndent > 0)
          udtRuler.LeftHangingIndent = (int) (rtfEditor.SelectionHangingIndent / 3.775f); 
				if (rtfEditor.SelectionIndent > 0)
					udtRuler.LeftIndent = (int) (rtfEditor.SelectionIndent / 3.775f);
        if (rtfEditor.SelectionRightIndent > 0)
          udtRuler.RightIndent = (int) (rtfEditor.SelectionRightIndent / 3.775f);
      // Fuente
        try
					{	cboFontSize.Text = Convert.ToInt32(rtfEditor.SelectionFont.Size).ToString();
					}
        catch
					{	cboFontSize.Text = "";
					}
				try
					{	cboFontName.Text = rtfEditor.SelectionFont.Name;
					}
        catch
					{	cboFontName.Text = "";
					}
        if (!string.IsNullOrEmpty(cboFontName.Text))
					{ using (FontFamily ff = new FontFamily(this.cboFontName.Text))
							{	// Negrita
									cmdBold.Enabled = ff.IsStyleAvailable(FontStyle.Bold);
									cmdBold.Checked = cmdBold.Enabled && rtfEditor.SelectionFont.Bold;
								// Cursiva
									cmdItalic.Enabled = ff.IsStyleAvailable(FontStyle.Italic);
									cmdItalic.Checked = rtfEditor.SelectionFont.Italic;
								// Subrayado
									cmdUnderline.Enabled = ff.IsStyleAvailable(FontStyle.Underline);
									cmdUnderline.Checked = rtfEditor.SelectionFont.Underline;
								// Tachado
									cmdStrikeThrough.Enabled = ff.IsStyleAvailable(FontStyle.Strikeout);
									cmdStrikeThrough.Checked = rtfEditor.SelectionFont.Strikeout;
							}
					}
        else
					{	cmdBold.Checked = false;
						cmdItalic.Checked = false;
						cmdUnderline.Checked = false;
						cmdStrikeThrough.Checked = false;
					}
		}

		/// <summary>
		///		Obtiene el estilo de la fuente
		/// </summary>
		private FontStyle GetFontStyle(FontAssignType intBold, FontAssignType intItalic, FontAssignType intUnderline,
																	 FontAssignType intStrikeThroug)
    {	FontStyle fs = new FontStyle();

				// Inicializa el estilo
					fs = FontStyle.Regular;
				// Asigna los estilos
					if (rtfEditor.SelectionFont != null)
						{	if (intBold != FontAssignType.UnAssign && 
										(rtfEditor.SelectionFont.Bold || intBold == FontAssignType.Assign))
								fs = fs | FontStyle.Bold;
							if (intItalic != FontAssignType.UnAssign && 
										(rtfEditor.SelectionFont.Italic || intItalic == FontAssignType.Assign))
								fs = fs | FontStyle.Italic;
							if (intUnderline != FontAssignType.UnAssign && 
										(rtfEditor.SelectionFont.Underline || intUnderline == FontAssignType.Assign))
								fs = fs | FontStyle.Underline;
							if (intStrikeThroug != FontAssignType.UnAssign && 
										(rtfEditor.SelectionFont.Strikeout || intStrikeThroug == FontAssignType.Assign) )
								fs = fs | FontStyle.Strikeout;
						}
				// Devuelve el estilo
					return fs;
    }

		/// <summary>
		///		Obtiene la fuente seleccionada
		/// </summary>
		public Font SelectionFont()
		{ return rtfEditor.SelectionFont;
		}
		
		/// <summary>
		///		Cambia la fuente seleccionada utilizando un cuadro de diálogo para seleccionar el formato
		/// </summary>
		public void SetFontWithDialog()
		{	using (FontDialog dlgFont = new FontDialog())
        {	// Inicializa las propiedades
            dlgFont.Font = rtfEditor.SelectionFont;
            dlgFont.AllowSimulations = true;
            dlgFont.AllowVectorFonts = true;
            dlgFont.AllowVerticalFonts = true;
            dlgFont.FontMustExist = true;
            dlgFont.ShowHelp = false;
            dlgFont.ShowEffects = true;
            dlgFont.ShowColor = false;
            dlgFont.ShowApply = false;
            dlgFont.FixedPitchOnly = false;
					// Cambia la fuente
            if (dlgFont.ShowDialog() == DialogResult.OK)
							SetFont(dlgFont.Font);
        }
		}
		
		/// <summary>
		///		Cambia la fuente según los datos seleccionados
		/// </summary>
		private void SetFont()
		{ SetFont(FontAssignType.Unknown, FontAssignType.Unknown, 
							FontAssignType.Unknown, FontAssignType.Unknown);
		}
		
		/// <summary>
		///		Cambia la fuente según los datos seleccionados
		/// </summary>
		private void SetFont(FontAssignType intBold, FontAssignType intItalic, FontAssignType intUnderLine,
												 FontAssignType intStrikeThrough)
		{ float fltSize;
		
				// Obtiene el tamaño
					if (!float.TryParse(cboFontSize.Text, out fltSize))
						fltSize = 8;
				// Cambia la fuente
					if (!string.IsNullOrEmpty(cboFontName.Text))
						SetFont(cboFontName.Text, fltSize, GetFontStyle(intBold, intItalic, intUnderLine, intStrikeThrough));
		}
		
		/// <summary>
		///		Cambia la fuente
		/// </summary>
		public void SetFont(string strFontName, float fltSize)
		{ SetFont(strFontName, fltSize, rtfEditor.SelectionFont.Style);
		}
		
		/// <summary>
		///   Cambia la fuente
		/// </summary>
		public void SetFont(string strFontName, float fltSize, bool blnBold, bool blnItalic, 
												bool blnUnderline, bool blnStrikeThrough)
		{	SetFont(strFontName, fltSize, GetFontStyle(GetFontAssign(blnBold), GetFontAssign(blnItalic), 
																								 GetFontAssign(blnUnderline), GetFontAssign(blnStrikeThrough))); 
		}
		
		/// <summary>
		///   Cambia la fuente
		/// </summary>
		public void SetFont(bool blnBold, bool blnItalic, bool blnUnderline, bool blnStrikeThrough)
		{	SetFont(GetFontAssign(blnBold), GetFontAssign(blnItalic), GetFontAssign(blnUnderline), GetFontAssign(blnStrikeThrough)); 
		}
		
		/// <summary>
		///   Cambia la fuente
		/// </summary>
		public void SetFont(string strFontName, float fltSize, FontStyle fstFont)
		{	try
				{	SetFont(new Font(strFontName, fltSize, fstFont));

				}
			catch {}
		}
		
		/// <summary>
		///		Cambia la fuente
		/// </summary>
		public void SetFont(Font fntFont)
		{ try
				{	rtfEditor.SelectionFont = fntFont;
				}
			catch {}
		}
		
		/// <summary>
		///		Obtiene el tipo de asignación de fuente a partir de un dato lógico
		/// </summary>
		private FontAssignType GetFontAssign(bool blnAssign)
		{ if (blnAssign)
				return FontAssignType.Assign;
			else
				return FontAssignType.UnAssign;
		}

		/// <summary>
		///		Cambia el color del texto
		/// </summary>
		public void SetForeColor()
		{ rtfEditor.SelectionColor = GetColor(rtfEditor.SelectionColor);
		}

		/// <summary>
		///		Cambia la alineación
		/// </summary>
		public void SetAlignment(HorizontalAlignment intAlign)
		{ // Cambia la alineación
				rtfEditor.SelectionAlignment = intAlign;
			// Cambia los botones
				cmdAlignLeft.Checked = rtfEditor.SelectionAlignment == HorizontalAlignment.Left;
				cmdAlignRight.Checked = rtfEditor.SelectionAlignment == HorizontalAlignment.Right;
				cmdAlignCenter.Checked = rtfEditor.SelectionAlignment == HorizontalAlignment.Center;
		}
		
		/// <summary>
		///		Cambia el color del fondo
		/// </summary>
		public void SetBackColor()
		{	rtfEditor.SelectionBackColor = GetColor(rtfEditor.SelectionBackColor);
		}        

		/// <summary>
		///		Cambia los tabuladores del editor a los tabuladores de la regla
		/// </summary>
		private void SetTabs()
    {	try
        {	rtfEditor.SelectionTabs = udtRuler.TabPositionsInPixels.ToArray();
        }
      catch {}
    }

		/// <summary>
		///		Comienza la búsqueda de una cadena
		/// </summary>
		public void Search()
    {	Dialogs.dlgFind frmNewSearch = new Dialogs.dlgFind();
    
				// Inicializa el formulario
					frmNewSearch.txtFindThis.Text = rtfEditor.SelectedText;
					frmNewSearch.Editor = this;
				// Muestra el formulario
					frmNewSearch.Show(this);
    }
    
		/// <summary>
		///		Convierte el texto RTF en HTML
		/// </summary>
		public string GetHTML()
		{ bool blnBold = false, blnUnderline = false, blnStrikeThru = false;
			bool blnItalic = false;
			Color colLastColor = Color.Black;
			HorizontalAlignment intLastAlignment = HorizontalAlignment.Left;
			string strHTML = "";
		
				for (int intIndex = 0; intIndex < rtfEditor.TextLength; intIndex++)
					{ // Selecciona el carácter correspondiente
							rtfEditor.Select(intIndex, 1);
						// Alineación
							if (intLastAlignment != rtfEditor.SelectionAlignment)
								{	// Crea un párrafo con la alineación adecuada
										switch (rtfEditor.SelectionAlignment)
											{ case HorizontalAlignment.Left:
														strHTML += "<p align = left>";
													break;
												case HorizontalAlignment.Center:
														strHTML += "<p align = center>";
													break;
												case HorizontalAlignment.Right:
														strHTML += "<p align = right>";
													break;
											}
									// Guarda la alineación
										intLastAlignment = rtfEditor.SelectionAlignment;
								}
						// Negrita
							if (blnBold != rtfEditor.SelectionFont.Bold)
								{ // Abre / cierra el tag HTML
										if (rtfEditor.SelectionFont.Bold)
											strHTML += "<b>";
										else
											strHTML += "</b>";
									// Guarda el estado
										blnBold = rtfEditor.SelectionFont.Bold;
								}
						// Cursiva
							if (blnItalic != rtfEditor.SelectionFont.Italic)
								{ if (blnItalic = rtfEditor.SelectionFont.Italic)
										strHTML += "<i>";
									else
										strHTML += "</i>";
								}
						// Subrayado
							if (blnUnderline != rtfEditor.SelectionFont.Underline)
								{ if (blnUnderline = rtfEditor.SelectionFont.Underline)
										strHTML += "<u>";
									else
										strHTML += "</u>";
								}
						// Tachado
							if (blnStrikeThru != rtfEditor.SelectionFont.Strikeout)
								{ if (blnStrikeThru = rtfEditor.SelectionFont.Strikeout)
										strHTML += "<s>";
									else
										strHTML += "</s>";
								}
						// Fuente
							//if (strLastFont != rtfEditor.SelectionFont.Name)
							//  { if (strLastFont != "")
							//      strHTML += "</font>";
							//    strLastFont = rtfEditor.SelectionFont.Name;
							//    strHTML += "<font face='" + strLastFont + "'>";
							//  }
						// Color
		//					if (colLastColor != rtfEditor.SelectionColor)
		//            lngLastFontColor& = rtbRichTextBox.SelColor
		//            
		//            ''Get hexidecimal value of color
		//            strHex$ = Hex(rtbRichTextBox.SelColor)
		//            strHex$ = String$(6 - Len(strHex$), "0") & strHex$
		//            strHex$ = Right$(strHex$, 2) & Mid$(strHex$, 3, 2) & Left$(strHex$, 2)
		//            
		//            strHTML$ = strHTML$ + "<font color=#" & strHex$ & ">"
		//        End If
						// Añade el texto seleccionado a la cadena de salida
							strHTML += rtfEditor.SelectedText;
					}
				// Devuelve la cadena HTML
					return strHTML;
		}
		
		/// <summary>
		///		Imprime el contenido del RTF
		/// </summary>
		public void Print(bool blnPreview)
		{ if (blnPreview)
				DocPreview.ShowDialog(this);
			else
				PrintWnd.ShowDialog(this);
		}
		
		/// <summary>
		///		Modifica el aspecto de la tabla
		/// </summary>
		private void UpdateLayout()
		{	// Pone a 0 el alto de las filas no visibles
				if (BarFilesVisible)
					tblEditorLayout.RowStyles[0].Height = 26;
				else
					tblEditorLayout.RowStyles[0].Height = 0;
				if (BarFormatVisible)
					tblEditorLayout.RowStyles[1].Height = 26;
				else
					tblEditorLayout.RowStyles[1].Height = 0;
				if (RulerVisible)
					tblEditorLayout.RowStyles[2].Height = 20;
				else
					tblEditorLayout.RowStyles[2].Height = 0;
					
					tblEditorLayout.RowStyles[0].SizeType = SizeType.Absolute;
			// Actualiza la visualización de la tabla
				tblEditorLayout.Refresh();
		}
		
		[Description("Muestra / oculta la regla"), DefaultValue(true)]
		public bool RulerVisible
		{ get { return udtRuler.Visible; } 
			set 
				{ udtRuler.Visible = value; 
					UpdateLayout();
				}
		}
		
		[Description("Muestra / oculta la barra de herramientas de edición"), DefaultValue(true)]
		public bool BarFilesVisible
		{ get { return tlbFiles.Visible; }
			set 
				{ tlbFiles.Visible = value; 
					UpdateLayout();
				}
		}
		
		[Description("Muestra / oculta la barra de herramientas del formato"), DefaultValue(true)]
		public bool BarFormatVisible
		{ get { return tlbFormat.Visible; }
			set 
				{ tlbFormat.Visible = value; 
					UpdateLayout();
				}
		}

		[Browsable(false)]
		public string PlainText
		{ get { return rtfEditor.Text; }
			set { rtfEditor.Text = value; }
		}
		
		[Browsable(false)]
		public override string Text
		{ get { return rtfEditor.Rtf; }
			set 
				{ try
						{	rtfEditor.Rtf = value; 
						}
					catch 
						{ rtfEditor.Text = value;
						}
				}
		}
				
		[Browsable(false)]
		public string FileName
		{ get { return strFileNameEditor; }
			private set { strFileNameEditor = value; }
		}

		[Browsable(true),DefaultValue(false)]
		public bool ReadOnly
		{ get { return rtfEditor.ReadOnly; }
			set 
				{ rtfEditor.ReadOnly = value;
					if (rtfEditor.ReadOnly)
						{ BarFormatVisible = false;
							BarFilesVisible = false;
							RulerVisible = false;
						}
				}
		}
		
    private void RtfTextEditor_Load(object sender, EventArgs e)
    {	Clear();
    }

    private void rtfEditor_SelectionChanged(object sender, EventArgs e)
    {	SetButtons();
    }

    private void rtfEditor_KeyDown(object sender, KeyEventArgs e)
    {	if (e.Control)
				{	if (e.KeyCode == Keys.B)
						cmdBold.PerformClick();
					else if (e.KeyCode == Keys.I)
            cmdItalic.PerformClick();
					else if (e.KeyCode == Keys.U)
						cmdUnderline.PerformClick();
        }
    }

    private void cboFontName_SelectedIndexChanged(object sender, EventArgs e)
    { SetFont();
    }

    private void cboFontName_KeyUp(object sender, KeyEventArgs e)
    {	if (e.KeyCode == Keys.Enter)
        {	SetFont();
          rtfEditor.Focus();
        }
    }

    private void cboFontSize_SelectedIndexChanged(object sender, EventArgs e)
    {	SetFont();
    }

    private void cboFontSize_KeyUp(object sender, KeyEventArgs e)
    {	if (e.KeyCode == Keys.Enter)
				try
					{	SetFont();
						rtfEditor.Focus();
					}
				catch {}
    }

    private void cboFontSize_KeyDown(object sender, KeyEventArgs e)
    {	e.SuppressKeyPress = !(e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
														 e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
														 e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
														 e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 ||
														 e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 ||
														 e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 ||
														 e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.Back ||
														 e.KeyCode == Keys.Enter || e.KeyCode == Keys.Delete);
    }

    private void udtRuler_LeftIndentChanging(int NewValue)
    {	try
				{	rtfEditor.SelectionHangingIndent = (int)(udtRuler.LeftHangingIndent * 3.775f) - (int)(udtRuler.LeftIndent * 3.775f);
					rtfEditor.SelectionIndent = (int)(udtRuler.LeftIndent * 3.775f);                
				}
      catch {}
    }

    private void udtRuler_LeftHangingIndentChanging(int NewValue)
    {	try
        {	rtfEditor.SelectionHangingIndent = (int)(udtRuler.LeftHangingIndent * 3.775f) - (int)(udtRuler.LeftIndent * 3.775f);
        }
			catch {}
    }

    private void udtRuler_RightIndentChanging(int NewValue)
    {	try
        {	rtfEditor.SelectionRightIndent = (int)(udtRuler.RightIndent * 3.775f);
        }
      catch {}
    }
    
    private void udtRuler_TabAdded(TextRulerControl.TextRuler.TabEventArgs args)
		{ SetTabs();
		}

    private void udtRuler_TabChanged(TextRulerControl.TextRuler.TabEventArgs args)
		{ SetTabs();
		}

    private void udtRuler_TabRemoved(TextRulerControl.TextRuler.TabEventArgs args)
		{ SetTabs();
		}

		private void cmdNew_Click(object sender, EventArgs e)
		{ Clear();
		}

		private void cmdOpen_Click(object sender, EventArgs e)
		{ OpenFile();
		}

		private void cmdSave_Click(object sender, EventArgs e)
		{ SaveFile(false);

		}

		private void cmdSaveAs_Click(object sender, EventArgs e)
		{ SaveFile(true);
		}
		
		private void cmdPrint_Click(object sender, EventArgs e)
		{ Print(false);
		}

		private void cmdPrintPreview_Click(object sender, EventArgs e)
		{ Print(true);
		}

		private void cmdCut_Click(object sender, EventArgs e)
		{ Cut();
		}

		private void cmdCopy_Click(object sender, EventArgs e)
		{ Copy();
		}

		private void cmdPaste_Click(object sender, EventArgs e)
		{ Paste();
		}

		private void cmdUndo_Click(object sender, EventArgs e)
		{	Undo();
		}

		private void cmdRedo_Click(object sender, EventArgs e)
		{	Redo();
		}

		private void cmdBold_Click(object sender, EventArgs e)
    {	cmdBold.Checked = !rtfEditor.SelectionFont.Bold;
			SetFont(GetFontAssign(cmdBold.Checked), FontAssignType.Unknown, FontAssignType.Unknown, FontAssignType.Unknown);
    }

		private void cmdItalic_Click(object sender, EventArgs e)
    {	cmdItalic.Checked = !rtfEditor.SelectionFont.Italic;
			SetFont(FontAssignType.Unknown, GetFontAssign(cmdItalic.Checked), FontAssignType.Unknown, FontAssignType.Unknown);
    }

		private void cmdUnderline_Click(object sender, EventArgs e)
    {	cmdUnderline.Checked = !rtfEditor.SelectionFont.Underline;
			SetFont(FontAssignType.Unknown, FontAssignType.Unknown, GetFontAssign(cmdUnderline.Checked), FontAssignType.Unknown);
    }

		private void cmdStrikeThrough_Click(object sender, EventArgs e)
    {	cmdStrikeThrough.Checked = !rtfEditor.SelectionFont.Strikeout;
			SetFont(FontAssignType.Unknown, FontAssignType.Unknown, FontAssignType.Unknown, GetFontAssign(cmdStrikeThrough.Checked));
    }

		private void cmdAlignLeft_Click(object sender, EventArgs e)
    {	SetAlignment(HorizontalAlignment.Left);
    }

		private void cmdAlignCenter_Click(object sender, EventArgs e)
    {	SetAlignment(HorizontalAlignment.Center);
    }

		private void cmdAlignRight_Click(object sender, EventArgs e)
    {	SetAlignment(HorizontalAlignment.Right);
    }

		private void cmdForeColor_Click(object sender, EventArgs e)
		{ SetForeColor();
		}

		private void cmdBackColor_Click(object sender, EventArgs e)
		{ SetBackColor();
		}
		
    private void prtDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {	intCheckPrint = rtfEditor.Print(intCheckPrint, rtfEditor.TextLength, e);
			if (intCheckPrint < rtfEditor.TextLength)
				e.HasMorePages = true;
      else
				e.HasMorePages = false;        
    }

    private void prtDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {	intCheckPrint = 0;
    }

		private void cmdSearch_Click(object sender, EventArgs e)
		{ Search();
		}

		private void cmdSetFont_Click(object sender, EventArgs e)
		{ SetFontWithDialog();
		}

		private void rtfEditor_TextChanged(object sender, EventArgs e)
		{ if (Changed != null)
				Changed(this, e);
		}
	}
}
