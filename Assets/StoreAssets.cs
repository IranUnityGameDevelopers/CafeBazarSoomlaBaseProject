using UnityEngine;
using System.Collections;
using Soomla.Store;

public class StoreAssets : IStoreAssets {

	public static string FULL_VERSION_LIFE_TIME_PRODUCT_ID = "FullVersion";     // cafe bazar product id

	public static string FULL_VERSION_LIFE_TIME_SOOMLA_ID = "full_version";     // cafe bazar product id
	
	/// <summary>
	/// see parent.
	/// </summary>
	public int GetVersion() {
		return 0;
	}
	
	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualCurrency[] GetCurrencies() {
		return new VirtualCurrency[]{};
	}
	
	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualGood[] GetGoods() {
		return new VirtualGood[] {};
	}
	
	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualCurrencyPack[] GetCurrencyPacks() {
		return new VirtualCurrencyPack[] {};
	}
	
	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualCategory[] GetCategories() {
		return new VirtualCategory[]{};
	}

	/// <summary>
	/// Retrieves the array of all non-consumable items served by your store.
	/// </summary>
	/// <returns>All non consumable items served in your game.</returns>
	public NonConsumableItem[] GetNonConsumableItems()
	{
		return new NonConsumableItem[]{FullVersionGame};
	}


	
	public static NonConsumableItem FullVersionGame = new NonConsumableItem(
			"FullVersion", 														// name
			"If you buy this item , your game will change to full version",		// description
			FULL_VERSION_LIFE_TIME_SOOMLA_ID,									// item id
		new PurchaseWithMarket(FULL_VERSION_LIFE_TIME_PRODUCT_ID, 0));




}
