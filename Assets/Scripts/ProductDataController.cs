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
	protected WindowStateBehaviour windowStateBehaviour;
	
	void Start () {
		homeButton.onClick.AddListener (delegate {
			windowStateBehaviour.WindowState = WindowState.ShowingMainWindow;
		});
		doneButton.onClick.AddListener (delegate {
			windowStateBehaviour.WindowState = WindowState.ShowingProductsList;
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