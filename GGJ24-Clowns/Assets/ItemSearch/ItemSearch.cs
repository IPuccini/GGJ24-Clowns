using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ItemSearch : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Material material1;
    public Material material2;//ShaderMat
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

    private ItemData _data;

    public void Init(ItemData itemData)
    {
        _data = itemData;
        _hideSprite.sprite = _data.HideSprite;
        _realSprite.sprite = _data.RealSprite;

        gameObject.SetActive(true);
    }

    public void onRollover()
    {
        Debug.Log("RO");
        transform.DOScaleX(2.2f, 0.6f).SetEase(Ease.OutSine);
        transform.DOScaleY(2.2f, 0.6f).SetEase(Ease.OutSine);

    }

    public void onRolloverOff()
    {
        Debug.Log("RO");

        transform.DOScaleX(2.0f, 0.6f).SetEase(Ease.OutBounce);
        transform.DOScaleY(2.0f, 0.6f).SetEase(Ease.OutBounce);

    }

    public void onClickShaderAnim()
    {
        Debug.Log("RO");
        transform.DOScaleX(2.4f, 0.6f).SetEase(Ease.OutBack);
        transform.DOScaleY(2.4f, 0.6f).SetEase(Ease.OutBack);

        rend = GetComponent<Renderer>();
        rend.material = material2;

        //Destroy(material2);

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
