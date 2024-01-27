using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
	protected StateManager _manager;

	public virtual void Enter(StateManager manager)
	{
		_manager = manager;

		gameObject.SetActive(true);
	}

	public virtual void Exit()
	{;
		gameObject.SetActive(false);
	}
	protected void ChangeState(State newState)
	{
		_manager.ChangeState(newState);
	}

}
