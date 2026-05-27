using UnityEngine;

public class TomateCortavel : MonoBehaviour
{
    public GameObject prefabMetade;
    public int numeroDePedacosAtual = 1;
    public int limiteMaximoPedacos = 5;

    public void Cortar()
    {
        if (numeroDePedacosAtual >= limiteMaximoPedacos)
        {
            return;
        }

        int novoNumeroDePedacos = numeroDePedacosAtual + 1;

        Vector3 posicaoOriginal = transform.position;
        Quaternion rotacaoOriginal = transform.rotation;

        GameObject metadeEsquerda = Instantiate(prefabMetade, posicaoOriginal + Vector3.left * 0.2f, rotacaoOriginal);
        GameObject metadeDireita = Instantiate(prefabMetade, posicaoOriginal + Vector3.right * 0.2f, rotacaoOriginal);

        metadeEsquerda.GetComponent<TomateCortavel>().numeroDePedacosAtual = novoNumeroDePedacos;
        metadeDireita.GetComponent<TomateCortavel>().numeroDePedacosAtual = novoNumeroDePedacos;

        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Cortar();
    }
}