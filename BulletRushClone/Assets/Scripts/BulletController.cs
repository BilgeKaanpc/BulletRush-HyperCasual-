﻿using UnityEngine;

public class BulletController : MonoBehaviour
{
    //test
    [SerializeField] private float speed;
    private Vector3 _movement;
    public void Fire(Vector3 direction)
    {
        _movement = direction * speed  ;
    }
    private void FixedUpdate()
    {
        transform.position += _movement * Time.deltaTime;
    }
}
