using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraZone))]
public class CameraZoneEditor : Editor {
    RenderTexture _rt;
    Rect _previewRect = new Rect(0, 0, 250, 250);
    public override void OnInspectorGUI()
    {
        CameraZone tgt = target as CameraZone;
        base.OnInspectorGUI();

        if (tgt.PreviewCamera != null)
        {
            tgt.PreviewCamera.targetTexture = Resources.Load<RenderTexture>("Textures/CameraPreview");
            tgt.PreviewCamera.Render();
        }

        GUILayout.Box(_rt);
    }
}
