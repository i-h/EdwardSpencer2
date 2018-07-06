using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CameraZone : MonoBehaviour {
    public Transform CameraPosition;
    public Transform CameraFocusPoint;
    Collider _c;

    private void Awake()
    {
        _c = GetComponent<Collider>();
        _c.isTrigger = true;
    }
    private void Start()
    {
        if(CameraFocusPoint == null)
        {
            CameraFocusPoint = new GameObject("Camera Focus Point").transform;
            CameraFocusPoint.position = transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        Camera.main.transform.position = CameraPosition.position;
        Camera.main.transform.LookAt(CameraFocusPoint);
    }

    private void OnDrawGizmos()
    {
        if (_c == null) _c = GetComponent<Collider>();
        Gizmos.DrawWireCube(_c.bounds.center, _c.bounds.size);
    }
}
