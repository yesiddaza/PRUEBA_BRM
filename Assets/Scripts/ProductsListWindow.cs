using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProductsListWindow  : MonoBehaviour {

	[SerializeField]
	private Button homeButton;
	[SerializeField]
	private Button searchButton;
	[SerializeField]
	private Button productButton;
	[SerializeField]
	protected GameStateBehaviour gameStateBehaviour;
	
	void Start () {
		homeButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingMainWindow;
		});
		searchButton.onClick.AddListener (delegate {
			Debug.Log("Busca");
		});
		productButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingProductData;
		});
	}

	public void SetActive ()
	{
		gameObject.SetActive (true);
	}
	public void SetInactive ()
	{
		gameObject.SetActive (false);
	}
}
