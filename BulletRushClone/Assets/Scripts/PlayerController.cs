using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MyCharacterController
{
    [SerializeField] ScreenTouchController input;
    [SerializeField] private ShootController shootController;

    private List<Transform> enemies = new List<Transform>();

    private int enemyAmount;
    private void Start()
    {
        enemyAmount = FindObjectsOfType<EnemyController>().Length;
    }
    private void FixedUpdate()
    {
        var direction = new Vector3(input.Direction.x, 0, input.Direction.y);
        Move(direction);
    }

    private void Update()
    {
        if (enemies.Count > 0)
        {
            transform.LookAt(enemies[0]);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy")){
            Dead();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            if (!enemies.Contains(other.transform))
            {
                enemies.Add(other.transform);
            }

            AutoShoot();
      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            enemies.Remove(other.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Finish"))
        {
            Win();
        }
    }

    private bool isShooting;

    private void AutoShoot()
    {

        var hasEnemy = enemies.Count > 0;
        IEnumerator Do()
        {
            while (enemies.Count > 0)
            {
                var enemy = enemies[0];
                var direction = enemy.transform.position - transform.position;
                direction.y = 0;
                direction = direction.normalized;
                shootController.Shoot(direction, transform.position);
               // transform.LookAt(enemy.transform);
                enemies.RemoveAt(0);
                yield return new WaitForSeconds(shootController.Delay);
            }
            isShooting = false;
        }

        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(Do());
        }


        
    }

    private void Dead()
    {
        Time.timeScale = 0;
    }
    private void Win()
    {
        Time.timeScale = 0;
        var current = FindObjectsOfType<EnemyController>().Length;
        var result = current / (float)enemyAmount;
        var success = Mathf.Lerp(100, 0, result);
        Debug.Log(success);

    }
}
