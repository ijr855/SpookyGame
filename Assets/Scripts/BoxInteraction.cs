using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEPressed = false;
    [SerializeField] private Text pieceText;
    public string pickedUp;
    private bool canInteract = false;
    [SerializeField] private GameObject interactPanel;
    void Start()
    {
        
    }
    private void Awake()
    {
        pieceText.text = "Press E to Interact";
        interactPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true && canInteract == true)
        {
            
            isEPressed = true;
            updateUI();
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        pieceText.text = "Press E to Interact";
        interactPanel.SetActive(true);
        canInteract = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (isEPressed == true)
        {
            other.isTrigger = false;
        }
        canInteract = false;
        interactPanel.SetActive(false);
        
    }
    private void updateUI()
    {
        pieceText.text = "You found " + pickedUp;
        
    }
    public bool wasEPressed()
    {
        return isEPressed;
    }

}
