using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrademarksListController : MonoBehaviour {

	[SerializeField]
	private Button homeButton;
	[SerializeField]
	private Button searchButton;
	[SerializeField]
	protected WindowStateBehaviour windowStateBehaviour;
	
	void Start () {
		homeButton.onClick.AddListener (delegate {
			windowStateBehaviour.WindowState = WindowState.ShowingMainWindow;
		});
		searchButton.onClick.AddListener (delegate {
			CatalogPersistence.Load();
			Debug.Log(CatalogPersistence.catalog.products[0].nameProduct);
		});
	}
	
	public void SetActive() {
		gameObject.SetActive (true);
	}
	
	public void SetInactive (){
		gameObject.SetActive (false);
	}
}