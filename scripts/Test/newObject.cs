using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newObject : MonoBehaviour
{
    public GameObject[] Objects;
    public float Ins_Time = 1;
    void Start()
    {
            InvokeRepeating("Ins_Objs", Ins_Time, Ins_Time);
    }

    void Ins_Objs() //�ͦ�����禡�C
    {
        
        int Random_Objects = Random.Range(0, Objects.Length);

        // �ͦ�����(����A�ͦ��a�I(Position)�A������ਤ��(Rotation)
        Instantiate(Objects[Random_Objects], 
                        new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(100.0f, 200.0f), Random.Range(-5.0f, 5.0f)), 
                        new Quaternion(5, 
                            Random.Range(-15.0f, 15.0f),
                            Random.Range(-15.0f, 15.0f),
                            Random.Range(-15.0f, 15.0f)));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
