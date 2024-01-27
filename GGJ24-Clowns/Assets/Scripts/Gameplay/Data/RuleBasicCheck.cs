using UnityEngine;

[CreateAssetMenu(fileName = "Rules_BasicCheck_New", menuName = "GGJ24/Rules/Basic check")]
public class RuleBasicCheck : RulesDataBase
{
	public override bool CheckRule(ItemData item)
	{
		foreach (ItemPropertyBase property in item.Properties)
		{
			if(property is ItemPropertyBool && ((ItemPropertyBool)property).Value)
			{
				return true;
			}
		}

		return false ;
	}
}
