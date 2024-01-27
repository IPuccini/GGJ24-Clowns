using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StateStart : State
{
	[SerializeField]
	private Gameplay _gameplay;
	[SerializeField]
	private DayController _dayUI;

	[SerializeField]
	private State _nextSate;


	public override void Enter(StateManager manager)
	{
		base.Enter(manager);

		_gameplay.NextDay();
		_dayUI.Show(_gameplay.CurrentDayData.Description, _gameplay.CurrentDayIndex);
		_dayUI.gameObject.SetActive(true);// TODO
		_dayUI.OnAnimationEnd += GoToNextState;
	}

	private void GoToNextState()
	{
		ChangeState(_nextSate);
	}

	public override void Exit()
	{
		_dayUI.OnAnimationEnd -= GoToNextState;
		_dayUI.gameObject.SetActive(false);
		base.Exit();
	}


}
