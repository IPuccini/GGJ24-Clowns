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
		_canvasGroup.gameObject.SetActive(true);
		_gameplay.SetActive(true);
		base.Enter(manager);

		_gameplay.NextPerson();
	}

	public override void Exit()
	{
		_canvasGroup.gameObject.SetActive(false);
		base.Exit();
	}
}
