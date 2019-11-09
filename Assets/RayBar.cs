using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBar : MonoBehaviour
{
    public bool stopRay = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Sent each frame where a collider on another object is touching
    /// this object's collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("ClassMates")){
            stopRay = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other) {
        stopRay = false;
    }
}
