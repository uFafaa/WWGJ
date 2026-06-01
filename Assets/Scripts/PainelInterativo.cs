using UnityEngine;

public class PapelInterativo : MonoBehaviour
{
    [Header("Configurações de UI")]
    public GameObject painelTexto;

    private bool jogadorPerto = false;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            painelTexto.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}