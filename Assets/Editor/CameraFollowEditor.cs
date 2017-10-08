using System.Collections;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof (CameraFollow))]

public class CameraFollowEditor : Editor {


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraFollow cF = (CameraFollow)target;

        if(GUILayout.Button("Set Min Cam Pos"))
        {
            cF.SetMinCamPosition();
        }

        if (GUILayout.Button("Set Max Cam Pos"))
        {
            cF.SetMaxCamPosition();

        }

    }
}
