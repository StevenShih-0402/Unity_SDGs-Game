using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;
using System;

public class addNewPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    FirebaseFirestore db;
    int playerNum = 1;
    string email = "test06@gmail.com";
    string username = "Jack";
    string gamename = "awake01";
    bool isCorrect = true;

    int time = 20;
    int environment = 15;
    int economic = 10;
    int social = 25;
    static int id = 1;

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
        // 欄位資料
        Dictionary<string, object> name = new Dictionary<string, object>
        {
                { "name",username }
        };

        Dictionary<string, object> awakeData = new Dictionary<string, object>
        {
                { "Date", DateTime.Now.ToString("yyyy-MM-dd") },
                { "finish", isCorrect },
                { "name", gamename},
                { "time", time },
                { "environment", environment },
                { "economic", economic },
                { "social", social }
        };

        Dictionary<string, object> nums = new Dictionary<string, object>
        {
                { "id", id },
                { "environment", environment },
                { "economic", economic },
                { "social", social }
        };
        // 集合名稱.文件名稱.欄位資料
        /*db.Collection("Players").Document("Player"+playerNum).SetAsync(playerData);
        Debug.Log("Upload a new Data!");*/

        db.Collection("user").Document(email).SetAsync(name);
        db.Collection("user").Document(email).Collection("games").Document(gamename).SetAsync(awakeData);
        db.Collection("user").Document(email).Collection("games").Document(gamename).Collection("score").Document("q1").SetAsync(nums);
        Debug.Log("Upload a new Data!");
    }
}
