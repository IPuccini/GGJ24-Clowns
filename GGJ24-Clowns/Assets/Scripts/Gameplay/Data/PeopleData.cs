using UnityEngine;

[CreateAssetMenu(fileName = "People_Data_New", menuName = "GGJ24/People/People Data")]
public class PeopleData : ScriptableObject
{
	[SerializeField]
	private ItemData[] _items;

	public ItemData[] Items => _items;
}


