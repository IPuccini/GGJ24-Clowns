using UnityEngine;

public class RulesDataBase : ScriptableObject
{
	[SerializeField, TextArea]
	private string _text;

	public string Text => _text;

	public virtual bool CheckRule(ItemData item )
	{
		return true;
	}

}


