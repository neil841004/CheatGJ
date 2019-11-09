using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classmate : MonoBehaviour
{
    public enum MateStatus
    {
        Gray, //一般狀態
        Yellow, //發光狀態
        Black, //扣分狀態
    }
    public Color[] colors;
    public MateStatus mateState;
    float seconds;
    int timeRamdon;
    public GameObject score;

    void Start()
    {
        this.GetComponent<SpriteRenderer>().color = colors[0];
        timeRamdon = Random.Range(0,150);
        
    }

    void Update()
    {
        if (GameManager.time == timeRamdon)
        {
            if (mateState == MateStatus.Gray)
            {
                ChangeState();
                GameManager.time++;
            }
        }
    }
    void ChangeState()
    {
        int state = Random.Range(0, 4);
        switch (state)
        {
            case 0:
            case 1:
            case 2:
                StartCoroutine(YellowState());
                break;

            case 3:
                StartCoroutine(BlackState());
                break;
        }
        timeRamdon = Random.Range(0,150);
    }
  
    //加分狀態
    IEnumerator YellowState()
    {
        seconds = Random.Range(7f, 12f);
        mateState = MateStatus.Yellow;
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().color = colors[1];
        yield return new WaitForSeconds(seconds);
        mateState = MateStatus.Gray;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().color = colors[0];
    }

    //扣分狀態
    IEnumerator BlackState()
    {
        seconds = Random.Range(6f, 10f);
        mateState = MateStatus.Black;
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().color = colors[2];
        yield return new WaitForSeconds(seconds);
        mateState = MateStatus.Gray;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().color = colors[0];
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("P1Ray")){
            if (mateState == MateStatus.Yellow)
            {
                score.GetComponent<ScoreBar>().scoreA +=.6f;
            }if (mateState == MateStatus.Black)
            {
                score.GetComponent<ScoreBar>().scoreA -=1.5f;
            }
        }
        if(other.CompareTag("P2Ray")){
            if (mateState == MateStatus.Yellow)
            {
                score.GetComponent<ScoreBar>().scoreA +=.6f;
            }if (mateState == MateStatus.Black)
            {
                score.GetComponent<ScoreBar>().scoreA -=1.5f;
            }
            
        }
    }
    
    
}
