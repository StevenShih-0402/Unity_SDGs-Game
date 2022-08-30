using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newRoad : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Objects;
    public float Ins_Time = 0.1f;
    public static int mapNum = 1;
    public int roadPosition = 30;
    public int mapLimit = 5;
    void Start()
    {
        if (mapNum <= mapLimit)
        {
            InvokeRepeating("Ins_Objs", Ins_Time, Ins_Time);
        }
    }

    void Ins_Objs() //生成物件函式。
    {
        if(mapNum == mapLimit)
        {
            Instantiate(Objects[Objects.Length-1],
                        new Vector3(0, 0, mapNum * roadPosition),
                        new Quaternion(0, 0, 0, 0));
            mapNum++;
        }
        else if(mapNum < mapLimit)
        {
            int Random_Objects = Random.Range(0, Objects.Length-1);
            Instantiate(Objects[Random_Objects],
                            new Vector3(0, 0, mapNum * roadPosition),
                            new Quaternion(0, 0, 0, 0));
            mapNum++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
