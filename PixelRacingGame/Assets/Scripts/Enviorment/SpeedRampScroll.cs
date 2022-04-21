using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRampScroll : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = -0.7f;
    [SerializeField] private float _speedBoost = 15f;
    
    void Update()
    {
        float offSetY = Time.time * _scrollSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offSetY);
    }

    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(Vector3.forward * _speedBoost);
        print("Triggered!!");
        Debug.Log(other);
    }
}
