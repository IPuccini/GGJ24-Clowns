using System;
using UnityEngine;

public class StateGameplay : State
{
	[SerializeField]
	private Gameplay _gameplay;
	[SerializeField]
	private CanvasGroup _canvasGroup;
	[SerializeField]
	private State _nextSate;
	[SerializeField]
	private State _timeOverState;

	public override void Enter(StateManager manager)
	{
		_gameplay.OnDayOver += DayOver;
		_gameplay.OnTimeOver += TimeOver;
		_canvasGroup.gameObject.SetActive(true);
		_gameplay.SetActive(true);
		base.Enter(manager);

		_gameplay.NextPerson();
	}

	private void TimeOver()
	{
		_gameplay.OnTimeOver -= TimeOver;
		ChangeState(_timeOverState);
	}

	private void DayOver()
	{
		ChangeState(_nextSate);
	}

	public override void Exit()
	{
		_gameplay.OnTimeOver -= TimeOver;
		_gameplay.OnDayOver -= DayOver;
		_canvasGroup.gameObject.SetActive(false);
		base.Exit();
	}
}
