using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour {

	public GameObject mainWindow;
	public WindowStateBehaviour windowStateBehaviour;
	public CreateDataController createData;
	public TrademarksListController trademarksList;
	public ProductDataController productData;
	public ProductsListWindow productsList;

	private bool IsShowingCreateData {
		get{
			return windowStateBehaviour.WindowState == WindowState.ShowingCreateData;
		}
	}

	private bool IsShowingTrademarksList {
		get{
			return windowStateBehaviour.WindowState == WindowState.ShowingTrademarksList;
		}
	}

	private bool IsShowingProductsList {
		get{
			return windowStateBehaviour.WindowState == WindowState.ShowingProductsList;
		}
	}

	private bool IsShowingMainWindow {
		get{
			return windowStateBehaviour.WindowState == WindowState.ShowingMainWindow;
		}
	}

	private bool IsShowingProductData {
		get{
			return windowStateBehaviour.WindowState == WindowState.ShowingProductData;
		}
	}

	void Start () {
		windowStateBehaviour.WindowState = WindowState.ShowingMainWindow;

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