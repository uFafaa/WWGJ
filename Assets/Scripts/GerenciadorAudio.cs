using UnityEngine;

public class GerenciadorAudio : MonoBehaviour
{
    private static GerenciadorAudio instancia;

    void Awake()
    {
        // Impede que o som duplique ao voltar para a primeira cena
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;

        // Mantém o objeto vivo entre as cenas
        DontDestroyOnLoad(gameObject);
    }
}