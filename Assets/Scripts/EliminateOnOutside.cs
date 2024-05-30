using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDisappearing : MonoBehaviour
{
    // Referencia al objeto que hará desaparecer al enemigo
    public GameObject Enemy;
    public GameObject Tower;
    TowerBehaviour towerBehaviour;
    
    private void Update()
    {
        Tower = GameObject.Find("Tower");
        towerBehaviour = Tower.GetComponent<TowerBehaviour>();
        OnTriggerEnter2D();
    }
    private void OnTriggerEnter2D()
    {       
        if (Enemy.transform.position.x < -3.0f)
        {
            //gameObject.SetActive(false);
            towerBehaviour.GameLifes--;
            Destroy(gameObject);
        }
    }
}

