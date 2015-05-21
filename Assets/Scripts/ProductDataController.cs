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
	private Text name;
	[SerializeField]
	private Text size;
	[SerializeField]
	private Text observations;
	[SerializeField]
	private Text trademarkName;
	[SerializeField]
	private Text trademarkReference;
	[SerializeField]
	private Text quantity;
	[SerializeField]
	private Text date;
	[SerializeField]
	protected WindowStateBehaviour windowStateBehaviour;
	private int windowCome;
	
	void Start () {
		homeButton.onClick.AddListener (delegate {
			windowStateBehaviour.WindowState = WindowState.ShowingMainWindow;
		});
		doneButton.onClick.AddListener (delegate {
			if (windowCome == 1)
				windowStateBehaviour.WindowState = WindowState.ShowingTrademarksList;
			else
				windowStateBehaviour.WindowState = WindowState.ShowingProductsList;
		});
		editButton.onClick.AddListener (delegate {
			Debug.Log("edito!");
		});
		deleteButton.onClick.AddListener (delegate {
			Debug.Log("borro!");
		});
	}

	public void SetData(Product p, int window){
		windowCome = window; 
		name.text = p.nameProduct;
		size.text = p.size;
		observations.text = p.observations;
		trademarkName.text = p.trademark.name;
		trademarkReference.text = p.trademark.reference.ToString();
		quantity.text = p.quantity.ToString();
		date.text= p.date;
	}

	public void SetActive() {
		gameObject.SetActive (true);
	}

	public void SetInactive (){
		gameObject.SetActive (false);
	}
}