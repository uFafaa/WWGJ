using UnityEngine;

public class ItemTorta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.CompareTag("Player"))
        {
            if (RecipeManager.instance != null)
            {
                RecipeManager.instance.tortaPronta = true;
            }
            Destroy(gameObject); 
        }
    }
}