using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTXT : MonoBehaviour
{
    TextAsset _text;
    public string[,] data;



    public string[,] Read()
    {
        _text = Resources.Load("TerrianData") as TextAsset;
        string str = _text.text;
        string[] row = str.Split('\n');
        data = new string[row.Length, row[0].Length];
        for (int i = 0; i < row.Length; i++)
        {
            string debugstr = "";
            string[] tile = row[i].Split(',');
            for (int j = 0; j < tile.Length; j++)
            {
                data[i, j] = tile[j];
                debugstr += data[i, j];
            }
        }
        return data;
    }

}
