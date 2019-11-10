using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _aimRayManager : MonoBehaviour
{
    public GameObject raybar;
    public float i; 
    bool stop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       stop = raybar.GetComponent<RayBar>().stopRay;
        if(i == 0){
            stop = false;
        }
        
    }
    public float aimRayManager(float angle){
        if(!stop){
        i += 0.04f;
        this.transform.rotation = Quaternion.Euler(0.0f , 0.0f , angle);
        raybar.transform.rotation = Quaternion.Euler(0.0f , 0.0f , angle);
        
        }
        
        raybar.transform.localScale = new Vector2(i , 0.05f);
        return i;
    }
    public float reduceScale(float i_x){
        i = i + i_x;
        if(i < 0) i = 0;
        raybar.transform.localScale = new Vector2(i , 0.05f);
        return i;
    }
}
