using UnityEngine;

public class DetectarObjetoDentro : MonoBehaviour
{
    public string tagDoObjeto;
    public int movimentosNecessarios = 100;

    private bool objetoDentro;
    private int movimentos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagDoObjeto))
            objetoDentro = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tagDoObjeto))
            objetoDentro = false;
    }

    private void Update()
    {
        if (!objetoDentro) return;

        if (Input.GetMouseButton(0))
        {
            movimentos++;

            if (movimentos >= movimentosNecessarios)
            {
                Debug.Log("Ação concluída!");
                enabled = false;
            }
        }
    }
}