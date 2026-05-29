using UnityEngine;
using UnityEngine.SceneManagement;

public class MisturarMassa : MonoBehaviour
{
    public int movimentosNecessarios = 80;
    public float distanciaMinima = 0.03f;

    private int movimentos = 0;
    private bool colherDentro = false;
    private Transform colher;
    private Vector3 ultimaPosicaoColher;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Colher"))
        {
            colherDentro = true;
            colher = collision.transform;
            ultimaPosicaoColher = colher.position;

            Debug.Log("Colher entrou na tigela");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Colher"))
        {
            colherDentro = false;
            colher = null;

            Debug.Log("Colher saiu da tigela");
        }
    }

    private void Update()
    {
        if (!colherDentro) return;
        if (colher == null) return;
        if (!Input.GetMouseButton(0)) return;

        float distancia = Vector3.Distance(colher.position, ultimaPosicaoColher);

        if (distancia >= distanciaMinima)
        {
            movimentos++;

            ultimaPosicaoColher = colher.position;

            Debug.Log("Misturando: " + movimentos + "/" + movimentosNecessarios);
        }

        if (movimentos >= movimentosNecessarios)
        {
            Debug.Log("Massa pronta!");

            SceneManager.LoadScene("FormaCena");
        }
    }
}