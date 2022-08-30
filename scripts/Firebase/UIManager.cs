using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Threading;

public class UIManager : MonoBehaviour
{
    public GameObject player1;                          // �H��1
    public TMP_Text player1Talking;                    // �H��1����r
    public GameObject player2;                          // �H��2
    public TMP_Text player2Talking;                    // �H��2����r
    public GameObject QuestionBox;                   // �D�ح��O
    public GameObject ChooseBox;                     // ��ܿﶵ���O
    public TMP_Text Choose1;                            // ��ܲĤ@�ӿﶵ
    public TMP_Text Choose2;                            // ��ܲĤG�ӿﶵ
    public GameObject StoryButton;                    // ����G�ƶi�檺���s

    public int nowStory;                                    // �ثe�O�ĴX�����
    static int nowWord = 0;                                // �ثe����ĴX�y��
    List<string> words = new List<string>();         // �@����ܪ��Ҧ��x�����e
    List<string> wordsType = new List<string>();   // �T�{��r�O���`��ܡA�٬O�n�����a����ܪ����
    List<string> wordQueue = new List<string>();  // ����e�������P��ܪ�����
    string response,response2;                          // �Y�ǹ�ܤ��֦��G�ئ^��
    bool haveAnotherWord;                               // �O�_�֦��ĤG�ئ^��
    int maybeSecond;                                       // ����ئ^����������

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

    // �Ĥ@��(���`)�^��
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

    // �ĤG�ئ^��
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
