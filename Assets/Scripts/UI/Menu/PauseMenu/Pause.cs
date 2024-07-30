using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void OpenPause() {
        SceneManager.LoadScene(3, LoadSceneMode.Additive);

    }
    public void ClosePause() {
        SceneManager.UnloadSceneAsync(3);
    }
}
