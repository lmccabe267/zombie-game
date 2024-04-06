using UnityEngine;

public class Spawners : MonoBehaviour
{
    public float SpawningRate = 2f;
    public GameObject ZombiePrefab;
    public Transform[] SpawnPoints;

    private float LastSpawnTime;

    void Update()
    {
        if (LastSpawnTime + SpawningRate < Time.time)
        {
            var randomSpawnPoint = SpawnPoints[Random.Range(0,SpawnPoints.Length - 1)];
            Instantiate(ZombiePrefab, randomSpawnPoint.position, Quaternion.identity);
            LastSpawnTime = Time.time;
            SpawningRate = 0.98f;
        }
    }
}
