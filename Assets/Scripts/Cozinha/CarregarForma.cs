using UnityEngine;

public class CarregarForma : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 1.2f, 0);

    public bool carregando = false;
    private bool playerPerto = false;

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            carregando = true;
        }

        if (carregando && player != null)
        {
            transform.position = player.position + offset;
        }
    }

    public void Soltar()
    {
        carregando = false;
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