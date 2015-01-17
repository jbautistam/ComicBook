using System;
using System.Drawing;
using System.IO;

using Bau.Controls.Files.API;

namespace Bau.Controls.Files.FilesInfo
{
	/// <summary>
	/// 	Clase que mantiene los datos de un archivo / directorio
	/// </summary>
	public class clsFile
  { // Variables privadas
  		private FileSystemInfo objFileInfo;
      private string strType;
      private IntPtr hndIcon;
      private Icon imgIcon;

    public clsFile(string strFullName) : this(new FileInfo(strFullName)) { }

    public clsFile(FileSystemInfo objFileInfo)
    {	Update(objFileInfo);
    }

    /// <summary>
    /// 	Reinicializa los valores
    /// </summary>
    public void Update(string strFullName)
    {	Update(new FileInfo(strFullName));
    }

    /// <summary>
    /// 	Reinicializa los valores
    /// </summary>
    public void Update(FileSystemInfo objFileInfo)
    {	SHFILEINFO hndInfo;
    	
    		// Recoge la información del archivo
	    		this.objFileInfo = objFileInfo;
				// Obtiene la información del archivo de la API
	        hndInfo = clsShellGetFileInfo.GetFileInfo(FullName);
				// Obtiene el tipo y el icono
	        strType = hndInfo.szTypeName;
	        hndIcon = hndInfo.hIcon;
	        try
		        {	imgIcon = Icon.FromHandle(hndInfo.hIcon);
		        }
	        catch
		        { imgIcon = null;
		        }
    }

    /// <summary>
    /// 	Copia el archivo origen en el destino
    /// </summary>
    public void Copy(string strPathTarget)
    { if (IsDirectory)
    		CopyPath(FullName, strPathTarget);
    	else
    		CopyFile(FullName, Path.Combine(strPathTarget, Name));
    }
    
    /// <summary>
    /// 	Copia un directorio en otro
    /// </summary>
    private void CopyPath(string strPathSource, string strPathTarget)
    { string [] arrStrFiles;
    	FileInfo objFile;
    	
    		// Obtiene el directorio destino
    			strPathTarget = Path.Combine(strPathTarget, (new FileInfo(strPathSource)).Name);
	    	// Crea el directorio destino
		    	if (!Directory.Exists(strPathTarget))
	    			Directory.CreateDirectory(strPathTarget);
	    	// Copia los archivos de este directorio
	    		arrStrFiles = Directory.GetFiles(strPathSource);
	    		for (int intIndex = 0; intIndex < arrStrFiles.Length; intIndex++)
		    		{ // Obtiene la información del archivo
		    				objFile = new FileInfo(arrStrFiles[intIndex]);
		    			// Copia el archivo
		    				CopyFile(objFile.FullName, Path.Combine(strPathTarget, objFile.Name));
		    		}
	    	// Copia los directorios de este directorio
	    		arrStrFiles = Directory.GetDirectories(strPathSource);
	    		for (int intIndex = 0; intIndex < arrStrFiles.Length; intIndex++)
		    		{ // Obtiene la información del archivo
		    				objFile = new FileInfo(arrStrFiles[intIndex]);
		    			// Copia el directorio
								CopyPath(Path.Combine(strPathSource, objFile.Name), strPathTarget);
		    		}
    }
    
    /// <summary>
    ///		Copia un archivo
    /// </summary>
    private void CopyFile(string strFileSource, string strFileTarget)
    { try
				{ File.Copy(strFileSource, strFileTarget);
				}
			catch {}
    }
    
    /// <summary>
    /// 	Mueve el archivo origen al destino
    /// </summary>
    public void Move(string strPathTarget)
    { // El nombre del archivo destino es el directorio más el nombre del archivo origen
    		strPathTarget = Path.Combine(strPathTarget, Name);
    	// Mueve los archivos
    		try
    			{	// Mueve el directorio o el archivo
    					if (IsDirectory)
    						Directory.Move(FullName, strPathTarget);
							else
								File.Move(FullName, strPathTarget);
						// Cambia los datos de esta clase
							Update(new FileInfo(strPathTarget));
					}
				catch {}
    }

    /// <summary>
    /// 	Modifica el nombre del archivo
    /// </summary>
    public void Rename(string strNewName)
    { // El nombre del archivo destino es el directorio más el nombre del archivo origen
    		strNewName = Path.Combine(PathName, strNewName);
    	// Cambia el nombre del archivo
    		if (IsDirectory)
    			Directory.Move(FullName, strNewName);
    		else
    			File.Move(FullName, strNewName);
    	// Cambia los datos de esta clase
    		Update(new FileInfo(strNewName));
    }
    
    public string PathName
    { get { return Path.GetDirectoryName(FullName); }
    }
    
    public string FullName
    {	get { return objFileInfo.FullName; }
    }
    
    public string Name
    {	get { return objFileInfo.Name; }
    }

    public long Size
    { get 
    		{ try
    				{	return (objFileInfo as FileInfo).Length;
    				}
	        catch // ... es un directorio
		        { return -1;
		        }
    		}
    }

    public DateTime DateModified
    {	get { return objFileInfo.LastWriteTime; }
    }

    public DateTime DateCreated
    {	get { return objFileInfo.CreationTime; }
    }

    public string Type
    {	get { return strType; }
    }

    public Icon Icon
    {	get { return imgIcon; }
    }
    
    public IntPtr HandleIcon
    { get { return hndIcon; }
    }
    
    public bool IsDirectory
    {	get { return Size == -1; }
    }
  }
}
