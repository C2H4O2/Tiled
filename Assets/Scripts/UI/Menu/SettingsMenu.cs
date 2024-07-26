using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void OpenSettings() {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
    public void CloseSettings() {
        SceneManager.UnloadSceneAsync(2);
    }
}
