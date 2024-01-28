using UnityEngine;

[CreateAssetMenu(fileName = "Rules_IntCheck_New", menuName = "GGJ24/Rules/Int check")]
public class RuleIntCheck : RulesDataBase
{
	[System.Serializable]
	private enum IntCheck
	{
		EQUAL,
		LESS,
		MORE
	}

	[SerializeField]
	private IntCheck _condition = IntCheck.EQUAL;
	[SerializeField]
	private int _triggerValue = 1;

	public override bool CheckRule(ItemData item)
	{
		foreach (ItemPropertyBase property in item.Properties)
		{
			if (property is ItemPropertyInt)
			{
				int value = ((ItemPropertyInt)property).Value;
				switch (_condition)
				{
					case IntCheck.EQUAL:
						if(value == _triggerValue)
						{
							return true;
						}
						break;
					case IntCheck.LESS:
						if (value < _triggerValue)
						{
							return true;
						}
						break;
					case IntCheck.MORE:
						if (value > _triggerValue)
						{
							return true;
						}
						break;
					default:
						break;
				}
			}
		}

		return false;
	}
}
