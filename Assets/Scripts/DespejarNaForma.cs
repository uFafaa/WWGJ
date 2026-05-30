using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DespejarNaForma : MonoBehaviour
{
    public GameObject tigelaMassa;
    public GameObject formaCheia;
    public Transform pontoDespejo;

    public string cenaDepois = "CenaCozinha";

    private bool despejando = false;

    private void Start()
    {
        formaCheia.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (despejando) return;

        if (collision.CompareTag("Massa"))
        {
            StartCoroutine(AnimarDespejo(collision.transform));
        }
    }

    IEnumerator AnimarDespejo(Transform tigela)
    {
        despejando = true;

        DragItem drag = tigela.GetComponent<DragItem>();
        if (drag != null) drag.enabled = false;

        tigela.position = pontoDespejo.position;

        float tempo = 0f;
        float duracao = 1f;

        Quaternion inicio = tigela.rotation;
        Quaternion fim = Quaternion.Euler(0, 0, -80);

        while (tempo < duracao)
        {
            tempo += Time.deltaTime;
            tigela.rotation = Quaternion.Lerp(inicio, fim, tempo / duracao);
            yield return null;
        }

        tigelaMassa.SetActive(false);
        formaCheia.SetActive(true);

        yield return new WaitForSeconds(1f);
        if (RecipeManager.instance != null)
        {
            RecipeManager.instance.formaPronta = true;
        }
        SceneManager.LoadScene(cenaDepois);
    }
}