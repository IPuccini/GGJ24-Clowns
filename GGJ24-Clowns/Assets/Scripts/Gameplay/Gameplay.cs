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
	private readonly List<RulesDataBase> _currentRules = new List<RulesDataBase>();

	public void InitDay(DayData newDay)
	{
		_currentDay = newDay;

		_currentPeople.Clear();
		_currentPeople.AddRange(_currentDay.People);
		_currentPeople.Shuffle();

		_currentRules.Clear();
		_currentRules.AddRange(_currentDay.Rules);

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

	public void AcceptPerson(bool accept)
	{
		if(CheckIfIsClown())
		{
			// TODO Lose time
			if (accept)
			{
				Debug.Log("WRONG! A clown was accepted");
			}else
			{
				Debug.Log("NICE! A clown was NOT accepted");
			}
		}else
		{
			if (!accept)
			{
				Debug.Log("WRONG! A normal person was NOT accepted");
			}
			else
			{
				Debug.Log("NICE! A normal person was accepted");
			}
		}
		// todo dispatch event?
	}


	private bool CheckIfIsClown()
	{
		foreach (RulesDataBase rule in _currentRules)
		{
			foreach (ItemData item in _currentPerson.Items)
			{
				if(rule.CheckRule(item))
				{
					return true;
				}
			}
		}
		return false;
	}


	public void NextDay()
	{
		// TODO
		InitDay(_initialDayData);
	}

}


