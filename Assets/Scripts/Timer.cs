using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public  int timeCount = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TimeCount", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TimeCount()
    {
        if (timeCount >= 1)
        {
            timeCount--;
            this.GetComponent<Text>().text = timeCount + "";
            
        }
        if (timeCount == 0){
            this.GetComponent<Text>().text = "OVER";
        }
    }
}
