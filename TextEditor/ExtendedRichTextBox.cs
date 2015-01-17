using System;
using System.Drawing.Printing; 
using System.Runtime.InteropServices;
using System.Windows.Forms;
 
namespace Bau.Controls.Text
{  
	/// <summary>
	///		Facilita la impresión de un control RichTextBox
	/// </summary>
 	internal class ExtendedRichTextBox : RichTextBox
 	{	// Constantes privadas
 			private const int WM_USER = 0x400;
 			private const int EM_FORMATRANGE = WM_USER + 57;
 		// Factor de conversión entre la unidad que utiliza el framework de .NET (1/100 pulgadas)
 		// y la unidad que utilizan las llamadas a API de Win32 (1/1440 pulgadas)
 			private const double cnstFactorInch = 14.4; 
 		
 		[StructLayout(LayoutKind.Sequential)]private struct RECT
 		{	public int Left;
 			public int Top;
 			public int Right;
 			public int Bottom;
 		}
 		
 		[StructLayout(LayoutKind.Sequential)]private struct CHARRANGE
 		{	public int cpMin; // Primer carácter del rango (0 para el comienzo del documento)
 			public int cpMax; // Ultimo carácter del rango (-1 para el fin del documento)
 		}
 		
 		[StructLayout(LayoutKind.Sequential)]private struct FORMATRANGE
 		{	public IntPtr hdc; // DC actual sobre el que se dibuja
 			public IntPtr hdcTarget; // DC destino para determinar el formato de texto
 			public RECT rc; // Región de DC a la que dibujar (en twips)
 			public RECT rcPage; // Región total del DC (tamaño de página) (en twips)
 			public CHARRANGE chrg; // Rango del texto a dibujar
 		}

 		[DllImport("USER32",EntryPoint="SendMessageA", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
 		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
 		
 		/// <summary>
 		///		Imprime el contenido del textBox
 		/// </summary>
 		/// <returns>Ultimo carácter impreso + 1 (comienzo de impresión de la siguiente página)</returns>
 		public int Print(int intPositionCharFrom, int intPositionCharTo, PrintPageEventArgs evtArgs)
 		{	IntPtr hdc = evtArgs.Graphics.GetHdc();
 			CHARRANGE udtRange;
 			RECT rctToPrint, rctPage;
 			FORMATRANGE fmtRange;
 			IntPtr res = IntPtr.Zero;
 			IntPtr wparam = new IntPtr(1);
  		IntPtr lparam = IntPtr.Zero;
 			 			 			 			
 				// Marca el carácter de inicio y fin
 					udtRange.cpMin = intPositionCharFrom;
 					udtRange.cpMax = intPositionCharTo;
 				// Calcula el área a dibujar e imprimir
 					rctToPrint.Top =  (int) (evtArgs.MarginBounds.Top * cnstFactorInch);
					rctToPrint.Bottom = (int) (evtArgs.MarginBounds.Bottom * cnstFactorInch);
					rctToPrint.Left = (int) (evtArgs.MarginBounds.Left * cnstFactorInch);
					rctToPrint.Right = (int) (evtArgs.MarginBounds.Right * cnstFactorInch);
 				// Calcula el tamaño de la página
					rctPage.Top = (int) (evtArgs.PageBounds.Top * cnstFactorInch);
					rctPage.Bottom = (int) (evtArgs.PageBounds.Bottom * cnstFactorInch);
					rctPage.Left = (int) (evtArgs.PageBounds.Left * cnstFactorInch);
					rctPage.Right = (int) (evtArgs.PageBounds.Right * cnstFactorInch);
 				// Inicializa el rango del formato
 					fmtRange.chrg = udtRange; // Indica el carácter de inicio y fin
 					fmtRange.hdc = hdc; // Utiliza el mismo DC para medir y dibujar
 					fmtRange.hdcTarget = hdc; // Apunta al handle la impresora
 					fmtRange.rc = rctToPrint; // Indica el área de la página a imprimir
 					fmtRange.rcPage = rctPage; // Indica el tamaño total de la página
  			// Mueve el puntero a la estructura FORMATRANGE en memoria
  				lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
  				Marshal.StructureToPtr(fmtRange, lparam, false);
  			// Envía los datos a la impresora
	  			res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam);
  			// Libera el bloque de memoria
  				Marshal.FreeCoTaskMem(lparam);
  			// Libera el contexto de dispositivo obtenido por una llamada anterior
  				evtArgs.Graphics.ReleaseHdc(hdc);
  			// Devuelve el último carácter impreso + 1
  				return res.ToInt32();
  		}
  	}
}