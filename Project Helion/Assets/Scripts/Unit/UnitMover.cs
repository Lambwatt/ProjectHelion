using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour
{
    public float Speed;

    public int Direction { get; private set; } = 4;
    public bool IsMoving { get; private set; } = false;
    Vector3 Step;

    // Start is called before the first frame update
    void Start()
    {
        Step = new Vector3(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        int x=0, y = 0;

        x += Input.GetKey(KeyCode.A) ? -1 : 0;
        x += Input.GetKey(KeyCode.D) ? 1 : 0;
        y += Input.GetKey(KeyCode.W) ? 1 : 0;
        y += Input.GetKey(KeyCode.S) ? -1 : 0;

        IsMoving = x != 0 || y != 0;
        if (IsMoving)
        {
            Direction = getDirectionCode(x, y);
        }

        Step = new Vector3(x, y);
        Step.Normalize();

        transform.position += Step * Speed * Time.deltaTime;
    }

    int getDirectionCode(int x, int y)
    {
        if (x == 0) return 2 + (y * -2);
        else if (x == 1) return 2 - y;
        else return 6 + y;       
    }
}
