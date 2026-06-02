using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReceberGeleiaTorta : MonoBehaviour
{
    public GameObject geleiaPronta;
    public GameObject tortaPronta;
    public Transform pontoDespejo;
    public string cenaDepois = "CenaCozinha";

    private bool despejando = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (despejando) return;

        if (collision.CompareTag("Geleia"))
        {
            StartCoroutine(Despejar(collision.gameObject));
        }
    }

    IEnumerator Despejar(GameObject geleia)
    {
        despejando = true;

        DragItem drag = geleia.GetComponent<DragItem>();
        if (drag != null) drag.enabled = false;

        Collider2D col = geleia.GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        geleia.transform.position = pontoDespejo.position;

        Quaternion inicio = geleia.transform.rotation;
        Quaternion fim = Quaternion.Euler(0, 0, -60);

        float tempo = 0f;

        while (tempo < 0.8f)
        {
            tempo += Time.deltaTime;
            geleia.transform.rotation = Quaternion.Lerp(inicio, fim, tempo / 0.8f);
            yield return null;
        }

        geleia.SetActive(false);

        if (tortaPronta != null)
            tortaPronta.SetActive(true);

        if (RecipeManager.instance != null)
            RecipeManager.instance.tortaPronta = true;

        Debug.Log("Carregando cozinha agora");

        SceneManager.LoadScene("CenaCozinha");
    }
}