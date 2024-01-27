using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class DayController : MonoBehaviour
{
    public Action OnAnimationEnd;

    [SerializeField]
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private TMP_Text _day;
    [SerializeField]
    private TMP_Text _description;
    [SerializeField]
    private string _dayText = "Day #{0}";
	[SerializeField]
	private float _duration = 3f;


	public void Show(string description, int number)
    {
        _day.text = string.Format(_dayText, number);
        _description.text = description;

        _canvasGroup.alpha = 0f;
        _canvasGroup.DOFade(1, .1f).OnComplete(()=> _canvasGroup.DOFade(0,.5f).SetDelay(_duration).OnComplete(Hide));
    }

    public void Hide()
    {
        OnAnimationEnd?.Invoke();
    }



}
