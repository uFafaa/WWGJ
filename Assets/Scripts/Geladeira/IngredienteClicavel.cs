using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredienteClicavel : MonoBehaviour
{
    public string nomeIngrediente;
    public string cenaDestino = "CenaFogao";

    private void OnMouseDown()
    {
        InventarioReceita.ingredienteSelecionado = nomeIngrediente;

        Destroy(gameObject);

        SceneManager.LoadScene(cenaDestino);
    }
}