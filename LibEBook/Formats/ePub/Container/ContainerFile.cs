﻿using System;

namespace Bau.Libraries.LibEBook.Formats.ePub.Container
{
	/// <summary>
	///		Archivo contenedor del formato ePub (container.xml)
	/// </summary>
	/// <example>
	///		<?xml version='1.0' encoding='utf-8'?>
	///		<container xmlns="urn:oasis:names:tc:opendocument:xmlns:container" version="1.0">
	///			<rootfiles>
	///				<rootfile media-type="application/oebps-package+xml" full-path="25640/content.opf"/>
	///			</rootfiles>
	///		</container>
	/// </example>
	public class ContainerFile
	{	
		public ContainerFile()
		{ RootFiles = new RootFilesCollection();
		}
		
		/// <summary>
		///		Archivos raíz (archivos de índice)
		/// </summary>
		public RootFilesCollection RootFiles { get; private set; }
	}
}
