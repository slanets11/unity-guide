using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private Transform[] spawnPositions;

    private int lastPosition = -1;

    private void Start()
    {
        SpawnGem();
    }

    public void SpawnGem()
    {
        while (true)
        {
            var next = Random.Range(0, spawnPositions.Length);
            if (next == lastPosition)
                continue;
            lastPosition = next;
            var gem = Instantiate(gemPrefab, spawnPositions[next].position, Quaternion.identity).GetComponent<Gem>();
            gem.gemSpawner = this;
            return;
        }
    }
}
