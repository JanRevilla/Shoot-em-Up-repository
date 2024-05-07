using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{    
    public float speed = 2f; 
    public float distance = 3f; 
    private Vector3 startingPosition;
    private int direction = -1; 

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {       
        Vector3 movement = Vector3.right * direction * speed * Time.deltaTime;
        
        transform.Translate(movement);     
    }
    public void Hit()
    {
        Destroy(gameObject); // Destruye al enemigo cuando es golpeado por la bala
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            player.Hit();
        }
    }
}
