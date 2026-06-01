using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DespejarGeleia : MonoBehaviour
{
    public Transform pontoDespejo;
    public GameObject tortaMontada;

    private bool despejando = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Encostou em: " + collision.name);

        if (despejando) return;

        if (collision.CompareTag("MassaTorta"))
        {
            Debug.Log("Achou MassaTorta!");
            StartCoroutine(Despejar());
        }
    }

    IEnumerator Despejar()
    {
        despejando = true;

        DragItem drag = GetComponent<DragItem>();
        if (drag != null) drag.enabled = false;

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

        gameObject.SetActive(false);

        if (tortaMontada != null)
            tortaMontada.SetActive(true);

        if (RecipeManager.instance != null)
        {
            RecipeManager.instance.AvancarEtapa();
        }

        Debug.Log("Carregando CenaCozinha agora");
        RecipeManager.instance.tortaPronta = true;
        SceneManager.LoadScene("CenaCozinha");
    }
}