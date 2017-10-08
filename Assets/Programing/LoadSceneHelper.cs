using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
    public string sceneName;
    public Color fadeColor;
    public float fadeSpeed = 0.5f;

    public void LoadScene()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;

        //SceneManager.LoadScene(sceneName);
        FadeScreen.Fade(sceneName, fadeColor, fadeSpeed);
    }
}
