using UnityEngine;

public class MostrarFormaNaCozinha : MonoBehaviour
{
    private void Start()
    {
        GameObject forma = EncontrarMesmoDesativado("FormaCheia");

        if (forma == null)
        {
            Debug.LogError("Não achei FormaCheia na CenaCozinha.");
            return;
        }

        if (RecipeManager.instance != null && RecipeManager.instance.formaPronta)
        {
            forma.SetActive(true);
            Debug.Log("FormaCheia apareceu na cozinha.");
        }
        else
        {
            forma.SetActive(false);
            Debug.Log("Forma ainda não está pronta.");
        }
    }

    GameObject EncontrarMesmoDesativado(string nome)
    {
        Transform[] todos = Resources.FindObjectsOfTypeAll<Transform>();

        foreach (Transform obj in todos)
        {
            if (obj.name == nome && obj.gameObject.scene.isLoaded)
            {
                return obj.gameObject;
            }
        }

        return null;
    }
}