using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProductDataController : MonoBehaviour {

	[SerializeField]
	private Button homeButton;
	[SerializeField]
	private Button doneButton;
	[SerializeField]
	private Button editButton;
	[SerializeField]
	private Button deleteButton;
	[SerializeField]
	protected GameStateBehaviour gameStateBehaviour;
	
	void Start () {
		homeButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingMainWindow;
		});
		doneButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingProductsList;
		});
		editButton.onClick.AddListener (delegate {
			Debug.Log("edito!");
		});
		deleteButton.onClick.AddListener (delegate {
			Debug.Log("borro!");
		});
	}

	public void SetActive() {
		gameObject.SetActive (true);
	}

	public void SetInactive (){
		gameObject.SetActive (false);
	}
}