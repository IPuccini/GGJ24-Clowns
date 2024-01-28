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
	private Sprite _normalPerson;
	[SerializeField]
	private Sprite _clownPerson;

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
		SetSprite(_normalPerson);
	}

	public void Show()
	{
		//Debug.Log("Show Person");
		transform.DOKill();
		transform.localPosition = _originalPosition - _offsetPosition;
		transform.DOLocalMove(_originalPosition, _animationDuration).SetEase(Ease.OutQuart).OnComplete(()=>OnPersonShow?.Invoke());
	}

	public void Reveal(bool isClown)
	{
		// TODO Particles or something like that
		SetSprite(isClown? _clownPerson : _normalPerson);
	}

	public void Hide(bool left = false)
	{
		_spriteRenderer.flipX = left;
		transform.DOKill();
		transform.DOLocalMove(_originalPosition + _offsetPosition  * (left? -1 :1), _animationDuration).SetDelay(.3f).SetEase(Ease.OutQuart).OnComplete(() => OnPersonHide?.Invoke());
	}


	private void SetSprite(Sprite sprite)
	{
		_spriteRenderer.sprite = sprite;
		_spriteRenderer.flipX = false;
	}
}


