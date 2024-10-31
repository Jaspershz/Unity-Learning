using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectibleManager : MonoBehaviour
{
    [SerializeField] private CircleCollider2D detectRange;
    [SerializeField] private float iniRange;
    private float currRange;
    private PlayerAttributeManager attributeManager;

    void Start(){
        attributeManager = GetComponent<PlayerAttributeManager>();
        currRange = iniRange;
        detectRange.radius = iniRange;
    }
    // Update is called once per frame
    
    public void addRange(float range){
        currRange += range;
        detectRange.radius = currRange;
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("ExpDrop")){
            attributeManager.addExp();
            Destroy(collider.gameObject);
        }
        else if(collider.gameObject.CompareTag("HealthDrop")){
            attributeManager.addHealth();
            Destroy(collider.gameObject);
        }
    }
}
