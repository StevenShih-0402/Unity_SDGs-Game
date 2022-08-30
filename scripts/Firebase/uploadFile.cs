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

public class uploadFile : MonoBehaviour
{
    public static string ReceiveFile(string localPath, string userName)
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference storageRef =
            storage.GetReferenceFromUrl("gs://fdata-55026.appspot.com");

        // ���a���ɮ�
        string localFile = localPath;
        string firebaseFilePath = userName + "/GameVideo_Q1.mp4";
        // Create a reference to the file you want to upload
        // Storage�̭����ɮ׸��|
        StorageReference riversRef = storageRef.Child(firebaseFilePath);

        // Upload the file to the path "images/rivers.jpg"
        // Player setting��API Level�令.NET4.x
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
        return firebaseFilePath;
    }
}
