using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorRemoval : MonoBehaviour
{
    private PieceTracker ptrack;
    // Start is called before the first frame update
    private void Awake()
    {
        ptrack = GameObject.FindObjectOfType<PieceTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ptrack.pieceOne);
    }

}
