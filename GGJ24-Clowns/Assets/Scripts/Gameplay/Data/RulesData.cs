using UnityEngine;

public class RulesDataBase : ScriptableObject
{
	public virtual bool CheckRule(ItemData item )
	{
		return true;
	}

}


