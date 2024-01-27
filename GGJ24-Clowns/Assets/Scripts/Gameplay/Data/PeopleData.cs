using UnityEngine;

[CreateAssetMenu(fileName = "People_Data_New", menuName = "GGJ24/People/People Data")]
public class PeopleData : ScriptableObject
{
	[SerializeField]
	private Sprite _hideSprite;
	[SerializeField]
	private Sprite _revealSprite;
	[SerializeField]
	private ItemData[] _items;

	public Sprite HideSprite => _hideSprite;
	public Sprite RevealSprite => _revealSprite;
	public ItemData[] Items => _items;
}


