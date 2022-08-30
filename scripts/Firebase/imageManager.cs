using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Firebase;
using Firebase.Extensions;
using Firebase.Storage;
using System.Threading.Tasks;

public class imageManager : MonoBehaviour
{
    int player = 1;
    string email = "test05@gmail.com";
    public void Doclick()
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference storageRef =
            storage.GetReferenceFromUrl("gs://user-e7316.appspot.com");

        for(int i = 1; i <= 6; i++)
        {
            // 本地端檔案
            string localFile = "D:/Data/unity/screenshot" + i + ".png";

            // Create a reference to the file you want to upload
            // Storage裡面的檔案路徑
            StorageReference riversRef = storageRef.Child("images/" + email + "/awake01/" + i + ".png");

            // Upload the file to the path "images/rivers.jpg"
            // Player setting的API Level改成.NET4.x
            riversRef.PutFileAsync(localFile)
                .ContinueWith((Task<StorageMetadata> task) => {
                    if (task.IsFaulted || task.IsCanceled)
                    {
                        Debug.Log(task.Exception.ToString());
                    // Uh-oh, an error occurred!
                }
                    else
                    {
                    // Metadata contains file metadata such as size, content-type, and download URL.
                    StorageMetadata metadata = task.Result;
                        string md5Hash = metadata.Md5Hash;
                        Debug.Log("Finished uploading...");
                        Debug.Log("md5 hash = " + md5Hash);
                    }
                });
        }
    }
}