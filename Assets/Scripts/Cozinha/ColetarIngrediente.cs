using UnityEngine;

public class ColetarIngrediente : MonoBehaviour
{
    public int etapaNecessaria = 1;

    private bool playerPerto;

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            if (RecipeManager.instance.etapaAtual == etapaNecessaria)
            {
                gameObject.SetActive(false);
                RecipeManager.instance.AvancarEtapa();
            }
            else
            {
                Debug.Log("Você ainda não precisa disso.");
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