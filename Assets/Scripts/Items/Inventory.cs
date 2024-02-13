using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] Item[] items;
	public Item currentItem { get; private set; }
	[SerializeField] private int selected = 0;

	private void Start()
	{
		if (items.Length > 0)
		{
			EquipSelectedItem();
		}
	}

	private void EquipSelectedItem()
	{
		currentItem = items[selected];
		currentItem.Equip();
	}

	public void NextItem()
	{
		if (items.Length > 0)
		{
			currentItem.Unequip();
			selected++;
			if (selected >= items.Length)
			{
				selected = 0;
			}
			EquipSelectedItem();
		}
	}

	public void PrevItem()
	{
		if (items.Length > 0)
		{
			currentItem.Unequip();
			selected--;
			if (selected < 0)
			{
				selected = items.Length - 1;
			}
			EquipSelectedItem();
		}
	}

	public void Use()
	{
		currentItem?.Use();
	}

	public void StopUse()
	{
		currentItem?.StopUse();
	}
}
