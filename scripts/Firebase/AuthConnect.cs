using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Firebase;
using Firebase.Auth;
using Firebase.Extensions;

public class AuthConnect : MonoBehaviour
{
    [Header("Login and Register")]
    public TMP_InputField email;
    public TMP_InputField password;
    public GameObject warningText1;
    public GameObject successText;

    FirebaseAuth auth;
    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        warningText1.SetActive(false);
        successText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoginClick()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            bool isSuccess = true;
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                isSuccess = false;
                test.IsSuccess = isSuccess;
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                isSuccess = false;
                test.IsSuccess = isSuccess;
                Debug.Log(test.IsSuccess);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            isSuccess = true;
            test.IsSuccess = isSuccess;
            Debug.Log("Success:" + test.IsSuccess);
        });

        if (test.IsSuccess)
        {
            warningText1.SetActive(false);
            successText.SetActive(true);
        }
        else if (!(test.IsSuccess))
        {
            warningText1.SetActive(true);
            successText.SetActive(false);
        }
    }
}
