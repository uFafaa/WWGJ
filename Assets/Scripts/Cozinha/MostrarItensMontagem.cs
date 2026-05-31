using UnityEngine;

public class MostrarItensMontagem : MonoBehaviour
{
    public GameObject formaMontagem;
    public GameObject geleiaPronta;
    public GameObject formaCheia;

    void Start()
    {
        if (RecipeManager.instance == null) return;

        if (formaCheia != null)
            formaCheia.SetActive(false);

        formaMontagem.SetActive(RecipeManager.instance.formaMontagemPronta);
        geleiaPronta.SetActive(RecipeManager.instance.geleiaPronta);
    }
}