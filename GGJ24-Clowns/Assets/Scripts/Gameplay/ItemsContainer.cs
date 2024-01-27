using System.Collections.Generic;
using UnityEngine;

public class ItemsContainer : MonoBehaviour
{
	[SerializeField]
	private ObjectPool _itemsPool;
	[SerializeField]
	private List<Transform> _positions;

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
		_positions.Shuffle();


		for (int i = 0; i < items.Length; i++)
		{

			ItemSearch newItem = _itemsPool.GetPooledObject().GetComponent<ItemSearch>();
			newItem.Init(items[i]);
			newItem.transform.parent = transform;
			newItem.transform.position = _positions[i].position;
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


