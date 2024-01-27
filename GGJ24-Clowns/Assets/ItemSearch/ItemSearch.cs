using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ItemSearch : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Material material1;
    public Material material2;
    Renderer rend;

    [Header("SpriteRenderers")]
    [SerializeField]
    private SpriteRenderer _hideSprite;
    [SerializeField]
    private SpriteRenderer _realSprite;

    [Header("Animation")]
    [SerializeField]
    private Vector3 _normalScale = Vector3.one;
    [SerializeField]
    private Vector3 _rollOverScale = Vector3.one;
    [SerializeField]
    private Vector3 _clickScale = Vector3.one;
    [SerializeField]
    private float _animDurations = .6f;

    private ItemData _data;


    public bool allowRollover = true;

	public void Init(ItemData itemData)
	{
        _data = itemData;
        _hideSprite.sprite = _data.HideSprite;
        _realSprite.sprite = _data.RealSprite;
        _realSprite.gameObject.SetActive(false);
        transform.localScale = Vector3.zero;

        gameObject.SetActive(true);
    }

    public void Show()
    {
        transform.DOScale(_normalScale, _animDurations).SetEase(Ease.OutBack);
    }

    public void Hide()
    {
        transform.DOKill();
        transform.DOScale(0, _animDurations).SetEase(Ease.InBack);
    }

    public void onRollover()
    {
        if (!allowRollover) return;

        //Debug.Log("RO");
        //transform.DOScaleX(2.2f, 0.6f).SetEase(Ease.OutSine);
        //transform.DOScaleY(2.2f, 0.6f).SetEase(Ease.OutSine);
        transform.DOScale(_rollOverScale, _animDurations).SetEase(Ease.OutSine);
    }

    public void onRolloverOff()
    {
        if (!allowRollover) return;

        //Debug.Log("RO");

        //transform.DOScaleX(2.0f, 0.6f).SetEase(Ease.OutBounce);
        //transform.DOScaleY(2.0f, 0.6f).SetEase(Ease.OutBounce);
        transform.DOScale(_normalScale, _animDurations).SetEase(Ease.OutBounce);
    }

    public void onClickShaderAnim()
    {
        if (!allowRollover) return;

        allowRollover = false;

        /*Debug.Log("RO");
        transform.DOScaleX(2.4f, 0.6f).SetEase(Ease.OutBack).OnComplete(() => {
            rend = GetComponent<Renderer>();
            rend.material = material2;
            transform.DOScaleX(2.4f, 2.5f).OnComplete(() =>
            {
                //rend.material = Empty;
                //rend.material.color.a = 0;
                rend.enabled = false;

            });
        });
        transform.DOScaleY(2.4f, 0.6f).SetEase(Ease.OutBack);*/

		transform.DOScale(_clickScale, _animDurations).SetEase(Ease.OutBack).OnComplete(() => {
			rend = GetComponent<Renderer>();
			rend.material = material2;
			transform.DOScale(_clickScale, 2.5f).OnComplete(() =>
			{
				//rend.material = Empty;
				//rend.material.color.a = 0;
				rend.enabled = false;

			});
		});
	}

	public void OnPointerClick(PointerEventData eventData)
	{
        onClickShaderAnim();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
        onRollover();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
        onRolloverOff();
	}
}
