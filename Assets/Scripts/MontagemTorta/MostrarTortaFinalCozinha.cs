using UnityEngine;

public class MostrarTortaFinalCozinha : MonoBehaviour
{
    public GameObject tortaFinalCozinha;

    private void Start()
    {
        if (RecipeManager.instance == null) return;

        if (tortaFinalCozinha != null)
        {
            tortaFinalCozinha.SetActive(RecipeManager.instance.tortaPronta);
        }
    }
}