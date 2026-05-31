using UnityEngine;

public class ColetarIngredientesGeladeira : MonoBehaviour
{
    public GameObject amora;
    public GameObject acucar;
    public GameObject limao;

    public Transform player;

    public Vector3 offsetAmora = new Vector3(-0.5f, 1.3f, 0);
    public Vector3 offsetAcucar = new Vector3(0, 1.5f, 0);
    public Vector3 offsetLimao = new Vector3(0.5f, 1.3f, 0);

    private bool playerPerto;
    private bool coletou;

    void Start()
    {
        amora.SetActive(false);
        acucar.SetActive(false);
        limao.SetActive(false);
    }

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E) && !coletou)
        {
            if (RecipeManager.instance == null) return;

            if (!RecipeManager.instance.formaGelada)
            {
                Debug.Log("Espere a forma ficar pronta no freezer.");
                return;
            }

            if (!RecipeManager.instance.formaNoBalcao)
            {
                Debug.Log("Coloque a forma no balcão primeiro.");
                return;
            }

            coletou = true;
            RecipeManager.instance.ingredientesPegos = true;
            RecipeManager.instance.AvancarEtapa();

            amora.SetActive(true);
            acucar.SetActive(true);
            limao.SetActive(true);

            Debug.Log("Pegou amora, açúcar e limão.");
        }

        if (coletou)
        {
            amora.transform.position = player.position + offsetAmora;
            acucar.transform.position = player.position + offsetAcucar;
            limao.transform.position = player.position + offsetLimao;
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