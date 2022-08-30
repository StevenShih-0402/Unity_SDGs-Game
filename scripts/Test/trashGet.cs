using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashGet : MonoBehaviour
{
    /*
    public Vector2 Last;
    public Vector2 New;
    public Vector2 Direction;
    */
    public Vector3 trash;
    public Transform MouseObject;   
    public float MouseSensitivity;      
    public bool moveControl = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveControl)
        {
            Move();
        }
        
    }
    private void OnMouseDown()
    {
        Debug.Log("Get Trash.");
        Debug.Log("Mouse Position: " + Input.mousePosition.x + ", " + Input.mousePosition.y + ", " + Input.mousePosition.z);
        moveControl = (moveControl == false) ? moveControl = true : moveControl = false;
    }
    private void Move()
    {
        /*
        Last = New;
        New = Input.mousePosition;
        Direction = New - Last; 
        
        trash = new Vector3(Direction.x, 0, -Direction.y) * MouseSensitivity;
        */
        trash = new Vector3(Input.GetAxis("Mouse Y"), 0, Input.GetAxis("Mouse X")) * MouseSensitivity;
        MouseObject.Translate(trash);
    }

    public void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
