using System;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class EndController : MonoBehaviour
{
	public Action OnAnimationEnd;

	[SerializeField]
	private CanvasGroup _canvasGroup;
	[SerializeField]
	private TMP_Text _text;
	[SerializeField]
	private string _message = "You survived {0} days without a clown coup!";
	[SerializeField]
	private float _duration = 3f;

	public void Show( int number)
	{
		_text.text = string.Format(_message, number);

		_canvasGroup.DOKill();
		_canvasGroup.alpha = 0f;
		_canvasGroup.DOFade(1, .1f).OnComplete(() => _canvasGroup.DOFade(0, .5f).SetDelay(_duration).OnComplete(Hide));
	}

	public void Hide()
	{
		OnAnimationEnd?.Invoke();
	}
}
