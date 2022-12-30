﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMover : MonoBehaviour
{
    public GameObject Target;
    public GameObject TargetSetter;

    public bool hasToMove;
    public bool moving;
    private Vector3 LastPosition;
    private Vector3 MoveStartLocation;
    private Vector3 GoalTargetPlacement;

    private float moveTime = 0.03f;
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        hasToMove = false;
        moving = false;
        LastPosition = TargetSetter.transform.position;
        counter = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(TargetSetter.transform.position, -TargetSetter.transform.up, out hit);
        Debug.DrawLine(TargetSetter.transform.position, hit.point, Color.cyan);
        counter += Time.deltaTime;


        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground") && (Target.transform.position - hit.point).magnitude > 0.15 && counter > moveTime)
        {
            hasToMove = true;
            GoalTargetPlacement = hit.point;
            MoveStartLocation = Target.transform.position;
            counter = 0;
        }


        else if (counter <= moveTime && moving)
        {

            Target.transform.position = Target.transform.position + ((GoalTargetPlacement - MoveStartLocation) * (Time.deltaTime / moveTime));

        }
        else
        {
            hasToMove = false;
            moving = false;
            GoalTargetPlacement += GoalTargetPlacement + (LastPosition - TargetSetter.transform.position);
            Target.transform.position = Target.transform.position + (LastPosition - TargetSetter.transform.position);
        }


        LastPosition = TargetSetter.transform.position;

    }
    public void SetMoving()
    {
        moving = true;
    }
    public float GetMoveDistance()
    {
        return (GoalTargetPlacement - MoveStartLocation).magnitude;
    }
}
