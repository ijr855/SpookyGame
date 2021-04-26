using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    float rotationOnX;
    public float mouseSensitivity = 7f;

    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

        //rotate camera up and down
        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -30f,60f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);

        //rotate left and right
        player.Rotate(Vector3.up * mouseX);
        
    }
}
