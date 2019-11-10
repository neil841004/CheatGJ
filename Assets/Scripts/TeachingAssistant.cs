using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachingAssistant : MonoBehaviour
{
    float taY;
    int t;
    public GameObject timer;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t = timer.GetComponent<Timer>().timeCount;
        position = this.transform.position;
        taY = position.y;
        if(taY>1.48f){
            this.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if(taY<1.48f && taY>-0.19){
            this.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }if(taY<-0.19f && taY>-2.03){
            this.GetComponent<SpriteRenderer>().sortingOrder = 6;
        }if(taY<-2.03f && taY>-3.76){
            this.GetComponent<SpriteRenderer>().sortingOrder = 9;
        }if(taY<-3.76f){
            this.GetComponent<SpriteRenderer>().sortingOrder = 12;
        }
        if(t == 0){
            this.GetComponent<Animator>().enabled = false;
        }
    }
}
