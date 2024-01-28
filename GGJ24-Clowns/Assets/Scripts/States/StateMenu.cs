using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMenu : State
{
	[SerializeField]
	private MenuController _menu;
	[SerializeField]
	private State _nextSate;

	[SerializeField]
	private Gameplay _gameplay;

	private void Awake()
	{
		_menu.OnStart =  ()=> ChangeState(_nextSate);
	}

	public override void Enter(StateManager manager)
	{
		_gameplay._currentDayIndex = -1;
		_menu.Show();
		base.Enter(manager);
	}

	public override void Exit()
	{
		_menu.Hide();
		base.Exit();
	}
}
