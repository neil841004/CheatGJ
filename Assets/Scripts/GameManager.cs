using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int time = 0;

    Classmate[] classmate;
    public bool stopTime = false;
    int t;
    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Timer", 0f, 0.5f);
        classmate = FindObjectsOfType<Classmate>();
    }

    // Update is called once per frame
    void Update()
    {
        t = timer.GetComponent<Timer>().timeCount;
    }
    void Timer()
    {
        int noGrayNumber = 0;
        foreach (var item in classmate)
        {
            if (item.mateState != Classmate.MateStatus.Gray)
            {
                noGrayNumber++;
            }
            if (noGrayNumber >= 3)
            {
                stopTime = true;
            }
            if ( noGrayNumber <= 1 ){
                stopTime = false;
            }
        }
        if (!stopTime && t != 0)
        {
            time++;
            if (time > 150)
            {
                time = 0;
            }
        }
    }
}
