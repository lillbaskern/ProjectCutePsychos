using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement")]
    [SerializeField] private float enemySpeed;
    private Vector3 initScale;
    private bool moveingLeft;

    [Header("Idle")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    //[Header("Animator")]
    //[SerializeField] private Animator anim;


    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void Update()
    {
        if (moveingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

    private void OnDisable()
    {
        //anim.SetBool("Moving", false);
    }

    private void DirectionChange()
    {
        //anim.SetBool("Moving", false);

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)

        moveingLeft = !moveingLeft;
    }


    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        //anim.SetBool("Moving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, 
                        initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * enemySpeed,
                                        enemy.position.y, enemy.position.z);
    }
}
