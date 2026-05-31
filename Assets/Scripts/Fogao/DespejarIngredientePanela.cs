using System.Collections;
using UnityEngine;

public class DespejarIngredientePanela : MonoBehaviour
{
    public GameObject botao;

    private bool amora;
    private bool acucar;
    private bool sucoDeLimao;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Amora"))
            StartCoroutine(Despejar(collision.gameObject, "Amora"));

        if (collision.CompareTag("Acucar"))
            StartCoroutine(Despejar(collision.gameObject, "Acucar"));

        if (collision.CompareTag("SucoDeLimao"))
            StartCoroutine(Despejar(collision.gameObject, "SucoDeLimao"));
    }

    IEnumerator Despejar(GameObject ingrediente, string tipo)
    {
        Collider2D col = ingrediente.GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        DragItem drag = ingrediente.GetComponent<DragItem>();
        if (drag != null) drag.enabled = false;

        Quaternion inicio = ingrediente.transform.rotation;
        Quaternion fim = Quaternion.Euler(0, 0, 35); // inclina pra esquerda

        float tempo = 0;
        float duracao = 0.6f;

        while (tempo < duracao)
        {
            tempo += Time.deltaTime;
            ingrediente.transform.rotation = Quaternion.Lerp(inicio, fim, tempo / duracao);
            yield return null;
        }

        ingrediente.SetActive(false);

        if (tipo == "Amora") amora = true;
        if (tipo == "Acucar") acucar = true;
        if (tipo == "SucoDeLimao") sucoDeLimao = true;

        if (amora && acucar && sucoDeLimao)
        {
            BotaoFogao botaoFogao = botao.GetComponent<BotaoFogao>();
            BotaoFogao scriptBotao = botao.GetComponent<BotaoFogao>();    
            scriptBotao.podeLigar = true;
            Debug.Log("Todos os ingredientes foram despejados. Agora ligue o fogo baixo.");
        }
    }
}