using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void MainScene(){
        SceneManager.LoadScene("Main Scene");
        
    }

     public void Tutorial(){
        SceneManager.LoadScene("Tutorial");
        
    }

     public void MiniGame(){
        SceneManager.LoadScene("MiniGame");
        
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
