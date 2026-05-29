using UnityEngine;

public class MexerColher : MonoBehaviour
{
    public float velocidadeRotacao = 200f;

    public int voltasNecessarias = 5;

    private float rotacaoTotal = 0f;

    private bool misturando = false;

    private void OnMouseDown()
    {
        misturando = true;
    }

    private void OnMouseUp()
    {
        misturando = false;
    }

    private void Update()
    {
        if (!misturando) return;

        float movimento = Input.GetAxis("Mouse X");

        transform.Rotate(0, 0, movimento * velocidadeRotacao * Time.deltaTime);

        rotacaoTotal += Mathf.Abs(movimento);

        if (rotacaoTotal >= voltasNecessarias * 10)
        {
            Debug.Log("Mistura pronta!");

            enabled = false;
        }
    }
}