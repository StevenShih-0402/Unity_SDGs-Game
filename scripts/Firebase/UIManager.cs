using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Threading;

public class UIManager : MonoBehaviour
{
    public GameObject player1;                          // 人物1
    public TMP_Text player1Talking;                    // 人物1的文字
    public GameObject player2;                          // 人物2
    public TMP_Text player2Talking;                    // 人物2的文字
    public GameObject QuestionBox;                   // 題目面板
    public GameObject ChooseBox;                     // 對話選項面板
    public TMP_Text Choose1;                            // 對話第一個選項
    public TMP_Text Choose2;                            // 對話第二個選項
    public GameObject StoryButton;                    // 控制故事進行的按鈕

    public int nowStory;                                    // 目前是第幾場對話
    static int nowWord = 0;                                // 目前講到第幾句話
    List<string> words = new List<string>();         // 一場對話的所有台詞內容
    List<string> wordsType = new List<string>();   // 確認文字是正常對話，還是要讓玩家做選擇的對話
    List<string> wordQueue = new List<string>();  // 控制畫面切換與顯示的索引
    string response,response2;                          // 某些對話中擁有二種回應
    bool haveAnotherWord;                               // 是否擁有第二種回應
    int maybeSecond;                                       // 有兩種回應的欄位索引

    // Start is called before the first frame update
    void Start()
    {
        player1.SetActive(false);
        player2.SetActive(false);
        QuestionBox.SetActive(false);
        ChooseBox.SetActive(false);
        StreamReader sr = new StreamReader("Assets/script/scripts.csv");
        string line;
        while((line = sr.ReadLine()) != null)
        {
            string[] splitLine = line.Split(',');
            if(splitLine[0].Equals(""+nowStory+"A") || splitLine[0].Equals("" + nowStory + "B"))
            {
                wordQueue.Add(splitLine[0]);
                wordsType.Add(splitLine[1]);
                words.Add(splitLine[2].Replace("\"", ""));
                if (splitLine[1].Equals("Q"))
                {     
                    Choose1.text = splitLine[3].Replace("\"", "");
                    Choose2.text = splitLine[4].Replace("\"", "");
                }
                if (splitLine[1].Equals("R"))
                {
                    haveAnotherWord = true;
                    string[] twice = splitLine[2].Split('/');
                    response = twice[0];
                    response2 = twice[1];
                    maybeSecond = words.Count - 1;
                }
            }
        }
        sr.Dispose();
        sr.Close();
        Debug.Log("" + nowStory + ", "+words.Count);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void DoClick()
    {
        Debug.Log("now Word = " + nowWord);
        if(nowWord <= words.Count)
        {
            if (nowWord < words.Count)
            {
                if (wordQueue[nowWord].Equals(nowStory + "A"))
                {
                    player1.SetActive(true);
                    player2.SetActive(false);

                    player1Talking.text = words[nowWord];
                    Debug.Log("Show Player 1");
                }
                if (wordQueue[nowWord].Equals(nowStory + "B"))
                {
                    player1.SetActive(false);
                    player2.SetActive(true);

                    player2Talking.text = words[nowWord];
                    Debug.Log("Show Player 2");
                }
                if (wordsType[nowWord].Equals("Q"))
                {
                    ChooseBox.SetActive(true);
                    StoryButton.SetActive(false);
                }
            }
            if (nowWord == words.Count)
            {
                player1.SetActive(false);
                player2.SetActive(false);
                StoryButton.SetActive(false);
                QuestionBox.SetActive(true);
            }
            nowWord++;
        }
    }

    // 第一種(正常)回應
    public void firstChooseClick()
    {
        ChooseBox.SetActive(false);
        StoryButton.SetActive(true);
        if (haveAnotherWord)
        {
            words[maybeSecond] = response;
        }
        DoClick();
    }

    // 第二種回應
    public void secondChooseClick()
    {
        ChooseBox.SetActive(false);
        StoryButton.SetActive(true);
        if (haveAnotherWord)
        {
            words[maybeSecond] = response2;
        }
        DoClick();
    }
}
