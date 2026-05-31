using UnityEngine;

public class ColocarFormaBalcao : MonoBehaviour
{
    public GameObject formaCheia;
    public Transform pontoForma;

    private bool playerPerto = false;

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            CarregarForma carregar = formaCheia.GetComponent<CarregarForma>();

            if (carregar != null && carregar.carregando)
            {
                carregar.Soltar();

                formaCheia.transform.position = pontoForma.position;

                if (RecipeManager.instance != null)
                {
                    RecipeManager.instance.formaNoBalcao = true;
                    RecipeManager.instance.AvancarEtapa();

                Debug.Log("Forma colocada no balcão. Agora pegue os ingredientes.");
                }
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