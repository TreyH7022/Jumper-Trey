using UnityEngine;

public class SpawnerSCripts : MonoBehaviour
{
    public GameObject prefab;
    public float spawnY = 0f;
    public float spawnX = 0f;
    public int platform = 500;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < platform; i++)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        float x = Random.Range(-spawnX, spawnX);
        Vector2 pos = new Vector2(x, spawnY);

        Instantiate(prefab, pos, Quaternion.identity);
        spawnY += Random.Range(1.5f,4.0f);

    }
}
