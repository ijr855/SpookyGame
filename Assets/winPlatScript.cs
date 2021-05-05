using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winPlatScript : MonoBehaviour
{
    [SerializeField] GameController gme;
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "winPlat") //if player collides with obstacle
        {
            gme.victory = true;
        }
    }
}
