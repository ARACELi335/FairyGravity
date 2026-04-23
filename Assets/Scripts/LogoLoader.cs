using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogoLoader : MonoBehaviour
{
    public Image logo; // tu imagen del logo
    public float fadeDuration = 1f;
    public float displayTime = 1f;

    void Start()
    {
        StartCoroutine(PlayLogo());
    }

    IEnumerator PlayLogo()
    {
        // Fade In
        yield return StartCoroutine(Fade(0f, 1f));

        // Espera
        yield return new WaitForSeconds(displayTime);

        // Fade Out
        yield return StartCoroutine(Fade(1f, 0f));

        // Cargar menú
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;
        Color color = logo.color;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            logo.color = new Color(color.r, color.g, color.b, alpha);

            time += Time.deltaTime;
            yield return null;
        }

        logo.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
