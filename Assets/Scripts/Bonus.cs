using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("OnTriggerEnter");
        
        if (other.gameObject.tag=="Player")
        {
            //If gameobject has tag "BuyPottery", than destory it.
            Destroy(other.gameObject);
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }
}
