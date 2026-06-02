using UnityEngine;

public class PassosJogador : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] sonsPassos;

    public float intervaloPasso = 0.4f;

    private float timer;

    void Update()
    {
        float movimento =
            Mathf.Abs(Input.GetAxisRaw("Horizontal")) +
            Mathf.Abs(Input.GetAxisRaw("Vertical"));

        if (movimento > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                TocarPasso();
                timer = intervaloPasso;
            }
        }
        else
        {
            timer = 0;
        }
    }

    void TocarPasso()
    {
        if (sonsPassos.Length == 0) return;

        int indice = Random.Range(0, sonsPassos.Length);

        audioSource.PlayOneShot(sonsPassos[indice]);
    }
}