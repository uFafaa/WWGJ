using UnityEngine;
using UnityEngine.UI;

public class ControladorMudo : MonoBehaviour
{
    public static ControladorMudo instancia;

    public Toggle alternadorMudo; 
    public Button botaoMudo; 

    private bool estaMutado = false;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        estaMutado = PlayerPrefs.GetInt("JogoMutado", 0) == 1;

        ConfigurarVolumeGeral(estaMutado);

        if (alternadorMudo != null)
        {
            alternadorMudo.isOn = estaMutado;
            alternadorMudo.onValueChanged.AddListener(AlternarMudoToggle);
        }
    }

    public void AlternarMudoBotao()
    {
        estaMutado = !estaMutado;
        ConfigurarVolumeGeral(estaMutado);
    }

    public void AlternarMudoToggle(bool mutar)
    {
        estaMutado = mutar;
        ConfigurarVolumeGeral(estaMutado);
    }

    private void ConfigurarVolumeGeral(bool mutar)
    {
        AudioListener.volume = mutar ? 0f : 1f;
        PlayerPrefs.SetInt("JogoMutado", mutar ? 1 : 0);
    }
}