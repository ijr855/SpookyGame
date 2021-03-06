using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] GameObject gameController;
    //the platform that will move
    public GameObject movingPlatform;
    private bool goUp = false;

    public GameObject level1;
    public GameObject level2;

    int count = 1;

    private void Start()
    {

    }

    private void Update()
    {
        
    }



    //while the player is touching the platform, this platform will go up
    private void OnTriggerStay(Collider other)
    {

        Debug.Log("goUp is " + goUp);
        Debug.Log("other.tag is " + other.tag);

        Debug.Log("level1 one position is " + level1.transform.position);
        Debug.Log("level2 one position is " + level2.transform.position);
        //move up
        if (other.tag == "Player" && goUp == true && (level2.transform.position.y >  movingPlatform.transform.position.y))
        {
            movingPlatform.transform.position += Vector3.up * 3 * Time.deltaTime;
            Debug.Log("movingPlatform position y is  " + movingPlatform.transform.position.y);
            Debug.Log("level2.transform.localScale.y is  " + level2.transform.localScale.y);
        }

        //move down
        if (other.tag == "Player" && goUp == false && ( level1.transform.position.y -1 < movingPlatform.transform.position.y))
        {
            movingPlatform.transform.position += Vector3.down * 3 * Time.deltaTime;
            Debug.Log("movingPlatform position y is  " + movingPlatform.transform.position.y);
            Debug.Log("level1.transform.localScale.y is  " + level1.transform.position.y);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger changes from " + goUp);
        Debug.Log("Trigger changes");
        

        //Remove the count %2 == 1 if we aren't on Level_One, for some reason
        //on that scene the player triggers the OnTriggerEnter twice
        if (goUp == true && other.tag == "Player" && count % 2 == 1)
        {
            Debug.Log("first if");
            goUp = false;

            gameController.GetComponent<GameController>().takeElevator();
        }
        
        else if (goUp == false && other.tag == "Player" && count % 2 == 1)
        {
            Debug.Log("second if");

            goUp = true;

            gameController.GetComponent<GameController>().takeElevator();
        }

        count++;

        Debug.Log("Trigger changes go up to " + goUp);
    }


}
