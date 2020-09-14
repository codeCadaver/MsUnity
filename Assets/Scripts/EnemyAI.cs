using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState
    {
        Patrolling,
        Attacking,
        Chasing,
        Death
    }

    public EnemyState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.Patrolling;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrolling:
                Debug.Log("Looking for target");
                break;
            case EnemyState.Chasing:
                Debug.Log("Target Spotted");
                break;
            case EnemyState.Attacking:
                Debug.Log("In Combat");
                break;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            int enumLength = Enum.GetNames(typeof(EnemyState)).Length;
            //currentState = EnemyState.Attacking;
            if((int)currentState == enumLength-1)
            {
                currentState = 0;
            } else
            {
                currentState ++;
            }
        }
    }
}
