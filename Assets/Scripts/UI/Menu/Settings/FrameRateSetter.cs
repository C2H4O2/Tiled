using UnityEngine;
using UnityEngine.UI;

public class FrameRateSetter : MonoBehaviour
{
    [SerializeField] private Slider FPSSlider;
    [SerializeField][Range(10, 120)] private int targetFrameRate = 60;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        targetFrameRate = PlayerPrefs.GetInt("FrameRate");
        Application.targetFrameRate = targetFrameRate;
        FPSSlider.value = targetFrameRate;
    }

    
    public void SetTargetFrameRate()
    {
        targetFrameRate = (int)FPSSlider.value;
        Application.targetFrameRate = targetFrameRate;
        PlayerPrefs.SetInt("FrameRate", targetFrameRate);
    }
}
