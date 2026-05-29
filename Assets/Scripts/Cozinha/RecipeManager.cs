using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager instance;

    public TMP_Text objetivoText;

    public int etapaAtual = 0;

    public bool massaPronta = false;

    private string[] objetivos =
    {
        "Fale com o gato para receber o pedido.",
        "Pegue as bolachas no armário.",
        "Leve as bolachas ao liquidificador.",
        "Triture as bolachas.",
        "Pegue a manteiga na geladeira.",
        "Misture bolacha e manteiga na tigela.",
        "Coloque a massa na forma.",
        "Leve a forma ao freezer.",
        "Pegue amora, açúcar e limão na geladeira.",
        "Leve os ingredientes ao fogão.",
        "Prepare a geleia.",
        "Coloque a geleia na torta.",
        "Entregue a sobremesa."
    };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AtualizarObjetivo();
    }

    public void AvancarEtapa()
    {
        etapaAtual++;
        AtualizarObjetivo();
    }

    public void AtualizarObjetivo()
    {
        if (objetivoText == null) return;

        if(etapaAtual < objetivos.Length)
        objetivoText.text = objetivos[etapaAtual];
        
    }    

    public void TrocarCena(string nomeCena)
    {
         SceneManager.LoadScene(nomeCena);
    }
}    