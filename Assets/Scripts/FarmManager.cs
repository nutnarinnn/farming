using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FarmManager : MonoBehaviour
{
	public PlantItem selectPlant;
    public bool isPlanting = false;
	public int money = 100;
    public Text moneyTxt;

    public Color buyColor = new Color32(101,192,79,255);
    public Color cancleColor = new Color32(221, 76, 83, 255);
	public Color sellColor = new Color32(255, 206, 50, 255);
	public Color greyColor = new Color32(128, 128, 128, 128);

	public bool isSelecting = false;
    public int selectedTool = 0;
    // 1:Water 2:Fertilizer 3:Buy plot

    public Image[] buttonsImg;
	public Sprite normalButton;
	public Sprite selectedButton;

	// Start is called before the first frame update
	void Start()
    {
		moneyTxt.text = "$" + money;
	}

	public void SelectPlant(PlantItem newPlant)
	{
		if (selectPlant == newPlant)
        {
            CheckSelection();
        }
        else
		{
            CheckSelection();
			selectPlant = newPlant;
			selectPlant.buyBtn.image.color = cancleColor;
			selectPlant.buyBtnTxt.text = "Cancle";
			selectPlant.sellBtn.image.color = greyColor;
            selectPlant.sellBtn.enabled = false;
			isPlanting = true;
        }
	}

	public void selectTool(int toolNumber)
	{
		if (toolNumber == selectedTool)
        {
			//deselect
			CheckSelection();

		}
        else
        {
            //select tool number and check to see if anything was also selected
            CheckSelection();
            isSelecting = true;
            selectedTool = toolNumber;
            buttonsImg[toolNumber - 1].sprite = selectedButton;
        }
	}

    void CheckSelection()
    {
        if (isPlanting)
        {
            isPlanting = false;
            if (selectPlant != null)
            {
                selectPlant.buyBtn.image.color = buyColor;
                selectPlant.buyBtnTxt.text = "Buy";
				selectPlant.sellBtn.image.color = sellColor;
				selectPlant.sellBtn.enabled = true;
				selectPlant = null;
            }
        }
        if (isSelecting)
        {
            if (selectedTool > 0)
            {
				buttonsImg[selectedTool - 1].sprite = normalButton;
			}
            isSelecting = false;
            selectedTool = 0;
        }
    }

	public void Transaction(int value)
    {
        money += value;
        moneyTxt.text = "$" + money;
    }
}
