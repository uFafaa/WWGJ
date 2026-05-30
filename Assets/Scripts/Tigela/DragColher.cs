using UnityEngine;

public class DragColher : MonoBehaviour
{
    private bool arrastando;

    private void OnMouseDown()
    {
        Debug.Log("Pegou a colher");
        arrastando = true;
    }

    private void OnMouseUp()
    {
        arrastando = false;
    }

    private void Update()
    {
        if (!arrastando) return;

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;

        transform.position = mouse;
    }
}