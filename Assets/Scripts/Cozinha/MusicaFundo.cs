using UnityEngine;

public class MusicaFundo : MonoBehaviour
{
    public AudioClip musica;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = musica;
        audioSource.loop = true;
        audioSource.playOnAwake = true;

        audioSource.Play();
    }
}