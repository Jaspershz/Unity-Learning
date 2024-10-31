using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float iFrameDuration;
    [SerializeField] private UIManager uiManager;
    private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        if((currentHealth - damage) <= 0)
            PlayerDeath();
        else
            currentHealth -= damage;
            StartCoroutine(Invunerability());
    }

    public void GetHeal(float heal){
        if((currentHealth + heal) > maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += heal;
    }

    public void PlayerDeath(){
        currentHealth = 0;
        Time.timeScale = 0f;
        uiManager.GameOver();
    }

    public float GetHealthPercentage(){
        return currentHealth/maxHealth;
    }

    private IEnumerator Invunerability(){
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(iFrameDuration);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
