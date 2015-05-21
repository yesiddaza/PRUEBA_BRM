using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class CreateDataController : MonoBehaviour {

	[SerializeField]
	private Button homeButton;
	[SerializeField]
	private Button saveButton;
	[SerializeField]
	private Button backMessageButton;
	[SerializeField]
	protected WindowStateBehaviour windowStateBehaviour;
	[SerializeField]
	private InputField name;
	[SerializeField]
	private InputField size;
	[SerializeField]
	private InputField observations;
	[SerializeField]
	private InputField trademarkName;
	[SerializeField]
	private InputField trademarkReference;
	[SerializeField]
	private InputField quantity;
	[SerializeField]
	private InputField date;
	[SerializeField]
	private Text SaveMessageText;
	[SerializeField]
	private GameObject SaveMessagePanel;
	private Product product;

	void Start () {
		homeButton.onClick.AddListener (delegate {
			windowStateBehaviour.WindowState = WindowState.ShowingMainWindow;
		});
		saveButton.onClick.AddListener (delegate {
			saveData();
		});
		backMessageButton.onClick.AddListener (delegate {
			SaveMessagePanel.SetActive(false);
		});
	}
	
	public void SetActive() {
		gameObject.SetActive (true);
	}
	
	public void SetInactive (){
		gameObject.SetActive (false);
	}

	private void saveData ()
	{
		product = new Product ();
		List<string> newInfo = GetInfoByInputField ();
		bool IsValidInfo = IsValidSize (newInfo [1].ToUpper ()) && IsInfoANumber (newInfo [4]) && IsInfoANumber (newInfo [5]) && IsFullInfo (newInfo) && IsReferenceLengthCorrect (newInfo [4]) && IsValidDate (newInfo [6]);
		if (IsValidInfo) {
			product.nameProduct = newInfo [0];
			product.size = newInfo [1].ToUpper();
			product.observations = newInfo [2];
			product.trademark = GetProductTrademark (newInfo [3], int.Parse (newInfo [4]));
			product.quantity = int.Parse (newInfo [5]);
			product.date = newInfo [6];
			CatalogPersistence.SaveProduct(product);
			SaveMessageText.text = "Guardado!";
			PutSpacesInBlank();
		}
		else {
			string errorMessage = "NO SE PUEDEN GUARDAR LOS DATOS! Verifique:";
			errorMessage = (!IsFullInfo (newInfo))? errorMessage + "\n-Todas las casillas deben contener datos." : errorMessage;
			errorMessage = (!IsValidSize (newInfo [1].ToUpper ()))? errorMessage + "\n-La talla debe ser S, M o L." : errorMessage;
			errorMessage = (!IsInfoANumber (newInfo [4]))? errorMessage + "\n-La referencia no debe contener letras." : errorMessage;
			errorMessage = (!IsReferenceLengthCorrect (newInfo [4]))? errorMessage + "\n-La longuitud de la referencia debe ser de 9 caracteres." : errorMessage;
			errorMessage = (!IsInfoANumber (newInfo [5]))? errorMessage + "\n-La cantidad en inventario no debe contener letras." : errorMessage;
			errorMessage = (!IsValidDate (newInfo [6]))? errorMessage + "\n-La fecha tiene un formato incorrecto." : errorMessage;
			SaveMessageText.text = errorMessage;
		}
		SaveMessagePanel.SetActive (true);
	}

	private List<string> GetInfoByInputField () {
		List<string> newInfo = new List<string> ();
		newInfo.Add (name.transform.GetChild(2).GetComponentInChildren<Text>().text);
		newInfo.Add (size.transform.GetChild(2).GetComponentInChildren<Text>().text);
		newInfo.Add (observations.transform.GetChild(2).GetComponentInChildren<Text>().text);
		newInfo.Add (trademarkName.transform.GetChild(2).GetComponentInChildren<Text>().text);
		newInfo.Add (trademarkReference.transform.GetChild(2).GetComponentInChildren<Text>().text);
		newInfo.Add (quantity.transform.GetChild(2).GetComponentInChildren<Text> ().text);
		newInfo.Add (date.transform.GetChild(2).GetComponentInChildren<Text> ().text);
		return newInfo;
	}

	private Trademark GetProductTrademark (string name, int reference) {
		Trademark trademark = new Trademark ();
		trademark.name = name;
		trademark.reference = reference;
		return trademark;
	}

	private bool IsValidDate (string tryDate)
	{
		DateTime dateTime;
		return DateTime.TryParse(tryDate, out dateTime);
	}

	private void PutSpacesInBlank () {
		name.text = string.Empty;
		size.text = string.Empty;
		observations.text = string.Empty;
		trademarkName.text = string.Empty;
		trademarkReference.text = string.Empty;
		quantity.text = string.Empty;
		date.text = string.Empty;
	}

	private bool IsFullInfo (List<string> tryInfo) {
		foreach (string word in tryInfo) {
			if (word==" " || word=="")
				return false;
		}
		return true;
	}

	private bool IsReferenceLengthCorrect (string number){
		return number.Length == 9;
	}

	private bool IsValidSize(string testSize){
		return (testSize.Length <= 1) && (testSize == "S" || testSize == "M" || testSize == "L");
	}

	private bool IsInfoANumber(string testInfo){
		try{
			int.Parse (testInfo);
			return true;
		}
		catch{
			return false;
		}
	}
}