using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributeManager : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField] private float value_exp;
    [SerializeField] private float value_health;
    [SerializeField] private float value_level;
    [SerializeField] private int maxLevel;
    [SerializeField] private TextMeshProUGUI levelText;
    private float currExp;
    private int currLevel;
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        currExp = 0;
        currLevel = 0;
        levelText.text = "Level: " + currLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if(currExp >= value_level){
            currExp -= value_level;
            if(currLevel >= maxLevel)
                print("Player leveled to max level");
            else{
                levelUp();
            }
                
        }
    }

    private void levelUp(){
        currLevel += 1;
        levelText.text = "Level: " + currLevel;
    }

    public float getEXPPercentage(){
        return currExp/value_level;
    }

    public void addExp(){
        currExp += value_exp;
    }

    public void addHealth(){
        playerHealth.GetHeal(value_health);
    }
}
