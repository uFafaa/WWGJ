using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FreezerDescanso : MonoBehaviour
{
    public Slider barra;
    public GameObject formaCheia;
    public Transform pontoDescanso;

    public float tempoDescanso = 30f;

    private bool playerPerto = false;
    private bool descansando = false;
    private bool jaDescansou = false;

    void Start()
    {
        if (barra != null)
            barra.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E) && !descansando && !jaDescansou)
        {
            StartCoroutine(DescansarForma());
        }
    }

    IEnumerator DescansarForma()
    {
        descansando = true;

        if (RecipeManager.instance != null)
            RecipeManager.instance.formaGelando = true;

        CarregarForma carregar = formaCheia.GetComponent<CarregarForma>();

        if (carregar != null)
        {
            carregar.Soltar();
            carregar.enabled = false;
        }

        formaCheia.transform.position = pontoDescanso.position;

        barra.gameObject.SetActive(true);
        barra.maxValue = tempoDescanso;
        barra.value = tempoDescanso;

        float tempo = tempoDescanso;

        while (tempo > 0)
        {
            tempo -= Time.deltaTime;
            barra.value = tempo;
            yield return null;
        }

        barra.gameObject.SetActive(false);

        jaDescansou = true;
        descansando = false;

        if (RecipeManager.instance != null)
        {
            RecipeManager.instance.formaGelando = false;
            RecipeManager.instance.formaGelada = true;
            RecipeManager.instance.AvancarEtapa();
        }

        if (carregar != null)
            carregar.enabled = true;

        Debug.Log("Forma pronta. Aperte E perto dela para pegar.");
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