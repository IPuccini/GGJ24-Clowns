using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	public Action OnStart;

	[SerializeField]
	private Button _startBtn;

	private void OnEnable()
	{
		_startBtn.onClick.AddListener(OnStartPressed);
	}
	private void OnDisable()
	{
		_startBtn.onClick.RemoveListener(OnStartPressed);

	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	private void OnStartPressed()
	{
		OnStart?.Invoke();
	}

}
