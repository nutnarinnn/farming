using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
	public PlantObject plant;

    public Text nameTxt;
    public Text priceTxt;
    public Image icon;

    public Button buyBtn;
    public Text buyBtnTxt;

	public Button sellBtn;
	public Text sellBtnTxt; 

	FarmManager fm;

	// Start is called before the first frame update
	void Start()
    {
        fm = FindObjectOfType<FarmManager>();
		InitializeUI();

    }

    public void BuyPlant()
    {
		fm.SelectPlant(this);
	}

	public void SellPlant()
	{
		if (plant.quantity > 0)
		{
			plant.quantity--;
			fm.Transaction(plant.sellPrice);
			plant.inventoryItem.quantityTxt.text = "x " + plant.quantity;
			Debug.Log("Sold " + plant.plantName);
		}
		else
		{
			Debug.Log("There is no any " + plant.plantName + " to sell.");
		}
	}

	private void InitializeUI()
	{
		nameTxt.text = plant.plantName;
		priceTxt.text = "$" + plant.buyPrice;
		icon.sprite = plant.icon;
	}
}
