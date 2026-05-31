using UnityEngine;

public class PanelaIngredientes : MonoBehaviour
{
    public bool amora;
    public bool acucar;
    public bool sucoDeLimao;

    public BotaoFogao botao;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Amora"))
        {
            amora = true;
            other.gameObject.SetActive(false);
            Debug.Log("Amora adicionada");
        }

        if (other.CompareTag("Acucar"))
        {
            acucar = true;
            other.gameObject.SetActive(false);
            Debug.Log("Açúcar adicionado");
        }

        if (other.CompareTag("SucoDeLimao"))
        {
            sucoDeLimao = true;
            other.gameObject.SetActive(false);
            Debug.Log("Suco de limão adicionado");
        }

        if (amora && acucar && sucoDeLimao)
        {
            Debug.Log("Todos ingredientes adicionados");
            botao.podeLigar = true;
        }
    }
}