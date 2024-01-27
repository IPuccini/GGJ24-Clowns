using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStart : State
{
	[SerializeField]
	private Gameplay _gameplay;
	[SerializeField]
	private State _nextSate;


	public override void Enter(StateManager manager)
	{
		base.Enter(manager);

		_gameplay.NextDay();
	}

}
