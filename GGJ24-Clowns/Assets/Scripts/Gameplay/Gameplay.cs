using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
	[Header("Systems")]
	[SerializeField]
	private PersonController _personController;


	[Header("Data")]
	[SerializeField]
	private DayData _initialDayData;

	private DayData _currentDay;
	private PeopleData _currentPerson;
	private int _currentPersonIndex = 0;

	private readonly List<PeopleData> _currentPeople = new List<PeopleData>();


	public void InitDay(DayData newDay)
	{
		_currentDay = newDay;

		_currentPeople.Clear();
		_currentPeople.AddRange(_currentDay.People);
		_currentPeople.Shuffle();

		_currentPersonIndex = -1;

		NextPerson();
	}

	public void NextPerson()
	{
		_currentPersonIndex++;
		if (_currentPersonIndex >= _currentPeople.Count)
		{
			//TODO
			Debug.LogWarning("Day ended. No more people");
			//NextDay();
			return;
		}

		_currentPerson = _currentPeople[_currentPersonIndex];

		_personController.Init(_currentPerson);
	}


	public void NextDay()
	{
		// TODO
		InitDay(_initialDayData);
	}

}


