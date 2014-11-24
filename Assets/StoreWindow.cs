using UnityEngine;
using System.Collections;
using Soomla.Store;

public class StoreWindow : MonoBehaviour {

	private static StoreEventHandler handler;

	void Start () {
		handler = new StoreEventHandler();

		SoomlaStore.Initialize(new StoreAssets());

	}
	

}
