using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	public GameObject inventoryItem;
	List<PlantObject> plantObjects = new List<PlantObject>();

	private void Awake()
	{
		//Assets/Resources/Plants
		var loadPlant = Resources.LoadAll("Plants", typeof(PlantObject));
		foreach (var plant in loadPlant)
		{
			plantObjects.Add((PlantObject)plant);
		}
		plantObjects.Sort(SortByPrice);

		foreach (var plant in plantObjects)
		{
			InventoryItem newItem = Instantiate(inventoryItem, transform).GetComponent<InventoryItem>();
			newItem.plant = plant;
			plant.inventoryItem = newItem;
		}
	}

	int SortByPrice(PlantObject plantObject1, PlantObject plantObject2)
	{
		return plantObject1.buyPrice.CompareTo(plantObject2.buyPrice);
	}
}
