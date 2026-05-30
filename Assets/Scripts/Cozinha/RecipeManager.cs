using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager instance;

    public TMP_Text objetivoText;

    public int etapaAtual = 0;

    public bool massaPronta = false;

    public bool formaPronta = false;

    private string[] objetivos =
    {
        "1. Falar com o gato",
        "2. Pegar a bolacha",
        "3. Levar a bolacha ao liquidificador",
        "4. Colocar a bolacha no liquidificador",
        "5. Apertar o botão do liquidificador",
        "6. Esperar triturar",
        "7. Colocar a bolacha triturada na tigela",
        "8. Mexer a massa com a colher",
        "9. Levar a massa para a forma",
        "10. Despejar a massa na forma",
        "11. Levar a forma ao freezer",
        "12. Esperar gelar",
        "13. Pegar amora, açúcar e limão",
        "14. Levar os ingredientes ao fogão",
        "15. Colocar amora na panela",
        "16. Colocar açúcar na panela",
        "17. Colocar limão na panela",
        "18. Mexer/cozinhar a geleia",
        "19. Colocar a geleia na torta",
        "20. Entregar a torta para a rainha"
        
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
        if (etapaAtual < objetivos.Length - 1)
        {
            etapaAtual++;
            AtualizarObjetivo();
        }
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