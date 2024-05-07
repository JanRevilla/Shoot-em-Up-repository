using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
}
