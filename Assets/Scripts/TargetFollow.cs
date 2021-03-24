using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothing = 0.5f;
    private Vector3 vel; // velocity

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //main camera will be at target position
        //transform.position = target.position + offset;


        //instead of position of the target, we use transform class
        //transofmr local space then to world space with TransformPoint
        //(world spacce is target.position + offset)
        Vector3 targetPos = target.TransformPoint(offset); //part 1, position

        //interpolate, slowly and smoothly get to target position
        //go from start to target position at the speed of velociting in the the time of smoothing
        //transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, smoothing);

        // another way of doing smoothing, but with LERP, different way of doing camera moving
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing); 


        //transform.position = targetPos;

        //part 2 is the angle, where we want to look at based on the player
        //transform will look at the target
        transform.LookAt(target);


        //smoothdamp allow 1 position to move to another target position(ie camera movement)
        //Vector3.SmoothDamp()
    }
}
