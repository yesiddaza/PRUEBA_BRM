using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour {

	[SerializeField]
	private Button createDataButton;
	[SerializeField]
	private Button trademarkButton;
	[SerializeField]
	private Button productButton;
	private WindowStateBehaviour windowStateBehaviour;


	void Start () {
		windowStateBehaviour = GameObject.FindGameObjectWithTag ("WindowState").GetComponent (typeof(WindowStateBehaviour)) as WindowStateBehaviour;
		createDataButton.onClick.AddListener (delegate {
			windowStateBehaviour.WindowState = WindowState.ShowingCreateData;
		});
		trademarkButton.onClick.AddListener (delegate {
			CatalogPersistence.Load();
			windowStateBehaviour.WindowState = WindowState.ShowingTrademarksList;
		});
		productButton.onClick.AddListener (delegate {
			CatalogPersistence.Load();
			windowStateBehaviour.WindowState = WindowState.ShowingProductsList;
		});
	}
}