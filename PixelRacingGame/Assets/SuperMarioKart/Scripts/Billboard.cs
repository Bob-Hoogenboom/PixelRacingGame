using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private bool _staticBillboard = true;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (!_staticBillboard)
        {
            transform.LookAt(_mainCam.transform);
        }
        else
        {
            transform.rotation = _mainCam.transform.rotation;
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
