using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Map))]
public class MapModelCreator : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawDefaultInspector();
        if (GUILayout.Button("CreateMap"))
        {
            Map map = target as Map;
            map.InitData();
        }
    }
   
}
