using UnityEngine;

public class PapelInterativo : MonoBehaviour
{
    [Header("Configurações de UI")]
    public GameObject painelTexto;

    public AudioSource audioPapel;

    private bool jogadorPerto = false;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            if (!painelTexto.activeSelf)
            {
                painelTexto.SetActive(true);

                if (audioPapel != null)
                    audioPapel.Play();             
            }
            else
            {
                painelTexto.SetActive(false);
                Destroy(gameObject);
            }
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