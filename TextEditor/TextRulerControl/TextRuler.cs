using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Bau.Controls.Text.TextRulerControl
{
	/// <summary
	///		Control para mostrar una regla sobre el cuadro de edición
	/// </summary>
	internal partial class TextRuler : UserControl
  {	// Delegados
      public delegate void IndentChangedEventHandler(int NewValue);
      public delegate void MarginChangedEventHandler(int NewValue);
      public delegate void TabChangedEventHandler(TabEventArgs args);
		// Eventos
      public event IndentChangedEventHandler LeftHangingIndentChanging;
      public event IndentChangedEventHandler LeftIndentChanging;
      public event IndentChangedEventHandler RightIndentChanging;
      public event MarginChangedEventHandler LeftMarginChanging;
      public event MarginChangedEventHandler RightMarginChanging;
      public event TabChangedEventHandler TabAdded;
      public event TabChangedEventHandler TabRemoved;
      public event TabChangedEventHandler TabChanged;
		// Enumerados
      internal enum ControlItems
				{	LeftIndent,
					LeftHangingIndent,
					RightIndent,
					LeftMargin,
					RightMargin
				}
		// Variables privadas
      private RectangleF rctControl = new RectangleF(); //control dimensions
      private RectangleF rctDrawZone = new RectangleF(); //drawzone area
      private RectangleF rctWorkArea = new RectangleF(); //area which is bounded by margins
      private List<RectangleF> lstRctItems = new List<RectangleF>();//items of the ruler
      private List<RectangleF> lstRctTabs = new List<RectangleF>();//tab stops
      private Pen pnPen = new Pen(Color.Transparent);//pen to draw with
      private int intLeftMargin = 20, intRightMargin = 15;
      private int intLeftHangingIndent = 20, intLeftIndent = 20, intRightIndent = 15;
      private Color clrBorder = Color.Black;
      private Color clrBackColor = Color.White;
      private int intPosition = -1;
      private bool blnTabsEnabled = false;
      private bool blnNoMargins = false;
      private int intCapturedObject = -1, intCapturedTab = -1;
      private bool blnCaptured = false;

		/// <summary>
		///		Clase con los argumentos del evento de colocación de un tab
		/// </summary>
    internal class TabEventArgs : EventArgs
    { // Variables privadas
				private int intNewPosition = -1;
				private int intOldPosition = -1;

        internal int NewPosition
        { get { return intNewPosition; }
          set { intNewPosition = value; }
        }

        internal int OldPosition
        { get { return intOldPosition; }
          set { intOldPosition = value; }
        }
    }

		public TextRuler()
		{	InitializeComponent();
			// Inicializa los estilos
				SetStyle(ControlStyles.UserPaint, true);
				SetStyle(ControlStyles.AllPaintingInWmPaint, true);
				SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
				SetStyle(ControlStyles.ResizeRedraw, true);
				SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			// Inicializa el color de fondo y la fuente
				BackColor = Color.Transparent;
				Font = new Font("Arial", 7.25f);
			// Limpia los tabs
				lstRctTabs.Clear();
			// Márgenes e indentación
				lstRctItems.Add(new RectangleF()); // items[0] - márgen izquierdo
				lstRctItems.Add(new RectangleF()); // items[1] - márgen derecho
				lstRctItems.Add(new RectangleF()); // items[2] - indentación izquierda marca superior
				lstRctItems.Add(new RectangleF()); // items[3] - indentación izquierda marca inferior (región de imagen)
				lstRctItems.Add(new RectangleF()); // items[4] - marca indentación derecha
				lstRctItems.Add(new RectangleF()); // items[5] - marca indentación izquierda (región auto movible)
				lstRctItems.Add(new RectangleF()); // items[6] - marca indentación izquierda (todas las regiones móviles)
		}

		/// <summary>
		///		Dibuja el fondo
		/// </summary>
    private void DrawBackGround(Graphics g)
    {	// Limpia el fondo
        pnPen.Color = Color.Transparent;
        g.FillRectangle(pnPen.Brush, rctControl);
			// Rellena el fondo
        pnPen.Color = clrBackColor;
        g.FillRectangle(pnPen.Brush, rctDrawZone);            
    }

		/// <summary>
		///		Dibuja los márgenes
		/// </summary>
    private void DrawMargins(Graphics g)
    { // Dibuja los márgenes
				lstRctItems[0] = new RectangleF(0f, 3f, intLeftMargin * 3.775f, 14f);
				lstRctItems[1] = new RectangleF(rctDrawZone.Width - ((float)intRightMargin * 3.775f) + 1f, 
																				3f, intRightMargin * 3.775f + 5f, 14f);
				pnPen.Color = Color.DarkGray;
				g.FillRectangle(pnPen.Brush, lstRctItems[0]);
				g.FillRectangle(pnPen.Brush, lstRctItems[1]);
				g.PixelOffsetMode = PixelOffsetMode.None;
      // Dibuja el borde
        pnPen.Color = clrBorder;
        g.DrawRectangle(pnPen, 0, 3, rctControl.Width - 1, 14);            
    }

		/// <summary>
		///		Dibuja el texto y las marcas
		/// </summary>
    private void DrawTextAndMarks(Graphics g)
    {	int points = (int)(rctDrawZone.Width / 3.775f) / 10;
      float range = 5 * 3.775f;
      SizeF sz;

				// Color de las líneas      
        pnPen.Color = Color.Black;
				// Dibuja el text y las marcas
					for (int i = 0; i <= points * 2 + 1; i++)
						if (i % 2 == 0 && i != 0)
							{	sz = g.MeasureString((Convert.ToInt32(i / 2)).ToString(), this.Font);
								g.DrawString(Convert.ToInt32(i / 2).ToString(), Font, pnPen.Brush, 
														 new PointF((float) (i * range - (float) (sz.Width / 2)), 
																				(float) (rctControl.Height / 2) - (float) (sz.Height / 2)));
							}
						else
							g.DrawLine(pnPen, (float)(i * range), 7f, (float)(i * range), 12f);
				// Cambia el modo de dibujo
					g.PixelOffsetMode = PixelOffsetMode.Half;
    }

		/// <summary>
		///		Dibuja las indentaciones
		/// </summary>
    private void DrawIndents(Graphics g)
    { // Inicializa las posiciones
        lstRctItems[2] = new RectangleF((float) intLeftIndent * 3.775f - 4.5f, 0f, 9f, 8f);
        lstRctItems[3] = new RectangleF((float) intLeftHangingIndent * 3.775f - 4.5f, 8.2f, 9f, 11.8f);
        lstRctItems[4] = new RectangleF((float)(rctDrawZone.Width - ((float) intRightIndent * 3.775f - 4.5f) - 7f), 
																				11f, 9f, 8f);
			// Regiones para desplazar a la izquierda las marcas de indentación
        lstRctItems[5] = new RectangleF((float)intLeftHangingIndent * 3.775f - 4.5f, 8.2f, 9f, 5.9f);
        lstRctItems[6] = new RectangleF((float)intLeftHangingIndent * 3.775f - 4.5f, 14.1f, 9f, 5.9f);
			// Dibuja las imágenes
        g.DrawImage(global::Bau.Controls.Text.Properties.Resources.l_indet_pos_upper, lstRctItems[2]);
        g.DrawImage(global::Bau.Controls.Text.Properties.Resources.l_indent_pos_lower, lstRctItems[3]);
        g.DrawImage(global::Bau.Controls.Text.Properties.Resources.r_indent_pos, lstRctItems[4]);
    }

		/// <summary>
		///		Dibuja las tabulaciones
		/// </summary>
    private void DrawTabs(Graphics g)
    {	if (blnTabsEnabled)
				for (int intIndex = 0; intIndex <= lstRctTabs.Count - 1; intIndex++)
					g.DrawImage(global::Bau.Controls.Text.Properties.Resources.tab_pos, lstRctTabs[intIndex]);
    }

		/// <summary>
		///		Añade un tabulador a una posición
		/// </summary>
    private void AddTab(float fltPosition)
    {	// Añade el tabulador a la lista
				lstRctTabs.Add(new RectangleF(fltPosition, 10f, 8f, 8f));
			// Lanza el evento
				if (TabAdded != null)
					TabAdded(CreateTabArgs(fltPosition));
    }

    /// <summary>
    ///		Devuelve la lista que contiene las posiciones de las tabulaciones convertidas en milímetros
    /// </summary>
    public List<int> TabPositions
    {	get
        {	List<int> lst = new List<int>();
        
						// Añade a la lista las posiciones de las tabulaciones convertidas en milímetros
							for (int i = 0; i <= lstRctTabs.Count - 1; i++)
								lst.Add((int) (lstRctTabs[i].X / 3.775f));
						// Devuelve la lista
							return lst;
        }
    }

    /// <summary>
    ///		Devuelve la lista que contiene las posiciones de las tabulaciones en pixels
    /// </summary>
    public List<int> TabPositionsInPixels
    {	get
        {	List<int> lst = new List<int>();
        
						// Añade las posiciones de las tabulaciones a la lista
							for (int i = 0; i <= lstRctTabs.Count - 1; i++)
								lst.Add((int) (lstRctTabs[i].X));
						// Devuelve la lista
							return lst;
        }
    }

    /// <summary>
    ///		Modifica las posiciones de los tabuladores. Utiliza posiciones representadas en pixels
    /// </summary>
    public void SetTabPositionsInPixels(int[] positions)
    {	// Limpia la lista de tabulaciones
				lstRctTabs.Clear();
			// Añade las posiciones a la lista de tabuladores
				if (positions != null)
					for (int i = 0; i <= positions.Length - 1; i++)
						lstRctTabs.Add(new RectangleF(Convert.ToSingle(positions[i]), 10f, 8f, 8f));                    
			// Actualiza el control
				Refresh();
    }

    /// <summary>
    ///		Modifica las posiciones de los tabuladores. Utiliza posiciones representadas en milímetros
    /// </summary>
    public void SetTabPositionsInMillimeters(int[] positions)
    {	// Limpia la lista de tabulaciones
				lstRctTabs.Clear();
			// Añade las posiciones a las listas de tabulaciones
        if (positions != null)
            for (int i = 0; i <= positions.Length - 1; i++)
                if (positions[i] != 0)
                    lstRctTabs.Add(new RectangleF(positions[i] * 3.775f, 10f, 8f, 8f));
			// Actualiza el control
				Refresh();
    }
    
    /// <summary>
    ///		Obtiene el valor en pixels
    /// </summary>
    internal int GetValueInPixels(ControlItems item)
    {	switch (item)
        {	case ControlItems.LeftIndent:
						return (int) (intLeftIndent * 3.775f);
					case ControlItems.LeftHangingIndent:
						return (int)(intLeftHangingIndent * 3.775f);
					case ControlItems.RightIndent:
						return (int)(intRightIndent * 3.775f);
					case ControlItems.LeftMargin:
						return (int)(intLeftMargin * 3.775f);
					case ControlItems.RightMargin:
						return (int)(intRightMargin * 3.775f);
					default:
						return 0;
        }
    }

		/// <summary>
		///		Sobrescribe el método OnPaint
		/// </summary>
    protected override void OnPaint(PaintEventArgs e)
    {	// Llama al método OnPaint de la base
        base.OnPaint(e);
      // Cambia la composición a alta calidad al usar imágenes para las indentaciones
        e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			// Cambia el modo de suavizado
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			// Indica que el texto se dibuje con mayor calidad
				e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
      // Inicializa los rectángulos
        rctControl = new RectangleF(0f, 0f, (float) Width, (float) Height);
        rctDrawZone = new RectangleF(1f, 3f, rctControl.Width - 2f, 14f);
        rctWorkArea = new RectangleF((float) intLeftMargin * 3.775f, 3f, 
																		 rctDrawZone.Width - ((float) intRightMargin * 3.775f) - rctDrawZone.X * 2, 14f);            
			// Dibuja el fondo
        DrawBackGround(e.Graphics);
			// Dibuja los márgenes
        DrawMargins(e.Graphics);
			// Dibuja el texto (números) y marcas (líneas verticales)
				DrawTextAndMarks(e.Graphics);
			// Dibuja las marcas de indentación
        DrawIndents(e.Graphics);
			// Dibuja los tabuladores
        DrawTabs(e.Graphics);
    }

		/// <summary>
		///		Sobrescribe el método OnResize
		/// </summary>
    protected override void OnResize(EventArgs e)
    {	base.OnResize(e);
      Height = 20;
    }

		/// <summary>
		///		Sobrescribe el método OnMouseDown
		/// </summary>
    protected override void OnMouseDown(MouseEventArgs e)
    {	// Llama al método base
        base.OnMouseDown(e);
			// Sólo procesa el botón izquierdo del ratón
        if (e.Button == MouseButtons.Left)
					{	for (int i = 0; i <= 6; i++)
							if (lstRctItems[i].Contains(e.Location) && i != 3) //i must not be equal to 3, as this is region for whole image
								{	if (!(blnNoMargins == true && (i == 0 || i == 1)))
										{	intCapturedObject = i;
											blnCaptured = true;
										}
								}
						if (!blnCaptured && lstRctTabs.Count != 0 && !blnTabsEnabled)
							for (int i = 0; i <= lstRctTabs.Count - 1; i++)
									if (lstRctTabs[i].Contains(e.Location))
										{	intCapturedTab = i;
											intPosition = (int) (lstRctTabs[i].X / 3.775f);
											blnCaptured = true;
										}
					}
    }

		/// <summary>
		///		Sobrescribe el método OnMouseUp
		/// </summary>
    protected override void OnMouseUp(MouseEventArgs e)
    {	// Llama el método base
        base.OnMouseUp(e);
			// Sólo trata el botón izquierdo del ratón
				if (e.Button == MouseButtons.Left)
					{	if (!rctWorkArea.Contains(e.Location))
							{	if (blnCaptured && intCapturedTab != -1 && blnTabsEnabled)
									try
										{	float pos = lstRctTabs[intCapturedTab].X * 3.775f;
										
												lstRctTabs.RemoveAt(intCapturedTab);
												if (TabRemoved != null)
														TabRemoved(CreateTabArgs(pos));
										}
									catch (Exception) {}
							}
						else if (rctWorkArea.Contains(e.Location))
							{	if (!blnCaptured && blnTabsEnabled)
									AddTab((float)e.Location.X);
								else if (blnCaptured && intCapturedTab != -1)
									{	if (TabChanged != null && blnTabsEnabled)
											TabChanged(CreateTabArgs(e.Location.X));
									}
							}
						intCapturedTab = -1;
						blnCaptured = false;
						intCapturedObject = -1;
						Refresh();
					}
    }

		/// <summary>
		///		Sobrescribe el método OnMouseMove
		/// </summary>
    protected override void OnMouseMove(MouseEventArgs e)
    {	// Llama al método base
        base.OnMouseMove(e);

        if (blnCaptured && intCapturedObject != -1)
					{	switch (intCapturedObject)
							{	case 0:
										if (!blnNoMargins && e.Location.X <= (int) (rctControl.Width - intRightMargin * 3.775f - 10))
											{	intLeftMargin = (int)(e.Location.X / 3.775f);
												if (intLeftMargin < 1)
													intLeftMargin = 1;
												if (LeftMarginChanging != null)
													LeftMarginChanging(intLeftMargin);
												Refresh();
											}
									break;
								case 1:
										if (!blnNoMargins && e.Location.X >= (int) (intLeftMargin * 3.775f + 10))
											{	intRightMargin = (int) ((rctDrawZone.Width / 3.775f) - (int) (e.Location.X / 3.775f));
												if (intRightMargin < 1)
													intRightMargin = 1;
												if (RightMarginChanging != null)
													RightMarginChanging(intRightMargin);
												Refresh();
											}
									break;
								case 2:
										if (e.Location.X <= (int) (rctControl.Width - intRightIndent * 3.775f - 10))
											{	intLeftIndent = (int) (e.Location.X / 3.775f);
												if (intLeftIndent < 1)
													intLeftIndent = 1;
												if (LeftIndentChanging != null)	
													LeftIndentChanging(intLeftIndent);
												Refresh();
											}
									break;
								case 4:
										if (e.Location.X >= (int) (Math.Max(intLeftHangingIndent, intLeftIndent) * 3.775f + 10))
											{	intRightIndent = (int) ((rctControl.Width / 3.775f) - (int) (e.Location.X / 3.775f));
												if (intRightIndent < 1)
													intRightIndent = 1;
												if (RightIndentChanging != null)
													RightIndentChanging(intRightIndent);
												Refresh();
											}
									break;
								case 5:
										if (e.Location.X <= (int)(rctDrawZone.Width - intRightIndent * 3.775f - 10))
											{	intLeftHangingIndent = (int)(e.Location.X / 3.775f);
												if (intLeftHangingIndent < 1)
													intLeftHangingIndent = 1;
												if (LeftHangingIndentChanging != null)
													LeftHangingIndentChanging(intLeftHangingIndent);
												Refresh();
											}
									break;
								case 6:
										if (e.Location.X <= (int) (rctDrawZone.Width - intRightIndent * 3.775f - 10))
											{	intLeftIndent = intLeftIndent + (int) (e.Location.X / 3.775f) - intLeftHangingIndent;
												if (intLeftIndent < 1)
													intLeftIndent = 1;
												if (LeftIndentChanging != null)
													LeftIndentChanging(intLeftHangingIndent);
												intLeftHangingIndent = (int) (e.Location.X / 3.775f);
												if (intLeftHangingIndent < 1)
													intLeftHangingIndent = 1;
												if (LeftHangingIndentChanging != null)
													LeftHangingIndentChanging(intLeftHangingIndent);
												Refresh();
											}
									break;
							}
					}
        else if (blnCaptured && intCapturedTab != -1)
					{	if (rctWorkArea.Contains(e.Location))
							{	lstRctTabs[intCapturedTab] = new RectangleF((float) e.Location.X, lstRctTabs[intCapturedTab].Y, 
																														lstRctTabs[intCapturedTab].Width, 
																														lstRctTabs[intCapturedTab].Height);
								Refresh();
							}
					}
        else
					for (int i = 0; i <= 4; i++)
						{	if (lstRctItems[i].Contains(e.Location))
								switch (i)
									{	case 0:
												if (!blnNoMargins) 
													Cursor = Cursors.SizeWE;
											break;
										case 1:
												if (!blnNoMargins) 
													Cursor = Cursors.SizeWE;
											break;
									}
								Cursor = Cursors.Default;
						}
    }

		/// <summary>
		///		Crea un evento de colocación de Tab
		/// </summary>
    private TabEventArgs CreateTabArgs(float newPos)
    {	TabEventArgs tae = new TabEventArgs();
    
        tae.NewPosition = (int)(newPos / 3.775f);            
        tae.OldPosition = intPosition;
        return tae;
    }
    
    /// <summary>
    ///		Obtiene o asigna el color del borde
    /// </summary>
    [DefaultValue(typeof(Color), "Black")]
    [Description("Color of the border drawn on the bounds of control.")]
    public Color BorderColor
    {	get { return clrBorder; }
      set 
				{ clrBorder = value; 
					Refresh(); 
				}
    }

    /// <summary>
    ///		Obtiene o asigna el color del fondo
    /// </summary>
    [DefaultValue(typeof(Color), "White")]
    [Description("Base color for the control.")]        
    public Color BaseColor
    {	get { return clrBackColor; }
      set
        {	clrBackColor = value;
					Refresh();
        }
    }

    /// <summary>
    ///		Habilita o inhabilita los márgenes. Si se desabilitan los valores de los márgenes se cambian a 1.
    /// </summary>
    [Category("Margins")]
    [Description("If true Margins are disabled, otherwise, false.")]
    [DefaultValue(false)]
    public bool NoMargins
    {	get { return blnNoMargins; }
      set 
        { blnNoMargins = value;
          if (value)
						intLeftMargin = intRightMargin = 1;
					Refresh(); 
        }
    }

    /// <summary>
    ///		Define el margen izquierdo
    /// </summary>
    [Category("Margins")]
    [Description("Gets or sets left margin. This value is in millimeters.")]
    [DefaultValue(20)]
    public int LeftMargin
    {	get { return intLeftMargin; }
      set 
        {	if (!blnNoMargins)
						intLeftMargin = value;
          Refresh(); 
        }
    }

    /// <summary>
    ///		Define el márgen derecho
    /// </summary>
    [Category("Margins")]
    [Description("Gets or sets right margin. This value is in millimeters.")]
    [DefaultValue(15)]
    public int RightMargin
    {	get { return intRightMargin; }
      set 
        {	if (!blnNoMargins)
						intRightMargin = value;
          Refresh();
        }
    }

    /// <summary>
    ///		Define la indentación de la primera línea del párrafo
    /// </summary>
    [Category("Indents")]
    [Description("Gets or sets left hanging indent (first line of the paragraph). This value is in millimeters.")]
    [DefaultValue(20)]
    public int LeftHangingIndent
    {	get { return intLeftHangingIndent; }
      set 
				{	if (value >= 1)
						{ intLeftHangingIndent = value;
							Refresh(); 
						}
				}
    }

    /// <summary>
    /// Gets or sets indentation from the left of the base text of the paragraph
    /// </summary>
    [Category("Indents")]
    [Description("Gets or sets left indent. This value is in millimeters.")]
    [DefaultValue(20)]
    public int LeftIndent
    {	get { return intLeftIndent; }
      set 
        {	if (value >= 1)
						{ intLeftIndent = value;
							Refresh(); 
						}
        }
    }

    /// <summary>
    ///		Define la indentación derecha del párrafo
    /// </summary>
    [Category("Indents")]
    [Description("Gets or sets right indent. This value is in millimeters.")]
    [DefaultValue(15)]
    public int RightIndent
    {	get { return intRightIndent; }
      set 
        {	if (value >= 1)
						{	intRightIndent = value; 
							Refresh();
						}
        }
    }

    [Category("Tabulation")]
    [Description("True to display tab stops, otherwise, False")]
    [DefaultValue(false)]
    public bool TabsEnabled
    {	get { return blnTabsEnabled; }
      set 
				{ blnTabsEnabled = value; 
					Refresh(); 
				}
    }
  }
}
