using System;
using UnityEngine;
using DG.Tweening;

public class PersonController : MonoBehaviour
{
	public Action OnPersonShow;
	public Action OnPersonHide;

	[SerializeField]
	private SpriteRenderer _spriteRenderer;
	[SerializeField]
	private Vector3 _offsetPosition;
	[SerializeField]
	private float _animationDuration = 1f;


	private PeopleData _data;
	private Vector3 _originalPosition;

	private void Awake()
	{
		_originalPosition = transform.localPosition;
	}

	public void Init(PeopleData newData)
	{
		_data = newData;
		SetSprite(_data.HideSprite);
	}

	public void Show()
	{
		transform.DOKill();
		transform.localPosition = _originalPosition - _offsetPosition;
		transform.DOLocalMove(_originalPosition, _animationDuration).SetEase(Ease.OutQuart).OnComplete(()=>OnPersonShow?.Invoke());
	}

	public void Reveal()
	{
		// TODO Particles or something like that
		SetSprite(_data.RevealSprite);
	}

	public void Hide()
	{
		transform.DOKill();
		transform.DOLocalMove(_originalPosition + _offsetPosition, _animationDuration).SetEase(Ease.OutQuart).OnComplete(() => OnPersonHide?.Invoke());
	}


	private void SetSprite(Sprite sprite)
	{
		_spriteRenderer.sprite = sprite;
	}
}


