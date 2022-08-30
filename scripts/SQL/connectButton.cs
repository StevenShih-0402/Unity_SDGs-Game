using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class connectButton : MonoBehaviour
{
    public GameObject story;
    public GameObject choose;
    public GameObject startButton;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoClick()
    {
        if (SQLTest.isOver == false)
        {
            story.SetActive(true);
            startButtonText.startText.text = "Next";
            SQLTest.Open();
            SQLTest.getData();
            databaseData.timu.text = SQLTest.question;
            Debug.Log("¦¬¨ì¤å¦r£{");
            SQLTest.Close();
        }

        else if (SQLTest.isOver)
        {
            startButton.SetActive(false);
            story.SetActive(false);
            choose.SetActive(true);
        }
    }
}
