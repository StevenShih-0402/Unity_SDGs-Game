using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTest : MonoBehaviour
{
    public bool moveControl = true;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveControl)
        {
            transform.Translate(Vector3.forward * speed);
        }
        else
        {
            transform.Translate(Vector3.forward * -speed);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (moveControl)
        {
            moveControl = false;
        }
        else
        {
            moveControl = true;
        }
    }
}
