using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Collider2D enemyCollider;
    HealthComponent healthComponent;
    public float speed = 2f;
    public float distance = 3f;
    private Vector3 startingPosition;
    private int direction = -1;
    public Animator animator;
    private bool canMove = true;

    void Start()
    {
        startingPosition = transform.position;
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.OnLifeDepleted += Die;
    }

    void Update()
    {
        if (canMove)
        {
            Vector3 movement = Vector3.right * direction * speed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
    private void Die()
    {
        animator.SetTrigger("EnemyDead");
        canMove = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        PointSystem.NewPoints(1);
        healthComponent.OnLifeDepleted -= Die;
        Destroy(gameObject, 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthComponent playerHealthComponent = other.GetComponent<HealthComponent>();
        if (playerHealthComponent != null)
        {
            playerHealthComponent.Hit();
        }
    }
}
