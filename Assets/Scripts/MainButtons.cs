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
	private GameStateBehaviour gameStateBehaviour;


	void Start () {
		gameStateBehaviour = GameObject.FindGameObjectWithTag ("GameState").GetComponent (typeof(GameStateBehaviour)) as GameStateBehaviour;
		createDataButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingCreateData;
		});
		trademarkButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingTrademarksList;
		});
		productButton.onClick.AddListener (delegate {
			gameStateBehaviour.GameState = GameState.ShowingProductsList;
		});
	}
}