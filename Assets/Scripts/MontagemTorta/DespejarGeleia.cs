using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DespejarGeleia : MonoBehaviour
{
    public Transform pontoDespejo;
    public GameObject tortaMontada;

    public AudioSource audioSource;
    public AudioClip somDespejar;

    public string cenaDepois = "CenaCozinha";

    private bool despejando = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (despejando) return;

        if (other.CompareTag("MassaTorta"))
        {
            StartCoroutine(Despejar());
        }
    }

    IEnumerator Despejar()
    {
        despejando = true;

        DragItem drag = GetComponent<DragItem>();
        if (drag != null)
            drag.enabled = false;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        if (pontoDespejo != null)
            transform.position = pontoDespejo.position;

        Quaternion inicio = transform.rotation;
        Quaternion fim = Quaternion.Euler(0, 0, -60);

        float tempo = 0f;

        while (tempo < 0.8f)
        {
            tempo += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(inicio, fim, tempo / 0.8f);
            yield return null;
        }

        if (audioSource != null && somDespejar != null)
        {
            audioSource.PlayOneShot(somDespejar);
        }

        yield return new WaitForSecondsRealtime(0.5f);

        gameObject.SetActive(false);

        if (tortaMontada != null)
            tortaMontada.SetActive(true);

        if (RecipeManager.instance != null)
        {
            RecipeManager.instance.tortaPronta = true;
            RecipeManager.instance.AvancarEtapa();
        }

        SceneManager.LoadScene(cenaDepois);
    }
}