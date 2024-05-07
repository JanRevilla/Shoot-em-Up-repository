using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    //private float maxX, maxY,minX, minY;
    float x, y;
    [SerializeField]private Transform spawnPoints;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float minTimeBetweenSpawns = 6f;
    [SerializeField] private float maxTimeBetweenSpawns = 9f;
    private float timeNextSpawn;
    void Start()
    {
        //maxX = puntos.Max(punto => punto.position.x);
        //minX = puntos.Min(punto => punto.position.y);
        //maxY = puntos.Max(punto => punto.position.x);
        //minX = puntos.Min(punto => punto.position.y);
        x = spawnPoints.position.x;
        y = spawnPoints.position.y;
        timeNextSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns); // Inicializa el tiempo para la pr�xima generaci�n aleatoriamente
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeNextSpawn)
        {
            CrearEnemigo(); // Genera un enemigo cuando se alcanza el tiempo para la pr�xima generaci�n
            timeNextSpawn = Time.time + Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns); // Actualiza el tiempo para la pr�xima generaci�n aleatoriamente
        }
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemies.Length);
        Vector2 posicionAleatoria = new Vector2 (x,y);

        Instantiate(enemies[numeroEnemigo],posicionAleatoria,Quaternion.identity) ;
    }
}
