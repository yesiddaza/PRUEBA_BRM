using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
public class Catalog {
	public List<Product> products;
	
	public Catalog () {
		this.products = new List<Product>();
	}
}