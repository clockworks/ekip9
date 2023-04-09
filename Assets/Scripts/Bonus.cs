using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.TurnBasedGame;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    private MeshRenderer renderer;
    private Knight knight;
    void OnTriggerEnter(Collider other) 
    {
        //if (other.gameObject.CompareTag("Head")) // See if the GameObject that we collided with has the tag "Player"
        //{
        
        GameManager.Instance.BonusHealth++;
        renderer.enabled = false;
        Destroy(this.gameObject);

        
        //knight = other.gameObject.GetComponent<Knight>();
        //knight.HP++;
        //renderer.enabled = false; // Enable the renderer, making the GameObject invisible
            
        //}
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        renderer = GetComponent<MeshRenderer>(); // Get the Mesh Renderer that is attached to this GameObject
        renderer.enabled = true; // Disable the renderer so that it is invisisble
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Update");
    }
}