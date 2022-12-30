using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    public List<GameObject> Legs;
    public GameObject BodyPivot;
    public float rotationSpeed = 5;
    private NavMeshAgent agent;
    private Quaternion goalRotation;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float mostMoveDistance = 0;
        int movingLegs = 0;
        GameObject theMoveNeedingLeg = null;

        foreach (GameObject leg in Legs)
        {
            if (leg.GetComponent<LegMover>().moving == true)
                movingLegs++;
        }
        if (movingLegs < 4)
        {
            foreach (GameObject leg in Legs)
            {
                if (leg.GetComponent<LegMover>().hasToMove == true && leg.GetComponent<LegMover>().moving == false)
                {
                    if (leg.GetComponent<LegMover>().GetMoveDistance() > mostMoveDistance)
                    {
                        theMoveNeedingLeg = leg;
                    }

                }
            }
            if (theMoveNeedingLeg)
                theMoveNeedingLeg.GetComponent<LegMover>().SetMoving();
        }
        
        if (agent.velocity.magnitude > 0.1f)
        {
            goalRotation = Quaternion.LookRotation(agent.velocity.normalized, Vector3.up);
        }
        
        BodyPivot.transform.rotation = Quaternion.Lerp(BodyPivot.transform.rotation, goalRotation, Time.deltaTime * rotationSpeed);


    }
}
