using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ItemSearch : MonoBehaviour
{
    public Material material1;
    public Material material2;//ShaderMat
    Renderer rend;

    public bool allowRollover = true;

    private void Start()
    {
    }

    public void onRollover()
    {
        if (!allowRollover) return;

        Debug.Log("RO");
        transform.DOScaleX(2.2f, 0.6f).SetEase(Ease.OutSine);
        transform.DOScaleY(2.2f, 0.6f).SetEase(Ease.OutSine);

    }

    public void onRolloverOff()
    {
        if (!allowRollover) return;

        Debug.Log("RO");

        transform.DOScaleX(2.0f, 0.6f).SetEase(Ease.OutBounce);
        transform.DOScaleY(2.0f, 0.6f).SetEase(Ease.OutBounce);

    }

    public void onClickShaderAnim()
    {
        if (!allowRollover) return;

        allowRollover = false;

        Debug.Log("RO");
        transform.DOScaleX(2.4f, 0.6f).SetEase(Ease.OutBack).OnComplete(()=> {
            rend = GetComponent<Renderer>();
            rend.material = material2;
            transform.DOScaleX(2.4f, 2.5f).OnComplete(() =>
            {
                //rend.material = Empty;
                //rend.material.color.a = 0;
                rend.enabled = false;
                
            });
        });
        transform.DOScaleY(2.4f, 0.6f).SetEase(Ease.OutBack);

        //rend = GetComponent<Renderer>();
        //rend.material = material2;

        //Destroy(material2);

    }

}
