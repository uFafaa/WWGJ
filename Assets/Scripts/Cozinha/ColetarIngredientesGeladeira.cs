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
            coletou = true;

            amora.SetActive(true);
            acucar.SetActive(true);
            limao.SetActive(true);

            RecipeManager.instance.AvancarEtapa();

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