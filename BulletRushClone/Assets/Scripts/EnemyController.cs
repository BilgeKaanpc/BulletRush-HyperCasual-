using UnityEngine;

public class EnemyController : MyCharacterController
{
    [SerializeField] private PlayerController player;
    private void FixedUpdate()
    {
        var delta = -transform.position + player.transform.position;
        delta.y = 0;
        var direction = delta.normalized;
        Move(direction);
    }
}
