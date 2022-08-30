using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class treeger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {   
        Global.add = true;
        Debug.Log("Throw 1 trash.");
    }
}
