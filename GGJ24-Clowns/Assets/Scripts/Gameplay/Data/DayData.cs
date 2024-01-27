using UnityEngine;

[CreateAssetMenu(fileName = "Day_Data_New", menuName = "GGJ24/Day/Data")]
public class DayData : ScriptableObject
{
	[SerializeField, TextArea]
	private string _description = string.Empty;
	[SerializeField]
	private float _levelDuration = 10f;
	[SerializeField]
	private float _extraTime = 5f;
	[SerializeField]
	private PeopleData[] _people;
	[SerializeField]
	private RulesDataBase[] _rules;

	public string Description => _description;
	public float ExtraTime => _extraTime;
	public PeopleData[] People => _people;
	public RulesDataBase[] Rules => _rules;
	public float LevelDuration => _levelDuration;

}


