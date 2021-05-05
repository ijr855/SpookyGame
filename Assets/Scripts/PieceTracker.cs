using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceTracker : MonoBehaviour
{
    public bool pieceOne = false;
    public bool pieceTwo = false;
    public bool pieceThree = false;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    [SerializeField] private Text box1Text;
    [SerializeField] private Text box2Text;
    [SerializeField] private Text box3Text;

    // Start is called before the first frame update
    private void Awake()
    {
        box1 = GameObject.FindGameObjectWithTag("Box1");
        box2 = GameObject.FindGameObjectWithTag("Box2");
        box3 = GameObject.FindGameObjectWithTag("Box3");
    }
    // Update is called once per frame

    void Update()
    {
        if (box1.GetComponent<BoxInteraction>().wasEPressed() == true)
        {
            box1Text.text = "Piece1: Found";
            box1Text.color = Color.green;
            pieceOne = true;

        }
        if (box2.GetComponent<BoxInteraction>().wasEPressed() == true)
        {
            box2Text.text = "Piece2: Found";
            box2Text.color = Color.green;
            pieceTwo = true;

        }
        if (box3.GetComponent<BoxInteraction>().wasEPressed() == true)
        {
            box3Text.text = "Piece3: Found";
            box3Text.color = Color.green;
            pieceThree = true;

        }
        if (pieceOne && pieceTwo && pieceThree)
        {
            GameObject.FindGameObjectWithTag("DoorBlocker").SetActive(false);
        }
    }

}
