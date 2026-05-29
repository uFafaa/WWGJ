using UnityEngine;

public class ReceberBolachaLiquidificador : MonoBehaviour
{
    public string tagItemCorreto = "Bolacha";
    public GameObject bolachaNoLiquidificador;

    private void Start()
    {
        bolachaNoLiquidificador.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(tagItemCorreto)) return;

        Destroy(collision.gameObject);
        bolachaNoLiquidificador.SetActive(true);

        Debug.Log("Bolacha colocada no liquidificador.");
    }
}