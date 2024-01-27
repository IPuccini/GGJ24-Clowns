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
				item.gameObject.SetActive(false);
			}
			_activeItems.Clear();
		}

		foreach (ItemData item in items)
		{
			ItemSearch newItem = _itemsPool.GetPooledObject().GetComponent<ItemSearch>();
			newItem.Init(item);
			_activeItems.Add(newItem);
		}
	}
}


