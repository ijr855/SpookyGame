using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string newGameScene;

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayRules(){
            //display text later 
    }

    public void DisplaySettings(){
            //display  later 
    }

    public void StartGame(){
        Debug.Log("Starting game");

        SceneManager.LoadScene(1); //load the next scene Level 0 

    }

    public void QuitGame(){ //quit game 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif 
    }
}
