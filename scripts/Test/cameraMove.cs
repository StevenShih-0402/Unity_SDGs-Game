using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{

    // Update is called once per frame
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
