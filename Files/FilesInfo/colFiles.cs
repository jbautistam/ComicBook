using System;
using System.IO;
using System.Collections;

namespace Bau.Controls.Files.FilesInfo
{
	/// <summary>
	/// Colección de objetos <see cref='clsFile'/>
	/// </summary>
	public class colFiles : CollectionBase
	{
		/// <summary>
		/// 	Carga en la colección los archivos del directorio
		/// </summary>
		public void Load(string strPath)
		{ Load(strPath, "*.*");
		}
		
		/// <summary>
		/// 	Carga en la colección los archivos del directorio que coinciden con la máscara de búsqueda
		/// </summary>
		public void Load(string strPath, string strMask)
		{ try
				{	// Añade los directorios
						Add(Directory.GetDirectories(strPath));
					// Carga los archivos
						string [] arrStrMask = strMask.Split(';');
						
							foreach (string strMaskFile in arrStrMask)
								Add(Directory.GetFiles(strPath, strMaskFile));
				}
			catch {}
		}
		
		/// <summary>
		///   Obtiene un elemento de la colección
		/// </summary>
		public clsFile this[int index] 
		{	get { return ((clsFile)(List[index])); }
			set { List[index] = value; }
		}

		/// <summary>
		/// 	Añade una serie de archivos cuyos nombres vienen en el array pasado como parámetro
		/// </summary>
		private void Add(string [] arrStrFiles)
		{	// Recorre los nombres de archivo generando la colección
				for (int intIndex = 0; intIndex < arrStrFiles.Length; intIndex++)
					Add(new clsFile(arrStrFiles[intIndex]));
		}
		
		/// <summary>
		///   Añade un elemento a la colección
		/// </summary>
		public int Add(clsFile val)
		{	return List.Add(val);
		}
		
		/// <summary>
		///   Comprueba si la colección contiene un elemento
		/// </summary>
		public bool Contains(clsFile val)
		{	return List.Contains(val);
		}
		
		/// <summary>
		///		Obtiene el índice de un elemento en la colección (o -1 si no lo encuentra)
		/// </summary>
		public int IndexOf(clsFile val)
		{	return List.IndexOf(val);
		}
		
		/// <summary>
		///		Obtiene un enumerador para recurrer la colección
		/// </summary>
		public new clsFileEnumerator GetEnumerator()
		{	return new clsFileEnumerator(this);
		}
		
		/// <summary>
		///   Elimina un elemento de la colección
		/// </summary>
		public void Remove(clsFile val)
		{	List.Remove(val);
		}
		
		/// <summary>
		///   Enumerador fuertemente tipado utilizado para recorrer la colección
		/// </summary>
		public class clsFileEnumerator : IEnumerator
		{ // Variables privadas
				IEnumerator baseEnumerator;
			
			/// <summary>
			///   Inicializa una nueva instancia del enumerador
			/// </summary>
			public clsFileEnumerator(colFiles mappings)
			{	baseEnumerator = ((IEnumerable) (mappings)).GetEnumerator();
			}
			
			/// <summary>
			///		Obtiene el elemento actual de la colección
			/// </summary>
			public clsFile Current 
			{	get { return ((clsFile) (baseEnumerator.Current)); }
			}
			
			/// <summary>
			///		Obtiene el elemento actual de la colección
			/// </summary>
			object IEnumerator.Current 
			{	get { return baseEnumerator.Current; }
			}
			
			/// <summary>
			///   Pasa al siguiente elemento de la colección
			/// </summary>
			public bool MoveNext()
			{	return baseEnumerator.MoveNext();
			}
			
			/// <summary>
			///		Pasa el enumerador a su posición inicial
			/// </summary>
			public void Reset()
			{	baseEnumerator.Reset();
			}
		}
	}
}
