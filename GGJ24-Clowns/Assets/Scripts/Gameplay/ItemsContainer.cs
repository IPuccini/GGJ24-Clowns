using System.Collections.Generic;
using UnityEngine;

public class ItemsContainer : MonoBehaviour
{
	[SerializeField]
	private ObjectPool _itemsPool;
	[SerializeField]
	private Transform _initialPosition; // TODO

	private readonly List<ItemSearch> _activeItems = new List<ItemSearch>();


	public void Init(ItemData[] items)
	{
		if(_activeItems.Count>0)
		{
			foreach (ItemSearch item in _activeItems)
			{
				item.transform.parent = null;
				item.gameObject.SetActive(false);
			}
			_activeItems.Clear();
		}

		foreach (ItemData item in items)
		{
			ItemSearch newItem = _itemsPool.GetPooledObject().GetComponent<ItemSearch>();
			newItem.Init(item);
			newItem.transform.parent = transform;
			_activeItems.Add(newItem);
		}
	}

	public void Show()
	{
		foreach (ItemSearch item in _activeItems)
		{
			item.Show();
		}
	}

	public void Hide()
	{
		foreach (ItemSearch item in _activeItems)
		{
			item.Hide();
		}
	}
}


