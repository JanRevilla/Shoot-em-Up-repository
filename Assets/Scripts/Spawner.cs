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
    [SerializeField] private float time;
    private float timeNext;
    void Start()
    {
        //maxX = puntos.Max(punto => punto.position.x);
        //minX = puntos.Min(punto => punto.position.y);
        //maxY = puntos.Max(punto => punto.position.x);
        //minX = puntos.Min(punto => punto.position.y);
        x = spawnPoints.position.x;
        y = spawnPoints.position.y;
         
    }

    // Update is called once per frame
    void Update()
    {
        timeNext += Time.deltaTime;
        if (timeNext >= time) 
        { 
            timeNext = 0;
            CrearEnemigo();
        }
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemies.Length);
        Vector2 posicionAleatoria = new Vector2 (x,y);

        Instantiate(enemies[numeroEnemigo],posicionAleatoria,Quaternion.identity) ;
    }
}
