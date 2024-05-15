using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Collider2D enemyCollider;
    public float speed = 2f;
    public float distance = 3f;
    private Vector3 startingPosition;
    private int direction = -1;
    public Animator animator;
    private bool canMove = true;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (canMove)
        {
            Vector3 movement = Vector3.right * direction * speed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
    public void Hit()
    {
        animator.SetTrigger("EnemyDead");
        canMove = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        PointSystem.NewPoints(1);
        Destroy(gameObject, 0.4f);
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
