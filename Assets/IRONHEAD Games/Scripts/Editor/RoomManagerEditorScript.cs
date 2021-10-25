using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for creating and joining room", MessageType.Info);
        base.OnInspectorGUI();

        RoomManager roomManager = (RoomManager)target;
        if(GUILayout.Button("Join Random Room"))
        {
            roomManager.JoinRandomRoom();
        }
    }
}
