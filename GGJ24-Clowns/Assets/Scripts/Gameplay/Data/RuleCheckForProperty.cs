using UnityEngine;

[CreateAssetMenu(fileName = "Rules_PropertCheck_New", menuName = "GGJ24/Rules/Property check")]
public class RuleCheckForProperty : RulesDataBase
{
	[System.Serializable]
	private enum IntCheck
	{
		EQUAL,
		LESS,
		MORE
	}


	[SerializeField]
	private ItemPropertyBase _property;
	[SerializeField]
	private IntCheck _condition = IntCheck.EQUAL;
	[SerializeField]
	private int _triggerValue = 1;

	public override bool CheckRule(ItemData item)
	{
		int counter = 0;
		foreach (ItemPropertyBase property in item.Properties)
		{
			if (property == _property)
			{
				counter++;
			}
		}
		Debug.Log($"{counter}");

		switch (_condition)
		{
			case IntCheck.EQUAL:
				if (counter == _triggerValue)
				{
					return true;
				}
				break;
			case IntCheck.LESS:
				if (counter < _triggerValue)
				{
					return true;
				}
				break;
			case IntCheck.MORE:
				if (counter > _triggerValue)
				{
					return true;
				}
				break;
		}
		return false;
	}
}
