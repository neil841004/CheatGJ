using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBar : MonoBehaviour
{
    public bool stopRay = false;
    public GameObject timer, amiRay;
    public Transform posPlayer, posTA;
    public float taDistance, mDistance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        taDistance = Vector2.Distance( posTA.position, posPlayer.position );
        if(timer.GetComponent<Timer>().timeCount == 0){
            stopRay = true;
        }
    }
    /// <summary>
    /// Sent each frame where a collider on another object is touching
    /// this object's collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    public void OnTriggerStay2D(Collider2D other)
    {
        // if(!other.CompareTag("TA")){
            stopRay = true;
        // }
            if(other.CompareTag("TA")){
                amiRay.GetComponent<_aimRayManager>().i = taDistance*.2f;
            }
            // if(other.CompareTag("ClassMates")){
            //     mDistance = Vector2.Distance( other.transform.position,posPlayer.position);
            //     amiRay.GetComponent<_aimRayManager>().i = taDistance*.2f;
            // }
    }
    public void OnTriggerExit2D(Collider2D other) {
        stopRay = false;
        if(other.CompareTag("ClassMates")){
        other.GetComponent<Classmate>().effect.SetActive(false);
        other.GetComponent<Classmate>().effectB.SetActive(false);
        }
    }
}
