using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Collider))]
public class CameraZone : MonoBehaviour {
    public Vector3 CameraPosition = new Vector3();
    public Quaternion CameraRotation = Quaternion.identity;
    public float CameraFov;

    public Camera PreviewCamera;
    Collider _c;

    private void Awake()
    {
        if (!Application.isPlaying)
        {
            SetupPreviewCamera();
        }
        else
        {
            SavePreviewCameraProperties();
            Destroy(PreviewCamera);
        }
        _c = GetComponent<Collider>();
        _c.isTrigger = true;
        gameObject.layer = 2;
    }
    public void SavePreviewCameraProperties()
    {
        CameraPosition = PreviewCamera.transform.position;
        CameraRotation = PreviewCamera.transform.rotation;
        CameraFov = PreviewCamera.fieldOfView;
    }
    public void SetupPreviewCamera()
    {
        if(PreviewCamera == null)
        {
            PreviewCamera = new GameObject("Preview Camera").AddComponent<Camera>();
        PreviewCamera.transform.parent = transform;
        PreviewCamera.transform.position = transform.position + Random.onUnitSphere + Vector3.up;
        PreviewCamera.transform.LookAt(transform);
        }
        PreviewCamera.targetTexture = Resources.Load<RenderTexture>("Textures/CameraPreview");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        Camera.main.transform.position = CameraPosition;
        Camera.main.transform.rotation = CameraRotation;
        Camera.main.fieldOfView = CameraFov;
    }

    private void OnDrawGizmos()
    {
        if (_c == null) _c = GetComponent<Collider>();
        Gizmos.DrawWireCube(_c.bounds.center, _c.bounds.size);
    }
}
