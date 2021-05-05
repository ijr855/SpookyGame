using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public int health = 100;
    public int level;
 
    public bool lockCursor = true;

    public bool victory = false;
    public bool isDead = false;
    public bool isPaused = false;

    
    void Start()
    {
        Cursor.visible = false; //make mouse invis
        Cursor.lockState = CursorLockMode.Locked;//lock mouse

        health = PlayerPrefs.GetInt("PlayerHealth", 100); //get current health if no health default is fifty
        level = PlayerPrefs.GetInt("PlayerLevel", 1); //get current level if no level default is one

    }

 
    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            GameOver();
            lockCursor = false;

        }
        

        
        if(Input.GetKeyDown(KeyCode.Escape) && !isDead){
            isPaused = true;
            lockCursor = false;
           
        }

        

        if (lockCursor) { //lock mouse so you cannot see cursor
            Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
         } else {
             Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
         }



    }

    void Victory(){
        victory = true;
    }

    void GameOver(){
        Debug.Log("Game Over!");
        isDead = true;
    }

    void ChangeLevels(){
    
    }
}
