using UnityEngine;

public class DragColher : MonoBehaviour
{
    private bool arrastando;

    private void OnMouseDown()
    {
        arrastando = true;
    }

    private void OnMouseUp()
    {
        arrastando = false;
    }

    private void Update()
    {
        if (!arrastando) return;

        Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posMouse.z = 0;
        transform.position = posMouse;
    }
}