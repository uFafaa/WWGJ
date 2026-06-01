using UnityEngine;

public class MostrarItensMontagem : MonoBehaviour
{
    public GameObject formaMontagem;
    public GameObject geleiaPronta;
    public GameObject tortaFinalCozinha;

    void Start()
    {
        if (RecipeManager.instance == null) return;

        if (RecipeManager.instance.tortaPronta)
        {
            formaMontagem.SetActive(false);
            geleiaPronta.SetActive(false);
            tortaFinalCozinha.SetActive(true);
            Debug.Log("Torta final apareceu.");
        }
        else
        {
            tortaFinalCozinha.SetActive(false);
            formaMontagem.SetActive(RecipeManager.instance.formaMontagemPronta);
            geleiaPronta.SetActive(RecipeManager.instance.geleiaPronta);
        }
    }
}