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
        }
        

        if (lockCursor) {
            Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
         } else {
             Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
         }
    }


    void GameOver(){
        Debug.Log("Game Over!");
    }

    void ChangeLevels(){
    
    }
}
