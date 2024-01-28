using UnityEngine;

[CreateAssetMenu(fileName = "ItemData_New", menuName = "GGJ24/People/Item")]
public class ItemData : ScriptableObject
{
	[SerializeField]
	private Sprite _hideSprite;
	[SerializeField]
	private Sprite _realSprite;


	[SerializeField]
	private ItemPropertyBase[] _properties;

	public Texture2D TexSprite => _realSprite.texture;

	public Sprite HideSprite => _hideSprite;
	public Sprite RealSprite => _realSprite;
	public ItemPropertyBase[] Properties => _properties;
}


