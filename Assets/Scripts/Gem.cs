using UnityEngine;

public class Gem : MonoBehaviour
{
    internal GemSpawner gemSpawner;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gemSpawner.SpawnGem();
            FindObjectOfType<GemCounter>().Score++; // Так делать крайне не рекомендуется, использую в учебных целях
            Destroy(gameObject);
        }     
    }
}
