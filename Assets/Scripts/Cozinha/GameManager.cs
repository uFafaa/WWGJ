using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Tempo")]
    public float tempoRestante = 180f;
    public TMP_Text timerText;

    [Header("Erros")]
    public int erros = 0;
    public int maxErros = 3;
    public TMP_Text errorText;

    [Header("Dicas")]
    public TMP_Text hintText;

    [Header("Painéis")]
    public GameObject winPanel;
    public GameObject losePanel;

    private bool jogoAcabou = false;

    void Awake()
    {
        instance = this;
    }

    //void Start()
    //{
        //AtualizarErros();
       //hintText.text = "";
        //winPanel.SetActive(false);
        //losePanel.SetActive(false);
        //Time.timeScale = 1f;
    //}

    void Update()
    {
        if (jogoAcabou) return;

        tempoRestante -= Time.deltaTime;

        if (tempoRestante <= 0)
        {
            tempoRestante = 0;
            Perder();
        }

        //AtualizarTimer();
    }

    //void AtualizarTimer()
    //{
      //  int minutos = Mathf.FloorToInt(tempoRestante / 60);
       // int segundos = Mathf.FloorToInt(tempoRestante % 60);

        //timerText.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    //}

    public void AdicionarErro()
    {
        erros++;
        //AtualizarErros();

        MostrarDica("Cuidado! Você cometeu um erro.");

        if (erros >= maxErros)
        {
            Perder();
        }
    }

    //void AtualizarErros()
    //{
        //errorText.text = "Erros: " + erros + "/" + maxErros;
    //}

    public void MostrarDica(string mensagem)
    {
        hintText.text = mensagem;
        CancelInvoke(nameof(LimparDica));
        Invoke(nameof(LimparDica), 4f);
    }

    void LimparDica()
    {
        hintText.text = "";
    }

    public void Vencer()
    {
        jogoAcabou = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Perder()
    {
        jogoAcabou = true;
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}