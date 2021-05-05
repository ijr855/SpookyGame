using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorDoorRemoval : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEPressed = false;
    [SerializeField] private Text doorText;
    private bool canInteract = false;
    [SerializeField] private GameObject DoorPanel;
    private PieceTracker ptrack;
    // Start is called before the first frame update
    private void Awake()
    {
        ptrack = GameObject.FindObjectOfType<PieceTracker>();
        doorText.text = "Press O to Interact";
        DoorPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) == true && ptrack.pieceOne && ptrack.pieceTwo
            &&ptrack.pieceThree && canInteract)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        doorText.text = "Press O to Interact";
        DoorPanel.SetActive(true);
        canInteract = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (isEPressed == true)
        {
            doorText.text = "";
            //peiceOne = true;
            other.isTrigger = false;
        }
        canInteract = false;
        DoorPanel.SetActive(false);

    }
}
