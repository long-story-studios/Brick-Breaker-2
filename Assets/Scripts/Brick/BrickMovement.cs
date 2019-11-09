using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the movement of the brick mainly through the rotations of it
public class BrickMovement : MonoBehaviour
{   

    Vector2 startingTapPos = new Vector2();
    Vector2 currentTapPos = new Vector2();
    Vector2 differenceInPos = new Vector2();

    Vector3 axisTowards = new Vector3();
    Vector3 axisUpwards = new Vector3();

    [SerializeField] float speed = 5.0f;

    GameObject cam;

    bool mouseHeld = false;
    // Start is called before the first frame update
    void Awake()
    {
        cam = FindObjectOfType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseHeld)
        {
            
        }

    }

    //When the mouse is pressed, save the starting position of the mouse
    private void OnMouseDown()
    {
        mouseHeld = true;
        startingTapPos = Input.mousePosition;
        
    }
    
    private void OnMouseUp()
    {
        mouseHeld = false;
    }
    //When the mouse is being dragged
    private void OnMouseDrag()
    {
        currentTapPos = Input.mousePosition;
        differenceInPos = startingTapPos - currentTapPos;
        axisTowards = cam.transform.position - transform.position;
        axisUpwards = new Vector3(axisTowards.x + 90.0f, axisTowards.y, axisTowards.z);

        transform.Rotate(Vector3.up, differenceInPos.x * speed);
        startingTapPos = currentTapPos;
    }
}
