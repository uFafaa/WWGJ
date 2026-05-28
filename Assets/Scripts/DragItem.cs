using UnityEngine;

public class DragItem : MonoBehaviour
{
    private Vector3 posicaoInicial;
    private bool foiEntregue = false;

    private void Start()
    {
        posicaoInicial = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        if (!foiEntregue)
        {
            transform.position = posicaoInicial;
        }
    }

    public void MarcarComoEntregue()
    {
        foiEntregue = true;
    }
}