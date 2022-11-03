using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    private const float Speed = 30f;

    //private EnemyMain enemyMain;
    private List<Vector3> pathVectorList;
    private int currentPathIndex;
    private float PathfindingTimer;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    private void Awake()
    {
        //enemyMain = GetComponent<EnemyMain>();

    }

    private void update()
    {
        PathfindingTimer -= Time.deltaTime;

        HandleMovement();
    }

private void FixedUpdate() {
    //enemyMain.EnemyRigidbody2D.velocity = moveDir * Speed;
}

private void HandleMovement(){
    //PrintPathfindingPath();
    if (pathVectorList != null) {
        Vector3 targetPosition = pathVectorList[currentPathIndex];
    }
}






}
