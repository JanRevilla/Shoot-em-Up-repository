using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDisappearing : MonoBehaviour
{
    public string Find = "TowerLifes";
    public GameObject Enemy;
    public GameObject Tower;
    TowerBehaviour towerBehaviour;
    
    private void Update()
    {
        Tower = GameObject.Find(Find);
        towerBehaviour = Tower.GetComponent<TowerBehaviour>();
        OnTriggerEnter2D();
    }
    private void OnTriggerEnter2D()
    {       
        if (Enemy.transform.position.x < -1.75f)
        {
            //gameObject.SetActive(false);
            towerBehaviour.GameLifes--;
            Destroy(gameObject);
        }
    }
}

