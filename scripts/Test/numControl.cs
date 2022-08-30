using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class numControl : MonoBehaviour
{
    public int num;
    public TextMeshProUGUI show;
    // Start is called before the first frame update
    void Start()
    {
        num = Global.num;
        show = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.add)
        {
            num = num + 1;
            Debug.Log("num + 1");
            show.text = "" + num + " / 10";
            Global.num = num;

            Global.add = false;
            Debug.Log("Back to Global");
        }
        
    }
}
