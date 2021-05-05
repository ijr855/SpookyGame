using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject EnemySpawn;

    private bool elevatorTaken = false; // true = player on 2nd floor
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

        if (lockCursor) {
            Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
         } else {
             Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
         }
    }


    // use this function to swithc to game over screen
    public void GameOver(){
        Debug.Log("Game Over!");
    }

    void ChangeLevels(){
    
    }


    // Enemy cannot take elevator -> must implement way for enemy to traverse hotel floors
    // when player interacts with elevator -> their script must call this function
    public void takeElevator()
    {
        this.elevatorTaken = !this.elevatorTaken;
        StartCoroutine(this.RespawnEnemy());
    }


    IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(10);
        // if elevator taken = true, player on second floor. Need to spawn enemy on 2nd floor. 
        int NewEnemyYAxis = (this.elevatorTaken) ? 75 : 25;
        EnemySpawn.GetComponent<SpawnObjects>().center.y = NewEnemyYAxis; // 1st or 2nd floor
        EnemySpawn.GetComponent<SpawnObjects>().SpawnEnemies();

    }

}
