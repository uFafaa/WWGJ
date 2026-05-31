using UnityEngine;
using UnityEngine.SceneManagement;

public class BalcaoMontagem : MonoBehaviour
{
    public GameObject formaMontagem;
    public GameObject geleiaPronta;

    public Transform pontoForma;
    public Transform pontoGeleia;

    public string cenaMontagem = "CenaMontagemTorta";

    private bool playerPerto;
    private bool colocouForma;
    private bool colocouGeleia;

    void Update()
    {
        if (!playerPerto || !Input.GetKeyDown(KeyCode.E)) return;

        CarregarObjeto forma = formaMontagem.GetComponent<CarregarObjeto>();
        CarregarObjeto geleia = geleiaPronta.GetComponent<CarregarObjeto>();

        if (forma != null && forma.carregando)
        {
            forma.Soltar();
            formaMontagem.transform.position = pontoForma.position;
            colocouForma = true;
            Debug.Log("FormaMontagem colocada.");
        }

        if (geleia != null && geleia.carregando)
        {
            geleia.Soltar();
            geleiaPronta.transform.position = pontoGeleia.position;
            colocouGeleia = true;
            Debug.Log("GeleiaPronta colocada.");
        }

        if (colocouForma && colocouGeleia)
        {
            Debug.Log("Indo para montagem da torta.");
            SceneManager.LoadScene(cenaMontagem);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerPerto = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerPerto = false;
    }
}