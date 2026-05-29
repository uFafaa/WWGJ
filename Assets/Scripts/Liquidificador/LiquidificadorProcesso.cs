using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LiquidificadorProcesso : MonoBehaviour
{
    public Slider barra;
    public GameObject bolachaInteira;
    public GameObject bolachaTriturada;
    public float tempoTriturar = 5f;

    private bool processando = false;

    private void Start()
    {
        if (barra != null)
            barra.gameObject.SetActive(false);

        if (bolachaTriturada != null)
            bolachaTriturada.SetActive(false);
    }

    private void OnMouseDown()
    {
        Debug.Log("Cliquei no botão do liquidificador");

        if (!processando)
        {
            StartCoroutine(Triturar());
        }
    }

    IEnumerator Triturar()
    {
        processando = true;

        barra.gameObject.SetActive(true);

        float tempo = tempoTriturar;
        barra.maxValue = tempoTriturar;
        barra.value = tempoTriturar;

        while (tempo > 0)
        {
            tempo -= Time.deltaTime;
            barra.value = tempo;
            yield return null;
        }

        bolachaInteira.SetActive(false);
        bolachaTriturada.SetActive(true);
        barra.gameObject.SetActive(false);

        processando = false;
    }
}