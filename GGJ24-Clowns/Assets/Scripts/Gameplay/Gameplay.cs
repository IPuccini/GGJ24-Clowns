using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gameplay : MonoBehaviour
{
	[Header("Systems")]
	[SerializeField]
	private PersonController _personController;
	[SerializeField]
	private ItemsContainer _itemsContainer;
	[SerializeField]
	private RulesController _rulesContainer;
	[SerializeField]
	private Clock _clock;

	[Header("Data")]
	[SerializeField]
	private DayData _initialDayData;

	private DayData _currentDay;
	private PeopleData _currentPerson;
	private int _currentPersonIndex = 0;

	private float _timer = 0;
	private bool _active = false;
	private int _currentDayIndex = -1;


	private readonly List<PeopleData> _currentPeople = new List<PeopleData>();
	private readonly List<RulesDataBase> _currentRules = new List<RulesDataBase>();

	public int CurrentDayIndex => _currentDayIndex;
	public DayData CurrentDayData => _currentDay;


	private void Awake()
	{
		_personController.OnPersonShow += ShowItems;

	}

	private void ShowItems()
	{
		_itemsContainer.Show();
	}

	public void InitDay(DayData newDay)
	{
		_currentDay = newDay;

		_currentPeople.Clear();
		_currentPeople.AddRange(_currentDay.People);
		_currentPeople.Shuffle();

		_currentRules.Clear();
		_currentRules.AddRange(_currentDay.Rules);

		_rulesContainer.Init(_currentDay.Rules);

		_currentPersonIndex = -1;

		_timer = _currentDay.LevelDuration;
		UpdateTimer(0);;

		//NextPerson();
	}

	private void Update()
	{
		if(!_active )
		{
			return;
		}

		UpdateTimer(Time.deltaTime);

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
		_personController.Show();

		_itemsContainer.Init(_currentPerson.Items);
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
		_currentDayIndex++;

		InitDay(_initialDayData);
	}

	private void UpdateTimer(float delta)
	{
		_timer -= delta;
		if(_timer <=.0f)
		{
			// NextDay();
		}

		_clock.UpdateTimer(_timer, _currentDay.LevelDuration);

	}

	public void SetActive(bool active)
	{
		_active = active;
	}
}


