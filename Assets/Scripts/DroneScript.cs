using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DroneScript : MonoBehaviour {
    public float TargetHeight = 5.0f;
    [SerializeField]
    float _ascendSpeed = 0.1f;
    [SerializeField]
    float _ascendForce = 0;
    float _maxAscendForce = 20.0f;
    float _maxAscendSpeed = 2.0f;
    
    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < TargetHeight && _rb.velocity.y < _maxAscendSpeed)
        {
            _ascendForce += _ascendSpeed * (TargetHeight - transform.position.y);
            _ascendForce = _ascendForce > _maxAscendForce ? _maxAscendForce : _ascendForce;
        } else if (_rb.velocity.y < -0.1f)
        {
            _ascendForce += _ascendSpeed;
        }else
        {
            _ascendForce = 0;
        }
        _rb.AddForce(Vector3.up * _ascendForce);
    }
}
