using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class CatalogPersistence {
	
	public static Catalog catalog = new Catalog();
	
	public static void Save(Catalog data) {
		SetEnvironment ();
		BinaryFormatter buffer = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/MainCatalog.gd"); 
		CatalogPersistence.catalog = data;
		buffer.Serialize(file, CatalogPersistence.catalog);
		file.Close();
	}	
	
	public static void Load() {
		SetEnvironment ();
		if(File.Exists(Application.persistentDataPath + "/MainCatalog.gd")) {
			BinaryFormatter buffer = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/MainCatalog.gd", FileMode.Open);
			CatalogPersistence.catalog = (Catalog)buffer.Deserialize(file);
			file.Close();
		}
	}
	
	public static void ClearProducts (){		
		Catalog Catalog = new Catalog();
		Save(catalog);
	}
	
	public static void SaveProduct (Product product){		
		Load();
		catalog.products.Add(product);
		Save(catalog);
	}
	
	private static void SetEnvironment ()	{
		Environment.SetEnvironmentVariable ("MONO_REFLECTION_SERIALIZER", "yes");
	}
}