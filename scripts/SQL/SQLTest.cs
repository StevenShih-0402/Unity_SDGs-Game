using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class SQLTest
{
    // ��Ʈw�򥻸�T
    public static MySqlConnection mySqlConnection;
    static string host = "127.0.0.1";
    static string user = "root";
    static string pwd = "";
    static string db = "SDGs_Question";
    static string port = "3306";

    // �n��ܪ���Ʈw���e
    public static string question = "";

    // ��Ʈw���
    public static string[] state = { "N1", "P1", "N2", "P2", "N3", "P3" };

    // �n�^������Ʈw��춶��
    public static int stateNum = 0;

    // �T�{���O�_Ū������
    public static bool isOver = false;

    public static void Open()
    {
        try
        {
            string connectionString = string.Format("Server={0};Port={4};Database={1};User={2};Password={3};", host, db, user, pwd, port);
            mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();
            Debug.Log("Success");
        }
        catch (System.Exception e)
        {
            throw new System.Exception("" + e.Message.ToString());
        }
    }

    public static void Close()
    {
        if (mySqlConnection != null)
        {
            mySqlConnection.Close();
            mySqlConnection.Dispose();
            mySqlConnection = null;
            Debug.Log("Close database.");
        }
    }
    
    public static void getData()
    {
        string cmdstr = "SELECT * FROM `question` WHERE ID = 5;";
        MySqlCommand sqlcmd = new MySqlCommand(cmdstr, mySqlConnection);
        var dr = sqlcmd.ExecuteReader();
        while (dr.Read())
        {
            string s = state[stateNum];
            if(dr[s] != null)
            {
                isOver = false;
                question = (string)dr[s];
            }
            else
            {
                isOver = true;
            }
            stateNum++;
        }
    }
}