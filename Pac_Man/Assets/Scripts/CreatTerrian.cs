using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatTerrian : MonoBehaviour
{
    //public int[,] _terrianData = new int[,]
    //{                             {1,1,1,1,0,0,0,1},
    //                              {1,1,1,0,0,1,0,0},
    //                              {1,1,0,0,1,0,0,1},
    //                              {1,1,1,0,0,0,1,1},
    //                              {0,0,0,0,1,1,1,1},
    //};
    public string[,] _terrianData;
    public Transform centerPos;
    public GameObject Cube;
    // Start is called before the first frame update
    void Start()
    {
        InitData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InitData()
    {
        _terrianData = FindObjectOfType<ReadTXT>().Read();
        for (int i = 0; i < _terrianData.GetLength(0); i++)
        {
            for (int j = 0; j < _terrianData.GetLength(1); j++)
            {
                if (_terrianData[i,j]=="1")
                {
                    Vector3 pos = centerPos.position + new Vector3(1f * i ,0, 1f * j);
                  var _data=  GameObject.Instantiate(Cube, pos, Quaternion.identity);
                    _data.transform.parent = centerPos;
                       
                }
                if (_terrianData[i,j]=="0")
                {
                    Debug.Log("000");
                }
            }
        }
    }
}
