using UnityEngine;

[CreateAssetMenu(fileName = "Day_Data_New", menuName = "GGJ24/Day/Data")]
public class DayData : ScriptableObject
{
	[SerializeField]
	private float _levelDuration = 10f;
	[SerializeField]
	private PeopleData[] _people;
	[SerializeField]
	private RulesDataBase[] _rules;

	public PeopleData[] People => _people;
	public RulesDataBase[] Rules => _rules;

}


