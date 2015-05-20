using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject mainWindow;
	public GameStateBehaviour gameStateBehaviour;
	public CreateDataController createData;
	public TrademarksListController trademarksList;
	public ProductDataController productData;
	public ProductsListWindow productsList;

	private bool IsShowingCreateData {
		get{
			return gameStateBehaviour.GameState == GameState.ShowingCreateData;
		}
	}

	private bool IsShowingTrademarksList {
		get{
			return gameStateBehaviour.GameState == GameState.ShowingTrademarksList;
		}
	}

	private bool IsShowingProductsList {
		get{
			return gameStateBehaviour.GameState == GameState.ShowingProductsList;
		}
	}

	private bool IsShowingMainWindow {
		get{
			return gameStateBehaviour.GameState == GameState.ShowingMainWindow;
		}
	}

	private bool IsShowingProductData {
		get{
			return gameStateBehaviour.GameState == GameState.ShowingProductData;
		}
	}

	void Start () {
		gameStateBehaviour.GameState = GameState.ShowingMainWindow;

		createData.SetActive ();
		trademarksList.SetActive ();
		productsList.SetActive ();
		productData.SetActive ();

		createData.SetInactive ();
		trademarksList.SetInactive ();
		productsList.SetInactive ();
		productData.SetInactive ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) 
			Application.Quit (); 
		
		if (IsShowingCreateData) {
			createData.SetActive ();
			trademarksList.SetInactive ();
			productsList.SetInactive ();
			mainWindow.SetActive (false);
			productData.SetInactive ();
		}
		else if (IsShowingTrademarksList) {
			createData.SetInactive ();
			trademarksList.SetActive ();
			productsList.SetInactive ();
			mainWindow.SetActive (false);
			productData.SetInactive ();
		}
		else if (IsShowingProductsList) {
			createData.SetInactive ();
			trademarksList.SetInactive ();
			productsList.SetActive ();
			mainWindow.SetActive (false);
			productData.SetInactive ();
		}
		else if (IsShowingMainWindow) {
			createData.SetInactive ();
			trademarksList.SetInactive ();
			productsList.SetInactive ();
			mainWindow.SetActive (true);
			productData.SetInactive ();
		}
		else if (IsShowingProductData) {
			createData.SetInactive ();
			trademarksList.SetInactive ();
			productsList.SetInactive ();
			mainWindow.SetActive (false);
			productData.SetActive();
		} else
			productData.SetInactive ();
	}

	void Awake(){
		Input.multiTouchEnabled = false;
	}
}