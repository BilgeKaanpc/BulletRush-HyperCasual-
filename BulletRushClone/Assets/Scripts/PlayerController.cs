using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ScreenTouchController input;
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float moveSpeed;

    public void Move(Vector3 direction)
    {
        myRigidbody.velocity = direction * moveSpeed * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        var direction = new Vector3(input.Direction.x, 0, input.Direction.y);
        Move(direction);
    }
}
