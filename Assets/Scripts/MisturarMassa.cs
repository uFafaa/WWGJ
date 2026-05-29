using UnityEngine;
using UnityEngine.SceneManagement;

public class MisturarMassa : MonoBehaviour
{
    public int movimentosNecessarios = 100;

    private int movimentos = 0;
    private bool colherDentro = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Colher"))
        {
            colherDentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Colher"))
        {
            colherDentro = false;
        }
    }

    private void Update()
    {
        if (!colherDentro) return;

        if (Input.GetMouseButton(0))
        {
            movimentos++;

            if (movimentos >= movimentosNecessarios)
            {
                RecipeManager.instance.massaPronta = true;

                Debug.Log("Mistura pronta!");

                enabled = false;
            }
        }
    }
}