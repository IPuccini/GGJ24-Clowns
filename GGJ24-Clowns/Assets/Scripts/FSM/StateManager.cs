using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
	[SerializeField]
	private State _initialState = null;

	[Header("Read only")]
	[SerializeField]
	private State _currentState = null;

	private State _lastState = null;

	private void Start()
	{
		ChangeState(_initialState);
	}


	public void ChangeState(State newState)
	{
		if (_currentState != null)
		{
			_currentState.Exit();
		}
		_lastState = _currentState;
		_currentState = newState;
		if (_currentState != null)
		{
			_currentState.Enter(this);
		}
	}

	public void GoPreviousState()
	{
		ChangeState(_lastState);
	}

}
