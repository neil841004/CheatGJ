using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _aimRayManager : MonoBehaviour
{
    public GameObject Raybar;
    float i; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    void aimRayManager(float angle){
        i += 0.1f;
        this.transform.rotation = Quaternion.Euler(0.0f , 0.0f , angle);
        Raybar.transform.rotation = Quaternion.Euler(0.0f , 0.0f , angle);
        Raybar.transform.localScale = new Vector2(i , 0.05f);
    }
    void reduceScale(float i_x){
        i = i + i_x;
        if(i < 0) i = 0;
        Raybar.transform.localScale = new Vector2(i , 0.05f);
    }
}
