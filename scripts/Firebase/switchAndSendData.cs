using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;
using System;
using UnityEngine.SceneManagement;

public class switchAndSendData : MonoBehaviour
{
    public int environment = 0;
    public int social = 0;
    public int economic = 0;
    public string playerName;
    public string path;
    FirebaseFirestore db;
    // Start is called before the first frame update
    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoClick()
    {
        Debug.Log("Correct!!");
        SceneManager.LoadScene(1);
        Debug.Log("Game Start!");

        uploadUserData();
    }

    public void uploadUserData()
    {
        string firebaseFilePath = uploadFile.ReceiveFile(path, playerName);
        Dictionary<string, object> playerData = new Dictionary<string, object>
        {
                { "Date", DateTime.Now.ToString("yyyy-MM-dd") },
                { "GameName", "關懷獨居老人" },
                { "Environment", environment },
                { "Social", social },
                { "Economic", economic },
                { "video", firebaseFilePath },
                { "videoTime", "02:25" },
                { "Q1Ans", "B" },
        };
        // 集合名稱.文件名稱.欄位資料
        db.Collection("Players").Document(playerName).SetAsync(playerData);
        Debug.Log("Upload a new Data!");
    }
}
