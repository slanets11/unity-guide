using UnityEngine;

public class Gem : MonoBehaviour
{
    internal GemSpawner gemSpawner;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gem Collected!");
            gemSpawner.SpawnGem();
            Destroy(gameObject);
        }     
    }
}
