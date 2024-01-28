using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class ItemsContainer : MonoBehaviour
{
	[SerializeField]
	private ObjectPool _itemsPool;
	[SerializeField]
	private List<Transform> _positions;
	[SerializeField]
	private Transform _briefcase;

	private readonly List<ItemSearch> _activeItems = new List<ItemSearch>();

	private void Awake()
	{

		_briefcase.transform.localScale = new Vector3(1, 0, 1);
	}

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

		_briefcase.transform.localScale = new Vector3(1, 0, 1);
	}

	public void Show()
	{
		foreach (ItemSearch item in _activeItems)
		{
			item.Show(.2f);
		}

		_briefcase.transform.DOScaleY(1, .3f);
	}

	public void Hide()
	{
		foreach (ItemSearch item in _activeItems)
		{
			item.Hide();
		}

		_briefcase.transform.DOScaleY(0, .3f).SetDelay(.4f);
	}
}


