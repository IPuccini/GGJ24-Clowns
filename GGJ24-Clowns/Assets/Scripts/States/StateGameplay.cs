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

	public override void Enter(StateManager manager)
	{
		_gameplay.OnDayOver += DayOver;
		_canvasGroup.gameObject.SetActive(true);
		_gameplay.SetActive(true);
		base.Enter(manager);

		_gameplay.NextPerson();
	}

	private void DayOver()
	{
		ChangeState(_nextSate);
	}

	public override void Exit()
	{

		_gameplay.OnDayOver -= DayOver;
		_canvasGroup.gameObject.SetActive(false);
		base.Exit();
	}
}
