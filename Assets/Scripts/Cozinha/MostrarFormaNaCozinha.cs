using UnityEngine;

public class MostrarFormaNaCozinha : MonoBehaviour
{
    private void Start()
    {
        GameObject forma = GameObject.Find("FormaCheia");

        if (forma == null) return;

        if (RecipeManager.instance != null && RecipeManager.instance.formaPronta)
        {
            forma.SetActive(true);
        }
        else
        {
            forma.SetActive(false);
        }
    }
}