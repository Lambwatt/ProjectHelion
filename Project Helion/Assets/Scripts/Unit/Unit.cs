using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitMover))]
[RequireComponent(typeof(UnitRenderer))]
public class Unit : MonoBehaviour
{
    UnitMover uMover;
    UnitRenderer uRenderer;

    public UnitState State { get; private set; } = UnitState.IDLE;

    public int Direction
    {
        get { return uMover.Direction; }
    }

    public bool IsMoving
    {
        get { return uMover.IsMoving; }
    }

    // Start is called before the first frame update
    void Start()
    {
        uMover = GetComponent<UnitMover>();
        uRenderer = GetComponent<UnitRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            State = UnitState.WALK;
        }
        else
        {
            State = UnitState.IDLE;
        }
    }

}
