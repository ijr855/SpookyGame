using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    //the platform that will move
    public GameObject movingPlatform;
    private bool goUp = false;

    public GameObject level1;
    public GameObject level2;

    private void Update()
    {
        
    }



    //while the player is touching the platform, this platform will go up
    private void OnTriggerStay(Collider other)
    {

        Debug.Log("goUp is " + goUp);
        Debug.Log("other.tag is " + other.tag);


        //move up
        if(other.tag == "Player" && goUp == true && (level2.transform.position.y + level2.transform.localScale.y/2 > movingPlatform.transform.position.y))
        {
            movingPlatform.transform.position += Vector3.up * Time.deltaTime;
        }

        //move down
        if (other.tag == "Player" && goUp == false && (level1.transform.position.y + level1.transform.localScale.y / 2 < movingPlatform.transform.position.y))
        {
            movingPlatform.transform.position += Vector3.down * Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger changes go up");

        if (goUp == true && other.tag == "Player")
        {
            goUp = false;
        }
        
        else if (goUp == false && other.tag == "Player" )
        {
            goUp = true;
        }

        //Debug.Log("Trigger changes go up to " + goUp);
    }


}
