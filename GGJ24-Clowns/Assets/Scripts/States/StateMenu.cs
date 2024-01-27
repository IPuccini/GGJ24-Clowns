using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMenu : State
{
	[SerializeField]
	private MenuController _menu;
	[SerializeField]
	private State _nextSate;

	private void Start()
	{
		_menu.OnStart +=  ()=> ChangeState(_nextSate);
	}

	public override void Enter(StateManager manager)
	{
		_menu.Show();
		base.Enter(manager);
	}

	public override void Exit()
	{
		_menu.Hide();
		base.Exit();
	}
}
