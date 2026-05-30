using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FreezerDescanso : MonoBehaviour
{
    public Slider barra;
    public GameObject formaCheia;
    public Transform pontoDescanso;

    public float tempoDescanso = 10f;

    private bool descansando = false;
    private bool playerPerto = false;

    void Start()
    {
        barra.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E) && !descansando)
        {
            StartCoroutine(DescansarForma());
        }
    }

    IEnumerator DescansarForma()
    {
        descansando = true;

        formaCheia.transform.position = pontoDescanso.position;

        barra.gameObject.SetActive(true);
        barra.maxValue = tempoDescanso;

        float tempo = tempoDescanso;

        while (tempo > 0)
        {
            tempo -= Time.deltaTime;
            barra.value = tempo;
            yield return null;
        }

        barra.gameObject.SetActive(false);

        Debug.Log("Forma descansou no freezer!");

        RecipeManager.instance.AvancarEtapa();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerPerto = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerPerto = false;
    }
}