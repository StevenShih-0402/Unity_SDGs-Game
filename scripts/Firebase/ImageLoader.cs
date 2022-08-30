using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Firebase;
using Firebase.Extensions;
using Firebase.Storage;

public class ImageLoader : MonoBehaviour
{
    // Start is called before the first frame update
    RawImage rawImage;

    FirebaseStorage storage;
    StorageReference storageReference;
    IEnumerator loadImage(string mediaURL)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaURL);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rawImage = gameObject.GetComponent<RawImage>();
        // StartCoroutine(loadImage("https://firebasestorage.googleapis.com/v0/b/sdgs-cd14a.appspot.com/o/picture%2F10.png?alt=media&token=2ac9b541-6deb-4250-9037-7bf222f0fb00"));
        // 簡短但速度慢

        //initialize storage reference
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://unitydb-c65df.appspot.com/");  
        // Storage的連結

        //get reference of image
        StorageReference image = storageReference.Child("=3=.png");

        //Get the download link of file
        image.GetDownloadUrlAsync().ContinueWithOnMainThread(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                StartCoroutine(loadImage(Convert.ToString(task.Result))); //Fetch file from the link
            }
            else
            {
                Debug.Log(task.Exception);
            }
        });
    }
}
