using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GammaChange : MonoBehaviour
{
    public void OnSliderChange(UnityEngine.UI.Slider slider)
    {
        RenderSettings.ambientLight = new Color(slider.value, slider.value, slider.value, 1.0f);
    }
}
