using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
	public PlantObject plant;
	public Image icon;
	public Text quantityTxt;

	void Start()
    {
		plant.quantity = 0;
		icon.sprite = plant.icon;
		quantityTxt.text = "x " + plant.quantity;
	}
}
