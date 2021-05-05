using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{

    [SerializeField] Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat("speed", Input.GetAxis("Vertical"));
        anim.SetFloat("speed", Input.GetAxis("Vertical") * (Input.GetKey(KeyCode.LeftShift) ? 0.5f : 1f));
        anim.SetFloat("strafeSpeed", Input.GetAxis("Horizontal"));

        if(Input.GetButtonDown("Jump")){
            anim.SetTrigger("isJumping");
        }

        if(Input.GetButtonDown("Fire1")){
            anim.SetTrigger("fire");
        }
      
    }

}
