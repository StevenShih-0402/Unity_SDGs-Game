using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMove : MonoBehaviour
{
    public static float speed = 0.05f;
    public static int health = 1;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        // ²¾°Ê
        transform.Translate(0, 0, speed);
        // ¼Y¸¨
        if (transform.position.y < -15 || transform.position.y > 30)
        {
            reborn();
        }

        // ¶É±×
        transform.rotation = new Quaternion(0, 0, 0, 0); 

        // ¥Í©R­ÈÂk¹s
        if(health == 0)
        {
            reborn();
            health += 1;
        }
    }

    public void reborn()
    {
        transform.position = new Vector3(0, 10, 0);
    }
}
