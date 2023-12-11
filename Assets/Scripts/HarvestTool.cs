using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HarvestTool : MonoBehaviour
{
	bool isBeingHold = false;

	void Update()
	{
		if (isBeingHold == true)
		{
			Vector3 mousePos;
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
		}
	}

	private void OnMouseDown()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos;
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			isBeingHold = true;
		}
	}

	private void OnMouseUp()
	{
		isBeingHold = false;
		this.gameObject.transform.localPosition = new Vector3(1.66f, 5.17f, 0);
	}

	void OnTriggerStay2D(Collider2D collision) => Log(collision);

	void Log(Collider2D collision)
	{
		if (collision.CompareTag("Plant"))
		{
			Debug.Log(collision.gameObject.name.ToString());
			PlotManager pm = collision.gameObject.transform.parent.GetComponent<PlotManager>();
			if (pm != null)
			{
				if (pm.plantStage == pm.selectedPlant.plantStages.Length - 1 && !pm.fm.isPlanting && !pm.fm.isSelecting)
				{
					pm.Harvest();
					pm.selectedPlant.quantity++;
					pm.selectedPlant.inventoryItem.quantityTxt.text = "x " + pm.selectedPlant.quantity;
				}
			}
		}
	}
}
