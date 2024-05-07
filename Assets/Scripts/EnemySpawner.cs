
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    //private float maxX, maxY,minX, minY;
    float x, y;
    [SerializeField]private Transform spawnPoints;
    [SerializeField] private GameObject[]enemies;
    [SerializeField] private float minTimeBetweenSpawns = 1f;
    [SerializeField] private float maxTimeBetweenSpawns = 3f;
    private float timeNextSpawn;
    void Start()
    {
        x = spawnPoints.position.x;
        y = spawnPoints.position.y;
        timeNextSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns); // Inicializa el tiempo para la próxima generación aleatoriamente
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeNextSpawn)
        {
            CrearEnemigo(); // Genera un enemigo cuando se alcanza el tiempo para la próxima generación
            timeNextSpawn = Time.time + Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns) + 3f; // Actualiza el tiempo para la próxima generación aleatoriamente
        }
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemies.Length);
        Vector2 posicionAleatoria = new Vector2 (x,y);

        Instantiate(enemies[numeroEnemigo],posicionAleatoria,Quaternion.identity) ;
    }
}
