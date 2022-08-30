using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;

public class firestoreManager : MonoBehaviour
{
    [SerializeField] Button updateCountButton;
    [SerializeField] InputField countUI;
    FirebaseFirestore db;
    ListenerRegistration listenerRegistration;
    // Start is called before the first frame update
    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        updateCountButton.onClick.AddListener(OnHandleClick);
        
        // 集合與文件
        listenerRegistration = db.Collection("counters").Document("counter").Listen(snapshot =>
        {
            Counter counter = snapshot.ConvertTo<Counter>();
            countUI.text = counter.Count.ToString();
        });


        // GetData();
    }
    void OnDestroy()
    {
        listenerRegistration.Stop();
    }
    void OnHandleClick()
    {
        int oldCount = int.Parse(countUI.text);
        // Using Structs
        Counter counter = new Counter
        {
            Count = oldCount + 1,
            UpdatedBy = "Steven"
        };

        // Using Dictionary
        // Dictionary<string, object> counter = new Dictionary<string, object>
        // {
        //     {"Count",oldCount+1},
        //     {"UpdatedBy","Vikings(Dictionary)"}
        // };
        DocumentReference countRef = db.Collection("counters").Document("counter");
        
        // 更新資料
        countRef.SetAsync(counter).ContinueWithOnMainThread(task =>
        {
            Debug.Log("Updated Counter");
            // GetData();
        });

    }
    void GetData()
    {
        db.Collection("counters").Document("counter").GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            Counter counter = task.Result.ConvertTo<Counter>();
            countUI.text = counter.Count.ToString();
        });
    }
}
