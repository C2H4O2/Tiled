using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OpenMainMenu() {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void CloseMainMenu() {
        SceneManager.UnloadSceneAsync(0);
    }
}
