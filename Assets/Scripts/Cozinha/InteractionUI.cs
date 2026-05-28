using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI instance;

    public TMP_Text texto;

    private void Awake()
    {
        instance = this;
    }

    public void Mostrar(string mensagem)
    {
        texto.text = mensagem;
        texto.gameObject.SetActive(true);
    }

    public void Esconder()
    {
        texto.gameObject.SetActive(false);
    }
}