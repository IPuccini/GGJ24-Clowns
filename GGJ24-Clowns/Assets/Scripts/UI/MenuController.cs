using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
		// Little hack, don't do this at home
		transform.DOScaleX(1.1f, .2f).OnComplete(() =>
		{
			transform.localScale = Vector3.one;

			gameObject.SetActive(false);
		});
	}

	private void OnStartPressed()
	{
		OnStart?.Invoke();
	}

}
