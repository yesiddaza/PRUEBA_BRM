using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateDataController : MonoBehaviour {

	[SerializeField]
	private Button homeButton;
	[SerializeField]
	private Button saveButton;
	[SerializeField]
	protected GameStateBehaviour gameStateBehaviour;

	void Start () {
		homeButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingMainWindow;
		});
		saveButton.onClick.AddListener (delegate {
			Debug.Log("guardo!");
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