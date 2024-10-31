using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyDropControl : MonoBehaviour
{
    private GameObject ExpDrop;
    private GameObject HealthDrop;
    public float HealthDropChance;
    public float dropForce;

    public void setExpDrop(GameObject expDrop){
        ExpDrop = expDrop;
    }

    public void setHealthDrop(GameObject healthDrop){
        HealthDrop = healthDrop;
    }

    // Update is called once per frame
    void OnDestroy(){
        DropItem();
    }

    void DropItem(){
        int randomIndex = UnityEngine.Random.Range(0, 1);
        Vector2 randomForce = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-0.5f, 0.5f))*dropForce;
        if(randomIndex < HealthDropChance){
            GameObject health = Instantiate(HealthDrop, transform.position, Quaternion.identity);
            Rigidbody2D hrb = health.GetComponent<Rigidbody2D>();
            hrb.AddForce(randomForce, ForceMode2D.Impulse);
        }
        GameObject exp = Instantiate(ExpDrop, transform.position, Quaternion.identity);
        Rigidbody2D erb = exp.GetComponent<Rigidbody2D>();
        randomForce = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-0.5f, 0.5f))*dropForce;
        erb.AddForce(randomForce, ForceMode2D.Impulse);
    }
}
