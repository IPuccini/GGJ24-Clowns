using UnityEngine;

[CreateAssetMenu(fileName = "People_Data_New", menuName = "GGJ24/People/People Data")]
public class PeopleData : ScriptableObject
{
	[SerializeField]
	private Sprite _hideSprite;
	[SerializeField]
	private Sprite _revealSprite;
	[SerializeField]
	private bool _isClown = true; // TODO this is going to be checked by the rules at some point

	public Sprite HideSprite => _hideSprite;
	public Sprite RevealSprite => _revealSprite;
	// TODO
	public bool IsClown => true;
}


