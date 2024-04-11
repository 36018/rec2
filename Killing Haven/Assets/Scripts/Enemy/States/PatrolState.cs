using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    //track which waypoint we are currently targeting.
    public int waypointIndex;
    public float waitTimer;
    public override void Enter()
    {
       
    }

    public override void Perform()
    {
        PatrolCycle();
        if (enemy.canSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }

    public override void Exit()
    {

    }

    public void PatrolCycle()
    {
        //implement our patrol logic.
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            //waitTimer += Time.deltaTime;
            //if(waitTimer > 3)
           // Debug.Log("sdfghj"+ Path.availableWPS[0].transform);
         
            if (waypointIndex < Path.availableWPS.Count - 1)
                waypointIndex++;
            else
                waypointIndex = 0;
            enemy.Agent.SetDestination(Path.availableWPS[waypointIndex].position);
            waitTimer = 0;
            
        }
    }
}
