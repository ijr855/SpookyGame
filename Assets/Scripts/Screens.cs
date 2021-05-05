using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Screens : MonoBehaviour
{
    [SerializeField] public GameController controller;
    [SerializeField] private Text gameOverText;
    [SerializeField] public GameObject pauseScreen;
    [SerializeField] public GameObject endScreen;


    void Start()
    {
        pauseScreen.SetActive(false);
        endScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isDead || controller.victory){
            ShowEndScreen();
        }

        if(controller.isPaused){
            ShowPausedScreen();
        }
        
    }
    public void ShowPausedScreen(){
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPauseGame(){
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        controller.isPaused = false;
        controller.lockCursor = true;
    }

    public void ShowEndScreen(){
        Time.timeScale = 0f;
        endScreen.SetActive(true);
        if(!controller.isDead){
            gameOverText.text = "VICTORY";
        }
        controller.lockCursor = false;

    }

    public void ReturnMainMenu(){
        PlayerPrefs.DeleteAll();
        controller.lockCursor = false;
        SceneManager.LoadScene(1); //load the next scene Level 0 
        

    }

     public void QuitGame(){ //quit game 
        PlayerPrefs.DeleteAll();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif 
    }   
}
