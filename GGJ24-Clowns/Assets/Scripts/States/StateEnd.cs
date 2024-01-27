using UnityEngine;

public class StateEnd : State
{
	[SerializeField]
	private Gameplay _gameplay;
	[SerializeField]
	private EndController _end;

	[SerializeField]
	private State _nextSate;


	public override void Enter(StateManager manager)
	{
		base.Enter(manager);
		_end.gameObject.SetActive(true);
		_end.Show( _gameplay.CurrentDayIndex);
		Debug.Log("StateEnd");
		_end.OnAnimationEnd += GoToNextState;
	}

	private void GoToNextState()
	{
		ChangeState(_nextSate);
	}

	public override void Exit()
	{
		_end.OnAnimationEnd -= GoToNextState;
		_end.gameObject.SetActive(false);
		base.Exit();
	}


}
