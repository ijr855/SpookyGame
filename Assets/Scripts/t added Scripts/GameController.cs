using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public int health = 100;
    public bool lockCursor = true;

    public int timer = 10;

    void Start()
    {
        Cursor.visible = false; //make mouse invis
        Cursor.lockState = CursorLockMode.Locked;//lock mouse

        health = PlayerPrefs.GetInt("PlayerHealth", 100); //get current health if no health default is fifty

    }

    // Update is called once per frame
    void Update()
    {

        if(health <= 0){
            GameOver();
        }
    }


    void GameOver(){
        Debug.Log("Game Over!");
    }

    void ChangeLevels(){
        //change levels
    }
}
