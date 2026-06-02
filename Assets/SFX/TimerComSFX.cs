using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerComSFX : MonoBehaviour
{
    public Slider barra;

    public float tempoTotal = 30f;

    public AudioSource audioSource;
    public AudioClip somRelogio;
    public AudioClip somPronto;

    private bool rodando = false;

    public void IniciarTimer()
    {
        if (rodando) return;

        StartCoroutine(ContarTempo());
    }

    IEnumerator ContarTempo()
    {
        rodando = true;

        barra.gameObject.SetActive(true);
        barra.maxValue = tempoTotal;
        barra.value = tempoTotal;

        if (audioSource != null && somRelogio != null)
        {
            audioSource.clip = somRelogio;
            audioSource.loop = true;
            audioSource.Play();
        }

        float tempo = tempoTotal;

        while (tempo > 0)
        {
            tempo -= Time.deltaTime;
            barra.value = tempo;
            yield return null;
        }

        barra.gameObject.SetActive(false);

        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.loop = false;

            if (somPronto != null)
                audioSource.PlayOneShot(somPronto);
        }

        Debug.Log("Timer terminou!");

        rodando = false;
    }
}