using UnityEngine;

public class SomDePapel : MonoBehaviour
{
    private AudioSource meuAudioSource;

    void Start()
    {
        meuAudioSource = GetComponent<AudioSource>();
    }

    public void TocarSomPapel()
    {
        // Altera o pitch levemente para o som nunca ser idêntico
        meuAudioSource.pitch = Random.Range(0.85f, 1.15f);
        
        // Toca o som de papel configurado
        meuAudioSource.Play();
    }
}