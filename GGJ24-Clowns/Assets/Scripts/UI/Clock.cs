using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private Image _clockBar;

    public void UpdateTimer(float current, float max)
    {
        _clockBar.fillAmount = 1f - current / max;
    }

}
