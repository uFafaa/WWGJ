using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public int etapaNecessaria;
    public string cenaParaAbrir;
    public bool trocaCena;
    public string mensagemErro = "Você ainda não precisa disso.";

    private bool playerPerto;

    private void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            Interagir();
        }
    }

    void Interagir()
    {
        if (RecipeManager.instance.etapaAtual != etapaNecessaria)
        {
            Debug.Log(mensagemErro);
            return;
        }

        RecipeManager.instance.AvancarEtapa();

        if (trocaCena)
        {
            RecipeManager.instance.TrocarCena(cenaParaAbrir);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.CompareTag("Player"))
    {
        playerPerto = true;

        InteractionUI.instance.Mostrar("Aperte E para interagir");
    }
    }  

    private void OnTriggerExit2D(Collider2D collision)
    {
    if (collision.CompareTag("Player"))
    {
        playerPerto = false;

        InteractionUI.instance.Esconder();
    }
    }
}