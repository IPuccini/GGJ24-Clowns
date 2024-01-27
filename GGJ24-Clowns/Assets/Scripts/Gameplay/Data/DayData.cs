using UnityEngine;

[CreateAssetMenu(fileName = "Day_Data_New", menuName = "GGJ24/Day/Data")]
public class DayData : ScriptableObject
{
	[SerializeField]
	private float _levelDuration = 10f;
	[SerializeField]
	private PeopleData[] _people;
	[SerializeField]
	private RulesData[] _rules;

	public PeopleData[] People => _people;
	public RulesData[] Rules => _rules;

}


