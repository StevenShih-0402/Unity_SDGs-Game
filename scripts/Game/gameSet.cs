using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Finish!");
        playerMove.speed = 0;
    }
}
