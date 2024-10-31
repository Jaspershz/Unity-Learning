using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    private Animator playerAnimator;
    private Vector2 movement;
    private bool isFacingRight;
    private PlayerHealth playerHealth;

    [SerializeField] private GameObject PlayerAttack;
    [SerializeField] private float attackActiveFrame;
    [SerializeField] private float attackSpeed;
    private float attackCoolDown;

    [SerializeField] private UIManager uIManager;
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        isFacingRight = true;
        PlayerAttack.SetActive(false);
        attackCoolDown = 10f/attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!uIManager.getIsPaused()){
            PlayerMovement();
        }
        UpdateAnimation();

        if(Input.GetKey(KeyCode.Space)){
            PlayerAttack.SetActive(true);
            StartCoroutine(AttackActiveAndCoolDown());
        }
    }

    void FixedUpdate(){
        rb.velocity = movement.normalized * moveSpeed;
    }

    private void PlayerMovement(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x != 0)
            Flip();
    }

    private void Flip(){
        Vector3 playerScale = transform.localScale;
        if(movement.x > 0 && !isFacingRight){
            isFacingRight = !isFacingRight;
            playerScale.x *= -1;
        }
        else if(movement.x < 0 && isFacingRight){
            isFacingRight = !isFacingRight;
            playerScale.x *= -1;
        }
        transform.localScale = playerScale;
    }

    private void UpdateAnimation(){
        if(movement.x != 0 || movement.y != 0)
            playerAnimator.SetBool("IsRunning", true);
        else 
            playerAnimator.SetBool("IsRunning", false);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            playerHealth.TakeDamage(5);
        }
    }

    private IEnumerator AttackActiveAndCoolDown(){
        yield return new WaitForSeconds(attackActiveFrame);
        PlayerAttack.SetActive(false);
        yield return new WaitForSeconds(attackCoolDown);
    }
}
