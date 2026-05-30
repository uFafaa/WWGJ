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
        "5. Leve a forma ao freezer e espere descansar",
        "6. Leve ao balcão novamente",
        "7. Pegar ingredientes na geladeira",
        "8. Vá ao fogão e prepare os ingredientes",
        "9. Pegar amora, açúcar e limão",
        "10. Levar os ingredientes ao fogão",
    };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += AoCarregarCena;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void AoCarregarCena(Scene scene, LoadSceneMode mode)
    {
        objetivoText = GameObject.Find("TextoObjetivo")?.GetComponent<TMP_Text>();
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
        objetivoText.text = objetivos[etapaAtual];
    }

    public void TrocarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
}