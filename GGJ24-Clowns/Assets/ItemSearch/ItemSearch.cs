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

    public Texture2D texture;

    public Material[] materials;

    public int IDShader;


    public float ShaderPos = 1;

    public void Init(ItemData itemData, int ID)
	{
		transform.DOKill();


        _data = itemData;
        _hideSprite.sprite = _data.HideSprite;
        _realSprite.sprite = _data.RealSprite;
        //_realSprite.gameObject.SetActive(false);
        transform.localScale = Vector3.zero;

        _hideSprite.material = material1; // Reseting material

        //material2 = Resources.Load("Shaders/ItemMat/Dissolve_" + ID + ".mat", typeof(Material)) as Material;
        //material2 = materials[ID];
        IDShader = ID;
        _hideSprite.enabled = true;

        texture = _data.TexSprite;

		gameObject.SetActive(true);

		material2.SetFloat("_Position", 1f);

		_realSprite.transform.localScale = Vector3.zero;
        allowRollover = true;
    }

    public void Show(float delay)
    {
        transform.DOKill();
        transform.DOScale(_normalScale, _animDurations).SetDelay(delay).SetEase(Ease.OutBack);
    }

    public void Hide()
    {
        transform.DOKill();
        transform.DOScale(0, _animDurations * .5f).SetEase(Ease.InBack);
    }

    public void onRollover()
    {
        if (!allowRollover) return;

        //Debug.Log("RO");
        //transform.DOScaleX(2.2f, 0.6f).SetEase(Ease.OutSine);
        //transform.DOScaleY(2.2f, 0.6f).SetEase(Ease.OutSine);
        transform.DOKill();
        transform.DOScale(_rollOverScale, _animDurations).SetEase(Ease.OutSine);
        FindObjectOfType<AudioManager>().Play("Hover");

    }

    public void onRolloverOff()
    {
        if (!allowRollover) return;

		//Debug.Log("RO");

		//transform.DOScaleX(2.0f, 0.6f).SetEase(Ease.OutBounce);
		//transform.DOScaleY(2.0f, 0.6f).SetEase(Ease.OutBounce);
		transform.DOKill();
		transform.DOScale(_normalScale, _animDurations).SetEase(Ease.OutBounce);
        FindObjectOfType<AudioManager>().Play("MouseOff");

    }

    public void onClickShaderAnim()
    {
        if (!allowRollover) return;

        allowRollover = false;

        FindObjectOfType<AudioManager>().Play("Chime");

        material2.SetTexture("ItemIMG", texture);

        material2 = materials[IDShader];


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
        transform.DOKill();
		transform.DOScale(_clickScale, _animDurations).SetEase(Ease.OutBack).OnComplete(() => {
			//rend = GetComponent<Renderer>();
			_hideSprite.material = material2;


            ShaderPos = 1f;
            material2.SetFloat("_Position", 1f);

            _realSprite.transform.DOScale(Vector3.one, .1f);
            DOTween.To(() => ShaderPos, x => ShaderPos = x, -1f, 1f).OnUpdate(AssetPostProcess);
            //{
            //    Debug.Log("Shader:" + ShaderPos);
            //    //material2.SetFloat("Position", ShaderPos);
            //    AssetPostProcess();
            //);

            transform.DOScale(_clickScale, 2.5f).OnComplete(() =>
            {
                //rend.material = Empty;
                //rend.material.color.a = 0;
                //_hideSprite.enabled = false;

            });
        });
	}

    public void AssetPostProcess()
    {
        material2.SetFloat("_Position", ShaderPos);

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
