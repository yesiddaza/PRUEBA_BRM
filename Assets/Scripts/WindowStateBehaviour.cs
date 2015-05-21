using UnityEngine;
using System.Collections;

public class WindowStateBehaviour : MonoBehaviour {
	[SerializeField]
	private WindowState windowState;

	public WindowState WindowState {
		get {
			return windowState;
		}
		set {
			windowState = value;
		}
	}
}
