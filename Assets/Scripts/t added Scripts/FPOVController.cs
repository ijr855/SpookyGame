using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPOVController : MonoBehaviour
{
   public float movementSpeed = 7.0f;
    public float jumpH = 4.0f;
    private float verticalVel = 0;
    CharacterController player;

    // Start is called before the first frame update
    
        void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GetComponent<CharacterController>(); //get player object

    }

    // Update is called once per frame
    void Update()
    {

        //movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed; //set forward speed 
        float sideToSideSpeed = Input.GetAxis("Horizontal") * movementSpeed; //set right left speed
        

        verticalVel += Physics.gravity.y * Time.deltaTime*2; //accelerate in relaiton to time 


        if(Input.GetKeyDown(KeyCode.Space) && player.isGrounded){
            verticalVel = jumpH;

        }


        Vector3 speed = new Vector3(sideToSideSpeed ,verticalVel, forwardSpeed); // be able to move


        speed = transform.rotation * speed; //rotate speed to match characters rotation
        

        player.Move( speed * Time.deltaTime ); //amount of time that has passed * speed to move our character
    }
}
