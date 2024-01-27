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

    private void Start()
    {
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


}
