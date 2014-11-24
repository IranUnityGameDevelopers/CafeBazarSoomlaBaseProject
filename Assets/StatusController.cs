using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusController : MonoBehaviour {

	public static StatusController Instance;

	public Text StatusComponent;

	// Use this for initialization
	void Awake () {
		Instance = this;
	}

	public void SetStatus(string statusText)
	{
		Debug.Log(statusText);
		StatusComponent.text = "Status : " + statusText;
	}
	

}
