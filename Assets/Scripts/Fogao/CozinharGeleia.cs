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
        barra.gameObject.SetActive(true);
        barra.maxValue = tempo;
        barra.value = tempo;

        float t = tempo;

        while (t > 0)
        {
            t -= Time.deltaTime;
            barra.value = t;
            yield return null;
        }

        barra.gameObject.SetActive(false);

        geleiaPronta.SetActive(true);

        if (RecipeManager.instance != null)
        {
            RecipeManager.instance.geleiaPronta = true;
            RecipeManager.instance.AvancarEtapa();
        }

        Debug.Log("Geleia pronta!");

        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene(cenaDepois);
    }
}