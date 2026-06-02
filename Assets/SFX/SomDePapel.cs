using UnityEngine;

public class SomDePapel : MonoBehaviour
{
    public AudioSource audioPapel;

    public void TocarSom()
    {
        if (audioPapel != null)
        {
            audioPapel.Play();
        }
    }
}