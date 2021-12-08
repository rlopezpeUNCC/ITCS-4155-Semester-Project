using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void MainScene(){
        FindObjectOfType<AudioManager>().Play("MainMenuChoice");
        SceneManager.LoadScene("Main Scene");
        
    }

     public void Tutorial(){
        FindObjectOfType<AudioManager>().Play("MainMenuChoice");
        SceneManager.LoadScene("Tutorial");
        
    }

     public void MiniGame(){
        FindObjectOfType<AudioManager>().Play("MainMenuChoice");
        SceneManager.LoadScene("Mini Game");
        
    }

    public void Credits(){
        FindObjectOfType<AudioManager>().Play("MainMenuChoice");
        SceneManager.LoadScene("Credits");
        
    }
    
    public void TeamInfo(){
        FindObjectOfType<AudioManager>().Play("MainMenuChoice");
        SceneManager.LoadScene("Team Info");
        
    }


    public void QuitGame (){
        FindObjectOfType<AudioManager>().Play("MainMenuChoice");
        Debug.Log("QUIT");
        Application.Quit();
    } 

}
