using UnityEngine;
using TMPro;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager instance;

    public TMP_Text recipeText;

    public int etapaAtual = 0;

    private string[] etapas =
    {
        "Pegue o ingrediente na geladeira.",
        "Coloque o ingrediente no fogão.",
        "Espere cozinhar sem queimar.",
        "Entregue o pedido."
    };

    void Awake()
    {
        instance = this;
    }

    //void Start()
    //{
        //AtualizarTextoReceita();
    //}

    public void CompletarEtapa(int etapa)
    {
        if (etapa == etapaAtual)
        {
            etapaAtual++;
            //AtualizarTextoReceita();

            if (etapaAtual >= etapas.Length)
            {
                GameManager.instance.Vencer();
            }
        }
        else
        {
            GameManager.instance.AdicionarErro();
            GameManager.instance.MostrarDica("Você fez a ação na ordem errada.");
        }
    }

    //void AtualizarTextoReceita()
    //{
        //if (etapaAtual < etapas.Length)
        //{
            //recipeText.text = "Objetivo: " + etapas[etapaAtual];
        //}
        //else
        //{
            //recipeText.text = "Pedido finalizado!";
        //}
    //}
}