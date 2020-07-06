using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{
    public Image fadeImage; 

    // Start is called before the first frame update
    void Awake()
    {
        Registrar.Instance.TransitionHandler = this;
        DontDestroyOnLoad(this);
    }

    public void GoToScene(string scene, bool crossFade = true, float fadeTime = 1.0f)
    {
        if (crossFade) {
            StartCoroutine(FadeToScene(scene, fadeTime));
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    } 

    IEnumerator FadeToScene(string scene, float fadeTime)
    {
        float a = 0;
        while (a < 1)
        {
            yield return null;
            a += Time.deltaTime;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, a);
        }

        SceneManager.LoadScene(scene);

        while (a > 0 )
        {
            yield return null;
            a -= Time.deltaTime;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, a);
        }
    }
}


