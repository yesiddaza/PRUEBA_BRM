using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProductDataController : MonoBehaviour {

	[SerializeField]
	private Button homeButton;
	[SerializeField]
	private Button doneButton;
	[SerializeField]
	protected GameStateBehaviour gameStateBehaviour;
	
	void Start () {
		homeButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingMainWindow;
		});
		doneButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingProductsList;
		});
	}

	public void SetActive() {
		gameObject.SetActive (true);
	}

	public void SetInactive (){
		gameObject.SetActive (false);
	}
}