using UnityEngine;
using UnityEngine.SceneManagement;

public class IrParaFogao : MonoBehaviour
{
    public string nomeCenaFogao = "CenaFogao";

    private bool playerPerto;

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            if (RecipeManager.instance.etapaAtual >= 14)
            {
                SceneManager.LoadScene(nomeCenaFogao);
            }
            else
            {
                Debug.Log("Pegue os ingredientes na geladeira primeiro.");
            }
        }
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