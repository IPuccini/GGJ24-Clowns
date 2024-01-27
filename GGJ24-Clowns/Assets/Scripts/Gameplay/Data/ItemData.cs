using UnityEngine;

[CreateAssetMenu(fileName = "ItemData_New", menuName = "GGJ24/People/Item")]
public class ItemData : ScriptableObject
{
	[SerializeField]
	private Sprite _sprite;

	[SerializeField]
	private ItemPropertyBase[] _properties;


	public Sprite Sprite => _sprite;
	public ItemPropertyBase[] Properties => _properties;
}


