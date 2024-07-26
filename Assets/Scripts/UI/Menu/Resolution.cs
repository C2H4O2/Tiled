using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public struct ResolutionSetting
{
    public int width;
    public int height;
}

public class Resolution : MonoBehaviour
{
    [SerializeField] private Slider resolutionSlider;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private ResolutionSetting[] resolutions;

    

    public void ChangeResolution() {
        int width = resolutions[(int)resolutionSlider.value].width;
        int height = resolutions[(int)resolutionSlider.value].height;
        Screen.SetResolution(width,height,fullScreenToggle.isOn);
    }

    
}
