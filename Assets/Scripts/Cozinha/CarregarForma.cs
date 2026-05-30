using UnityEngine;

public class CarregarForma : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 1.2f, 0);

    private bool carregando = false;
    private bool playerPerto = false;

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            carregando = true;
        }

        if (carregando)
        {
            transform.position = player.position + offset;
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