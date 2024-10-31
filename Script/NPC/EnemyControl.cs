using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    public float speed;
    public Transform player;
    // Update is called once per frame
    void Awake(){
        enemyRb = GetComponent<Rigidbody2D>();
        enemyRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        enemyRb.freezeRotation = true;
    }
    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer(){
        Vector2 direction = (player.position - transform.position).normalized;

        enemyRb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player"))
            enemyRb.velocity = Vector2.zero;
    }
}
