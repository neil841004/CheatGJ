using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public  int timeCount = 60;
    public GameObject winR, winL, score;
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
            Invoke("GameOver",2f);
        }
    }
    void GameOver(){
        if(score.GetComponent<ScoreBar>().scoreA >= score.GetComponent<ScoreBar>().scoreB){
            winL.SetActive(true);
        }
        if(score.GetComponent<ScoreBar>().scoreB > score.GetComponent<ScoreBar>().scoreA){
            winR.SetActive(true);
        }
        GameObject.FindWithTag("BGM").SendMessage("CM");
        Invoke("BackToMenu",5f);
    }
    void BackToMenu(){
        SceneManager.LoadScene(0);
        
    }
}
