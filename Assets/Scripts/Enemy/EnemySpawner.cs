using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    //private float maxX, maxY,minX, minY;
    float x, y;
    [SerializeField] private Transform spawnPoints;
    [SerializeField] private GameObject[] enemies;
    float minTimeBetweenSpawns = 1;
    float maxTimeBetweenSpawns = 2;
    private float timeNextSpawn;
    [SerializeField]public static float spawnTime;
    void Start()
    {
        x = spawnPoints.position.x;
        y = spawnPoints.position.y;
        timeNextSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeNextSpawn)
        {
            CrearEnemigo();
            timeNextSpawn = Time.time + Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns) + spawnTime;
        }
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemies.Length);
        Vector2 posicionAleatoria = new Vector2(x, y);

        Instantiate(enemies[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }
}