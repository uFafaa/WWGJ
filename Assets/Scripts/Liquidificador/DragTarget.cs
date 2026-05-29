using UnityEngine;
using UnityEngine.SceneManagement;

public class DragTarget : MonoBehaviour
{
    public string tagItemCorreto = "Bolacha";
    public int etapaNecessaria = 3;
    public string cenaVoltar = "Cozinha";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Encostou no alvo: " + collision.name);

        if (!collision.CompareTag(tagItemCorreto)) return;

        if (RecipeManager.instance == null)
        {
            Debug.LogError("Não existe RecipeManager na cena.");
            return;
        }

        if (RecipeManager.instance.etapaAtual != etapaNecessaria)
        {
            Debug.Log("Etapa errada. Etapa atual: " + RecipeManager.instance.etapaAtual);
            return;
        }

        DragItem item = collision.GetComponent<DragItem>();
        if (item != null)
        {
            item.MarcarComoEntregue();
        }

        Destroy(collision.gameObject);

        RecipeManager.instance.AvancarEtapa();
        SceneManager.LoadScene(cenaVoltar);
    }
}