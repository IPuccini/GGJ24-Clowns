using System;
using UnityEngine;

public class PersonController : MonoBehaviour
{
	public Action OnPersonShow;
	public Action OnPersonHide;

	[SerializeField]
	private SpriteRenderer _spriteRenderer;
	[SerializeField]
	private Vector3 _offsetPosition;


	private PeopleData _data;
	private Vector3 _originalPosition;

	private void Awake()
	{
		_originalPosition = transform.localPosition;
	}

	public void Init(PeopleData newData)
	{
		_data = newData;

		// TODO
		SetSprite(_data.HideSprite);

	}

	public void Show()
	{
		transform.localPosition = _originalPosition - _offsetPosition;
		//TODO
		//TWeen position
		transform.localPosition = _originalPosition;
		// TODO on complete tween
		OnPersonShow?.Invoke();
	}

	public void Reveal()
	{
		// TODO
		SetSprite(_data.RevealSprite);

		OnPersonHide?.Invoke();
	}

	public void Hide()
	{
		//TODO
		//tween position transform.local + offset
		//On complete tween
		OnPersonHide?.Invoke();
	}


	private void SetSprite(Sprite sprite)
	{
		_spriteRenderer.sprite = sprite;
	}
}


