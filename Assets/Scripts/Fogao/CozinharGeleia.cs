using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CozinharGeleia : MonoBehaviour
{
    public Slider barra;
    public GameObject geleiaPronta;

    public float tempo = 15f;
    public string cenaDepois = "CenaCozinha";

    public AudioSource audioSource;
    public AudioClip somFervura;
    public AudioClip somPronto;

    private bool iniciou = false;

    private void Start()
    {
        if (barra != null)
            barra.gameObject.SetActive(false);

        if (geleiaPronta != null)
            geleiaPronta.SetActive(false);
    }

    public void Iniciar()
    {
        if (iniciou) return;

        iniciou = true;
        StartCoroutine(Cozinhar());
    }

    IEnumerator Cozinhar()
    {
        if (barra != null)
        {
            barra.gameObject.SetActive(true);
            barra.maxValue = tempo;
            barra.value = tempo;
        }

        if (audioSource != null && somFervura != null)
        {
            audioSource.Stop();
            audioSource.clip = somFervura;
            audioSource.loop = true;
            audioSource.Play();
        }

        float t = tempo;

        while (t > 0)
        {
            t -= Time.deltaTime;

            if (barra != null)
                barra.value = t;

            yield return null;
        }

        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.loop = false;

            if (somPronto != null)
                audioSource.PlayOneShot(somPronto);
        }

        if (barra != null)
            barra.gameObject.SetActive(false);

        if (geleiaPronta != null)
            geleiaPronta.SetActive(true);

        if (RecipeManager.instance != null)
        {
            RecipeManager.instance.geleiaPronta = true;
            RecipeManager.instance.formaMontagemPronta = true;
            RecipeManager.instance.AvancarEtapa();
        }

        Debug.Log("Geleia pronta!");

        yield return new WaitForSecondsRealtime(1f);

        SceneManager.LoadScene(cenaDepois);
    }
}