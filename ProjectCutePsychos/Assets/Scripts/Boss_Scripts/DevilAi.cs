using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{

private enum State
{
ChaseTarget,
}

    private Pathfinding pathfinding;
    private Vector3 startingPosition;
    private State state;

    private void Awake()
    {
        pathfinding = GetComponent<Pathfinding>();
        state = State.ChaseTarget;
    }

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update() 
    {
        switch (state)
        {
            default:
            case State.ChaseTarget:
            //pathfinding.MoveToTimer(PlayerBasicAttack.Instance.GetPosition)();
            break;

        }
    }






}
