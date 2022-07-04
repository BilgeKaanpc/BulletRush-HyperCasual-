using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MyCharacterController
{
    [SerializeField] ScreenTouchController input;

   
    private void FixedUpdate()
    {
        var direction = new Vector3(input.Direction.x, 0, input.Direction.y);
        Move(direction);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy")){
            Dead();
        }
    }
    private void Dead()
    {
        Time.timeScale = 0;
    }
}
