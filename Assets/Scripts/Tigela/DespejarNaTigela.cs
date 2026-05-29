using System.Collections;
using UnityEngine;

public class DespejarNaTigela : MonoBehaviour
{
    public GameObject tigelaBolachaTriturada;
    public GameObject conteudoBolachaTriturada;
    public GameObject massaNaTigela;

    public Transform pontoDespejo;

    private bool despejando = false;

    private void Start()
    {
        massaNaTigela.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (despejando) return;

        if (collision.CompareTag("BolachaTriturada"))
        {
            StartCoroutine(AnimarDespejo(collision.transform));
        }
    }

    IEnumerator AnimarDespejo(Transform tigelaPequena)
    {
        despejando = true;

        DragItem drag = tigelaPequena.GetComponent<DragItem>();
        if (drag != null) drag.enabled = false;

        tigelaPequena.position = pontoDespejo.position;

        float tempo = 0f;
        float duracao = 1f;

        Quaternion rotacaoInicial = tigelaPequena.rotation;
        Quaternion rotacaoFinal = Quaternion.Euler(0, 0, -80);

        while (tempo < duracao)
        {
            tempo += Time.deltaTime;
            tigelaPequena.rotation = Quaternion.Lerp(rotacaoInicial, rotacaoFinal, tempo / duracao);
            yield return null;
        }

        conteudoBolachaTriturada.SetActive(false);
        massaNaTigela.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        tigelaPequena.gameObject.SetActive(false);

        Debug.Log("Bolacha despejada na tigela.");
    }
}