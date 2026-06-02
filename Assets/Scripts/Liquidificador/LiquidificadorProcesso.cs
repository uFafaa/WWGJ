using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LiquidificadorProcesso : MonoBehaviour
{
    public Slider barra;

    public GameObject bolachaInteira;
    public GameObject bolachaTriturada;

    public float tempoTriturar = 5f;

    public AudioSource audioSource;
    public AudioClip somLiquidificador;
    public AudioClip somPronto;

    private bool processando = false;
    private bool terminou = false;

    private void Start()
    {
        if (barra != null)
            barra.gameObject.SetActive(false);

        if (bolachaTriturada != null)
            bolachaTriturada.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (processando || terminou) return;

        StartCoroutine(Triturar());
    }

    IEnumerator Triturar()
    {
        processando = true;

        if (barra != null)
        {
            barra.gameObject.SetActive(true);
            barra.maxValue = tempoTriturar;
            barra.value = tempoTriturar;
        }

        if (audioSource != null && somLiquidificador != null)
        {
            audioSource.Stop();
            audioSource.clip = somLiquidificador;
            audioSource.loop = true;
            audioSource.Play();
        }

        float tempo = tempoTriturar;

        while (tempo > 0)
        {
            tempo -= Time.deltaTime;

            if (barra != null)
                barra.value = tempo;

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

        if (bolachaInteira != null)
            bolachaInteira.SetActive(false);

        if (bolachaTriturada != null)
            bolachaTriturada.SetActive(true);

        terminou = true;
        processando = false;
    }
}