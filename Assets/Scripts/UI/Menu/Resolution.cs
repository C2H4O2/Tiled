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

    private void Start() {
        
        ResolutionSetting resolutionSetting = resolutions[PlayerPrefs.GetInt("ResolutionValue")];
        bool fullScreenOn = GetBool("FullScreen");
        Screen.SetResolution(resolutionSetting.width, resolutionSetting.height,fullScreenOn);
        fullScreenToggle.isOn = fullScreenOn;
        resolutionSlider.value = PlayerPrefs.GetInt("ResolutionValue");
    }

    public void ChangeResolution() {
        int width = resolutions[(int)resolutionSlider.value].width;
        int height = resolutions[(int)resolutionSlider.value].height;
        Screen.SetResolution(width,height,fullScreenToggle.isOn);
        PlayerPrefs.SetInt("ResolutionValue", (int)resolutionSlider.value);
        SetBool("FullScreen",fullScreenToggle.isOn);
        PlayerPrefs.Save();
    }

    public void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public bool GetBool(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
    }

}
