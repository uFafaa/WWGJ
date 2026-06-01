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
            bool painelEstaAtivo = painelTexto.activeSelf;
            painelTexto.SetActive(!painelEstaAtivo);
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
            painelTexto.SetActive(false);
        }
    }
}