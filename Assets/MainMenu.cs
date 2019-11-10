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
    public GameObject now_Select;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        MainMenu_index = 0;
        now_Select = MainMenu_Button[MainMenu_index];
    }
    void FixedUpdate()
    {
        limit_time +=Time.deltaTime; 
        float SelectY = player.GetAxis("SelectVertical");
        Debug.Log(SelectY);
        if (SelectY > 0 && limit_time > 0.5)
        {
            MainMenu_index--;
            if(MainMenu_index < 0)MainMenu_index = 2;
            now_Select = MainMenu_Button[MainMenu_index];
            limit_time = 0;
        }
        else if(SelectY < 0 && limit_time > 0.5){
            MainMenu_index++;
            if(MainMenu_index > 2)MainMenu_index = 0;
            now_Select = MainMenu_Button[MainMenu_index];
            limit_time = 0;
        }
        if(MainMenu_index == 0 && player.GetButtonDown("Select")){
            PlayGame();
        }
        else if(MainMenu_index == 1 && player.GetButtonDown("Select")){
            
        }
        else if(MainMenu_index == 2 && player.GetButtonDown("Select")){
            Debug.Log("QUIT");
            Application.Quit();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
