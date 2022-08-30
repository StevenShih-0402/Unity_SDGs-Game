using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterGame : MonoBehaviour
{
    public int sceneNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Doclick()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
