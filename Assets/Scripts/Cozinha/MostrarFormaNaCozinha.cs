using UnityEngine;

public class MostrarFormaNaCozinha : MonoBehaviour
{
    void Start()
    {
        GameObject forma = ProcurarMesmoDesativado("FormaCheia");

        if (forma == null)
        {
            Debug.LogError("Não achei FormaCheia.");
            return;
        }

        if (RecipeManager.instance != null && RecipeManager.instance.formaPronta)
        {
            forma.SetActive(true);
            Debug.Log("Ativei FormaCheia.");
        }
        else
        {
            Debug.Log("FormaPronta ainda está false.");
        }
    }

    GameObject ProcurarMesmoDesativado(string nome)
    {
        Transform[] todos = Resources.FindObjectsOfTypeAll<Transform>();

        foreach (Transform t in todos)
        {
            if (t.name == nome && t.gameObject.scene.isLoaded)
                return t.gameObject;
        }

        return null;
    }
}