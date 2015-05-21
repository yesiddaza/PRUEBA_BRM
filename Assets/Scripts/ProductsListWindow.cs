using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ProductsListWindow : MonoBehaviour {

	[SerializeField]
	private Button homeButton;
	[SerializeField]
	private Button searchButton;
	[SerializeField]
	private Button productButton;
	[SerializeField]
	private InputField searchInput;
	[SerializeField]
	private GameObject buttonListUI;
	[SerializeField]
	private ProductDataController productData;
	[SerializeField]
	protected WindowStateBehaviour windowStateBehaviour;
	
	void Start () {
		CatalogPersistence.Load();
		DrawButtonsByProduct(CatalogPersistence.catalog.products);
		homeButton.onClick.AddListener (delegate {
			windowStateBehaviour.WindowState = WindowState.ShowingMainWindow;
		});
		searchButton.onClick.AddListener (delegate {
			SearchWord();
		});
		productButton.onClick.AddListener (delegate {
			windowStateBehaviour.WindowState = WindowState.ShowingProductData;
		});
	}

	private void SearchWord () {
		DestroyWordList ();
		foreach(Product p in CatalogPersistence.catalog.products){
			if(p.nameProduct.Contains(searchInput.text))
				createButton(p, p.nameProduct);
		}
	}

	private void DestroyWordList(){
		foreach(Transform  child in buttonListUI.transform ) {
			Destroy (child.gameObject);
		}
	}

	public void DrawButtonsByProduct(List<Product> products){
		foreach(Product product in products){
			createButton(product, product.nameProduct);
		}
	}

	private Button createButton (Product p, string name){
		Button newItem = Instantiate(productButton) as Button;
		newItem.name = name;
		newItem.transform.GetChild(0).GetComponent<Text>().text = name;
		newItem.transform.SetParent(buttonListUI.gameObject.transform, false);	
		newItem.onClick.AddListener(delegate {
			OpenProduct(p, name);
		});
		return newItem;
	}

	public void SetActive() {
		gameObject.SetActive (true);
	}
	
	public void SetInactive (){
		gameObject.SetActive (false);
	}

	private void OpenProduct(Product p, string name){
		DestroyWordList ();
		DrawButtonsByProduct(CatalogPersistence.catalog.products);
		windowStateBehaviour.WindowState = WindowState.ShowingProductData;
		productData.SetData(p, 2);
		searchButton.gameObject.SetActive (true);
		searchInput.text = string.Empty;
		searchInput.interactable = true;
	}
}