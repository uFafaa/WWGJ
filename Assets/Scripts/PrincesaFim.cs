using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincesaFim : MonoBehaviour
{
    [Header("Objeto da Torta na Cena")]
    public GameObject tortaFinalCozinha; // Arraste a torta aqui no Inspector

    private bool jogadorPerto = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && jogadorPerto)
        {
            EntregarTorta();
        }
    }

    void EntregarTorta()
    {
        Debug.Log("SUCESSO: Você entregou a torta para a princesa!");

        // Faz a torta sumir da cena se ela existir
        if (tortaFinalCozinha != null)
        {
            Destroy(tortaFinalCozinha);
        }

        // Carrega a tela final do jogo
        SceneManager.LoadScene("CenaFinal"); 
    }

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}