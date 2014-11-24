using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Store;

public class GameHandler : MonoBehaviour {

	public static GameHandler Instance;

	public static StoreEventHandler handler;

	public Text VersionText;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		handler = new StoreEventHandler();
		SoomlaStore.Initialize(new StoreAssets());
	}


	public void ChangeToFullVersion()
	{
		VersionText.text = "Full Version";
		VersionText.color = new Color(0 , 1 , 0);
	}


	public void BuyGame()
	{
		Debug.Log("Buy Called");
		StoreInventory.BuyItem(StoreAssets.FULL_VERSION_LIFE_TIME_SOOMLA_ID);
	}
}
