using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TrademarksListController : MonoBehaviour {

	[SerializeField]
	private Button homeButton;
	[SerializeField]
	private Button searchButton;
	[SerializeField]
	private Button trademarkButton;
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
		DrawButtonsByTrademark(CatalogPersistence.catalog.products);
		homeButton.onClick.AddListener (delegate {
			windowStateBehaviour.WindowState = WindowState.ShowingMainWindow;
		});
		searchButton.onClick.AddListener (delegate {
			SearchWord();
		});
	}

	private void SearchWord () {
		DestroyWordList ();
		foreach(Product p in CatalogPersistence.catalog.products){
			if(p.trademark.name.Contains(searchInput.text))
				createButton(p.trademark.name, 1);
		}
	}

	private void DestroyWordList(){
		foreach(Transform  child in buttonListUI.transform ) {
			Destroy (child.gameObject);
		}
	}

	public void DrawButtonsByTrademark(List<Product> products){
		foreach(Product product in products){
			createButton(product.trademark.name, 1);
		}
	}

	private Button createButton (string name, int casePanel){
		Button newItem = Instantiate(trademarkButton) as Button;
		newItem.name = name;
		newItem.transform.GetChild(0).GetComponent<Text>().text = name;
		newItem.transform.SetParent(buttonListUI.gameObject.transform, false);	
		newItem.onClick.AddListener(delegate {
			if (casePanel==1)
				OpenProductsByTrademark(name);
			else if (casePanel==2)
				OpenProduct(name);
		});
		return newItem;
	}

	private void OpenProductsByTrademark(string markName){
		DestroyWordList ();
		searchButton.gameObject.SetActive (false);
		searchInput.text = markName;
		searchInput.interactable = false;
		foreach(Product p in CatalogPersistence.catalog.products){
			if(p.trademark.name == markName)
				createButton(p.nameProduct, 2);
		}
	}

	private void OpenProduct(string name){
		DestroyWordList ();
		DrawButtonsByTrademark(CatalogPersistence.catalog.products);
		windowStateBehaviour.WindowState = WindowState.ShowingProductData;
		foreach(Product p in CatalogPersistence.catalog.products){
			if(p.nameProduct == name && p.trademark.name == searchInput.text){
				productData.SetData(p, 1);
				break;
			}
		}
		searchButton.gameObject.SetActive (true);
		searchInput.text = string.Empty;
		searchInput.interactable = true;
	}
	
	public void SetActive() {
		gameObject.SetActive (true);
	}
	
	public void SetInactive (){
		gameObject.SetActive (false);
	}
}