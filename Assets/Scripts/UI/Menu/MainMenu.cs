using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void OpenSettings() {
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
    }

    public void CloseSettings() {

    }

    public void Quit() {

    }
}
