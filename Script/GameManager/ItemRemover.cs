using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemover : MonoBehaviour
{
    // Start is called before the first frame update
    void OnApplicationQuit(){
        Destroy(gameObject);
    }
}
