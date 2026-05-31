using UnityEngine;

public class BotaoFogao : MonoBehaviour
{
    public bool podeLigar = false;
    public CozinharGeleia cozinhar;

    private bool clicando = false;

    private void OnMouseDown()
    {
        clicando = true;
    }

    private void OnMouseUp()
    {
        clicando = false;
    }

    private void Update()
    {
        if (!clicando) return;

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, 0, -mouseX * 200 * Time.deltaTime);

        float angulo = transform.eulerAngles.z;

        if (angulo > 40 && angulo < 120)
        {
            if (!podeLigar)
            {
                Debug.Log("Coloque amora, açúcar e suco de limão primeiro.");
                return;
            }

            Debug.Log("Fogo baixo!");

            if (cozinhar != null)
                cozinhar.Iniciar();

            enabled = false;
        }
    }
}