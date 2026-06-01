using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void IrParaOMenu()
    {
        // Certifique-se de que o nome entre aspas é o nome da sua cena de Menu
        SceneManager.LoadScene("MenuJogo");
    }
}