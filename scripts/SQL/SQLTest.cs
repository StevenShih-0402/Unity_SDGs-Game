using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class SQLTest
{
    // 資料庫基本資訊
    public static MySqlConnection mySqlConnection;
    static string host = "127.0.0.1";
    static string user = "root";
    static string pwd = "";
    static string db = "SDGs_Question";
    static string port = "3306";

    // 要顯示的資料庫內容
    public static string question = "";

    // 資料庫欄位
    public static string[] state = { "N1", "P1", "N2", "P2", "N3", "P3" };

    // 要擷取的資料庫欄位順序
    public static int stateNum = 0;

    // 確認欄位是否讀取完畢
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