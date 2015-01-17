using System;
using System.Runtime.InteropServices;

namespace Bau.Controls.Files.API
{
  [StructLayout(LayoutKind.Sequential)]
  internal struct SHFILEINFO
  { public IntPtr hIcon;
    public IntPtr iIcon;
    public uint dwAttributes;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string szDisplayName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
    public string szTypeName;
  };

	/// <summary>
	/// 	Clase que recoge los datos de la API
	/// </summary>
	internal class clsShellGetFileInfo
  { // Constantes públics
	    public const uint SHGFI_ICON = 0x100;         // Obtiene el icono
	    public const uint SHGFI_DISPLAYNAME = 0x200;  // Obtiene el nombre a visualizar
	    public const uint SHGFI_TYPENAME = 0x400;     // Obtiene el nombre del tipo de archivo
	    public const uint SHGFI_LARGEICON = 0x0;      // Icono grande
	    public const uint SHGFI_SMALLICON = 0x1;      // Icono pequeño

    [DllImport("shell32.dll")]
    public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, 
                                              uint cbSizeFileInfo, uint uFlags);

    public static SHFILEINFO GetFileInfo(string strFileName)
    { SHFILEINFO shfInfo = new SHFILEINFO();
     	IntPtr icon;

      	icon = SHGetFileInfo(strFileName, 0, ref shfInfo, (uint) Marshal.SizeOf(shfInfo), 
     	                     	 SHGFI_ICON | SHGFI_TYPENAME | SHGFI_SMALLICON);
        return shfInfo;
    }
  }		
}
