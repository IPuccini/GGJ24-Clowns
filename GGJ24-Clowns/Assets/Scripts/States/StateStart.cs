using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StateStart : State
{
	[SerializeField]
	private Gameplay _gameplay;
	[SerializeField]
	private CanvasGroup _gameplayUI;

	[SerializeField]
	private State _nextSate;


	public override void Enter(StateManager manager)
	{
		base.Enter(manager);

		_gameplay.NextDay();
		_gameplayUI.gameObject.SetActive(true);// TODO
	}

	public override void Exit()
	{
		_gameplayUI.gameObject.SetActive(false);
		base.Exit();
	}


}
