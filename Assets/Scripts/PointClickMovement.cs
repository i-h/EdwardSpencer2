using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PointClickMovement : MonoBehaviour {
    public string WalkableTag = "Walkable";
    public float MoveSpeed = 0.5f;
    private float _moveThreshold = 0.1f;
    private Vector3 _moveTarget = new Vector3();
    private Rigidbody _rb;
    private Vector3 _moveDir = new Vector3();
    private bool _atTarget = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckInput();
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        Vector3 distance = _moveTarget - transform.position;
        _moveDir = distance;
        _moveDir.y = 0;
        _moveDir = _moveDir.normalized;
        if(_atTarget = distance.magnitude > _moveThreshold)
        {
            //_rb.AddForce(_moveDir * MoveSpeed);
            //_rb.velocity = _moveDir*MoveSpeed;
            _moveTarget.y = transform.position.y;
            _rb.MovePosition(Vector3.MoveTowards(transform.position, _moveTarget, MoveSpeed/10.0f));
        }
    }

    private void CheckInput()
    {
        if (Input.GetMouseButton(0))
        {
            Ray mouseWorld = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseHit;
            if (Physics.Raycast(mouseWorld, out mouseHit) && mouseHit.collider.tag == WalkableTag)
            {
                _moveTarget = mouseHit.point;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _atTarget ? Color.yellow : Color.green;
        Gizmos.DrawSphere(_moveTarget, 1.0f);
        Gizmos.DrawRay(transform.position, _moveDir * 2);
    }
}
