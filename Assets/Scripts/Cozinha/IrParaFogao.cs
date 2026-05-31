using UnityEngine;
using UnityEngine.SceneManagement;

public class IrParaFogao : MonoBehaviour
{
    public string nomeCenaFogao = "CenaFogao";

    private bool playerPerto;

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            if (RecipeManager.instance == null) return;

            if (!RecipeManager.instance.ingredientesPegos)
            {
                Debug.Log("Pegue amora, açúcar e limão primeiro.");
                return;
            }

            GameObject.Find("AmoraCarregada")?.SetActive(false);
            GameObject.Find("AcucarCarregado")?.SetActive(false);
            GameObject.Find("LimaoCarregado")?.SetActive(false);

            SceneManager.LoadScene(nomeCenaFogao);
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