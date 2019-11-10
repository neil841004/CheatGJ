using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
public class MainMenu : MonoBehaviour
{
    public List<GameObject> MainMenu_Button;
    float limit_time;
    int MainMenu_index;
    int playerID = 0;
    public GameObject now_Select, black,btn_1,btn_2,btn_3;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        MainMenu_index = 0;
        now_Select = MainMenu_Button[MainMenu_index];
        btn_1.GetComponent<Animator>().Play("MenuBtn");
    }
    void FixedUpdate()
    {
        limit_time += Time.deltaTime;
        float SelectY = player.GetAxis("SelectVertical");
        Debug.Log(SelectY);
        if (SelectY > 0 && limit_time > 0.5)
        {
            MainMenu_index--;
            if (MainMenu_index < 0) MainMenu_index = 2;
            if(MainMenu_index == 0){
                btn_1.GetComponent<Animator>().Play("MenuBtn");
                GameObject.FindWithTag("SE").SendMessage("PlaySE",1);
            }
            if(MainMenu_index == 1){
                btn_2.GetComponent<Animator>().Play("MenuBtn");
                GameObject.FindWithTag("SE").SendMessage("PlaySE",1);
            }
            if(MainMenu_index == 2){
                btn_3.GetComponent<Animator>().Play("MenuBtn");
                GameObject.FindWithTag("SE").SendMessage("PlaySE",1);
            }
            now_Select = MainMenu_Button[MainMenu_index];
            limit_time = 0;
        }
        else if (SelectY < 0 && limit_time > 0.5)
        {
            MainMenu_index++;
            if (MainMenu_index > 2) MainMenu_index = 0;
            if(MainMenu_index == 0){
                btn_1.GetComponent<Animator>().Play("MenuBtn");
                GameObject.FindWithTag("SE").SendMessage("PlaySE",1);
            }
            if(MainMenu_index == 1){
                btn_2.GetComponent<Animator>().Play("MenuBtn");
                GameObject.FindWithTag("SE").SendMessage("PlaySE",1);
            }
            if(MainMenu_index == 2){
                btn_3.GetComponent<Animator>().Play("MenuBtn");
                GameObject.FindWithTag("SE").SendMessage("PlaySE",1);
            }
            now_Select = MainMenu_Button[MainMenu_index];
            limit_time = 0;
        }
        if (MainMenu_index == 0 && player.GetButtonDown("Select"))
        {
            btn_1.GetComponent<Animator>().Play("MenuBtnPress");
            GameObject.FindWithTag("SE").SendMessage("PlaySE",2);
            PlayGame();

        }
        else if (MainMenu_index == 1 && player.GetButtonDown("Select"))
        {
            btn_2.GetComponent<Animator>().Play("MenuBtnPress");
            GameObject.FindWithTag("SE").SendMessage("PlaySE",2);
        }
        else if (MainMenu_index == 2 && player.GetButtonDown("Select"))
        {
            btn_3.GetComponent<Animator>().Play("MenuBtnPress");
            GameObject.FindWithTag("SE").SendMessage("PlaySE",2);
            Debug.Log("QUIT");
            Invoke("Exit",1.5f);
            
        }
    }

    public void PlayGame()
    {
        black.SetActive(true);
        Invoke("NextLevel",1.5f);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit(){
        Application.Quit();
    }

}
