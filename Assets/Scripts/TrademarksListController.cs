using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrademarksListController : MonoBehaviour {

	[SerializeField]
	private Button homeButton;
	[SerializeField]
	private Button searchButton;
	[SerializeField]
	protected GameStateBehaviour gameStateBehaviour;
	
	void Start () {
		homeButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingMainWindow;
		});
		searchButton.onClick.AddListener (delegate {
			Debug.Log("Busca");
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