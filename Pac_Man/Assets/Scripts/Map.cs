﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TerrianType
{
Block,
Player,
Box,
Gem,
Enemy,
Sword
}
public enum GameState
{
    Start,
    Running,
    Finish,
    NextStep,
    Over
}
public class Map : MonoBehaviour
{
    public string[,] _terrianData;
    public Transform centerPos;
    public GameObject Cube;
    public TerrianType _mapType;
    public Transform _player;
    private float offset_X = 1.0f;
    private float offset_Z = 1.0f;
    public GameState _gameState;
    public GameObject[] enemys;

  public  void InitData()
    {

        _terrianData = FindObjectOfType<ReadTXT>().Read();
        for (int i = 0; i < _terrianData.GetLength(0); i++)
        {
            string debugstr = "";

            for (int j = 0; j < _terrianData.GetLength(1); j++)
            {
               Vector3 pos = centerPos.position + new Vector3(offset_X * i ,0, offset_Z * j);
                switch (_terrianData[i,j])
                {
                    case "*":
                        _mapType = TerrianType.Block;
                        var _data = GameObject.Instantiate(Cube, pos, Quaternion.identity);
                        _data.transform.parent = centerPos;
                        break;
                    case "c":
                        _mapType = TerrianType.Gem;
                        break;
                    case "p":
                        _mapType = TerrianType.Player;
                        GameObject.Instantiate(_player, pos, Quaternion.identity);
                        break;
                    case "s":
                        _mapType = TerrianType.Sword;
                        break;
                    case "t":
                        _mapType = TerrianType.Box;
                        break;
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        _mapType = TerrianType.Enemy;
                        int EnemyType = int.Parse(_terrianData[i, j]);
                        GameObject.Instantiate(enemys[EnemyType], pos, Quaternion.identity);
                        break;
                    
                }
                debugstr += _terrianData[i, j];
            }
          Debug.Log(debugstr);
        }
    }
}
