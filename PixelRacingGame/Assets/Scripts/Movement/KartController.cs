using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class KartController : MonoBehaviour
{
    [SerializeField] private Rigidbody _sphereRB; //*interpolation needs to be selected*

    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private bool _isGrounded;

    [SerializeField] private float _rayToGroundLength = 2f;

    [SerializeField] private float _groundDrag = 4f;
    [SerializeField] private float _airDrag = .7f;
    
    [SerializeField] private float _kartSpeed = 100f;
    [SerializeField] private float _reverseSpeed = 50f;
    [SerializeField] private float _turnSpeed = 1f;
    
    [SerializeField] private float _gravity = 9.81f;

    private float _moveInput;
    private float _turnInput;
    
    private void Start()
    {
        _sphereRB = gameObject.GetComponentInChildren<Rigidbody>();
        _groundLayer = LayerMask.GetMask("Circuit");
        _sphereRB.transform.parent = null;
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Vertical");
        _turnInput = Input.GetAxisRaw("Horizontal");
        
        _moveInput *= _moveInput > 0 ? _kartSpeed : _reverseSpeed;
        
        transform.position = _sphereRB.transform.position;

        float newRotation = _turnInput * _turnSpeed * Time.deltaTime * _moveInput;
        transform.Rotate(0, newRotation, 0, Space.World);

        GroundChecker();
        DragCheck();
    }

    private void FixedUpdate()
    {
        if (_isGrounded)
        {
            _sphereRB.AddForce(transform.forward * _moveInput, ForceMode.Acceleration);
        }
        else
        {
            _sphereRB.AddForce(-transform.up * _gravity);
        }
    }

    private void DragCheck()
    {
        if (_isGrounded)
        {
            _sphereRB.drag = _groundDrag;
        }
        else
        {
            _sphereRB.drag = _airDrag;
        }
    }
    
    private void GroundChecker()
    {
        RaycastHit hit;
        _isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, _rayToGroundLength , _groundLayer );
        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal)* transform.rotation;
    }
}
